using Innovation_Uniform_Editor_Backend.Enums;
using Innovation_Uniform_Editor_Backend.Globals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor_Backend.Updater
{
    /// <summary>
    /// Handles events of file or folder corruption.
    /// </summary>
    public class CorruptionHandler
    {
        private HashHandler hashHandler;
        private TemplateZipHandler zipHandler;

        public CorruptionHandler(HashHandler hashHandler, TemplateZipHandler zipHandler)
        {
            this.hashHandler = hashHandler;
            this.zipHandler = zipHandler;
        }

        public void BackupCreate(string templatePath)
        {
            try
            {
                if (Directory.Exists(templatePath))
                    Directory.Move(templatePath, templatePath + "_backup");
            }
            catch (Exception e)
            {
                Failure(templatePath);
            }
        }

        public void BackupDelete(string templatePath)
        {
            try
            {
                if (Directory.Exists(templatePath + "_backup"))
                    Directory.Delete(templatePath + "_backup", true);
            }
            catch (Exception e)
            {
                Failure(templatePath);
            }
        }

        /// <summary>
        /// Creates "failedupdate" file and closes the application.
        /// </summary>
        /// <param name="templatePath"></param>
        public void Failure(string templatePath)
        {
            try
            {
                if (Directory.Exists(templatePath + "_backup") && Directory.Exists(templatePath))
                {
                    Directory.Delete(templatePath);
                    Directory.Move(templatePath + "_backup", templatePath);
                }

            }
            catch (Exception e)
            {
            }

            File.WriteAllText(EditorPaths.DataPath + "/failedupdate", "");

            MessageBox.Show("The application will now be closed and the update will be completed on the next startup.", "Regular update failed.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Environment.Exit(0);
            Application.Exit();
        }
        /// <summary>
        /// To be called on application restart when an update failed.
        /// </summary>
        public void FailedInstall()
        {
            OfflineSetup();
        }

        public TemplateUpdateStatus OfflineSetup()
        {
            try
            {
                if (File.Exists(EditorPaths.ZipPath))
                {
                    BackupCreate(EditorPaths.TemplatePath);
                    zipHandler.ExtractToFolder(EditorPaths.ZipPath, EditorPaths.TemplatePath);
                    return TemplateUpdateStatus.SUCCESS;
                }

                if (File.Exists(EditorPaths.ZipTemp))
                {
                    BackupCreate(EditorPaths.TemplatePath);
                    zipHandler.ExtractToFolder(EditorPaths.ZipTemp, EditorPaths.TemplatePath);
                    File.Delete(EditorPaths.ZipTemp);
                    return TemplateUpdateStatus.SUCCESS;
                }

                if (!Directory.Exists(EditorPaths.TemplatePath))
                {
                    MessageBox.Show("Templates not found.\nAnd there are no available resources to download from.\n\nDid you install the application correctly? ", "Cannot continue.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Environment.Exit(0);
                    Application.Exit();
                }

                MessageBox.Show("Critical error in updating templates, please reinstall the application.", "Critical error.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return TemplateUpdateStatus.FAILURE;
            }
            catch (Exception e)
            {
                Failure(EditorPaths.TemplatePath);
                return TemplateUpdateStatus.FAILURE;
            }
        }
    }
}
