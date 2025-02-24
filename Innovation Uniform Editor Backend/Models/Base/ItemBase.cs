using Innovation_Uniform_Editor_Backend.Helpers;
using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using Newtonsoft.Json;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Models.Base
{
    public abstract class ItemBase<T> : IIdentifier<T>, IPreviewable<Image>, INamable, IHasCreator
    {
        public T Id { get; set; }
        public string Name { get; set; }
        public int CreatorId { get; set; }
        private Creator _creator;
        [JsonIgnore]
        public Creator Creator 
        { 
            get
            {
                if (_creator == null)
                    _creator = EditorMain.CreatorLoader.FindBy(CreatorId);
                return _creator;
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
