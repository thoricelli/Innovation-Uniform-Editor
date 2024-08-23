using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor.Classes.Helpers
{
    public static class FileToBitmap
    {
        public static Bitmap Convert(string path)
        {
            if (!File.Exists(path))
            {
                TemplateUpdater.CheckForUpdates(true);
                return fileToBitmapBase("./Templates/Normal/ERROR/Original.png");
            }
            return fileToBitmapBase(path);
        }

        private static Bitmap fileToBitmapBase(string path)
        {
            FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read);
            Bitmap img = new Bitmap(fs);
            fs.Close();

            return img;
        }
    }
}
