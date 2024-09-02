using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using System;

namespace Innovation_Uniform_Editor_Backend.Models
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
