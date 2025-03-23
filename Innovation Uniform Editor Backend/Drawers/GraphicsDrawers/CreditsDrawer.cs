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
            if (creators.Count <= 0)
                return;

            int size = 30;
            int x = 105;

            AddCreator(creators[0], x, 10, size);

            if (creators.Count <= 1)
                return;

            //Default size for the remainder of the credits. (not the top one basically)
            x = 75;
            size = 21;

            int y = 75;

            for (int i = 1; i < creators.Count; i++)
            {
                AddCreator(creators[i], x, y, size);

                y += 45;
            }
        }

        private void AddCreator(Creator creator, int x, int y, int size)
        {
            textDrawerBases.Add(
                new TextDrawerBase(creator.Text, new PointF(x, y), creator.FontFamily, size, Color.Red, creator.FontStyle, StringAlignment.Center, StringAlignment.Near)
            );
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
