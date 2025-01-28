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
        private List<CustomColor> _color;
        private List<UniformDataLogo> _logs;
        public LogoDrawer(Preset preset, List<UniformDataLogo> logos)
        {
            _logs = logos;
            ChangePreset(preset);
        }

        public void ChangePreset(Preset preset)
        {
            _color = preset.Colors;
        }

        public override bool HasAsset()
        {
            return _logs != null;
        }

        public override string Name => "Logo";

        public override void DrawToGraphics(Graphics graphics, Bitmap result)
        {
            if (_logs != null && Visible)
            {
                foreach (UniformDataLogo item in _logs)
                {
                    //Not great, oh well.
                    ColorDrawer drawer = new ColorDrawer(_color, item.Logo.Selections, item.Location, null);

                    drawer.DrawToGraphics(graphics, result);

                    //TODO: Position data!
                    DrawImageToGraphics(graphics, item.Logo.Image, item.Location);
                }
            }
        }
    }
}
