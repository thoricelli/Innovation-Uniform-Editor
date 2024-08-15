using Innovation_Uniform_Editor.Classes.Drawers.Interfaces;
using Innovation_Uniform_Editor.Classes.Images;
using Innovation_Uniform_Editor.Classes.Loaders;
using Innovation_Uniform_Editor.Classes.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor.Classes.Drawers
{
    public class CustomDrawer : IDrawable
    {
        private readonly Point DIMENSIONS = new Point(585, 559);

        private Bitmap _result;

        private UniformAssets _assets;

        public CustomDrawer(UniformAssets assets)
        {
            _assets = assets;
            _result = new Bitmap(DIMENSIONS.X, DIMENSIONS.Y);
        }

        /*
        How a custom is built up: (back to front)
        - Background

        - Textures (if any)

        - Color(s) as OVERLAY -> separately masked.

        - Shading masked on top of the colored and/or textured layers
        (Since the vest is already shaded)

        - Overlay
        */
        public Bitmap Draw()
        {
            using (Graphics g = Graphics.FromImage(_result))
            {
                g.Clear(Color.White);

                if (_assets.Background != null)
                    DrawBackground(g);

                DrawOverlay(g);
            }
            return _result;
        }
        private void DrawColorsMasked(Graphics graphics, List<CustomColor> colors, List<Bitmap> masks)
        {
            //Graphics colored = Graphics.

        }
        private void DrawBackground(Graphics graphics)
        {
            DrawImageToGraphics(graphics, _assets.Background);
        }
        private void DrawOverlay(Graphics graphics)
        {
            DrawImageToGraphics(graphics, _assets.Overlay);
        }
        private void DrawImageToGraphics(Graphics graphics, Bitmap image)
        {
            graphics.DrawImage(image, new Rectangle(0, 0, DIMENSIONS.X, DIMENSIONS.Y));
        }
    }
}
