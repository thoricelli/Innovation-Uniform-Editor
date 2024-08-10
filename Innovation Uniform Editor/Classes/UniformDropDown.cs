using Innovation_Uniform_Editor.Classes.Models;
using Innovation_Uniform_Editor.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            string fullpath = "./Templates/Normal/" + part.ToString() + "/" + uniforms[currentUniform].Id + "/Original.png";
            if (!File.Exists(fullpath))
                TemplateUpdater.CheckForUpdates(true);
            FileStream fs = File.Open(fullpath, FileMode.Open, FileAccess.Read);
            Image returnResult = Image.FromStream(fs);
            fs.Close();
            return returnResult;
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
