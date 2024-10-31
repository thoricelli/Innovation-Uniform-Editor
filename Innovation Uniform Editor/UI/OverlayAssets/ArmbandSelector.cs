using Innovation_Uniform_Editor.UI.Generic;
using Innovation_Uniform_Editor_Backend;
using Innovation_Uniform_Editor_Backend.Models.OverlayAssets;
using System;

namespace Innovation_Uniform_Editor.UI.OverlayAssets
{
    public partial class ArmbandSelector : GenericWithNameSelector<Armband, Guid>
    {
        public ArmbandSelector() : base(EditorMain.ArmbandsLoader)
        {
        }
        public ArmbandSelector(Guid armbandId) : base(armbandId, EditorMain.ArmbandsLoader)
        {
        }
    }
}
