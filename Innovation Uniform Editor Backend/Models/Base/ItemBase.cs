using Innovation_Uniform_Editor_Backend.Helpers;
using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Innovation_Uniform_Editor_Backend.Models.Base
{
    public abstract class ItemBase<T> : IIdentifier<T>, IPreviewable<Image>, INamable, IHasCreators
    {
        public T Id { get; set; }
        public string Name { get; set; }
        public int[] CreatorIds { get; set; }
        private List<Creator> _creators;
        [JsonIgnore]
        public List<Creator> Creators
        { 
            get
            {
                if (_creators == null)
                    _creators = EditorMain.CreatorLoader.FindAllBy(CreatorIds.ToList());
                return _creators;
            } 
        }
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
