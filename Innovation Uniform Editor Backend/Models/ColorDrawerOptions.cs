using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers;
using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.ComponentDrawers.Bases;
using System.Collections.Generic;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Models
{
    public class ColorDrawerOptions
    {
        public List<CustomColor> Colors { get; set; }
        public List<Bitmap> Selections { get; set; }
        public List<MaskImage> Masks { get; set; }
        public ShadingDrawer ShadingDrawer { get; set; }
        public List<ComponentDrawerBase> ColorDrawerItems { get; set; }

        //Optional
        public List<Bitmap> Texture { get; set; } = null;
        public Point Location { get; set; } = Point.Empty;
        public float Transparency { get; set; } = 1f;
    }
}
