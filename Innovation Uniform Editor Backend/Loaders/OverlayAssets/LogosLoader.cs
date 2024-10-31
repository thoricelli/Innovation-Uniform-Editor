using Innovation_Uniform_Editor_Backend.Models.OverlayAssets;

namespace Innovation_Uniform_Editor_Backend.Loaders.OverlayAssets
{
    public class LogosLoader : RecolorableAssetLoader<Logo, ulong>
    {
        public LogosLoader(string path) : base(path)
        {
        }
    }
}
