using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Models
{
    public class Preset : IIdentifier<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CustomColor> Colors { get; set; }
    }
}
