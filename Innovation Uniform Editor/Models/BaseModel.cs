using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor.Models
{
    public class BaseModel
    {
        private int _id;
        public int Id { get { return _id; } }

        private Guid _guid;
        public Guid Guid { get { return _guid; } }
    }
}
