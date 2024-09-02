using Innovation_Uniform_Editor_Backend.Enums;
using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using System;
using System.ComponentModel;

namespace Innovation_Uniform_Editor_Backend.Models
{
    public class Uniform : IIdentifier<ulong>
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }
        public ClothingPart part { get; set; }
        [DefaultValue(true)]
        public bool Shading { get; set; } = true;
    }
}
