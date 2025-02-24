using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    internal class LineTemplateDrawer : BaseGraphicsDrawer
    {
        private Pen pen;

        public LineTemplateDrawer(int size, Color color, DashStyle style)
        {
            pen = new Pen(color, size)
            {
                DashStyle = style
            };
        }

        public override string Name => "Line Template";

        public override void DrawToGraphics(Graphics graphics, Bitmap result)
        {
            if (Visible)
            {
                graphics.DrawRectangle(pen, new Rectangle(230, 7, 130, 262));
                graphics.DrawRectangle(pen, new Rectangle(164, 73, 262, 130));
                graphics.DrawRectangle(pen, new Rectangle(426, 73, 130, 130));

                graphics.DrawRectangle(pen, new Rectangle(216, 288, 66, 262));
                graphics.DrawRectangle(pen, new Rectangle(18, 354, 264, 130));
                graphics.DrawRectangle(pen, new Rectangle(84, 354, 66, 130));

                graphics.DrawRectangle(pen, new Rectangle(307, 288, 66, 262));
                graphics.DrawRectangle(pen, new Rectangle(307, 354, 264, 130));
                graphics.DrawRectangle(pen, new Rectangle(439, 354, 66, 130));
            }
        }

        public override bool HasAsset()
        {
            return true;
        }
    }
}
