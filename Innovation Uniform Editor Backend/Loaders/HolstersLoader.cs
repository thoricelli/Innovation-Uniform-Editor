using Innovation_Uniform_Editor_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Loaders
{
    public class HolstersLoader : OverlayAssetLoader<Holster>
    {
        public HolstersLoader(string path) : base(path)
        {
        }
    }
}
