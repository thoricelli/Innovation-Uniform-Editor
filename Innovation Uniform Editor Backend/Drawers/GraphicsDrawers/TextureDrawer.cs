using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases;
using System.Collections.Generic;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    public class TextureDrawer : BaseAssetDrawer<List<Bitmap>>
    {
        public override string Name => "Texture";
        public TextureDrawer(List<Bitmap> asset) : base(asset)
        {
        }

        public override void DrawToGraphics(Graphics graphics, Bitmap result)
        {
            DrawList(graphics, asset);
        }
    }
}
