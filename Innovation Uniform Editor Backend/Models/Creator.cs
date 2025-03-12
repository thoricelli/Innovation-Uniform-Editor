using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using System;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Models
{
    public class Creator : IIdentifier<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string FontName { get; set; }
        private FontFamily _fontFamily;
        public FontFamily FontFamily 
        { 
            get
            {
                if (_fontFamily == null)
                    _fontFamily = EditorMain.FontsLoader.FindBy(FontName).FontFamily;

                return _fontFamily;
            }
        }
        public FontStyle FontStyle { get; set; } = FontStyle.Regular;
    }
}
