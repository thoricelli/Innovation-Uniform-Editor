using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Innovation_Uniform_Editor_Backend.Helpers
{
    public static class JsonUtils
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
        public static T Load<T>(string json)
        {
            using (var stringReader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(stringReader))
            {
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<T>(jsonReader);
                } 
            }
        }
        public static void SaveToFile<T>(T item, string path)
        {
            JsonSerializer serializer = new JsonSerializer()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, item);
            }
        }
    }
}
