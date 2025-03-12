using Innovation_Uniform_Editor_Backend.Globals;
using Innovation_Uniform_Editor_Backend.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Models.OverlayAssets
{
    public class Shoe : ItemBase<Guid>
    {
        public override string Path => EditorPaths.ShoesPath;
    }
}
