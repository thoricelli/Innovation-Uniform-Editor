using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Bases;
using System.Collections.Generic;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    public class TextureDrawer : BaseAssetDrawer<List<Bitmap>>
    {
        public TextureDrawer(List<Bitmap> asset) : base(asset)
        {
        }

        public override void DrawToGraphics(Graphics graphics)
        {
            DrawList(graphics, asset);
        }
    }
}
