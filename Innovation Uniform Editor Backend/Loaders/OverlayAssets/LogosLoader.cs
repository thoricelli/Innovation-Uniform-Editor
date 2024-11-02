using Innovation_Uniform_Editor_Backend.Models.OverlayAssets;
using System;

namespace Innovation_Uniform_Editor_Backend.Loaders.OverlayAssets
{
    public class LogosLoader : RecolorableAssetLoader<Logo, ulong>
    {
        public LogosLoader(string path) : base(path)
        {
        }

        protected override Logo NewInstance(string id)
        {
            return new Logo() { Id = Convert.ToUInt64(id) };
        }
    }
}
