using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Bases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    internal class OverlayDrawer : BitmapDrawer
    {
        public override string Name => "Overlay";
        public OverlayDrawer(Bitmap asset) : base(asset)
        {
        }
    }
}
