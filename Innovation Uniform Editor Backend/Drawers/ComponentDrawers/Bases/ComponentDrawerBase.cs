using Innovation_Uniform_Editor_Backend.Drawers.ComponentDrawers.Interfaces;
using Innovation_Uniform_Editor_Backend.Drawers.Interfaces;
using Innovation_Uniform_Editor_Backend.ImageEditors.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Drawers.ComponentDrawers.Bases
{
    public abstract class ComponentDrawerBase : IComponentInterface
    {
        public int MaxIndex { get; set; }
        public int StartIndex { get; set; }
        protected IImageEditor _imageEditor;

        protected ComponentDrawerBase(IImageEditor imageEditor)
        {
            _imageEditor = imageEditor;
        }

        public abstract Color Draw(Color current, int index);
    }
}
