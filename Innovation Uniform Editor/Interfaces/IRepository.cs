using Innovation_Uniform_Editor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        T GetObject(Guid guid);
        void AddObject(T obj);
        void DeleteObject(Guid guid);
        T FindFromId(int id);
        T Update(Guid guid, T newObj);
    }
}
