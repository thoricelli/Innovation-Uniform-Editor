using Innovation_Uniform_Editor.UI.Generic;
using Innovation_Uniform_Editor_Backend;
using Innovation_Uniform_Editor_Backend.Models.OverlayAssets;
using System;

namespace Innovation_Uniform_Editor.UI.OverlayAssets
{
    public partial class BottomSelector : GenericWithNameSelector<Bottom, Guid>
    {
        public BottomSelector() : base(EditorMain.BottomsLoader)
        {
        }
        public BottomSelector(Guid bottomId) : base(bottomId, EditorMain.BottomsLoader)
        {
        }
    }
}
