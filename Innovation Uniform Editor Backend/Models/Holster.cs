using Innovation_Uniform_Editor_Backend.Globals;
using Innovation_Uniform_Editor_Backend.Models.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Models
{
    public class Holster : ItemBase
    {
        [JsonIgnore]
        public List<Image> SelectionTemplates { get; set; }

        public override string Path => EditorPaths.HolstersPath;
    }
}
