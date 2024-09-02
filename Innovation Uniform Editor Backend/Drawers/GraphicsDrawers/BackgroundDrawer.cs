using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Bases;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    public class BackgroundDrawer : BaseAssetDrawer<Bitmap>
    {
        public BackgroundDrawer(Bitmap asset) : base(asset)
        {
        }

        public override void DrawToGraphics(Graphics graphics)
        {
            if (asset != null)
                DrawImageToGraphics(graphics, asset);
        }
    }
}
