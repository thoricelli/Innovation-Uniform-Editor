using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Bases
{
    public abstract class BaseGraphicsDrawer : IGraphicsDrawer
    {
        public abstract string Name { get; }
        public bool Visible { get; set; } = true;
        public float Transparency { get; set; } = 1.0F;
        public Point Shift { get; set; } = new Point(0, 0);

        public abstract void DrawToGraphics(Graphics graphics, Bitmap result);
        public Bitmap GetResult()
        {
            //TODO not to hardcode this :)
            Bitmap result = new Bitmap(585, 559);

            using (Graphics g = Graphics.FromImage(result)) {
                DrawToGraphics(g, result);
            }

            return result;
        }
        protected void DrawImageToGraphics(Graphics graphics, Bitmap image)
        {
            if (Visible)
                graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
        }
        protected void DrawList(Graphics graphics, List<Bitmap> images)
        {
            if (Visible)
            {
                foreach (Bitmap image in images)
                {
                    DrawImageToGraphics(graphics, image);
                }
            }
        }
    }
}
