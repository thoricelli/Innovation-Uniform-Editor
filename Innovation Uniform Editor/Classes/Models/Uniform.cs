using Innovation_Uniform_Editor.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor.Classes.Models
{
    public class Uniform : IIdentifier<UInt64>
    {
        public UInt64 Id { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }
        public ClothingPart part { get; set; }
        [DefaultValue(true)]
        public bool Shading { get; set; } = true;
    }
}
