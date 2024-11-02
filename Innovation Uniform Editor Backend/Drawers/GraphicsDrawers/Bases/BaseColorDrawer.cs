using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.ComponentDrawers;
using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.ComponentDrawers.Bases;
using Innovation_Uniform_Editor_Backend.Helpers;
using Innovation_Uniform_Editor_Backend.ImageEditors;
using Innovation_Uniform_Editor_Backend.ImageEditors.Base;
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
        private List<CustomColor> _colors;
        private List<bool[]> _masks;
        /// <summary>
        /// Doesn't shade the color at specified index.
        /// </summary>
        private List<int> doNotShade = new List<int>();
        private int currentDrawerIndex = 0;

        private int repeat = 2;

        private List<ComponentDrawerBase> colorDrawerItems = new List<ComponentDrawerBase>()
        {
            new ColorComponentDrawer(0.3, ColorDrawerTypes.SOLID, ColorType.FirstColor, BlendMode.Overlay),
            new FadeComponentDrawer(0.72, ColorDrawerTypes.FADE, BlendMode.Overlay),
            new ColorComponentDrawer(1, ColorDrawerTypes.SOLID, ColorType.LastColor, BlendMode.Overlay),
        };

        public BaseColorDrawer(List<CustomColor> colors, List<Bitmap> Selections)
        {
            _colors = colors;
            _masks = ImageHelper.BitmapToBoolean(Selections);
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

        public unsafe override void DrawToGraphics(Graphics graphics, Bitmap result)
        {
            //I've been trying to generalize this function to make it usable with literally anything,
            //and I failed.

            ImageEditorBase<Bitmap> colorsResultLooper = new BitmapEditor(new Bitmap(result.Width, result.Height));

            BitmapEditor resultLooper = new BitmapEditor(result);

            int totalSize = colorsResultLooper.GetTotalSize();
            int width = colorsResultLooper.GetWidth();

            for (int maskIndex = 0; maskIndex < _masks.Count; maskIndex++)
            {
                bool[] mask = _masks[maskIndex];

                for (int i = 0; i < mask.Length; i++)
                {
                    bool canDraw = mask[i];

                    if (canDraw)
                    {
                        double yProgress = (double)(i / width) / (totalSize / width);

                        double progressRepeat = yProgress * repeat;
                        double progressWithRepeat = progressRepeat - Math.Truncate(progressRepeat);

                        ComponentDrawerBase currentDrawItem = GetCurrentComponent(
                            progressWithRepeat
                        );

                        if (currentDrawItem != null)
                        {
                            currentDrawItem.Draw(
                                _colors[maskIndex],
                                colorsResultLooper,
                                resultLooper,
                                i,
                                GetCurrentProgressForComponent(progressWithRepeat)
                             );
                        }
                    }
                }
            }

            //TEMP
            currentDrawerIndex = 0;
            resultLooper.CloseImage();

            DrawImageToGraphics(graphics, colorsResultLooper.Result);
        }
    }
}
