using Innovation_Uniform_Editor_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Loaders
{
    public class LogosLoader : RecolorableAssetLoader<Logo, ulong>
    {
        public LogosLoader(string path) : base(path)
        {
        }
    }
}
