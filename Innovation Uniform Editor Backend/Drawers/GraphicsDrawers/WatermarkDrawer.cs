using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    internal class WatermarkDrawer : BitmapDrawer
    {
        public override string Name => "Watermark";
        private FontFamily fontFamily;
        public WatermarkDrawer(Bitmap asset) : base(asset)
        {
            fontFamily = EditorMain.FontsLoader.FindBy("smallest_pixel-7").FontFamily;
        }
        public override void DrawToGraphics(Graphics graphics, Bitmap result)
        {
            base.DrawToGraphics(graphics, result);

            if (Visible)
            {
                var font = new Font(fontFamily, 12, FontStyle.Regular, GraphicsUnit.Pixel);

                var solidBrush = new SolidBrush(Color.FromArgb(0, 0, 0));

                graphics.DrawString(Versioning.VersionString, font, solidBrush, new PointF(430, 487));
            }
        }
    }
}
