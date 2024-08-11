using Innovation_Uniform_Editor.Classes.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor.Classes.Models
{
    public class CustomLoader : Loader<Custom, Guid>
    {
        public CustomLoader(string path) : base(path)
        {
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        protected override void Load()
        {
            throw new NotImplementedException();
        }
    }
}
