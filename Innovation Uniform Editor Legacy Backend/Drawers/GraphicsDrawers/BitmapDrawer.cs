using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Bases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    public abstract class BitmapDrawer : BaseAssetDrawer<Bitmap>
    {
        public BitmapDrawer(Bitmap asset) : base(asset)
        {
        }

        public override void DrawToGraphics(Graphics graphics, Bitmap result)
        {
            DrawImageToGraphics(graphics, asset);
        }
    }
}
