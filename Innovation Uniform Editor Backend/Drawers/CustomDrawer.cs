using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy;
using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases;
using Innovation_Uniform_Editor_Backend.Drawers.Interfaces;
using Innovation_Uniform_Editor_Backend.Models;
using System.Collections.Generic;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers
{
    public class CustomDrawer : IDrawable<Bitmap>
    {
        private readonly Point DIMENSIONS = new Point(585, 559);

        private Bitmap _result;

        private UniformAssets _assets;

        private List<CustomColor> _colors = new List<CustomColor>();

        public List<BaseGraphicsDrawer> GraphicsDrawers;

        public CustomDrawer(UniformAssets assets, List<CustomColor> colors)
        {
            _assets = assets;
            _result = new Bitmap(DIMENSIONS.X, DIMENSIONS.Y);
            _colors = colors;

            Initialize();
        }
        /*
        How a custom is built up: (back to front)
        - Background

        - Textures (if any)
        (Textures can be shaded already if no source exists = add no shading to color)

        - Color(s) as OVERLAY -> separately masked.

        - Shading masked on top of the colored and/or textured layers
        (Since the vest is already shaded)

        - Overlay
        */
        private void Initialize()
        {
            GraphicsDrawers = new List<BaseGraphicsDrawer>()
            {
                new BackgroundDrawer(_assets.Background),
                new TextureDrawer(_assets.Textures),
                new ColorDrawer(_colors, _assets.Selections),
                new TopDrawer(_assets.Top),
                new OverlayDrawer(_assets.Overlay),
                new WatermarkDrawer(EditorMain.Uniforms.waterMark)
            };
        }
        public Bitmap Draw()
        {
            using (Graphics g = Graphics.FromImage(_result))
            {
                g.Clear(Color.Transparent);

                foreach (BaseGraphicsDrawer drawer in GraphicsDrawers)
                {
                    drawer.DrawToGraphics(g, _result);
                }
            }
            return _result;
        }
    }
}
