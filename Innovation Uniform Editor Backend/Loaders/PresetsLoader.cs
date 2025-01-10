using Innovation_Uniform_Editor_Backend.Helpers;
using Innovation_Uniform_Editor_Backend.Loaders.Base;
using Innovation_Uniform_Editor_Backend.Models;
using System;

namespace Innovation_Uniform_Editor_Backend.Loaders
{
    public class PresetsLoader : Loader<Preset, Guid>
    {
        public PresetsLoader(string path) : base(path)
        {
        }
        public override void Load()
        {
            base.Load();

            Set(JsonToList.LoadList<Preset>(_path + "/Presets.json"));
        }
    }
}
