using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    public class GloveDrawer : BitmapDrawer
    {
        public GloveDrawer(Bitmap asset) : base(asset)
        {
        }

        public override string Name => "Glove";
    }
}
