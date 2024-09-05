using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Bases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    internal class WatermarkDrawer : BitmapDrawer
    {
        public override string Name => "Watermark";
        public WatermarkDrawer(Bitmap asset) : base(asset)
        {
        }
    }
}
