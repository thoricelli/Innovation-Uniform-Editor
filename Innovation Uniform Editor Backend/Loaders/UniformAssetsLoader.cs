using Innovation_Uniform_Editor_Backend.Enums;
using Innovation_Uniform_Editor_Backend.Globals;
using Innovation_Uniform_Editor_Backend.Helpers;
using Innovation_Uniform_Editor_Backend.Models;
using Innovation_Uniform_Editor_Backend.Models.Assets;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Innovation_Uniform_Editor_Backend.Loaders
{
    public static class UniformAssetsLoader
    {
        private static readonly string EXTENSION = ".png";
        private static string pathBuilder(ClothingPart part, ulong id)
        {
            string basePath = $"{EditorPaths.TemplatePath}/Normal/";

            switch (part)
            {
                case ClothingPart.Pants:
                    basePath += "Pants";
                    break;
                case ClothingPart.Shirts:
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

        private static List<Bitmap> getSelectionTemplates(string path)
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
        private static List<Bitmap> getListFromPath(string path, string query)
        {
            List<Bitmap> images = new List<Bitmap>();

            List<string> paths = Directory.GetFiles(path, query, SearchOption.TopDirectoryOnly).ToList();

            foreach (string imagePath in paths)
            {
                images.Add(FileToBitmap.Convert(imagePath));
            }

            return images;
        }
        public static UniformAssets GetAssetsForUniform(Uniform uniform)
        {
            string basePath = pathBuilder(uniform.part, uniform.Id);

            return new UniformAssets()
            {
                Original = getOriginal(basePath),
                Overlay = getOverlay(basePath),
                Selections = getSelectionTemplates(basePath),
                Textures = getListFromPath(basePath, "texture*.png"),
                Top = getListFromPath(basePath, "top*.png"),
            };
        }
    }
}
