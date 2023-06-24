using Innovation_Uniform_Editor.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor.Classes
{
    public class UniformDropDown
    {
        public Uniform SelectedUniform { get { return uniforms[currentUniform]; } }

        private ClothingPart part;
        public int currentUniform = 0;
        public List<Uniform> uniforms;

        public UniformDropDown(ClothingPart cPart)
        {
            part = cPart;

            uniforms = part == ClothingPart.Pants ? JSONtoUniform.Pants : JSONtoUniform.Shirts;
        }

        public Image LoadUniformPreview()
        {
            return Image.FromFile("./Templates/Normal/" + part.ToString() + "/" + uniforms[currentUniform].Id + "/Original.png");
        }

        public Image NextUniform()
        {
            if (currentUniform > 0)
                currentUniform--;
            return LoadUniformPreview();
        }

        public Image PreviousUniform()
        {
            if (currentUniform < uniforms.Count - 1)
                currentUniform++;
            return LoadUniformPreview();
        }

        public Image UniformFromIndex(int index)
        {
            currentUniform = index;
            return LoadUniformPreview();
        }
    }
}
