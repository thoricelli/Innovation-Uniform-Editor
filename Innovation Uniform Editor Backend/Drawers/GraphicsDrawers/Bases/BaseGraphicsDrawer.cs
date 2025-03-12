using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases
{

    public abstract class BaseGraphicsDrawer : IGraphicsDrawer<Bitmap>, IResultDrawable<Bitmap>
    {
        public abstract string Name { get; }
        public bool Visible { get; set; } = true;
        public float Transparency { get; set; } = 1.0F;
        public Point Shift { get; set; } = new Point(0, 0);
        public abstract bool HasAsset();
        public abstract void DrawToGraphics(Graphics graphics, Bitmap result);
        public Bitmap GetResult()
        {
            //TODO not to hardcode this :)
            Bitmap result = new Bitmap(585, 559);

            using (Graphics g = Graphics.FromImage(result))
            {
                DrawToGraphics(g, result);
            }

            return result;
        }
        protected void DrawImageToGraphics(Graphics graphics, Bitmap image)
        {
            this.DrawImageToGraphics(graphics, image, Point.Empty);
        }
        protected void DrawImageToGraphics(Graphics graphics, Bitmap image, Point point, float Transparency = 1f)
        {
            if (Visible)
            {
                if (Transparency != 1f)
                {
                    using (ImageAttributes imageAttributes = new ImageAttributes())
                    {
                        ColorMatrix colorMatrix = new ColorMatrix();
                        colorMatrix.Matrix33 = Transparency;

                        imageAttributes.SetColorMatrix(colorMatrix);

                        graphics.DrawImage(
                            image,
                            new Rectangle(point.X, point.Y, image.Width, image.Height),
                            0, 0, image.Width, image.Height,
                            GraphicsUnit.Pixel,
                            imageAttributes);
                    }
                } else
                {
                    graphics.DrawImage(image, new Rectangle(point.X, point.Y, image.Width, image.Height));
                }
            }
        }
        protected void DrawImageToGraphics(Graphics graphics, Image image)
        {
            this.DrawImageToGraphics(graphics, (Bitmap)image);
        }
        protected void DrawImageToGraphics(Graphics graphics, Image image, Point point)
        {
            this.DrawImageToGraphics(graphics, (Bitmap)image, point);
        }
        protected void DrawImageToGraphics(Graphics graphics, Image image, Point point, float transparency)
        {
            this.DrawImageToGraphics(graphics, (Bitmap)image, point, transparency);
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
