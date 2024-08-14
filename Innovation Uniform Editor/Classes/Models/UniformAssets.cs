using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor.Classes.Models
{
    public class UniformAssets
    {
        public UniformAssets(Bitmap original, Bitmap overlay, List<Bitmap> selections, List<Bitmap> textures)
        {
            Original = original;
            Overlay = overlay;
            Selections = selections;
            Textures = textures;
        }
        public void ChangeBackground(Bitmap background)
        {

        }
        /// <summary>
        /// Original uniform used as preview.
        /// </summary>
        public Bitmap Original { get; set; }
        /// <summary>
        /// Overlay (vest, boots, etc)
        /// </summary>
        public Bitmap Overlay { get; set; }
        /// <summary>
        /// A list of selection templates for coloring.
        /// </summary>
        public List<Bitmap> Selections { get; set; }
        /// <summary>
        /// Textures used on the uniform (no shading)
        /// </summary>
        public List<Bitmap> Textures { get; set; }
        public Bitmap Background { get; set; }
    }
}
