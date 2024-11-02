using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases;
using Innovation_Uniform_Editor_Backend.Models;
using Innovation_Uniform_Editor_Backend.Models.Assets;
using Innovation_Uniform_Editor_Backend.Models.OverlayAssets;
using System.Collections.Generic;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    public class LogoDrawer : BaseGraphicsDrawer
    {
        private List<CustomColor> _customColors;
        private List<Logo> _logs;
        public LogoDrawer(List<CustomColor> colors, List<Logo> logos)
        {
            _logs = logos;
            _customColors = colors;
        }

        public override string Name => "Logo";

        public override void DrawToGraphics(Graphics graphics, Bitmap result)
        {
            if (_logs != null && Visible)
            {
                foreach (Logo item in _logs)
                {
                    //Not great, oh well.
                    ColorDrawer drawer = new ColorDrawer(_customColors, item.Selections);

                    drawer.DrawToGraphics(graphics, result);

                    //TODO: Position data!
                    DrawImageToGraphics(graphics, item.Image);
                }
            }
        }
    }
}
