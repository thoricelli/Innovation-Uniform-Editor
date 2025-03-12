using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Interfaces
{
    public interface IGraphicsDrawer<T>
    {
        void DrawToGraphics(Graphics graphics, T result);
    }
}
