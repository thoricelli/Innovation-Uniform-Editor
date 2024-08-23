using Innovation_Uniform_Editor.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor.Classes
{
    public abstract class MenuItem : IIdentifier<Guid>, IComparable<MenuItem>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Position { get; set; }

        public int CompareTo(MenuItem obj)
        {
            return Position.CompareTo(obj.Position);
        }
    }
}
