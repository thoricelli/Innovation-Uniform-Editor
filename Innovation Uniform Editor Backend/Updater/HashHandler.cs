using Innovation_Uniform_Editor_Backend.Globals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Updater
{
    public class HashHandler
    {
        private string url;

        public HashHandler(string url)
        {
            this.url = url;
        }

        public void WriteNewHash(string newHash)
        {
            File.WriteAllText($"{EditorPaths.HashPath}", newHash);
        }
        public string GetNewHash()
        {
            WebRequest webRequest = WebRequest.Create($"{url}{EditorPaths.HashName}");

            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                return reader.ReadToEnd().Replace("\n", "");
            }
        }
    }
}
