using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor.Classes
{
    public abstract class MenuItem : IComparable<MenuItem>
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Position { get; set; }

        public int CompareTo(MenuItem obj)
        {
            return Position.CompareTo(obj.Position);
        }
    }
}
