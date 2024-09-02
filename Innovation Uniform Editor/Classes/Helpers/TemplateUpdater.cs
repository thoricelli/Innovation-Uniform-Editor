using Innovation_Uniform_Editor.Classes.Globals;
using Innovation_Uniform_Editor.Classes.Helpers.Enums;
using System;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor.Classes
{
    public static class TemplateUpdater
    {
        public static bool CheckOnStartup(bool ignoreHash = false)
        {
            MessageBox.Show("Sorry but updating uniforms is not supported on Windows XP.");
            return true;
        }
    }
}
