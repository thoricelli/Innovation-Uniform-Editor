using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Bases
{
    public abstract class BaseGraphicsDrawer : IGraphicsDrawer
    {
        public bool Visible { get; set; }
        public float Transparency { get; set; }
        public Point Shift { get; set; }

        public abstract void DrawToGraphics(Graphics graphics);

        protected void DrawImageToGraphics(Graphics graphics, Bitmap image)
        {
            graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
        }
        protected void DrawList(Graphics graphics, List<Bitmap> images)
        {
            foreach (Bitmap image in images)
            {
                DrawImageToGraphics(graphics, image);
            }
        }
    }
}
