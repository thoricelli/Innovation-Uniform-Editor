using Innovation_Uniform_Editor_Backend.Helpers;
using Innovation_Uniform_Editor_Backend.Loaders.Base;
using Innovation_Uniform_Editor_Backend.Models.Base;
using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Innovation_Uniform_Editor_Backend.Loaders
{
    public abstract class RecolorableAssetLoader<TType, TId> : Loader<TType, TId> where TType : ItemRecolorableBase<TId>, IIdentifier<TId>
    {

        public RecolorableAssetLoader(string path) : base(path)
        {
        }

        protected abstract TType NewInstance(string id);

        public override void Load()
        {
            base.Load();

            foreach (string directory in Directory.GetDirectories(_path))
            {
                Add(NewInstance(Path.GetFileName(directory)));
            }
        }
    }
}
