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
        private List<MaskImage> _masks;
        private int currentDrawerIndex = 0;

        private Bitmap texturesMerged;
        private MaskImage textureMask;

        private int repeat = 2;

        private ColorDrawerOptions options;

        public BaseColorDrawer(ColorDrawerOptions options)
        {
            this.options = options;
            _masks = ImageHelper.BitmapToBoolean(options.Selections);
            if (options.Texture != null && options.Texture.Count > 0)
            {
                texturesMerged = ImageHelper.Merge(options.Texture);
                textureMask = ImageHelper.BitmapToSingleBoolean(options.Texture);
            }
        }
        public override bool HasAsset()
        {
            return options.Colors.Count > 0 && _masks.Count > 0;
        }
        private ComponentDrawerBase GetCurrentComponent(double Yprogress)
        {
            for (int i = currentDrawerIndex; i < options.ColorDrawerItems.Count; i++)
            {
                // Does our Yprogress fall below our current find? If so, this might be the current component.
                if (options.ColorDrawerItems[i].EndYPercentage >= Yprogress)
                {
                    /* Is there no component behind us? skip.
                       Otherwise check if it also falls above the previous component.
                       Eg:

                       Current: 0.6
                       (before us) EndYPercentage: 0.5,
                       (in front of us) EndYPercentage: 0.75
                        
                       Yes, that's between those two!
                    */
                    if (i <= 0 || options.ColorDrawerItems[i - 1].EndYPercentage < Yprogress)
                    {
                        currentDrawerIndex = i;
                        return options.ColorDrawerItems[i];
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
                options.ColorDrawerItems[currentDrawerIndex - 1].EndYPercentage
                : 0;
            double currentEndPercentage = options.ColorDrawerItems[currentDrawerIndex].EndYPercentage;

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

            if (options.ShadingDrawer != null)
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

                            int drawIndex = x + options.Location.X + ((y + options.Location.Y) * width);

                            //TODO: Texture mask if texture is supplied.
                            if (shading != null && (textureMask == null || textureMask.mask[i]))
                            {
                                Color shadingColor = ComponentDrawerBase.shading.GetPixelColorAtIndex(drawIndex);

                                for (int rep = 0; rep < options.ShadingAmount - 1; rep++)
                                {
                                    shadingColor = Blend(shadingColor, shadingColor);
                                }

                                shading.ChangePixelColorAtIndex(drawIndex, shadingColor);
                            }

                            currentDrawItem.Draw(
                                options.Colors[maskIndex],
                                colorsResultLooper,
                                resultLooper,
                                texture,
                                drawIndex,
                                GetCurrentProgressForComponent(progressWithRepeat),
                                options.Transparency
                             );
                        }
                    }
                }
            }

            currentDrawerIndex = 0;

            if (shading != null)
                options.ShadingDrawer.ChangeAsset(shading.Result);

            texture.CloseImage();

            resultLooper.CloseImage();

            DrawImageToGraphics(graphics, colorsResultLooper.Result);
        }

        private Color Blend(Color ForeGround, Color BackGround)
        {
            float fgAlpha = ForeGround.A / 255f;
            float bgAlpha = BackGround.A / 255f;
            float outAlpha = fgAlpha + bgAlpha * (1 - fgAlpha);

            if (outAlpha == 0)
                return Color.FromArgb(0, 0, 0, 0);

            int R = (int)((ForeGround.R * fgAlpha + BackGround.R * bgAlpha * (1 - fgAlpha)) / outAlpha);
            int G = (int)((ForeGround.G * fgAlpha + BackGround.G * bgAlpha * (1 - fgAlpha)) / outAlpha);
            int B = (int)((ForeGround.B * fgAlpha + BackGround.B * bgAlpha * (1 - fgAlpha)) / outAlpha);
            int A = (int)(outAlpha * 255);

            return Color.FromArgb(A, R, G, B);
        }

    }
}
