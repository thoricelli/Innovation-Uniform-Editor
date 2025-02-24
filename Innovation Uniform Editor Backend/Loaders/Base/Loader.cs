using Innovation_Uniform_Editor_Backend.Loaders.Interfaces;
using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Innovation_Uniform_Editor_Backend.Loaders.Base
{
    public abstract class Loader<TType, TId> : IFindable<TType, TId> where TType : IIdentifier<TId>
    {
        //private List<TType> _items = new List<TType>();
        private Dictionary<TId, TType> _items = new Dictionary<TId, TType>();
        protected string _path;

        protected Loader(string path)
        {
            _path = path;
            Load();
        }
        public virtual void Add(TType item)
        {
            _items.Add(item.Id, item);
        }
        public virtual void Concat(List<TType> item)
        {
            _items = _items.Concat(item.ToDictionary(x => x.Id, x => x)).ToDictionary(x => x.Key, x => x.Value);
        }
        public virtual List<TType> GetAll()
        {
            return _items.OrderBy(x => x.Key).Select(x => x.Value).ToList();
        }
        public virtual void Set(List<TType> list)
        {
            _items = list.ToDictionary(x => x.Id, x => x);
        }
        public virtual void Load()
        {
            _items = new Dictionary<TId, TType>();
        }

        public virtual TType FindBy(TId id)
        {
            return _items.TryGetValue(id, out var value) ? value : default(TType);
        }

        public virtual void Sort()
        {
            _items = _items.OrderBy(kv => kv.Key).ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        public virtual void DeleteBy(TId id)
        {
            _items.Remove(id);
        }

        public virtual TType GetByIndex(int index)
        {
            return GetAll().ElementAt(index);
        }
    }
}
