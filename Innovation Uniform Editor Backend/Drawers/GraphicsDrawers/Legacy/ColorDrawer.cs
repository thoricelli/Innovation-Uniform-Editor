using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases;
using Innovation_Uniform_Editor_Backend.ImageEditors;
using Innovation_Uniform_Editor_Backend.ImageLooper.Interface;
using Innovation_Uniform_Editor_Backend.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy
{
    public class ColorDrawer : BasePixelDrawer
    {
        public override string Name => "Colors";

        private List<CustomColor> _colors;
        private List<bool[]> _masks;
        /// <summary>
        /// Doesn't shade the color at specified index.
        /// </summary>
        private List<int> doNotShade = new List<int>();

        public ColorDrawer(List<CustomColor> colors, List<bool[]> masks)
        {
            _colors = colors;
            _masks = masks;
        }

        public unsafe override void DrawToGraphics(Graphics graphics, Bitmap result)
        {
            //I've been trying to generalize this function to make it usable with literally anything,
            //and I failed.

            Bitmap colorsResult = new Bitmap(result.Width, result.Height);

            BitmapEditor colorsResultLooper = new BitmapEditor(colorsResult);

            Bitmap shading = EditorMain.Uniforms.shading;
            BitmapEditor shadingLooper = new BitmapEditor(shading);

            BitmapEditor resultLooper = new BitmapEditor(result);

            int index = 0;
            int totalSize = colorsResultLooper.GetTotalSize();

            for (int i = 0; i < totalSize; i++)
            {
                index++;
                for (int maskIndex = 0; maskIndex < _masks.Count; maskIndex++)
                {
                    bool canDraw = _masks[maskIndex][index];

                    if (canDraw)
                    {
                        Color currentColor = resultLooper.GetPixelColorAtIndex(i);

                        Color fullColor;
                        if (_colors[maskIndex].Colors == null || _colors[maskIndex].Colors.Count > 1)
                            fullColor = FadePixel(_colors[maskIndex], (double)i / totalSize);
                        else
                            fullColor = GetColorFromCustomColor(_colors[maskIndex]);

                        Color finalColor = Overlay(fullColor, currentColor);

                        if (!doNotShade.Exists(e => e == maskIndex))
                        {
                            Color shadingColor = shadingLooper.GetPixelColorAtIndex(i);
                            finalColor = Blend(shadingColor, finalColor);
                        }

                        colorsResultLooper.ChangePixelColorAtIndex(i, finalColor);
                    }
                }
            }

            //TEMP

            colorsResultLooper.CloseImage();
            shadingLooper.CloseImage();
            resultLooper.CloseImage();

            DrawImageToGraphics(graphics, colorsResult);
        }
        private Color GetColorFromCustomColor(CustomColor color)
        {
            return color.GetColorAtIndex(0);
        }
    }
}
