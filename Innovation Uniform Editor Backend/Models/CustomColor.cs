using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor_Backend.Models
{
    public class CustomColor
    {
        public Color GetColorAtIndex(int colorIndex)
        {
            CheckForEmpty();

            return Colors[colorIndex];
        }
        public void ChangeFirstColor(Color color)
        {
            CheckForEmpty();

            ChangeColorAtIndex(0, color);
        }

        public void ChangeColorAtIndex(int colorIndex, Color color)
        {
            CheckForEmpty();

            //Swagiform :)
            if (color == Color.FromArgb(255, 255, 174, 201))
            {
                MessageBox.Show("You are NOT making the swagiform.");
                return;
            }
            Colors[colorIndex] = color;
        }

        public int GetColorCount()
        {
            CheckForEmpty();

            return Colors.Count;
        }

        //This bug has me pulling my hairs!!
        private void CheckForEmpty()
        {
            if (Colors == null || Colors.Count <= 0)
                Colors = new List<Color>() { Color.Transparent };
        }
        public List<Color> Colors { get; set; }
        /// <summary>
        /// How many times to repeat the fade.
        /// </summary>
        public int Repeat { get; set; } = 2;

        //Where to start repeating the fade.
        //public float RepeatPosition { get; set; } = 0.5F;
    }
}
