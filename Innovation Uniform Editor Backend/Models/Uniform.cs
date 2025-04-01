using Innovation_Uniform_Editor_Backend.Enums;
using Innovation_Uniform_Editor_Backend.Globals;
using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using System;

namespace Innovation_Uniform_Editor_Backend.Models
{
    public class Uniform : IIdentifier<ulong>, IOverlayAssets
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public int CreatorId { get; set; }
        private Creator _creator;
        public Creator Creator
        {
            get
            {
                if (_creator == null)
                    _creator = EditorMain.CreatorLoader.FindBy(CreatorId);
                return _creator;
            }
        }
        public ClothingPart part { get; set; }
        #region Customization
        /*
         * If the uniform supports changing armbands, holsters, etc
         * I don't have the textures for some of the uniforms, so, they have customization disabled!
        */
        public bool CanBeCustomized { get; set; } = true;
        public Guid? HolsterId { get; set; }
        public Guid? ArmbandId { get; set; }
        public Guid? ShoeId { get; set; }
        public Guid? GloveId { get; set; }
        public UniformDataLogo[] LogoIds { get; set; } 
        public CustomColor[] Colors { get; set; }
        public int ShadingAmount { get; set; } = 1;
        #region USERNAMES
        //This should probably be presets instead.
        /*public PointF UsernamePosition { get; set; } = new PointF(471,124);
        public Color UsernameColor { get; set; } = Color.FromArgb(167, 167, 167, 255);
        public int UsernameSize { get; set; } = 10;*/

        #endregion
        #endregion
        public string Path 
        { 
            get
            {
                return $"{EditorPaths.TemplateNormalPath}/{part.ToString()}/{Id}";
            } 
        }

    }
}
