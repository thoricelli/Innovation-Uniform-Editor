using Innovation_Uniform_Editor.Classes.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor.Classes.Loaders
{
    public class UniformsLoader : Loader<Uniform, UInt64>
    {
        //Both public temporarily
        //Please unpublicize this!!!!
        public Image backgroundMask;
        public Image waterMark;

        public UniformsLoader(string path) : base(path)
        {
        }
        protected override void Load()
        {
            if (!File.Exists("./Templates/Misc/Background_Mask.png"))
            {
                JSONtoUniform.FixTemplates();
                return;
            }
            if (!File.Exists("./Templates/Misc/Watermark.png"))
            {
                JSONtoUniform.FixTemplates();
                return;
            }
            if (!File.Exists("./Templates/TemplateInfo.json"))
            {
                JSONtoUniform.FixTemplates();
                return;
            }

            FileStream fs = File.Open("./Templates/Misc/Background_Mask.png", FileMode.Open, FileAccess.Read);
            Image mask = Image.FromStream(fs);
            backgroundMask = new Bitmap(mask);
            fs.Close();

            fs = File.Open("./Templates/Misc/Watermark.png", FileMode.Open, FileAccess.Read);
            Image watermark = Image.FromStream(fs);
            waterMark = new Bitmap(watermark);
            fs.Close();

            using (StreamReader r = new StreamReader(_path))
            {
                string json = r.ReadToEnd();

                using (var stringReader = new StringReader(json))
                using (var jsonReader = new JsonTextReader(stringReader))
                {
                    while (jsonReader.Read())
                    {
                        if (jsonReader.TokenType == JsonToken.PropertyName
                            && (string)jsonReader.Path == "Pants")
                        {
                            jsonReader.Read();

                            var serializer = new JsonSerializer();
                            List<Uniform> Pants = serializer.Deserialize<List<Uniform>>(jsonReader);
                            
                            Pants.ForEach(e => e.part = Enums.ClothingPart.Pants);
                            
                            this.Concat(Pants);
                        }
                        else if (jsonReader.TokenType == JsonToken.PropertyName
                            && (string)jsonReader.Path == "Shirts")
                        {
                            jsonReader.Read();

                            var serializer = new JsonSerializer();
                            List<Uniform> Shirts = serializer.Deserialize<List<Uniform>>(jsonReader);
                            
                            Shirts.ForEach(e => e.part = Enums.ClothingPart.Shirts);
                            
                            this.Concat(Shirts);
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
            return this.GetAll().FindAll(e => e.part == Enums.ClothingPart.Pants).ToList();
        }
        public List<Uniform> GetShirts()
        {
            return this.GetAll().FindAll(e => e.part == Enums.ClothingPart.Shirts).ToList();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
