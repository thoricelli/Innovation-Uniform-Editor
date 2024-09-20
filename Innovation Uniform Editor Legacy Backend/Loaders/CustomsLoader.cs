using Innovation_Uniform_Editor_Backend.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Innovation_Uniform_Editor_Backend.Loaders
{
    public class CustomsLoader : Loader<Custom, Guid>
    {
        public CustomsLoader(string path) : base(path)
        {
        }

        protected override void Load()
        {
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

        public override Custom FindBy(Guid id)
        {
            Custom custom = base.FindBy(id);

            if (custom != null)
                custom.Clear();

            return custom;
        }
    }
}
