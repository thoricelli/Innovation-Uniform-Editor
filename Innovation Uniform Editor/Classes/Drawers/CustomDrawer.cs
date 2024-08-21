using Innovation_Uniform_Editor.Classes.Drawers.Interfaces;
using Innovation_Uniform_Editor.Classes.Images;
using Innovation_Uniform_Editor.Classes.Loaders;
using Innovation_Uniform_Editor.Classes.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor.Classes.Drawers
{
    public class CustomDrawer : IDrawable
    {
        private readonly Point DIMENSIONS = new Point(585, 559);

        private Bitmap _result;

        private UniformAssets _assets;

        private List<CustomColor> _colors = new List<CustomColor>();

        /// <summary>
        /// Doesn't shade the color at specified index.
        /// </summary>
        private List<int> doNotShade = new List<int>();

        public CustomDrawer(UniformAssets assets, List<CustomColor> colors)
        {
            _assets = assets;
            _result = new Bitmap(DIMENSIONS.X, DIMENSIONS.Y);
            _colors = colors;
        }

        /*
        How a custom is built up: (back to front)
        - Background

        - Textures (if any)
        (Textures can be shaded already if no source exists = add no shading to color)

        - Color(s) as OVERLAY -> separately masked.

        - Shading masked on top of the colored and/or textured layers
        (Since the vest is already shaded)

        - Overlay
        */
        public Bitmap Draw()
        {
            using (Graphics g = Graphics.FromImage(_result))
            {
                g.Clear(Color.Transparent);

                if (_assets.Background != null)
                    DrawBackground(g);

                DrawList(g, _assets.Textures);

                DrawColorsMasked(g, _colors, _assets.Selections);

                DrawOverlay(g);

                DrawList(g, _assets.Top);
            }
            return _result;
        }
        private unsafe void DrawColorsMasked(Graphics graphics, List<CustomColor> colors, List<bool[]> masks)
        {
            Bitmap colorsResult = new Bitmap(DIMENSIONS.X, DIMENSIONS.Y);
            BitmapData colorsResultData = colorsResult.LockBits(new Rectangle(0, 0, colorsResult.Width, colorsResult.Height), ImageLockMode.ReadOnly, _result.PixelFormat);
            byte* scan0PointerColorData = (byte*)colorsResultData.Scan0;

            Bitmap shading = Assets.UniformsLoader.shading;
            BitmapData shadingData = shading.LockBits(new Rectangle(0, 0, shading.Width, shading.Height), ImageLockMode.ReadOnly, _result.PixelFormat);

            byte* scan0ShadingPointer = (byte*)shadingData.Scan0;

            BitmapData resultData = _result.LockBits(new Rectangle(0, 0, _result.Width, _result.Height), ImageLockMode.ReadOnly, _result.PixelFormat);
            byte* scan0Pointer = (byte*)resultData.Scan0;

            int pixelSize = Image.GetPixelFormatSize(resultData.PixelFormat);

            int index = 0;
            for (int i = 0; i < resultData.Stride * resultData.Height; i += pixelSize / 8)
            {
                index++;
                for (int maskIndex = 0; maskIndex < masks.Count; maskIndex++)
                {
                    bool canDraw = masks[maskIndex][index];

                    if (canDraw)
                    {
                        Color currentColor = Color.FromArgb(scan0Pointer[i + 3], scan0Pointer[i + 2], scan0Pointer[i + 1], scan0Pointer[i]);

                        Color fullColor;
                        if (colors[maskIndex].Colors == null || colors[maskIndex].Colors.Count > 1)
                            fullColor = FadePixel(colors[maskIndex], ((double)i / resultData.Stride) / resultData.Height);
                        else
                            fullColor = GetColorFromCustomColor(colors[maskIndex]);

                        Color finalColor = Overlay(fullColor, currentColor);

                        if (!doNotShade.Exists(e => e == maskIndex))
                        {
                            Color shadingColor = Color.FromArgb(scan0ShadingPointer[i + 3], scan0ShadingPointer[i + 2], scan0ShadingPointer[i + 1], scan0ShadingPointer[i]);
                            finalColor = Blend(shadingColor, finalColor);
                        }

                        //Blue, Green, Red, Alpha
                        scan0PointerColorData[i] = finalColor.B;
                        scan0PointerColorData[i+1] = finalColor.G;
                        scan0PointerColorData[i+2] = finalColor.R;
                        scan0PointerColorData[i+3] = finalColor.A;
                    }
                }
            }

            _result.UnlockBits(resultData);
            shading.UnlockBits(shadingData);
            colorsResult.UnlockBits(colorsResultData);

            DrawImageToGraphics(graphics, colorsResult);
        }
        private Color FadePixel(CustomColor color, double progress)
        {
            if (progress < 1 && color.Colors != null && color.Colors.Count > 1)
            {
                //For every repeat, we want the progress to restart back to zero.
                double progressRepeat = progress * color.Repeat;
                double progressWithRepeat = progressRepeat - Math.Truncate(progressRepeat);

                //More colors = less time for each color to fade
                double colorProgress =
                    progressWithRepeat == 0 ? 
                    0 : progressWithRepeat / ((double)1 / (color.Colors.Count-1));
                
                //First number is the index, everything beyond the decimal is the fade progress.
                int currentIndex = Convert.ToInt32(Math.Floor(colorProgress));
                double currentFadeAmount = colorProgress - Math.Truncate(colorProgress);
                
                Color currentColor = color.Colors[currentIndex];
                Color fadeToColor = color.Colors[currentIndex + 1];

                return Blend(fadeToColor, currentColor, currentFadeAmount);
            }
            return Color.Transparent;
        }
        private Color Blend(Color color, Color backColor, double amount)
        {
            byte r = (byte)(color.R * amount + backColor.R * (1 - amount));
            byte g = (byte)(color.G * amount + backColor.G * (1 - amount));
            byte b = (byte)(color.B * amount + backColor.B * (1 - amount));
            return Color.FromArgb(255, r, g, b);
        }
        //Took this from a stackoverflow post... it's not great, but works...
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
        private Color Overlay(Color ForeGround, Color Background)
        {
            if (Background.R > 0 && Background.B > 0 && Background.G > 0)
                return Color.FromArgb(
                        255,//OverlayPixel(ForeGround.A, Background.A),
                        OverlayPixel(ForeGround.R, Background.R),
                        OverlayPixel(ForeGround.G, Background.G),
                        OverlayPixel(ForeGround.B, Background.B)
                    );
            return ForeGround;
        }
        //Help.....
        private int OverlayPixel(int upper, int lower)
        {
            if (lower < 128)
                return ClampColor(2 * upper * lower / 255);
            return ClampColor(255 - 2 * (255 - upper) * (255 - lower) / 255);
            //Can't be lower than 0 or higher than 255.
        }
        private int ClampColor(int value)
        {
            return value < 0 ? 0 : value > 255 ? 255 : value;
        }
        private Color GetColorFromCustomColor(CustomColor color)
        {
            return color.GetColorAtIndex(0);
        }
        private void DrawList(Graphics graphics, List<Bitmap> images)
        {
            foreach (Bitmap image in images)
            {
                DrawImageToGraphics(graphics, image);
            }
        }
        private void DrawBackground(Graphics graphics)
        {
            DrawImageToGraphics(graphics, _assets.Background);
        }
        private void DrawOverlay(Graphics graphics)
        {
            DrawImageToGraphics(graphics, _assets.Overlay);
        }
        private void DrawImageToGraphics(Graphics graphics, Bitmap image)
        {
            graphics.DrawImage(image, new Rectangle(0, 0, DIMENSIONS.X, DIMENSIONS.Y));
        }
    }
}
