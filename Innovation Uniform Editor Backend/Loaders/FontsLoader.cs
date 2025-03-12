using Innovation_Uniform_Editor_Backend.Globals;
using Innovation_Uniform_Editor_Backend.Loaders.Base;
using Innovation_Uniform_Editor_Backend.Models;
using System.Drawing;
using System.Drawing.Text;
using System.IO;

namespace Innovation_Uniform_Editor_Backend.Loaders
{
    public class FontsLoader : Loader<FontItem, string>
    {
        public FontsLoader(string path) : base(path)
        {
        }
        public override void Load()
        {
            base.Load();

            foreach (string path in Directory.GetFiles(_path))
            {
                string fontName = Path.GetFileNameWithoutExtension(path);
                
                PrivateFontCollection collection = new PrivateFontCollection();
                collection.AddFontFile(path);

                Add(new FontItem()
                {
                    Id = fontName,
                    FontFamily = new FontFamily(collection.Families[0].Name, collection)
                });

                collection.Dispose();
            }
        }
    }
}
