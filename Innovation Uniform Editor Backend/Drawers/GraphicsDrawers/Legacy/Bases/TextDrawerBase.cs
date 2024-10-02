using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var fontFamily = new FontFamily("Times New Roman");
            var font = new Font(fontFamily, 32, FontStyle.Regular, GraphicsUnit.Pixel);
            var solidBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));

            graphics.DrawString(text, font, solidBrush, position);
        }
    }
}
