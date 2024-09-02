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
        public static TemplateUpdateStatus CheckOnStartup()
        {
            return CheckForUpdates(false);
        }
        public static TemplateUpdateStatus CheckForUpdates(bool ignoreHash = false)
        {
            MessageBox.Show("Sorry but updating uniforms is not supported on Windows XP.");
            return TemplateUpdateStatus.FAILURE;
        }
    }
}
