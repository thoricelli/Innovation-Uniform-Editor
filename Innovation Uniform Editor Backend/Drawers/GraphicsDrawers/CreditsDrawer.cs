using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy;
using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases;
using Innovation_Uniform_Editor_Backend.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    public class CreditsDrawer : BaseGraphicsDrawer
    {
        List<TextDrawerBase> textDrawerBases = new List<TextDrawerBase>();

        public override string Name => "Credits";

        public CreditsDrawer(List<Creator> creators)
        {
            int size = 30;

            int x = 105;
            int y = 45;

            foreach (Creator creator in creators)
            {
                textDrawerBases.Add(
                    new TextDrawerBase(creator.Text, new PointF(x, y), creator.FontFamily, size, Color.Red, creator.FontStyle, StringAlignment.Center, StringAlignment.Center)
                );

                y += 45;
                x = 75;
                size = 21;
            }
        }

        public override bool HasAsset()
        {
            return true;
        }

        public override void DrawToGraphics(Graphics graphics, Bitmap result)
        {
            if (Visible)
            {
                foreach (TextDrawerBase text in textDrawerBases)
                {
                    text.DrawToGraphics(graphics, result);
                }
            }
        }
    }
}
