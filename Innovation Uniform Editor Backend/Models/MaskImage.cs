using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Models
{
    public class MaskImage
    {
        public MaskImage(int width, int height, bool[] mask)
        {
            Height = height;
            Width = width;
            this.mask = mask;
        }

        public int Height { get; set; }
        public int Width { get; set; }
        public bool[] mask { get; set; }
    }
}
