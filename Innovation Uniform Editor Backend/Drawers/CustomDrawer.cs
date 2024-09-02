using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers;
using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Interfaces;
using Innovation_Uniform_Editor_Backend.Drawers.Interfaces;
using Innovation_Uniform_Editor_Backend.Models;
using System.Collections.Generic;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers
{
    public class CustomDrawer : IDrawable<Bitmap>
    {
        private readonly Point DIMENSIONS = new Point(585, 559);

        private Bitmap _result;

        private UniformAssets _assets;

        private List<CustomColor> _colors = new List<CustomColor>();

        private List<IGraphicsDrawer> graphicsDrawers;

        /// <summary>
        /// Doesn't shade the color at specified index.
        /// </summary>
        private List<int> doNotShade = new List<int>();

        public CustomDrawer(UniformAssets assets, List<CustomColor> colors)
        {
            _assets = assets;
            _result = new Bitmap(DIMENSIONS.X, DIMENSIONS.Y);
            _colors = colors;

            Initialize();
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
        private void Initialize()
        {
            graphicsDrawers = new List<IGraphicsDrawer>()
            {
                new BackgroundDrawer(_assets.Background),
                new TextureDrawer(_assets.Textures),
            };
        }
        public Bitmap Draw()
        {
            using (Graphics g = Graphics.FromImage(_result))
            {
                g.Clear(Color.Transparent);

                foreach (IGraphicsDrawer drawer in graphicsDrawers)
                {
                    drawer.DrawToGraphics(g);
                }

                /*if (_assets.Background != null)
                    DrawBackground(g);

                DrawList(g, _assets.Textures);

                DrawColorsMasked(g, _colors, _assets.Selections);

                DrawOverlay(g);

                DrawList(g, _assets.Top);

                DrawImageToGraphics(g, Assets.UniformsLoader.waterMark);*/
            }
            return _result;
        }
        private unsafe void DrawColorsMasked(Graphics graphics, List<CustomColor> colors, List<bool[]> masks)
        {
            /*Bitmap colorsResult = new Bitmap(DIMENSIONS.X, DIMENSIONS.Y);
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
                        scan0PointerColorData[i + 1] = finalColor.G;
                        scan0PointerColorData[i + 2] = finalColor.R;
                        scan0PointerColorData[i + 3] = finalColor.A;
                    }
                }
            }

            _result.UnlockBits(resultData);
            shading.UnlockBits(shadingData);
            colorsResult.UnlockBits(colorsResultData);

            DrawImageToGraphics(graphics, colorsResult);*/
        }
        private Color GetColorFromCustomColor(CustomColor color)
        {
            return color.GetColorAtIndex(0);
        }
    }
}
