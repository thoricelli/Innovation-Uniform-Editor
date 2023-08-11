using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor.Classes
{
    public static class JSONtoUniform
    {
        //This is terrible, please make this private and add functions!
        public static List<Uniform> Pants { get; set; }
        public static List<Uniform> Shirts { get; set; }
        public static List<BackgroundImage> Backgrounds { get; set; } = new List<BackgroundImage>();
        public static List<MenuItem> MenuItems = new List<MenuItem>();
        public static Bitmap backgroundMask;
        public static Bitmap waterMark;
        //This should be done when the class is loaded, not outside of it!
        public static void LoadMenuItems(string path)
        {
            //Customs -> UUID -> info.json is the custom.
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string[] customs = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);

            //Loading customs.
            foreach (string dir in customs)
            {
                Guid guid = new Guid(Path.GetFileName(dir));

                if (File.Exists(dir + "/info.json"))
                {
                    using (StreamReader r = new StreamReader(dir + "/info.json"))
                    {
                        string json = r.ReadToEnd();

                        using (var stringReader = new StringReader(json))
                        using (var jsonReader = new JsonTextReader(stringReader))
                        {
                            while (jsonReader.Read())
                            {
                                var serializer = new JsonSerializer();
                                MenuItems.Add(serializer.Deserialize<Custom>(jsonReader));
                            }
                        }
                    }
                }
            }

            if (File.Exists(path + "groups.json"))
            {
                using (StreamReader r = new StreamReader(path + "groups.json"))
                {
                    string json = r.ReadToEnd();

                    using (var stringReader = new StringReader(json))
                    using (var jsonReader = new JsonTextReader(stringReader))
                    {
                        while (jsonReader.Read())
                        {
                            var serializer = new JsonSerializer();
                            MenuItems.Add(serializer.Deserialize<Group>(jsonReader));

                            //Delete all customs that are already in the array from the group
                        }
                    }
                }
            }

            MenuItems.Sort();
        }
        public static void LoadUniforms(string path)
        {
            if (!File.Exists("./Templates/Misc/Background_Mask.png"))
            {
                FixTemplates();
                return;
            }
            if (!File.Exists("./Templates/Misc/Watermark.png"))
            {
                FixTemplates();
                return;
            }
            if (!File.Exists("./Templates/TemplateInfo.json"))
            {
                FixTemplates();
                return;
            }

            backgroundMask = new Bitmap(Image.FromFile("./Templates/Misc/Background_Mask.png"));
            waterMark = new Bitmap(Image.FromFile("./Templates/Misc/Watermark.png"));
            using (StreamReader r = new StreamReader(path))
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
                            Pants = serializer.Deserialize<List<Uniform>>(jsonReader);

                        } else if (jsonReader.TokenType == JsonToken.PropertyName
                            && (string)jsonReader.Path == "Shirts")
                        {
                            jsonReader.Read();

                            var serializer = new JsonSerializer();
                            Shirts = serializer.Deserialize<List<Uniform>>(jsonReader);
                        }
                    }

                    foreach (Uniform pants in Pants)
                    {
                        pants.part = Enums.ClothingPart.Pants;
                    }

                    foreach (Uniform shirt in Shirts)
                    {
                        shirt.part = Enums.ClothingPart.Shirts;
                    }
                }
            }
        }
        private static void FixTemplates()
        {
            TemplateUpdater.CheckForUpdates(true);
        }
        public static void LoadBackgrounds(string path)
        {
            string[] directories = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly);
            foreach (string image in directories)
            {
                BackgroundImage bg = new BackgroundImage(image.Replace(path,"").Replace(".png",""));
                Backgrounds.Add(bg);
            }
        }
        public static Uniform FindFromId(ulong id)
        {
            foreach (Uniform pants in Pants)
            {
                if (pants.Id == id)
                    return pants;
            }
            foreach (Uniform shirt in Shirts)
            {
                if (shirt.Id == id)
                    return shirt;
            }

            return null;
        }
        public static void AddCustom(Custom custom)
        {
            MenuItems.Add(custom);
        }
        public static void DeleteBackgroundFromGuid(Guid guid)
        {
            string path = "./Backgrounds/" + guid;
            if (File.Exists(path))
                File.Delete(path);
            Backgrounds.Remove(FindBackgroundFromGuid(guid));
        }
        public static void DeleteCustomFromGuid(Guid guid)
        {
            string path = "./Customs/" + guid;
            if (Directory.Exists(path))
                Directory.Delete(path, true);
            MenuItems.Remove(MenuItemFromGuid(guid));
        }
        public static MenuItem MenuItemFromGuid(Guid guid)
        {
            MenuItem menu = MenuItems.Find(element =>
            {
                return element.Guid == guid;
            });

            if (menu is Group)
                menu = ((Group)menu).FindInGroupFromGuid(guid);
            return menu;
        }
        public static BackgroundImage FindBackgroundFromGuid(Guid guid)
        {
            return Backgrounds.Find(element =>
            {
                return element.backgroundGUID == guid;
            });
        }
        public static Custom FindCustomFromGuid(Guid guid)
        {
            return MenuItems.Find(element =>
            {
                return element.Guid == guid;
            }) as Custom;
        }
        /// <summary>
        /// Moves menuItem to the left.
        /// </summary>
        /// <param name="menuItem"></param>
        /// <returns>Index of item</returns>
        /*public static int MoveToLeft(MenuItem menuItem)
        {

            MenuItems.Sort();
        }
        /// <summary>
        /// Moves menuItem to the right.
        /// </summary>
        /// <param name="menuItem"></param>
        /// <returns>Index of item</returns>
        public static int MoveToRight(MenuItem menuItem)
        {

            MenuItems.Sort();
        }*/
        public static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
        {
            Bitmap b = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, size.Width, size.Height);
            g.Dispose();
            return (System.Drawing.Image)b;
        }
    }
}
