using Innovation_Uniform_Editor_Backend.Drawers.ComponentDrawers.Bases;
using Innovation_Uniform_Editor_Backend.Enums;
using Innovation_Uniform_Editor_Backend.Globals;
using Innovation_Uniform_Editor_Backend.Helpers;
using Innovation_Uniform_Editor_Backend.ImageEditors;
using Innovation_Uniform_Editor_Backend.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Innovation_Uniform_Editor_Backend.Loaders
{
    public class UniformsLoader : Loader<Uniform, ulong>
    {
        //Both public temporarily
        //Please unpublicize this!!!!
        public Bitmap backgroundMask;
        public Bitmap waterMark;
        public Bitmap shading;
        public UniformsLoader(string path) : base(path)
        {
        }
        protected override void Load()
        {
            if (!File.Exists($"{EditorPaths.TemplateMiscPath}/Background_Mask.png"))
            {
                TemplateUpdater.CheckForUpdates(true);
                return;
            }
            if (!File.Exists($"{EditorPaths.TemplateMiscPath}/Watermark.png"))
            {
                TemplateUpdater.CheckForUpdates(true);
                return;
            }
            if (!File.Exists($"{EditorPaths.TemplatePath}/TemplateInfo.json"))
            {
                TemplateUpdater.CheckForUpdates(true);
                return;
            }

            backgroundMask = FileToBitmap.Convert($"{EditorPaths.TemplateMiscPath}/Background_Mask.png");

            waterMark = FileToBitmap.Convert($"{EditorPaths.TemplateMiscPath}/Watermark.png");

            shading = FileToBitmap.Convert($"{EditorPaths.TemplateMiscPath}/Shading_Template.png");
            BitmapEditor shadingLooper = new BitmapEditor(shading);

            ComponentDrawerBase.shading = shadingLooper;
            shadingLooper.CloseImage();

            using (StreamReader r = new StreamReader(_path))
            {
                string json = r.ReadToEnd();

                using (var stringReader = new StringReader(json))
                using (var jsonReader = new JsonTextReader(stringReader))
                {
                    while (jsonReader.Read())
                    {
                        if (jsonReader.TokenType == JsonToken.PropertyName
                            && jsonReader.Path == "Pants")
                        {
                            jsonReader.Read();

                            var serializer = new JsonSerializer();
                            List<Uniform> Pants = serializer.Deserialize<List<Uniform>>(jsonReader);

                            Pants.ForEach(e => e.part = ClothingPart.Pants);

                            Concat(Pants);
                        }
                        else if (jsonReader.TokenType == JsonToken.PropertyName
                            && jsonReader.Path == "Shirts")
                        {
                            jsonReader.Read();

                            var serializer = new JsonSerializer();
                            List<Uniform> Shirts = serializer.Deserialize<List<Uniform>>(jsonReader);

                            Shirts.ForEach(e => e.part = ClothingPart.Shirts);

                            Concat(Shirts);
                        }
                    }
                }
            }
        }
        /*
         Pants and shirts, 
         and pants, and shirts, 
         and pants and ...
        */
        public List<Uniform> GetPants()
        {
            return GetAll().FindAll(e => e.part == ClothingPart.Pants).ToList();
        }
        public List<Uniform> GetShirts()
        {
            return GetAll().FindAll(e => e.part == ClothingPart.Shirts).ToList();
        }
    }
}
