using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor.Classes
{
    public class CustomColor
    {
        public Color GetColorAtIndex(int colorIndex)
        {
            return Colors[colorIndex];
        }
        public void ChangeFirstColor(Color color)
        {
            ChangeColorAtIndex(0, color);
        }

        public void ChangeColorAtIndex(int colorIndex, Color color)
        {
            //Swagiform :)
            if (color == Color.FromArgb(255, 255, 174, 201))
            {
                MessageBox.Show("You are NOT making the swagiform.");
                return;
            }
            Colors[colorIndex] = color;
        }
        private List<Color> _colors;
        public List<Color> Colors { 
            get {
                if (_colors == null)
                    _colors = new List<Color>() { Color.Transparent };
                return _colors;
            }
        }
        /// <summary>
        /// How many times to repeat the fade.
        /// </summary>
        public int Repeat { get; set; } = 2;

        //Where to start repeating the fade.
        //public float RepeatPosition { get; set; } = 0.5F;
    }
}
