using Innovation_Uniform_Editor_Backend.ImageEditors.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.ImageEditors.Base
{
    public abstract class ImageEditorBase<T> : IImageEditor
    {
        public abstract T Result { get; }

        public abstract void ChangePixelColorAtIndex(int index, Color color);

        public abstract Color GetPixelColorAtIndex(int index);

        public abstract int GetTotalSize();
        public abstract int GetWidth();
        public abstract int GetHeight();
    }
}
