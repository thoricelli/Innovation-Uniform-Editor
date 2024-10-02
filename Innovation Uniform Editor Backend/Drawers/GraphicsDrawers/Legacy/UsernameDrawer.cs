using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy
{
    public class UsernameDrawer : TextDrawerBase
    {
        public UsernameDrawer() : base("Test", new PointF(0, 0))
        {
        }

        public override string Name => "Username";
    }
}
