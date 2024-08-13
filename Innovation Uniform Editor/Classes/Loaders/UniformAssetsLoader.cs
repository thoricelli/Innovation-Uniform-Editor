using Innovation_Uniform_Editor.Classes.Helpers;
using Innovation_Uniform_Editor.Classes.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Innovation_Uniform_Editor.Classes.Loaders
{
    public class UniformAssetsLoader
    {
        private string path;
        private readonly string EXTENSION = ".png";
        public UniformAssetsLoader(Uniform uniform)
        {
            string basePath = "./Templates/Normal/";

            switch (uniform.part)
            {
                case Enums.ClothingPart.Pants:
                    basePath += "Pants";
                    break;
                case Enums.ClothingPart.Shirts:
                    basePath += "Shirts";
                    break;
                default:
                    break;
            }

            basePath += "/" + uniform.Id + "/";

            this.path = basePath;
        }

        private Bitmap getOverlay()
        {
            return FileToBitmap.Convert($"{path}/Original{EXTENSION}");
        }

        private Bitmap getOriginal()
        {
            return FileToBitmap.Convert($"{path}/Overlay{EXTENSION}");
        }

        private List<Bitmap> getSelectionTemplates()
        {
            List<Bitmap> selections = new List<Bitmap>()
            {
                FileToBitmap.Convert($"{path}/Selection_Template{EXTENSION}")
            };

            string selectionTwo = $"{path}/Selection_Template_Secondary{EXTENSION}";
            if (File.Exists(selectionTwo))
                selections.Add(FileToBitmap.Convert(selectionTwo));

            List<string> otherSelections = Directory.GetFiles(path, "Selection_Template_*.png", SearchOption.TopDirectoryOnly).ToList();

            otherSelections.RemoveAll(e => e.Contains("Selection_Template_Secondary"));

            foreach (string path in otherSelections)
            {
                selections.Add(FileToBitmap.Convert(path));
            }

            return selections;
        }
        private List<Bitmap> getTextures()
        {
            List<Bitmap> textures = new List<Bitmap>();

            return textures;
        }
        #region ASSETS
        private Bitmap _original;
        private Bitmap _overlay;
        private List<Bitmap> _selections;
        private List<Bitmap> _textures;

        /// <summary>
        /// Original uniform used as preview.
        /// </summary>
        public Bitmap Original { 
            get {
                if (_original == null)
                    _original = getOriginal();
                return _original;
            } 
        }
        /// <summary>
        /// Overlay (vest, boots, etc)
        /// </summary>
        public Bitmap Overlay
        {
            get
            {
                if (_overlay == null)
                    _overlay = getOverlay();
                return _overlay;
            }
        }
        /// <summary>
        /// A list of selection templates for coloring.
        /// </summary>
        public List<Bitmap> Selections {
            get
            {
                if (_selections == null)
                    _selections = getSelectionTemplates();
                return _selections;
            }
        }
        /// <summary>
        /// Textures used on the uniform (no shading)
        /// </summary>
        public List<Bitmap> Textures {
            get
            {
                if (_textures == null)
                    _textures = getTextures();
                return _textures;
            }
        }
        #endregion
    }
}
