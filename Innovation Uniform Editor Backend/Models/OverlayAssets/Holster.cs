using Innovation_Uniform_Editor_Backend.Globals;
using Innovation_Uniform_Editor_Backend.Models.Base;
using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Models.OverlayAssets
{
    public class Holster : ItemRecolorableBase<Guid>, IRecolorable
    {
        [JsonIgnore]
        public override string Path => EditorPaths.HolstersPath;

        [JsonIgnore]
        public List<Bitmap> Selections { get; set; }
    }
}
