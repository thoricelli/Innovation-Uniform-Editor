using Innovation_Uniform_Editor.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor.Classes.Loaders.Interfaces
{
    public interface IFindable<TType, TId>
    {
        TType FindBy(TId id);
        void DeleteBy(TId id);
    }
}
