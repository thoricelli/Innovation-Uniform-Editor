using System.Collections.Generic;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Models.Interfaces
{
    internal interface IRecolorable
    {
        /// <summary>
        /// A list of selection templates for coloring.
        /// </summary>
        List<Bitmap> Selections { get; set; }
    }
}
