using System.Collections.Generic;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Models.Base
{
    public class BaseRecolorableAssets
    {
        /// <summary>
        /// Overlay (vest, boots, etc)
        /// </summary>
        public Bitmap Overlay { get; set; }
        public List<Bitmap> Selections { get; set; }
    }
}
