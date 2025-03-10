﻿using Innovation_Uniform_Editor_Backend.Loaders.Interfaces;
using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Innovation_Uniform_Editor_Backend.Loaders
{
    public abstract class Loader<TType, TId> : IFindable<TType, TId> where TType : IIdentifier<TId>
    {
        private List<TType> _items = new List<TType>();
        protected string _path;

        protected Loader(string path)
        {
            _path = path;
            Load();
        }
        public virtual void Add(TType item)
        {
            _items.Add(item);
        }
        public virtual void Concat(List<TType> item)
        {
            _items = _items.Concat(item).ToList();
        }
        public virtual void Sort()
        {
            _items.Sort();
        }
        public virtual List<TType> GetAll()
        {
            return _items;
        }
        public virtual void Set(List<TType> list)
        {
            _items = list;
        }
        public virtual void Load()
        {
            this._items = new List<TType>();
        }

        public virtual TType FindBy(TId id)
        {
            return _items.Find(e => e.Id.Equals(id));
        }

        public virtual void DeleteBy(TId id)
        {
            _items.Remove(FindBy(id));
        }

        public virtual TType GetByIndex(int index)
        {
            return _items.ElementAt(index);
        }
    }
}
