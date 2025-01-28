using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases;
using Innovation_Uniform_Editor_Backend.Models;
using System.Collections.Generic;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    public class ColorDrawer : BaseColorDrawer
    {
        public ColorDrawer(List<CustomColor> colors, List<Bitmap> Selections, ShadingDrawer shading) : base(colors, Selections, shading)
        {
        }

        public ColorDrawer(List<CustomColor> colors, List<Bitmap> Selections, Point location, ShadingDrawer shading) : base(colors, Selections, location, shading)
        {
        }

        public override string Name => "Colors";
    }
}
