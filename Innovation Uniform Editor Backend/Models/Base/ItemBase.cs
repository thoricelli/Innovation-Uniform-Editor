using Innovation_Uniform_Editor_Backend.Helpers;
using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using Newtonsoft.Json;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Models.Base
{
    public abstract class ItemBase<T> : IIdentifier<T>, IPreviewable<Image>, INamable
    {
        public T Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public abstract string Path { get; }
        [JsonIgnore]
        public virtual Image Image
        {
            get
            {
                if (_image == null)
                    _image = FileToBitmap.Convert($"{Path}/{Id}.png");
                return _image;
            }
        }

        protected Image _image;
    }
}
