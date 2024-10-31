using Innovation_Uniform_Editor_Backend.Globals;
using Innovation_Uniform_Editor_Backend.Models.Base;
using System;

namespace Innovation_Uniform_Editor_Backend.Models.OverlayAssets
{
    public class Armband : ItemBase<Guid>
    {
        public override string Path => EditorPaths.ArmbandsPath;
    }
}
