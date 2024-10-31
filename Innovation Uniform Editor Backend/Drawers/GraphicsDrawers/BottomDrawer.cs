using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    public class BottomDrawer : BitmapDrawer
    {
        public BottomDrawer(Bitmap asset) : base(asset)
        {
        }

        public override string Name => "Bottom";
    }
}
