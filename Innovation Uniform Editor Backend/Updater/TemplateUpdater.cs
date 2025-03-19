using Innovation_Uniform_Editor_Backend.Enums;
using Innovation_Uniform_Editor_Backend.Globals;
using Innovation_Uniform_Editor_Backend.Helpers;
using Innovation_Uniform_Editor_Backend.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor_Backend.Updater
{
    public class TemplateUpdater
    {
        private Version templateVersion;
        public Version TemplateVersion { 
            get
            {
                if (templateVersion == null && File.Exists(EditorPaths.TemplateVersioningPath))
                    templateVersion = JsonUtils.Load<TemplateVersioning>(File.ReadAllText(EditorPaths.TemplateVersioningPath)).TemplateVersion;
                return templateVersion;
            }
            set
            {
                templateVersion = value;
            }
        }
        private CorruptionHandler corruptionHandler;
        private HashHandler hashHandler;
        private TemplateZipHandler zipHandler;
        private UpdaterVersioning updaterVersioning;

        private const string githubURL = "https://raw.githubusercontent.com/thoricelli/Innovation-Uniform-Editor/master/";

        public TemplateUpdater()
        {
            hashHandler = new HashHandler(githubURL);
            updaterVersioning = new UpdaterVersioning(githubURL);
            zipHandler = new TemplateZipHandler(hashHandler);
            corruptionHandler = new CorruptionHandler(hashHandler, zipHandler);
        }

        public bool IsOutdated()
        {
            return updaterVersioning.IsOutOfDate();
        }

        public TemplateUpdateStatus CheckAndUpdate()
        {
            try
            {
                string hashTemplate = hashHandler.GetNewHash();

                TemplateUpdateStatus status = Update();

                //Update the current hash.
                if (status == TemplateUpdateStatus.SUCCESS)
                {
                    if (updaterVersioning.CachedNewVersioning != null)
                    {
                        JsonUtils.SaveToFile(updaterVersioning.CachedNewVersioning, EditorPaths.TemplateVersioningPath);
                        TemplateVersion = updaterVersioning.CachedNewVersioning.TemplateVersion;
                    }

                    updaterVersioning.UpdateHash(hashTemplate);
                    hashHandler.WriteNewHash(hashTemplate);
                }

                return status;
            }
            catch (IOException e)
            {
                //Something went wrong, start handle corruption.
                corruptionHandler.Failure(EditorPaths.TemplatePath);
                return TemplateUpdateStatus.FAILURE;
            }
            catch (WebException e)
            {
                //No internet, start offline setup.
                return corruptionHandler.OfflineSetup();
            }
            catch (Exception e)
            {
                MessageBox.Show("An unexpected error occured.");
                return TemplateUpdateStatus.FAILURE;
            }
        }
        /// <summary>
        /// Call when corrupt.
        /// </summary>
        public void CorruptionSignal()
        {
            TemplateUpdateStatus status = Update();

            if (status == TemplateUpdateStatus.UP_TO_DATE || status == TemplateUpdateStatus.FAILURE)
            {
                MessageBox.Show("Template files corrupted, failure to recover, please reinstall the application.", "Application exiting.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                Application.Exit();
            }
        }

        /// <summary>
        /// Updates templates, ignoring the hash.
        /// </summary>
        public TemplateUpdateStatus Update()
        {
            //Download zip file from the internet.
            UpdaterVersioningResult result = updaterVersioning.CheckVersioning();

            if (result == UpdaterVersioningResult.OUT_OF_DATE)
            {
                zipHandler.DownloadZipFile($"{githubURL}{EditorPaths.ZipName}", EditorPaths.ZipTempPath);

                //Create backup in case of corruption
                corruptionHandler.BackupCreate(EditorPaths.TemplatePath);

                //Extract the zip file to the templates directory.
                TemplateUpdateStatus status = zipHandler.ExtractToFolder(EditorPaths.ZipTempPath, EditorPaths.TemplatePath);

                //Delete the downloaded zip file.
                File.Delete(EditorPaths.ZipTempPath);

                return status;
            }
            else if (result == UpdaterVersioningResult.SOMETHING_WENT_WRONG || result == UpdaterVersioningResult.NOT_COMPATIBLE)
            {
                corruptionHandler.OfflineSetup();
                return TemplateUpdateStatus.SUCCESS;
            }
            
            return TemplateUpdateStatus.UP_TO_DATE;
        }

        public void CheckInstallationFiles()
        {
            string freshInstallFile = $"{EditorPaths.DataPath}/freshinstall";
            string failedInstallFile = $"{EditorPaths.DataPath}/failedupdate";

            if (File.Exists(freshInstallFile) && Convert.ToBoolean(File.ReadAllText(freshInstallFile)))
            {
                File.WriteAllText(freshInstallFile, "false");
                File.Delete(EditorPaths.HashPath);

                //Use online templates first, then try offline ones.
                CheckAndUpdate();
            }
            else if (!Directory.Exists(EditorPaths.TemplatePath))
            {
                //Templates don't exist, get it from the internet.
                CheckAndUpdate();
            }
            else if (File.Exists(failedInstallFile))
            {
                //The application has restarted because of a failed update.
                File.Delete(failedInstallFile);

                corruptionHandler.FailedInstall();
            }
        }
    }
}
