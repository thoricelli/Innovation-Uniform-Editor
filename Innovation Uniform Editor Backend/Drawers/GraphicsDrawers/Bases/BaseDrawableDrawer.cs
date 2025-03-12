using Innovation_Uniform_Editor_Backend.Drawers.Interfaces;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases
{
    //Draws drawers with the IDrawable class (uhm, yeah...)
    public abstract class BaseDrawableDrawer : BaseGraphicsDrawer
    {
        private IDrawable<Bitmap> _drawable;
        public BaseDrawableDrawer(IDrawable<Bitmap> drawable)
        {
            _drawable = drawable;
        }
        public override void DrawToGraphics(Graphics graphics, Bitmap result)
        {
            DrawImageToGraphics(graphics, _drawable.Draw());
        }
    }
}
