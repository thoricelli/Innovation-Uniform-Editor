using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.ComponentDrawers.Bases;
using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases;
using Innovation_Uniform_Editor_Backend.Models;
using System.Collections.Generic;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    public class ColorDrawer : BaseColorDrawer
    {
        public ColorDrawer(List<CustomColor> colors, List<Bitmap> Selections, List<ComponentDrawerBase> Drawers, ShadingDrawer shading) : base(colors, Selections, Drawers, shading)
        {
        }

        public ColorDrawer(List<CustomColor> colors, List<Bitmap> Selections, List<ComponentDrawerBase> Drawers, Point location, ShadingDrawer shading) : base(colors, Selections, Drawers, location, shading)
        {
        }

        public ColorDrawer(List<CustomColor> colors, List<Bitmap> Selections, List<ComponentDrawerBase> Drawers, Point location, ShadingDrawer shading, float transparency) : base(colors, Selections, Drawers, location, shading, transparency)
        {
        }

        public override string Name => "Colors";
    }
}
