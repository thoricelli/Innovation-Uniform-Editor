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
        public static bool CheckForUpdates(bool ignoreHash = false)
        {
            MessageBox.Show("Sorry but updating uniforms is not supported on Windows XP.");
            return true;
        }

        private static void ExtractMain(string zipPath, string templatePath)
        {
            ZipFile.ExtractToDirectory(zipPath, templatePath);

            //Untill I find a way to fix the MSI auto repair stuff.
            //File.Delete(zipPath);
        }

        private static void BackupCreate(string templatePath)
        {
            if (Directory.Exists(templatePath))
                Directory.Move(templatePath, templatePath + "_backup");
        }

        private static void BackupDelete(string templatePath)
        {
            if (Directory.Exists(templatePath + "_backup"))
                Directory.Delete(templatePath + "_backup", true);
        }

        private static void Failure(string templatePath)
        {
            try
            {
                if (Directory.Exists(templatePath + "_backup") && Directory.Exists(templatePath))
                {
                    Directory.Delete(templatePath);
                    Directory.Move(templatePath + "_backup", templatePath);
                }

            } catch (Exception e)
            {
            }

            File.WriteAllText(EditorPaths.DataPath + "/failedupdate", "");

            File.WriteAllText(EditorPaths.HashPath, oldHash);
            MessageBox.Show("The application will now be closed and the update will be completed on the next startup.", "Regular update failed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            Environment.Exit(0);
            Application.Exit();
        }
    }
}
