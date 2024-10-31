using System.Drawing;

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
