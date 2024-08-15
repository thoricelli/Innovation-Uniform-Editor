using Innovation_Uniform_Editor.Classes.Helpers;
using Innovation_Uniform_Editor.Classes.Models;
using Innovation_Uniform_Editor.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Innovation_Uniform_Editor.Classes.Loaders
{
    public static class UniformAssetsLoader
    {
        private static readonly string EXTENSION = ".png";
        private static string pathBuilder(ClothingPart part, ulong id)
        {
            string basePath = "./Templates/Normal/";

            switch (part)
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

            basePath += "/" + id + "/";

            return basePath;
        }
        private static Bitmap getOverlay(string path)
        {
            return FileToBitmap.Convert($"{path}/Overlay{EXTENSION}");
        }

        private static Bitmap getOriginal(string path)
        {
            return FileToBitmap.Convert($"{path}/Original{EXTENSION}");
        }

        private static List<bool[]> getSelectionTemplates(string path)
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

            return ImageHelper.BitmapToBoolean(selections);
        }
        private static List<Bitmap> getTextures(string path)
        {
            List<Bitmap> textures = new List<Bitmap>();

            return textures;
        }
        public static UniformAssets GetAssetsForUniform(Uniform uniform)
        {
            string basePath = pathBuilder(uniform.part, uniform.Id);

            return new UniformAssets()
            {
                Original = getOriginal(basePath),
                Overlay = getOverlay(basePath),
                Selections = getSelectionTemplates(basePath),
                Textures = getTextures(basePath)
            };
        }
    }
}
