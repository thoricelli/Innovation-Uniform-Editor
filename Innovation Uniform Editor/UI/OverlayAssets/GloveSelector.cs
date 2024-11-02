using Innovation_Uniform_Editor.UI.Generic;
using Innovation_Uniform_Editor_Backend;
using Innovation_Uniform_Editor_Backend.Models.OverlayAssets;
using System;

namespace Innovation_Uniform_Editor.UI.OverlayAssets
{
    public partial class GloveSelector : GenericWithNameSelector<Glove, Guid>
    {
        public GloveSelector() : base(EditorMain.GlovesLoader)
        {
        }
        public GloveSelector(Guid gloveId) : base(gloveId, EditorMain.GlovesLoader)
        {
        }
    }
}
