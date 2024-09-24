using Innovation_Uniform_Editor_Backend.Drawers.ComponentDrawers.Bases;
using Innovation_Uniform_Editor_Backend.Drawers.Interfaces;
using Innovation_Uniform_Editor_Backend.ImageEditors.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Drawers.ComponentDrawers
{
    /// <summary>
    /// Draws a solid color to a buffer.
    /// </summary>
    public class ColorComponentDrawer : ComponentDrawerBase
    {
        public ColorComponentDrawer(IImageEditor imageEditor) : base(imageEditor)
        {
        }

        public override Color Draw(Color current, int index)
        {
            throw new NotImplementedException();
        }
    }
}
