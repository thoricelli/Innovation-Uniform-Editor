using Innovation_Uniform_Editor_Backend.ImageEditors.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.ImageEditors.Factory
{
    public static class ImageFactory
    {
        public static IImageEditor CreateImageEditor<T>(T image)
        {
            Type typeOfT = typeof(T);

            if (typeOfT == typeof(Bitmap))
                return new BitmapEditor(image as Bitmap);

            return null;
        }
        public static IImageEditor CreateImageEditor<T>(int width, int height)
        {
            Type typeOfT = typeof(T);

            if (typeOfT == typeof(Bitmap))
                return new BitmapEditor(new Bitmap(width, height));

            return null;
        }
    }
}
