using Innovation_Uniform_Editor_Backend.Enums;
using Innovation_Uniform_Editor_Backend.Globals;
using Innovation_Uniform_Editor_Backend.Helpers;
using System.Collections.Generic;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Models
{
    public class UniformDropDown
    {
        public Uniform SelectedUniform { get { return uniforms[currentUniform]; } }

        private ClothingPart part;
        public int currentUniform = 0;
        public List<Uniform> uniforms { get; set; }

        public bool isLast
        {
            get
            {
                return currentUniform >= uniforms.Count - 1;
            }
        }
        public bool isFirst
        {
            get
            {
                return currentUniform <= 0;
            }
        }

        public UniformDropDown(ClothingPart cPart)
        {
            part = cPart;

            uniforms = part == ClothingPart.Pants ? EditorMain.Uniforms.GetPants() : EditorMain.Uniforms.GetShirts();
        }
        public Image LoadUniformPreview()
        {
            string fullpath = $"{EditorPaths.TemplateNormalPath}/" + part.ToString() + "/" + uniforms[currentUniform].Id + "/Original.png";
            return FileToBitmap.Convert(fullpath);
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
