using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy
{
    public abstract class TextDrawerBase : BaseGraphicsDrawer
    {
        private string text;
        private PointF position;

        protected TextDrawerBase(string text, PointF position)
        {
            this.text = text;
            this.position = position;
        }

        public override void DrawToGraphics(Graphics graphics, Bitmap result)
        {
            var font = new Font(EditorMain.Neuropol, 10, FontStyle.Regular, GraphicsUnit.Pixel);
            var solidBrush = new SolidBrush(Color.FromArgb(255, 167, 167, 167));

            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            graphics.DrawString(text, font, solidBrush, position, format);
        }
    }
}
