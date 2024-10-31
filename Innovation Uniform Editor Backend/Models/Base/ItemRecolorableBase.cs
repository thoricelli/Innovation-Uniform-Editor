using Innovation_Uniform_Editor_Backend.Helpers;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Models.Base
{
    public abstract class ItemRecolorableBase<T> : ItemBase<T>
    {
        public override Image Image
        {
            get
            {
                if (_image == null)
                    _image = FileToBitmap.Convert($"{Path}/{Id}/Overlay.png");
                return _image;
            }
        }
    }
}
