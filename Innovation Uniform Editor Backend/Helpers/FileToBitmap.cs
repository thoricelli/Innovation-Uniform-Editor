﻿using Innovation_Uniform_Editor_Backend.Globals;
using Innovation_Uniform_Editor_Backend.Updater;
using System.Drawing;
using System.IO;

namespace Innovation_Uniform_Editor_Backend.Helpers
{
    public static class FileToBitmap
    {
        public static Bitmap Convert(string path)
        {
            if (!File.Exists(path))
            {
                EditorMain.TemplateUpdater.CorruptionSignal();
                return fileToBitmapBase($"{EditorPaths.TemplateNormalPath}/ERROR/Original.png");
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
