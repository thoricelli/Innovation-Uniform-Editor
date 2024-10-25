using Innovation_Uniform_Editor_Backend.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Models.Base
{
    public abstract class ItemRecolorableBase : ItemBase
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
