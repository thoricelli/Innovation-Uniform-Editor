using System;

namespace Innovation_Uniform_Editor_Backend.Globals
{
    public static class EditorPaths
    {
        public static string ToolName = "Thoricelli's Uniform Editor";

        public static string DataPathName = "thoricelli";
        public static string DataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" + DataPathName;

        public static string HashName = "templateshash.txt";
        public static string HashPath = $"{DataPath}/{HashName}";

        public static string ZipName = "Templates.zip";
        public static string ZipPath = $"{DataPath}/{ZipName}";

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
