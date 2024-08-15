using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Innovation_Uniform_Editor.Classes.Helpers
{
    public static class ImageHelper
    {
        public static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
        {
            Bitmap b = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, size.Width, size.Height);
            g.Dispose();
            return (System.Drawing.Image)b;
        }
        public static Image SetOpacity(this Image image, float opacity)
        {
            var colorMatrix = new ColorMatrix();
            colorMatrix.Matrix33 = opacity;
            var imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(
                colorMatrix,
                ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);
            var output = new Bitmap(image.Width, image.Height);
            using (var gfx = Graphics.FromImage(output))
            {
                gfx.SmoothingMode = SmoothingMode.AntiAlias;
                gfx.DrawImage(
                    image,
                    new Rectangle(0, 0, image.Width, image.Height),
                    0,
                    0,
                    image.Width,
                    image.Height,
                    GraphicsUnit.Pixel,
                    imageAttributes);
            }
            return output;
        }
        public unsafe static List<bool[]> BitmapToBoolean(List<Bitmap> images)
        {
            List<bool[]> bools = new List<bool[]>();

            foreach (Bitmap item in images)
            {
                BitmapData bitmapData = item.LockBits(new Rectangle(0, 0, item.Width, item.Height), ImageLockMode.ReadOnly, item.PixelFormat);

                byte* scan0Base = (byte*)bitmapData.Scan0.ToPointer();

                int pixelSize = Image.GetPixelFormatSize(item.PixelFormat);

                bool[] alphas = new bool[bitmapData.Stride * item.Height];

                int index = 0;
                for (int i = 0; i < bitmapData.Stride * item.Height; i += pixelSize / 8)
                {
                    //Blue, Green, Red, Alpha
                    index++;
                    if (item.PixelFormat == PixelFormat.Format32bppArgb)
                        alphas[index] = scan0Base[i+3] == 255;
                }

                bools.Add(alphas);

                item.UnlockBits(bitmapData);
            }
            return bools;
        }
    }
}
