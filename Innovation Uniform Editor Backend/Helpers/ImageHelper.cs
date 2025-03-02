using Innovation_Uniform_Editor_Backend.ImageEditors;
using Innovation_Uniform_Editor_Backend.ImageEditors.Interface;
using Innovation_Uniform_Editor_Backend.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Innovation_Uniform_Editor_Backend.Helpers
{
    public static class ImageHelper
    {
        public static Image resizeImage(Image imgToResize, Size size)
        {
            Bitmap b = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, size.Width, size.Height);
            g.Dispose();
            return b;
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
        /// <summary>
        /// Maps alpha values to booleans using the STRIDE width
        /// </summary>
        /// <param name="images"></param>
        /// <returns>A list of alpha values mapped as boolean</returns>
        public static List<MaskImage> BitmapToBoolean(List<Bitmap> images)
        {
            List<MaskImage> bools = new List<MaskImage>();

            foreach (Bitmap item in images)
            {
                IImageEditor editor = new BitmapEditor(item);

                int totalSize = editor.GetTotalSize();
                bool[] alphas = new bool[totalSize];

                for (int i = 0; i < totalSize; i++)
                {
                    alphas[i] = editor.GetPixelColorAtIndex(i).A == 0;
                }

                ((BitmapEditor)editor).CloseImage();

                bools.Add(new MaskImage(editor.GetWidth(), editor.GetHeight(), alphas));
            }
            return bools;
        }

        public static MaskImage BitmapToSingleBoolean(List<Bitmap> images)
        {
            if (images != null && images.Count > 0)
            {
                IImageEditor editor = new BitmapEditor(images[0]);

                int totalSize = editor.GetTotalSize();
                bool[] alphas = new bool[totalSize];

                ((BitmapEditor)editor).CloseImage();

                foreach (Bitmap image in images)
                {
                    editor = new BitmapEditor(image);

                    for (int i = 0; i < totalSize; i++)
                    {
                        alphas[i] |= editor.GetPixelColorAtIndex(i).A == 0;
                    }

                    ((BitmapEditor)editor).CloseImage();
                }

                return new MaskImage(editor.GetWidth(), editor.GetHeight(), alphas);
            }
            return null;
        } 
    }
}
