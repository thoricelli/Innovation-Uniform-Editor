using System;
using System.IO;
using System.Reflection;

namespace Innovation_Uniform_Editor_Backend.Globals
{
    public static class EditorPaths
    {
        private static string dataPathBaseUrl = EditorMain.Portable
            ? Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) :
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public static string DataPathName = EditorMain.Portable ? String.Empty : "thoricelli";
        public static string DataPath = dataPathBaseUrl + "/" + DataPathName;

        public static string HashName = "templateshash.txt";
        public static string HashPath = $"{DataPath}/{HashName}";

        public static string ZipName = "Templates.zip";
        public static string ZipPath = $"{DataPath}/{ZipName}";

        public static string ZipTemp = "Templates_TEMP.zip";
        public static string ZipTempPath = $"{DataPath}/{ZipTemp}";

        public static string TemplateName = "Templates";
        public static string TemplatePath = $"{DataPath}/{TemplateName}";

        #region TEMPLATES
        public static string TemplateMiscName = "Misc";
        public static string TemplateMiscPath = $"{TemplatePath}/{TemplateMiscName}";

        public static string TemplateNormalName = "Normal";
        public static string TemplateNormalPath = $"{TemplatePath}/{TemplateNormalName}";

        public static string FontsName = "Fonts";
        public static string FontsPath = $"{TemplatePath}/{FontsName}";
        #endregion

        #region OVERLAY_ASSETS
        public static string OverlayAssetsName = "OverlayAssets";
        public static string OverlayAssetsPath = $"{TemplatePath}/{OverlayAssetsName}";

        public static string ArmbandsName = "Armbands";
        public static string ArmbandsPath = $"{OverlayAssetsPath}/{ArmbandsName}";

        public static string BottomsName = "Bottoms";
        public static string BottomsPath = $"{OverlayAssetsPath}/{BottomsName}";

        public static string GlovesName = "Gloves";
        public static string GlovesPath = $"{OverlayAssetsPath}/{GlovesName}";

        public static string ShoesName = "Shoes";
        public static string ShoesPath = $"{OverlayAssetsPath}/{ShoesName}";

        public static string HolstersName = "Holsters";
        public static string HolstersPath = $"{OverlayAssetsPath}/{HolstersName}";

        public static string LogosName = "Logos";
        public static string LogosPath = $"{OverlayAssetsPath}/{LogosName}";
        #endregion

        #region PERSONAL
        public static string Customs = "Customs";
        public static string CustomsPath = $"{DataPath}/{Customs}";

        public static string Backgrounds = "Backgrounds";
        public static string BackgroundsPath = $"{DataPath}/{Backgrounds}";
        #endregion
    }
}
