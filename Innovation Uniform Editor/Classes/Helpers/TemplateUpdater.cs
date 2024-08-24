using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor.Classes
{
    public static class TemplateUpdater
    {
        public static bool CheckForUpdates(bool ignoreHash = false)
        {
            MessageBox.Show("Sorry but updating uniforms is not supported on Windows XP.");
            return true;
        }
    }
}
