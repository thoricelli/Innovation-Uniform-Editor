using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    public class HolsterDrawer : BitmapDrawer
    {
        public HolsterDrawer(Bitmap asset) : base(asset)
        {
        }

        public override string Name => "Holster";
    }
}
