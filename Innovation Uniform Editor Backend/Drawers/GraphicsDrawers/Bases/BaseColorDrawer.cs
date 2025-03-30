using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.ComponentDrawers;
using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.ComponentDrawers.Bases;
using Innovation_Uniform_Editor_Backend.Helpers;
using Innovation_Uniform_Editor_Backend.ImageEditors;
using Innovation_Uniform_Editor_Backend.ImageEditors.Base;
using Innovation_Uniform_Editor_Backend.ImageEditors.Interface;
using Innovation_Uniform_Editor_Backend.Models;
using Innovation_Uniform_Editor_Backend.Models.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases
{
    public abstract class BaseColorDrawer : BaseGraphicsDrawer
    {
        private Point _location;
        private ShadingDrawer _shadingDrawer;

        private List<CustomColor> _colors;
        private List<MaskImage> _masks;
        private int currentDrawerIndex = 0;

        private Bitmap texturesMerged;
        private MaskImage textureMask;

        private float _transparency = 1f;

        private int repeat = 2;
        private int shadingRepeat = 1;

        private List<ComponentDrawerBase> colorDrawerItems;

        public BaseColorDrawer(List<CustomColor> colors, List<Bitmap> Selections, List<ComponentDrawerBase> Drawers, ShadingDrawer shading, List<Bitmap> texture)
        {
            Initialize(colors, Selections, Drawers, Point.Empty, shading, texture, 1f);
        }
        public BaseColorDrawer(List<CustomColor> colors, List<Bitmap> Selections, List<ComponentDrawerBase> Drawers, Point location, ShadingDrawer shading, List<Bitmap> texture)
        {
            Initialize(colors, Selections, Drawers, location, shading, texture, 1f);
        }
        public BaseColorDrawer(List<CustomColor> colors, List<Bitmap> Selections, List<ComponentDrawerBase> Drawers, Point location, ShadingDrawer shading, List<Bitmap> texture, float transparency)
        {
            Initialize(colors, Selections, Drawers, location, shading, texture, transparency);
        }
        private void Initialize(List<CustomColor> colors, List<Bitmap> Selections, List<ComponentDrawerBase> Drawers, Point location, ShadingDrawer shading, List<Bitmap> texture, float transparency)
        {
            _colors = colors;
            _masks = ImageHelper.BitmapToBoolean(Selections);
            _location = location;
            _shadingDrawer = shading;
            colorDrawerItems = Drawers;
            _transparency = transparency;
            if (texture != null && texture.Count > 0)
            {
                texturesMerged = ImageHelper.Merge(texture);
                textureMask = ImageHelper.BitmapToSingleBoolean(texture);
            }
        }
        public override bool HasAsset()
        {
            return _colors.Count > 0 && _masks.Count > 0;
        }
        private ComponentDrawerBase GetCurrentComponent(double Yprogress)
        {
            for (int i = currentDrawerIndex; i < colorDrawerItems.Count; i++)
            {
                // Does our Yprogress fall below our current find? If so, this might be the current component.
                if (colorDrawerItems[i].EndYPercentage >= Yprogress)
                {
                    /* Is there no component behind us? skip.
                       Otherwise check if it also falls above the previous component.
                       Eg:

                       Current: 0.6
                       (before us) EndYPercentage: 0.5,
                       (in front of us) EndYPercentage: 0.75
                        
                       Yes, that's between those two!
                    */
                    if (i <= 0 || colorDrawerItems[i - 1].EndYPercentage < Yprogress)
                    {
                        currentDrawerIndex = i;
                        return colorDrawerItems[i];
                    }
                }
            }

            //Seems like none matches, this means Yprogress got reset back to 0, start back from square 0!
            //TODO: Will this cause a recursion bug?
            currentDrawerIndex = 0;
            return GetCurrentComponent(Yprogress);
        }

        private double GetCurrentProgressForComponent(double yProgress)
        {
            double previousEndPercentage =
                currentDrawerIndex > 0 ?
                colorDrawerItems[currentDrawerIndex - 1].EndYPercentage
                : 0;
            double currentEndPercentage = colorDrawerItems[currentDrawerIndex].EndYPercentage;

            // 0 - 100% becomes a scale of X% - Y% (mainly used by fades)
            return (yProgress - previousEndPercentage) * (1 / (currentEndPercentage - previousEndPercentage));
        }

        public override void DrawToGraphics(Graphics graphics, Bitmap result)
        {
            //This thing requires a rework, cause it ain't pretty.

            ImageEditorBase<Bitmap> colorsResultLooper = new BitmapEditor(new Bitmap(result.Width, result.Height));

            BitmapEditor resultLooper = new BitmapEditor(result);

            BitmapEditor texture;

            if (texturesMerged != null)
                texture = new BitmapEditor(texturesMerged);
            else
                texture = new BitmapEditor(new Bitmap(resultLooper.GetWidth(), resultLooper.GetHeight()));

            ImageEditorBase<Bitmap> shading = null;

            if (_shadingDrawer != null)
                shading = new BitmapEditor(new Bitmap(ComponentDrawerBase.shading.GetWidth(), ComponentDrawerBase.shading.GetHeight()));

            int totalSize = colorsResultLooper.GetTotalSize();
            int width = colorsResultLooper.GetWidth();

            for (int maskIndex = 0; maskIndex < _masks.Count; maskIndex++)
            {
                MaskImage maskImage = _masks[maskIndex];

                for (int i = 0; i < maskImage.mask.Length; i++)
                {
                    bool canDraw = maskImage.mask[i];

                    if (canDraw)
                    {
                        //The total progress of the image, for every Y position increase.
                        double yProgress = (double)(i / width) / (totalSize / width);

                        //The amount of times it has to be repeated. Defaults to 2.
                        double progressRepeat = yProgress * repeat;
                        //double progressWithRepeat = progressRepeat - Math.Truncate(progressRepeat);
                        double progressWithRepeat = progressRepeat - Math.Truncate(progressRepeat);

                        //progressWithRepeat is corresponds to the current index of the current drawing component.
                        ComponentDrawerBase currentDrawItem = GetCurrentComponent(
                            progressWithRepeat
                        );

                        if (currentDrawItem != null)
                        {
                            /*
                              Original image has different size than the mask images have.
                              So, i, being the index of the current pixel will be different 
                              (since of width and height difference).

                              We just get the x and y position and just map them to the width of the image.
                            */

                            int y = i / maskImage.Width;
                            int x = i % maskImage.Width;

                            int drawIndex = x + _location.X + ((y + _location.Y) * width);

                            //TODO: Texture mask if texture is supplied.
                            if (shading != null && (textureMask == null || textureMask.mask[i]))
                            {
                                Color originalShadingColor = ComponentDrawerBase.shading.GetPixelColorAtIndex(drawIndex);
                                Color shadingColor = ComponentDrawerBase.shading.GetPixelColorAtIndex(drawIndex);

                                for (int rep = 0; rep < shadingRepeat - 1; rep++)
                                {
                                    shadingColor = Blend(shadingColor, shadingColor);
                                }

                                shading.ChangePixelColorAtIndex(drawIndex, shadingColor);
                            }

                            currentDrawItem.Draw(
                                _colors[maskIndex],
                                colorsResultLooper,
                                resultLooper,
                                texture,
                                drawIndex,
                                GetCurrentProgressForComponent(progressWithRepeat),
                                _transparency
                             );
                        }
                    }
                }
            }

            currentDrawerIndex = 0;

            if (shading != null)
                _shadingDrawer.ChangeAsset(shading.Result);

            texture.CloseImage();

            resultLooper.CloseImage();

            DrawImageToGraphics(graphics, colorsResultLooper.Result);
        }

        private Color Blend(Color ForeGround, Color BackGround)
        {
            if (ForeGround.A == 0)
                return BackGround;
            if (BackGround.A == 0)
                return ForeGround;
            if (ForeGround.A == 255)
                return ForeGround;

            int Alpha = ForeGround.A + 1;
            int A = ForeGround.A;

            int B = Alpha * ForeGround.B + (255 - Alpha) * BackGround.B >> 8;
            int G = Alpha * ForeGround.G + (255 - Alpha) * BackGround.G >> 8;
            int R = Alpha * ForeGround.R + (255 - Alpha) * BackGround.R >> 8;


            if (BackGround.A == 255)
                A = 255;
            if (R > 255)
                R = 255;
            if (G > 255)
                G = 255;
            if (B > 255)
                B = 255;

            return Color.FromArgb(Math.Abs(A), Math.Abs(R), Math.Abs(G), Math.Abs(B));
        }
    }
}
