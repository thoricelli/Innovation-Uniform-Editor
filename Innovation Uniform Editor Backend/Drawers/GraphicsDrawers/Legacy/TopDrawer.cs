using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy
{
    public class TopDrawer : BaseAssetDrawer<List<Bitmap>>
    {
        public TopDrawer(List<Bitmap> asset) : base(asset)
        {
        }

        public override string Name => "Top";

        public override void DrawToGraphics(Graphics graphics, Bitmap result)
        {
            DrawList(graphics, asset);
        }
    }
}
