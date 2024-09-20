using Innovation_Uniform_Editor_Backend.Globals;
using Innovation_Uniform_Editor_Backend.Helpers.Enums;
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor_Backend.Helpers
{
    public static class TemplateUpdater
    {
        private static string githubURL = "https://raw.githubusercontent.com/thoricelli/Innovation-Uniform-Editor/master/";

        private static string oldHash = "";
        private static bool tryingToFix = false;

        public static void CheckOnStartup()
        {
            string freshInstallFile = $"{EditorPaths.DataPath}/freshinstall";
            string failedInstallFile = $"{EditorPaths.DataPath}/failedupdate";

            if (File.Exists(freshInstallFile) && Convert.ToBoolean(File.ReadAllText(freshInstallFile)))
            {
                File.WriteAllText(freshInstallFile, "false");
                File.Delete(EditorPaths.HashPath);

                CheckForUpdates();
            }
            else if (!Directory.Exists(EditorPaths.TemplatePath))
            {
                CheckForUpdates();
            }
            else if (File.Exists(failedInstallFile))
            {
                File.Delete(failedInstallFile);

                string hash = GetNewHash();

                WriteNewHash(hash);

                DownloadZipFile($"{githubURL}{EditorPaths.ZipName}", EditorPaths.ZipPath);
                OfflineSetup();
            }
        }

        public static TemplateUpdateStatus CheckForUpdates(bool ignoreHash = false)
        {
            tryingToFix = ignoreHash;
            oldHash = File.Exists(EditorPaths.HashPath) ? File.ReadAllText(EditorPaths.HashPath).Replace("\r\n", "") : "";

            try
            {
                string hashTemplate = GetNewHash();

                if (hashTemplate != oldHash || ignoreHash)
                {
                    WriteNewHash(hashTemplate);

                    BackupCreate(EditorPaths.TemplatePath);

                    DownloadZipFile($"{githubURL}{EditorPaths.ZipName}", EditorPaths.ZipPath);
                    return ExtractToFolder(EditorPaths.ZipPath, EditorPaths.TemplatePath);
                }

                return TemplateUpdateStatus.UP_TO_DATE;
            }
            catch (IOException e)
            {
                Failure(EditorPaths.TemplatePath);
                return TemplateUpdateStatus.FAILURE;
            }
            catch (WebException e)
            {
                return OfflineSetup();
            }
        }
        private static void WriteNewHash(string newHash)
        {
            File.WriteAllText($"{EditorPaths.HashPath}", newHash);
        }
        private static string GetNewHash()
        {
            WebRequest webRequest = WebRequest.Create($"{githubURL}{EditorPaths.HashName}");

            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                return reader.ReadToEnd().Replace("\n", "");
            }
        }
        private static TemplateUpdateStatus OfflineSetup()
        {
            try
            {
                if (File.Exists(EditorPaths.ZipPath))
                {
                    BackupCreate(EditorPaths.TemplatePath);
                    ExtractToFolder(EditorPaths.ZipPath, EditorPaths.TemplatePath);
                    return TemplateUpdateStatus.SUCCESS;
                }

                if (!Directory.Exists(EditorPaths.TemplatePath))
                {
                    MessageBox.Show("Templates not found.\nAnd there are no available resources to download from.\n\nDid you install the application correctly? ", "Cannot continue.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Environment.Exit(0);
                    Application.Exit();
                }

                MessageBox.Show("You are offline, please connect to the internet.", "Offline.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return TemplateUpdateStatus.FAILURE;
            }
            catch (Exception e)
            {
                Failure(EditorPaths.TemplatePath);
                return TemplateUpdateStatus.FAILURE;
            }
        }
        private static void DownloadZipFile(string url, string filename)
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Accept: text/html, application/xhtml+xml, */*");
            webClient.Headers.Add("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)");
            webClient.DownloadFile(new Uri(url), filename);
        }

        private static TemplateUpdateStatus ExtractToFolder(string zipPath, string templatePath)
        {
            try
            {
                ExtractMain(zipPath, templatePath);
                BackupDelete(templatePath);

                if (tryingToFix)
                {
                    MessageBox.Show("Application has tried to fix the templates folder due to corruption. Please restart the application.", "Fixing templates.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                    Environment.Exit(0);
                }
                return TemplateUpdateStatus.SUCCESS;
            }
            catch (Exception e)
            {
                Failure(templatePath);
                return TemplateUpdateStatus.FAILURE;
            }
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

            }
            catch (Exception e)
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
