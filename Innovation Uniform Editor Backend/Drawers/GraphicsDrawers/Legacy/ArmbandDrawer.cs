using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy
{
    public class ArmbandDrawer : BitmapDrawer
    {
        public ArmbandDrawer(Bitmap asset) : base(asset)
        {
        }

        public override string Name => "Armband";
    }
}
