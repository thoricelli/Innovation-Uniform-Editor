using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Models
{
    public class FontItem : IIdentifier<string>
    {
        public string Id { get; set; }
        public FontFamily FontFamily { get; set; }
    }
}
