using Innovation_Uniform_Editor_Backend.Helpers;
using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Models.Base
{
    public abstract class ItemBase : IIdentifier<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public abstract string Path { get; }
        [JsonIgnore]
        public Image Image 
        {
            get
            {
                if (_image == null)
                    _image = FileToBitmap.Convert($"{Path}/{Id}.png");
                return _image;
            }
        }

        private Image _image;
    }
}
