using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases;
using Innovation_Uniform_Editor_Backend.Drawers.Interfaces;
using Innovation_Uniform_Editor_Backend.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy
{
    public class LogoDrawer : BaseColorDrawer
    {
        public LogoDrawer(List<CustomColor> colors, List<Bitmap> Selections) : base(colors, Selections)
        {
        }

        public override string Name => "Logo";
    }
}
