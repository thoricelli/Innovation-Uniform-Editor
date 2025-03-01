using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.ComponentDrawers;
using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.ComponentDrawers.Bases;
using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases;
using Innovation_Uniform_Editor_Backend.Models;
using Innovation_Uniform_Editor_Backend.Models.Assets;
using Innovation_Uniform_Editor_Backend.Models.Enums;
using Innovation_Uniform_Editor_Backend.Models.OverlayAssets;
using System.Collections.Generic;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    public class LogoDrawer : BaseGraphicsDrawer
    {
        private List<UniformDataLogo> _logos;
        private Custom _custom;

        private static List<ComponentDrawerBase> componentDrawers = new List<ComponentDrawerBase>
        {
            new ColorComponentDrawer(1, ColorDrawerTypes.SOLID, ColorType.FirstColor, BlendMode.None)
        };
        public LogoDrawer(List<UniformDataLogo> logos, Custom custom)
        {
            _logos = logos;
            _custom = custom;
        }

        public override bool HasAsset()
        {
            return _logos != null;
        }

        public override string Name => "Logo";

        public override void DrawToGraphics(Graphics graphics, Bitmap result)
        {
            if (_logos != null && Visible)
            {
                for (int i = 0; i < _logos.Count; i++)
                {
                    UniformDataLogo item = _logos[i];

                    List<CustomColor> colors = _custom.Presets[i].Colors;

                    //Not great, oh well.
                    ColorDrawer drawer = new ColorDrawer(colors, item.Logo.Selections, componentDrawers, item.Location, null, item.Transparency);

                    drawer.DrawToGraphics(graphics, result);

                    //TODO: Position data!
                    DrawImageToGraphics(graphics, item.Logo.Image, item.Location, item.Transparency);
                }
            }
        }
    }
}
