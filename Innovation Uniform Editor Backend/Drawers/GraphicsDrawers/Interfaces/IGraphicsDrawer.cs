using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Interfaces
{
    public interface IGraphicsDrawer<T>
    {
        void DrawToGraphics(Graphics graphics, T result);
    }
}
