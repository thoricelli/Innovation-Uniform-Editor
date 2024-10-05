using Innovation_Uniform_Editor_Backend.Models;
using Innovation_Uniform_Editor_Backend.Models.Base;
using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Loaders
{
    public abstract class OverlayAssetLoader<TType> : Loader<TType, Guid> where TType : ItemBase, IIdentifier<Guid>
    {
        private const string InfoName = "Info.json";
        protected OverlayAssetLoader(string path) : base(path)
        {
        }
        public override void Load()
        {
            base.Load();

            using (StreamReader r = new StreamReader($"{_path}/{InfoName}"))
            {
                string json = r.ReadToEnd();

                using (var stringReader = new StringReader(json))
                using (var jsonReader = new JsonTextReader(stringReader))
                {
                    while (jsonReader.Read())
                    {
                        var serializer = new JsonSerializer();
                        
                        Set(serializer.Deserialize<List<TType>>(jsonReader));
                    }
                }
            }
        }
    }
}
