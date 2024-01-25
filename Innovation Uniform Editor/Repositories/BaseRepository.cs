using Innovation_Uniform_Editor.Interfaces;
using Innovation_Uniform_Editor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        private List<T> _objects;
        public List<T> Objects { get { return _objects; } }
        public void AddObject(T obj)
        {
            _objects.Add(obj);
        }

        public void DeleteObject(Guid guid)
        {
            _objects.Remove(this.GetObject(guid));
        }

        public T FindFromId(int id)
        {
            return _objects.Find(b => b.Id == id);
        }

        public T GetObject(Guid guid)
        {
            return _objects.Find(b => b.Guid == guid);
        }

        public T Update(Guid guid, T newObj)
        {
            return _objects[_objects.IndexOf(this.GetObject(guid))] = newObj;
        }
    }
}
