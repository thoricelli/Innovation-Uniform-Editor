using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Bases
{
    public abstract class BaseAssetDrawer<T> : BaseGraphicsDrawer
    {
        protected T asset;
        public BaseAssetDrawer(T asset)
        {
            this.asset = asset;
        }
    }
}
