using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    public class UsernameDrawer : TextDrawerBase
    {
        public UsernameDrawer() : base("Sample", new PointF(471, 124))
        {
        }

        public override string Name => "Username";
    }
}
