using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    public class ArmbandDrawer : BitmapDrawer
    {
        public ArmbandDrawer(Bitmap asset) : base(asset)
        {
        }

        public override string Name => "Armband";
    }
}
