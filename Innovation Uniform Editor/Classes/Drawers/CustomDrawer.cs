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

                DrawColorsMasked(g, _colors, _assets.Selections);

                DrawOverlay(g);
            }
            return _result;
        }
        private unsafe void DrawColorsMasked(Graphics graphics, List<CustomColor> colors, List<bool[]> masks)
        {
            Bitmap shading = Assets.UniformsLoader.shading;
            BitmapData shadingData = shading.LockBits(new Rectangle(0, 0, shading.Width, shading.Height), ImageLockMode.ReadOnly, _result.PixelFormat);
            
            byte* scan0ShadingPointer = (byte*)shadingData.Scan0.ToPointer();

            BitmapData resultData = _result.LockBits(new Rectangle(0, 0, _result.Width, _result.Height), ImageLockMode.ReadOnly, _result.PixelFormat);
            byte* scan0Pointer = (byte*)resultData.Scan0.ToPointer();

            int pixelSize = Image.GetPixelFormatSize(resultData.PixelFormat);

            int index = 0;
            for (int i = 0; i < resultData.Stride * resultData.Width; i += pixelSize / 8)
            {
                index++;
                for (int maskIndex = 0; maskIndex < masks.Count; maskIndex++)
                {
                    bool canDraw = masks[maskIndex][index];

                    if (canDraw)
                    {
                        Color fullColor = GetColorFromCustomColor(colors[maskIndex]);
                        Color shadingColor = Color.FromArgb(scan0ShadingPointer[i+3], scan0ShadingPointer[i+2], scan0ShadingPointer[i+1], scan0ShadingPointer[i]);

                        Color blendColor = Blend(shadingColor, fullColor);
                        //Blue, Green, Red, Alpha
                        scan0Pointer[i] = blendColor.B;
                        scan0Pointer[i+1] = blendColor.G;
                        scan0Pointer[i+2] = blendColor.R;
                        scan0Pointer[i+3] = blendColor.A;
                    }
                }
            }

            _result.UnlockBits(resultData);
            shading.UnlockBits(shadingData);
        }
        //Took this from a stackoverflow post... it's not great, but works...
        public Color Blend(Color ForeGround, Color BackGround)
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
        //TODO add extra for fading.
        private Color GetColorFromCustomColor(CustomColor color)
        {
            if (color.Colors.Count > 0)
                return color.Colors[0];
            return Color.Transparent;
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
