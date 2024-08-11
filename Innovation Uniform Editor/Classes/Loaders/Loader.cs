using Innovation_Uniform_Editor.Classes.Loaders.Interfaces;
using Innovation_Uniform_Editor.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor.Classes.Loaders
{
    public abstract class Loader<TType, TId> : ISaveable<TType>, IFindable<TType, TId> where TType : IIdentifier<TId>
    {
        private List<TType> _items = new List<TType>();
        protected string _path;

        protected Loader(string path)
        {
            _path = path;
            this.Load();
        }
        public virtual void Add(TType item)
        {
            _items.Add(item);
        }
        public virtual void Concat(List<TType> item)
        {
            _items = _items.Concat(item).ToList();
        }
        public virtual List<TType> GetAll()
        {
            return _items;
        }
        protected abstract void Load();

        public abstract void Save();

        public virtual TType FindBy(TId id)
        {
            return _items.Find(e => e.Id.Equals(id));
        }

        public virtual void DeleteBy(TId id)
        {
            _items.Remove(FindBy(id));
        }
    }
}
