using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Models.Interfaces
{
    public interface IRecolorableAssets
    {
        /// <summary>
        /// Overlay (vest, boots, etc)
        /// </summary>
        Bitmap Overlay { get; set; }
        List<Bitmap> Selections { get; set; }
    }
}
