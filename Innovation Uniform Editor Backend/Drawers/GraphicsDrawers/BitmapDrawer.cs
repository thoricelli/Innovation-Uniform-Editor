using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    public abstract class BitmapDrawer : BaseAssetDrawer<Bitmap>
    {
        public BitmapDrawer(Bitmap asset) : base(asset)
        {
        }
        public override void DrawToGraphics(Graphics graphics, Bitmap result)
        {
            if (asset != null)
                DrawImageToGraphics(graphics, asset);
        }
    }
}
