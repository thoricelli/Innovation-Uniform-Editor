using System.Drawing;
using System.Drawing.Drawing2D;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy
{
    internal class WatermarkDrawer : BitmapDrawer
    {
        public override string Name => "Watermark";
        public WatermarkDrawer(Bitmap asset) : base(asset)
        {
        }
        public override void DrawToGraphics(Graphics graphics, Bitmap result)
        {
            base.DrawToGraphics(graphics, result);

            if (Visible)
            {
                var font = new Font(EditorMain.SmallestPixel7, 12, FontStyle.Regular, GraphicsUnit.Pixel);

                var solidBrush = new SolidBrush(Color.FromArgb(0, 0, 0));

                graphics.DrawString(EditorMain.VersionString, font, solidBrush, new PointF(430, 487));
            }
        }
    }
}
