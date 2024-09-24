using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Drawers.ComponentDrawers.Interfaces
{
    public interface IComponentInterface
    {
        /// <summary>
        /// Draw at the index of an image.
        /// </summary>
        /// <param name="current">The current color of the pixel.</param>
        /// <param name="index">The current index of the pixel.</param>
        /// <returns>The modified pixel color.</returns>
        Color Draw(Color current, int index);
    }
}
