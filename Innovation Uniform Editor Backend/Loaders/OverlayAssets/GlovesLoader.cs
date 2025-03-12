using Innovation_Uniform_Editor_Backend.Loaders.OverlayAssets.Base;
using Innovation_Uniform_Editor_Backend.Models.OverlayAssets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Loaders.OverlayAssets
{
    public class GlovesLoader : OverlayAssetLoader<Glove>
    {
        public GlovesLoader(string path) : base(path)
        {
        }
    }
}
