using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor.Classes.Models
{
    public interface IIdentifier<T>
    {
        T Id { get; set; }
    }
}
