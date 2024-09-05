using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Interfaces
{
    public interface IGraphicsDrawer
    {
        void DrawToGraphics(Graphics graphics, Bitmap result);
    }
}
