using Innovation_Uniform_Editor_Backend.Models.OverlayAssets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Models
{
    public class UniformDataLogo
    {
        public ulong LogoId { get; set; }
        public Point Location { get; set; }
        public Logo Logo { get; set; }
        public Guid? PresetGuid { get; set; }
        public float Transparency { get; set; } = 1f;

        private Preset _preset;
        public Preset Preset
        { 
            get
            {
                if (PresetGuid.HasValue)
                {
                    if (_preset == null)
                        _preset = EditorMain.PresetsLoader.FindBy(PresetGuid.Value);
                } else
                {
                    if (_preset == null)
                        _preset = EditorMain.PresetsLoader.FindBy(new Guid("ae418e5f-65ba-4f00-84f1-a69ea34d568e"));
                }

                return _preset;
            }
        }
    }
}
