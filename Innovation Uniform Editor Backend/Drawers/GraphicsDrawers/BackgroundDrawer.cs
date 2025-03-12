using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    public class BackgroundDrawer : BitmapDrawer
    {
        public override string Name => "Background";
        public BackgroundDrawer(Bitmap asset) : base(asset)
        {
        }

        public override void DrawToGraphics(Graphics graphics, Bitmap result)
        {
            if (asset != null)
                base.DrawToGraphics(graphics, result);
        }
    }
}
