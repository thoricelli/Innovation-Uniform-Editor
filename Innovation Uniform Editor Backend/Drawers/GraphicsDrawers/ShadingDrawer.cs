using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    public class ShadingDrawer : BitmapDrawer
    {
        public ShadingDrawer()
        {
        }
        public ShadingDrawer(Bitmap asset) : base(asset)
        {
        }

        public override string Name => "Shading";
    }
}
