using Innovation_Uniform_Editor.UI.Generic;
using Innovation_Uniform_Editor_Backend;
using Innovation_Uniform_Editor_Backend.Models.OverlayAssets;
using System;

namespace Innovation_Uniform_Editor.UI.OverlayAssets
{
    public partial class HolsterSelector : GenericWithNameSelector<Holster, Guid>
    {
        public HolsterSelector() : base(EditorMain.HolstersLoader)
        {
        }
        public HolsterSelector(Guid holsterId) : base(holsterId, EditorMain.HolstersLoader)
        {
        }
    }
}
