using Innovation_Uniform_Editor_Backend.Enums;
using Innovation_Uniform_Editor_Backend.Globals;
using Innovation_Uniform_Editor_Backend.Helpers;
using Innovation_Uniform_Editor_Backend.Models;
using System;
using System.IO;
using System.Net;
using System.Security.Policy;

namespace Innovation_Uniform_Editor_Backend.Updater
{
    /// <summary>
    /// Handles versioning for the templates.
    /// </summary>
    public class UpdaterVersioning
    {
        public TemplateVersioning CachedNewVersioning;
        private HashHandler hashHandler;
        private string _url;
        private string _hash;
        public string Hash
        {
            get
            {
                if (_hash == null)
                    _hash = File.Exists(EditorPaths.HashPath) ? File.ReadAllText(EditorPaths.HashPath).Replace("\r\n", "") : string.Empty;
                return _hash;
            }
        }

        public UpdaterVersioning(string url)
        {
            hashHandler = new HashHandler(url);
            this._url = url;
        }

        public UpdaterVersioningResult CheckVersioning()
        {
            string newHash = hashHandler.GetNewHash();

            if (Hash == newHash)
                return UpdaterVersioningResult.NO_UPDATE_NEEDED;

            TemplateVersioning templateVersioningNet = null;

            HttpStatusCode result = GetTemplateVersion(ref templateVersioningNet);

            if (result != HttpStatusCode.OK)
                return UpdaterVersioningResult.SOMETHING_WENT_WRONG;

            CachedNewVersioning = templateVersioningNet;

            //Check if the online template version is compatible with this tool version.
            if (templateVersioningNet.MinimumToolVersion.CompareTo(Versioning.Version) >= 1)
                return UpdaterVersioningResult.NOT_COMPATIBLE;

            //Check if the current template version is higher or the hash doesn't match and the version is not lower.
            if (templateVersioningNet.TemplateVersion.CompareTo(EditorMain.TemplateUpdater.TemplateVersion) <= -1
                || (Hash != newHash && templateVersioningNet.TemplateVersion.CompareTo(EditorMain.TemplateUpdater.TemplateVersion) >= 0))
                return UpdaterVersioningResult.OUT_OF_DATE;

            return UpdaterVersioningResult.NO_UPDATE_NEEDED;
        }
        public bool IsOutOfDate()
        {
            try
            {
                return CheckVersioning() == UpdaterVersioningResult.OUT_OF_DATE;
            } catch(Exception e)
            {
                return false;
            }
        }
        public void UpdateHash(string newHash)
        {
            _hash = newHash;
        }
        public HttpStatusCode GetTemplateVersion(ref TemplateVersioning versioning)
        {
            try
            {
                WebRequest webRequest = WebRequest.Create($"{_url}{EditorPaths.TemplateVersioningName}");

                using (var response = webRequest.GetResponse())
                using (var content = response.GetResponseStream())
                using (var reader = new StreamReader(content))
                {
                    string result = reader.ReadToEnd().Replace("\n", "");
                    versioning = JsonUtils.Load<TemplateVersioning>(result);
                    return (response as HttpWebResponse).StatusCode;
                }
            } catch (WebException e)
            {
                return (e.Response as HttpWebResponse).StatusCode;
            }
        }
    }
}
