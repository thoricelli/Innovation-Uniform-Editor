using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases;
using Innovation_Uniform_Editor_Backend.Models;
using Innovation_Uniform_Editor_Backend.Models.Assets;
using System.Collections.Generic;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    public class LogoDrawer : BaseGraphicsDrawer
    {
        private List<CustomColor> _customColors;
        private List<LogoAssets> _logoAssets;
        public LogoDrawer(List<CustomColor> colors, List<LogoAssets> logoAssets)
        {
            _logoAssets = logoAssets;
            _customColors = colors;
        }

        public override string Name => "Logo";

        public override void DrawToGraphics(Graphics graphics, Bitmap result)
        {
            if (_logoAssets != null)
            {
                foreach (LogoAssets item in _logoAssets)
                {
                    //Not great, oh well.
                    ColorDrawer drawer = new ColorDrawer(_customColors, item.Selections);

                    drawer.DrawToGraphics(graphics, result);

                    //TODO: Position data!
                    DrawImageToGraphics(graphics, item.Overlay);
                }
            }
        }
    }
}
