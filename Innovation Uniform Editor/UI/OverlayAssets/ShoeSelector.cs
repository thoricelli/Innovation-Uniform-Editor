using Innovation_Uniform_Editor.UI.Generic;
using Innovation_Uniform_Editor_Backend;
using Innovation_Uniform_Editor_Backend.Models.OverlayAssets;
using System;

namespace Innovation_Uniform_Editor.UI.OverlayAssets
{
    public partial class ShoeSelector : GenericWithNameSelector<Shoe, Guid>
    {
        public ShoeSelector() : base(EditorMain.ShoesLoader)
        {
        }
        public ShoeSelector(Guid shoeId) : base(shoeId, EditorMain.ShoesLoader)
        {
        }
    }
}
