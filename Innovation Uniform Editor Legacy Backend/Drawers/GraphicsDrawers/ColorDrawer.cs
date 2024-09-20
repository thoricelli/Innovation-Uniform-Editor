using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Bases;
using Innovation_Uniform_Editor_Backend.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
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
            Bitmap colorsResult = new Bitmap(result.Width, result.Height);
            BitmapData colorsResultData = colorsResult.LockBits(new Rectangle(0, 0, colorsResult.Width, colorsResult.Height), ImageLockMode.ReadOnly, result.PixelFormat);
            byte* scan0PointerColorData = (byte*)colorsResultData.Scan0;

            Bitmap shading = EditorMain.Uniforms.shading;
            BitmapData shadingData = shading.LockBits(new Rectangle(0, 0, shading.Width, shading.Height), ImageLockMode.ReadOnly, result.PixelFormat);

            byte* scan0ShadingPointer = (byte*)shadingData.Scan0;

            BitmapData resultData = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.ReadOnly, result.PixelFormat);
            byte* scan0Pointer = (byte*)resultData.Scan0;

            int pixelSize = Image.GetPixelFormatSize(resultData.PixelFormat);

            int index = 0;
            for (int i = 0; i < resultData.Stride * resultData.Height; i += pixelSize / 8)
            {
                index++;
                for (int maskIndex = 0; maskIndex < _masks.Count; maskIndex++)
                {
                    bool canDraw = _masks[maskIndex][index];

                    if (canDraw)
                    {
                        Color currentColor = Color.FromArgb(scan0Pointer[i + 3], scan0Pointer[i + 2], scan0Pointer[i + 1], scan0Pointer[i]);

                        Color fullColor;
                        if (_colors[maskIndex].Colors == null || _colors[maskIndex].Colors.Count > 1)
                            fullColor = FadePixel(_colors[maskIndex], ((double)i / resultData.Stride) / resultData.Height);
                        else
                            fullColor = GetColorFromCustomColor(_colors[maskIndex]);

                        Color finalColor = Overlay(fullColor, currentColor);

                        if (!doNotShade.Exists(e => e == maskIndex))
                        {
                            Color shadingColor = Color.FromArgb(scan0ShadingPointer[i + 3], scan0ShadingPointer[i + 2], scan0ShadingPointer[i + 1], scan0ShadingPointer[i]);
                            finalColor = Blend(shadingColor, finalColor);
                        }

                        //Blue, Green, Red, Alpha
                        scan0PointerColorData[i] = finalColor.B;
                        scan0PointerColorData[i + 1] = finalColor.G;
                        scan0PointerColorData[i + 2] = finalColor.R;
                        scan0PointerColorData[i + 3] = finalColor.A;
                    }
                }
            }

            result.UnlockBits(resultData);
            shading.UnlockBits(shadingData);
            colorsResult.UnlockBits(colorsResultData);

            DrawImageToGraphics(graphics, colorsResult);
        }
        private Color GetColorFromCustomColor(CustomColor color)
        {
            return color.GetColorAtIndex(0);
        }
    }
}
