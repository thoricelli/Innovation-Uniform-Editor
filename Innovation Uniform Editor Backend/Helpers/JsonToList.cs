using Innovation_Uniform_Editor_Backend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Helpers
{
    public static class JsonToList
    {
        public static List<T> LoadList<T>(string path)
        {
            List<T> list = new List<T>();

            if (File.Exists(path))
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();

                    using (var stringReader = new StringReader(json))
                    using (var jsonReader = new JsonTextReader(stringReader))
                    {
                        while (jsonReader.Read())
                        {
                            var serializer = new JsonSerializer();

                            list = serializer.Deserialize<List<T>>(jsonReader);
                        }
                    }
                }
            }

            return list;
        }
    }
}
