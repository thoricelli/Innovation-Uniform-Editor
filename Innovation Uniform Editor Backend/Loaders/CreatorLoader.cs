using Innovation_Uniform_Editor_Backend.Helpers;
using Innovation_Uniform_Editor_Backend.Loaders.Base;
using Innovation_Uniform_Editor_Backend.Models;
using Innovation_Uniform_Editor_Backend.Models.Base;
using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using System;

namespace Innovation_Uniform_Editor_Backend.Loaders
{
    public class CreatorLoader : Loader<Creator, int>
    {
        public CreatorLoader(string path) : base(path)
        {
        }
        public override void Load()
        {
            base.Load();

            Set(JsonToList.LoadList<Creator>(_path + "/Creators.json"));
        }
    }
}
