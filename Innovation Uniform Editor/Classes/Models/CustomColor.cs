using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor.Classes
{
    public class CustomColor
    {
        public List<Color> Colors { get; set; } = new List<Color>();
        /// <summary>
        /// How many times to repeat the fade.
        /// </summary>
        public int Repeat { get; set; } = 2;

        //Where to start repeating the fade.
        //public float RepeatPosition { get; set; } = 0.5F;
    }
}
