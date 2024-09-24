using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.ImageEditors.Interface
{
    public interface IImageEditor
    {
        Color GetPixelColorAtIndex(int index);
        void ChangePixelColorAtIndex(int index, Color color);
        int GetTotalSize();
    }
}
