using Innovation_Uniform_Editor_Backend.Enums;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor_Backend.Updater
{
    public class TemplateZipHandler
    {
        private CorruptionHandler corruptionHandler;

        public TemplateZipHandler(HashHandler hashHandler)
        {
            corruptionHandler = new CorruptionHandler(hashHandler, this);
        }

        public void DownloadZipFile(string url, string filename)
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Accept: text/html, application/xhtml+xml, */*");
            webClient.Headers.Add("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)");
            webClient.DownloadFile(new Uri(url), filename);
        }

        public void ExtractZipToDirectory(string zipPath, string templatePath)
        {
            ZipFile.ExtractToDirectory(zipPath, templatePath);

            //Untill I find a way to fix the MSI auto repair stuff.
            //File.Delete(zipPath);
        }

        public TemplateUpdateStatus ExtractToFolder(string zipPath, string templatePath)
        {
            try
            {
                ExtractZipToDirectory(zipPath, templatePath);
                corruptionHandler.BackupDelete(templatePath);

                /*if (tryingToFix)
                {
                    MessageBox.Show("Application has tried to fix the templates folder due to corruption. Please restart the application.", "Fixing templates.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                    Environment.Exit(0);
                }*/
                return TemplateUpdateStatus.SUCCESS;
            }
            catch (Exception e)
            {
                corruptionHandler.Failure(templatePath);
                return TemplateUpdateStatus.FAILURE;
            }
        }
    }
}
