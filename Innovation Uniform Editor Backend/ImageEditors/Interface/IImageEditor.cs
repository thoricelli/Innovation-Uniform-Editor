using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.ImageEditors.Interface
{
    public interface IImageEditor
    {
        Color GetPixelColorAtIndex(int index);
        void ChangePixelColorAtIndex(int index, Color color);
        int GetTotalSize();
    }
}
