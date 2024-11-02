using Innovation_Uniform_Editor_Backend.Helpers;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Innovation_Uniform_Editor_Backend.Models.Base
{
    public abstract class ItemRecolorableBase<T> : ItemBase<T>
    {
        public override Image Image
        {
            get
            {
                if (_image == null)
                    _image = FileToBitmap.Convert($"{Path}/{Id}/Overlay.png");
                return _image;
            }
        }
        public List<Bitmap> Selections
        {
            get
            {
                if (_selections == null)
                    _selections = getSelectionTemplates($"{Path}/{Id}");
                return _selections;
            }
        }
        private readonly string EXTENSION = ".png";
        private List<Bitmap> getSelectionTemplates(string path)
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

            foreach (string otherPath in otherSelections)
            {
                selections.Add(FileToBitmap.Convert(otherPath));
            }

            return selections;
        }

        private List<Bitmap> _selections;
    }
}
