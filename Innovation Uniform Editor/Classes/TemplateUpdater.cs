using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor.Classes
{
    public static class TemplateUpdater
    {
        private static string githubURL = "https://raw.githubusercontent.com/thoricelli/Innovation-Uniform-Editor/master/";
        private static string hashFile = "templateshash.txt";
        private static string zipFile = "Templates.zip";
        private static string oldHash = "";
        private static bool tryingToFix = false;
        public static bool CheckForUpdates(bool ignoreHash = false)
        {
            tryingToFix = ignoreHash;
            oldHash = File.Exists(hashFile) ? File.ReadAllText(hashFile).Replace("\r\n", "") : "" ;
            WebRequest webRequest = WebRequest.Create($"{githubURL}{hashFile}");

            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                string hashTemplate = reader.ReadToEnd().Replace("\n","");
                if (hashTemplate != oldHash || ignoreHash)
                {
                    File.WriteAllText($"{hashFile}", hashTemplate);
                    return DownloadZipFile($"{githubURL}{zipFile}", zipFile);
                }

                return false;
            }
        }

        private static bool DownloadZipFile(string url, string filename)
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Accept: text/html, application/xhtml+xml, */*");
            webClient.Headers.Add("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)");
            webClient.DownloadFile(new Uri(url), filename);
            return ExtractToFolder(zipFile, "Templates");
        }

        private static bool ExtractToFolder(string filename, string foldername)
        {
            try
            {
                if (Directory.Exists(foldername))
                    Directory.Move(foldername, foldername + "_backup");
                ZipFile.ExtractToDirectory(filename, foldername);
                File.Delete(filename);
                if (Directory.Exists(foldername + "_backup"))
                    Directory.Delete(foldername + "_backup", true);
                if (tryingToFix)
                {
                    MessageBox.Show("Application has tried to fix the templates folder due to corruption. Please restart the application.", "Fixing templates.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                    Environment.Exit(0);
                }
                return true;
            } catch(Exception e) {
                if (File.Exists(filename))
                    File.Delete(filename);
                if (Directory.Exists(foldername + "_backup"))
                    Directory.Move(foldername + "_backup", foldername);
                File.WriteAllText(hashFile, oldHash);
                MessageBox.Show("An error occured whilst trying to update, restoring files.", "Update failed.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
        }
    }
}
