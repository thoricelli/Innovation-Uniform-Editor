using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    public class ShoeDrawer : BitmapDrawer
    {
        public ShoeDrawer(Bitmap asset) : base(asset)
        {
        }

        public override string Name => "Shoe";
    }
}
