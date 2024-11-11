using Innovation_Uniform_Editor_Backend.Globals;
using Innovation_Uniform_Editor_Backend.Models.Base;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Models.OverlayAssets
{
    public class Logo : ItemRecolorableBase<ulong>
    {
        public override string Path => EditorPaths.LogosPath;
    }
}
