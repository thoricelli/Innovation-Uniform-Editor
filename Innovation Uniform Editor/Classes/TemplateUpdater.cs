using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor.Classes
{
    public static class TemplateUpdater
    {
        private static string githubURL = "https://raw.githubusercontent.com/thoricelli/Innovation-Uniform-Editor/master/";
        private static string hashFile = "templateshash.txt";
        private static string zipFile = "Templates.zip";

        public static bool CheckForUpdates()
        {
            string currenthashTemplate = File.ReadAllText(hashFile).Replace("\r\n", "");
            WebRequest webRequest = WebRequest.Create($"{githubURL}{hashFile}");

            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                string hashTemplate = reader.ReadToEnd().Replace("\n","");
                if (hashTemplate != currenthashTemplate)
                {
                    File.WriteAllText($"{hashFile}", hashTemplate);
                    DownloadZipFile($"{githubURL}{zipFile}", zipFile);
                    return true;
                }

                return false;
            }
        }

        private static void DownloadZipFile(string url, string filename)
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Accept: text/html, application/xhtml+xml, */*");
            webClient.Headers.Add("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)");
            webClient.DownloadFileAsync(new Uri(url), filename);
            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
        }

        private static void WebClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            ExtractToFolder(zipFile, "Templates");
        }

        private static void ExtractToFolder(string filename, string foldername)
        {
            Directory.Delete(foldername, true);
            ZipFile.ExtractToDirectory(filename, foldername);
            File.Delete(filename);
        }
    }
}
