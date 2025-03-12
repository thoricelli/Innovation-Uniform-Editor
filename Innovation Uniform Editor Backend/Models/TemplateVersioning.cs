using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Models
{
    public class TemplateVersioning
    {
        /// <summary>
        /// Minimum version the editor has to be to use these templates.
        /// </summary>
        public Version MinimumToolVersion;
        /// <summary>
        /// The template version itself.
        /// </summary>
        public Version TemplateVersion;
    }
}
