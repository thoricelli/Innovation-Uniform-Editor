using System.Collections.Generic;
using System.Drawing;

namespace Innovation_Uniform_Editor.Classes.Models
{
    public class UniformAssets
    {
        public void ChangeBackground(Bitmap background)
        {
            Background = background;
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
        public List<bool[]> Selections { get; set; }
        /// <summary>
        /// Textures used on the uniform (no shading)
        /// </summary>
        public List<Bitmap> Textures { get; set; }
        /// <summary>
        /// Extra images that are drawn on top.
        /// This can include logo's, lines, drawings, text, etc.
        /// </summary>
        public List<Bitmap> Top { get; set; }
        public Bitmap Background { get; set; }
    }
}
