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

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases
{
    public abstract class BaseColorDrawer : BaseGraphicsDrawer
    {
        private Point _location;
        private ShadingDrawer _shadingDrawer;

        private List<CustomColor> _colors;
        private List<MaskImage> _masks;
        private int currentDrawerIndex = 0;

        private float _transparency = 1f;

        private int repeat = 2;

        private List<ComponentDrawerBase> colorDrawerItems;

        public BaseColorDrawer(List<CustomColor> colors, List<Bitmap> Selections, List<ComponentDrawerBase> Drawers, ShadingDrawer shading)
        {
            _colors = colors;
            _masks = ImageHelper.BitmapToBoolean(Selections);
            _shadingDrawer = shading;
            colorDrawerItems = Drawers;
        }
        public BaseColorDrawer(List<CustomColor> colors, List<Bitmap> Selections, List<ComponentDrawerBase> Drawers, ShadingDrawer shading, float transparency)
        {
            _colors = colors;
            _masks = ImageHelper.BitmapToBoolean(Selections);
            _shadingDrawer = shading;
            colorDrawerItems = Drawers;
            _transparency = transparency;
        }
        public BaseColorDrawer(List<CustomColor> colors, List<Bitmap> Selections, List<ComponentDrawerBase> Drawers, Point location, ShadingDrawer shading)
        {
            _colors = colors;
            _masks = ImageHelper.BitmapToBoolean(Selections);
            _location = location;
            _shadingDrawer = shading;
            colorDrawerItems = Drawers;
        }
        public BaseColorDrawer(List<CustomColor> colors, List<Bitmap> Selections, List<ComponentDrawerBase> Drawers, Point location, ShadingDrawer shading, float transparency)
        {
            _colors = colors;
            _masks = ImageHelper.BitmapToBoolean(Selections);
            _location = location;
            _shadingDrawer = shading;
            colorDrawerItems = Drawers;
            _transparency = transparency;
        }
        public override bool HasAsset()
        {
            return _colors.Count > 0 && _masks.Count > 0;
        }
        private ComponentDrawerBase GetCurrentComponent(double Yprogress)
        {
            //this code is shit.

            ComponentDrawerBase drawer = null;

            if (currentDrawerIndex < colorDrawerItems.Count)
            {
                if (Yprogress < colorDrawerItems.First().EndYPercentage)
                    currentDrawerIndex = 0;

                if (colorDrawerItems[currentDrawerIndex].EndYPercentage < Yprogress)
                    if (currentDrawerIndex < colorDrawerItems.Count - 1)
                        currentDrawerIndex++;
                    else
                        return null;

                drawer = colorDrawerItems[currentDrawerIndex];
            }

            return drawer;
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

                            if (shading != null)
                                shading.ChangePixelColorAtIndex(drawIndex, ComponentDrawerBase.shading.GetPixelColorAtIndex(drawIndex));

                            

                            currentDrawItem.Draw(
                                _colors[maskIndex],
                                colorsResultLooper,
                                resultLooper,
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

            resultLooper.CloseImage();

            DrawImageToGraphics(graphics, colorsResultLooper.Result);
        }
    }
}
