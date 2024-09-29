using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy
{
    internal class WatermarkDrawer : BitmapDrawer
    {
        public override string Name => "Watermark";
        public WatermarkDrawer(Bitmap asset) : base(asset)
        {
        }
    }
}
