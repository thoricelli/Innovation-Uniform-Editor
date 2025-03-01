using Innovation_Uniform_Editor_Backend.Loaders.Base;
using Innovation_Uniform_Editor_Backend.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor_Backend.Loaders
{
    public class CustomsLoader : Loader<Custom, Guid>
    {
        public CustomsLoader(string path) : base(path)
        {
        }

        public override void Load()
        {
            base.Load();
            //Customs -> UUID -> info.json is the custom.
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);
            string[] customs = Directory.GetDirectories(_path, "*", SearchOption.TopDirectoryOnly);

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
                                Add(serializer.Deserialize<Custom>(jsonReader));
                            }
                        }
                    }
                }
            }

            //Unused
            /*if (File.Exists(_path + "groups.json"))
            {
                using (StreamReader r = new StreamReader(_path + "groups.json"))
                {
                    string json = r.ReadToEnd();

                    using (var stringReader = new StringReader(json))
                    using (var jsonReader = new JsonTextReader(stringReader))
                    {
                        while (jsonReader.Read())
                        {
                            var serializer = new JsonSerializer();
                            this.Add(serializer.Deserialize<Group>(jsonReader));

                            //Delete all customs that are already in the array from the group
                        }
                    }
                }
            }*/

            Sort();
        }
        public static Custom LoadFromFile(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();

                using (var stringReader = new StringReader(json))
                using (var jsonReader = new JsonTextReader(stringReader))
                {
                    jsonReader.Read();
                    var serializer = new JsonSerializer();

                    //Get versioning without extra data, otherwise we might get an error parsing.
                    CustomVersioning customVersioning = serializer.Deserialize<CustomVersioning>(jsonReader);

                    if (AskForOutdatedLoad(customVersioning.MinimumVersion))
                    {
                        using (var stringReader2 = new StringReader(json))
                        using (var jsonReader2 = new JsonTextReader(stringReader2))
                        {
                            jsonReader2.Read();

                            //Get versioning without extra data, otherwise we might get an error parsing.
                            return serializer.Deserialize<Custom>(jsonReader2);
                        }
                    }
                    
                    return null;
                }
            }
        }
        private static bool AskForOutdatedLoad(Version version)
        {
            if (version.CompareTo(EditorMain.Version) <= -1)
            {
                DialogResult result = MessageBox.Show($"This custom was made with an older version ({version}).\nAre you sure you want to load this file?", "Outdated custom", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                return result == DialogResult.Yes;
            }
            return true;
        }
        public override void DeleteBy(Guid id)
        {
            Directory.Delete($"{_path}/{id}", true);

            base.DeleteBy(id);
        }

        public override Custom FindBy(Guid id)
        {
            Custom custom = base.FindBy(id);

            if (custom != null)
                custom.Clear();

            return custom;
        }
    }
}
