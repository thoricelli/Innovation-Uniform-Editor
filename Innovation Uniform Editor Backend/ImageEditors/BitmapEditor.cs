using Innovation_Uniform_Editor_Backend.ImageEditors.Base;
using System.Drawing;
using System.Drawing.Imaging;

namespace Innovation_Uniform_Editor_Backend.ImageEditors
{
    public class BitmapEditor : ImageEditorBase<Bitmap>
    {
        private Bitmap original;
        private BitmapData data;

        public override Bitmap Result
        {
            get
            {
                CloseImage();
                return original;
            }
        }

        public BitmapEditor(Bitmap result)
        {
            original = result;
            CreateData(result);
        }

        private void CreateData(Bitmap bitmap)
        {
            data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
        }

        //Blue, Green, Red, Alpha
        public override unsafe void ChangePixelColorAtIndex(int index, Color color)
        {
            byte* scan0Pointer = (byte*)data.Scan0;

            index *= 4;

            scan0Pointer[index] = color.B;
            scan0Pointer[index + 1] = color.G;
            scan0Pointer[index + 2] = color.R;
            scan0Pointer[index + 3] = color.A;
        }

        public override unsafe Color GetPixelColorAtIndex(int index)
        {
            byte* scan0Pointer = (byte*)data.Scan0;

            index *= 4;

            return Color.FromArgb(
                scan0Pointer[index + 3],
                scan0Pointer[index + 2],
                scan0Pointer[index + 1],
                scan0Pointer[index]
            );
        }
        public void CloseImage()
        {
            original.UnlockBits(data);
        }

        public override int GetTotalSize()
        {
            return data.Stride * data.Height / 4;
        }

        public override int GetWidth()
        {
            return data.Stride / 4;
        }

        public override int GetHeight()
        {
            return data.Height;
        }

        ~BitmapEditor()
        {
            //ugh...
            //CloseImage();
        }
    }
}
