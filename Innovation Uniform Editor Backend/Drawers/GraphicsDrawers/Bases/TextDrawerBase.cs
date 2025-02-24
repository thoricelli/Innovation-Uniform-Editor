using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy
{
    public class TextDrawerBase : BaseGraphicsDrawer
    {
        private string text;
        private PointF position;
        private FontFamily fontFamily;
        private int size;
        private Color color;
        private FontStyle fontStyle;
        private StringAlignment alignment;
        private StringAlignment lineAlignment;
        private string name;

        public override string Name => "Text";

        public TextDrawerBase(string text, PointF position)
        {
            this.text = text;
            this.position = position;
            //fontFamily = EditorMain.Neuropol;
            size = 10;
            color = Color.FromArgb(255, 167, 167, 167);
            fontStyle = FontStyle.Regular;
            alignment = StringAlignment.Center;
            lineAlignment = StringAlignment.Center;
        }

        public TextDrawerBase(string text, PointF position, FontFamily fontFamily, int size, Color color, FontStyle fontStyle, StringAlignment alignment, StringAlignment lineAlignment)
        {
            this.text = text;
            this.position = position;
            this.fontFamily = fontFamily;
            this.size = size;
            this.color = color;
            this.fontStyle = fontStyle;
            this.alignment = alignment;
            this.lineAlignment = lineAlignment;
        }

        public override bool HasAsset()
        {
            return true;
        }

        public override void DrawToGraphics(Graphics graphics, Bitmap result)
        {
            if (Visible)
            {
                var font = new Font(fontFamily, size, fontStyle, GraphicsUnit.Pixel);
                var solidBrush = new SolidBrush(color);

                StringFormat format = new StringFormat();
                format.LineAlignment = lineAlignment;
                format.Alignment = alignment;

                graphics.DrawString(text, font, solidBrush, position, format);
            }
        }
    }
}
