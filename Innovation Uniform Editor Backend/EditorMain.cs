using Innovation_Uniform_Editor_Backend.Globals;
using Innovation_Uniform_Editor_Backend.Loaders;
using Innovation_Uniform_Editor_Backend.Loaders.OverlayAssets;
using Innovation_Uniform_Editor_Backend.Models;
using Innovation_Uniform_Editor_Backend.Models.Enums;
using Innovation_Uniform_Editor_Backend.Updater;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;

namespace Innovation_Uniform_Editor_Backend
{
    public static class EditorMain
    {
        #region VERSIONING
        public static string ToolName { get; } = "Thoricelli's Uniform Editor";
        public static Version Version { get; } = new Version(1, 0, 0, 0);
        private static string VersionToString(Version version)
        {
            return $"{Version.Major}.{Version.Minor}.{Version.Build}";
        }
        public static VersionType VersionType { get; } = VersionType.Bugtest;
        public static string VersionString { get; } = 
            VersionType == VersionType.Release ?
            VersionToString(Version) : 
            $"{VersionToString(Version)} ({VersionType} BUILD)";

        private static bool isPortable = false;

        public static bool Portable = VersionType == VersionType.Development && !isPortable ? true : isPortable;
        
        #endregion
        public static TemplateUpdater TemplateUpdater { get; set; }
        public static BackgroundsLoader Backgrounds { get; set; }
        public static UniformsLoader Uniforms { get; set; }
        public static CustomsLoader Customs { get; set; }
        public static ArmbandsLoader ArmbandsLoader { get; set; }
        public static GlovesLoader GlovesLoader { get; set; }
        public static ShoesLoader ShoesLoader { get; set; }
        public static HolstersLoader HolstersLoader { get; set; }
        public static LogosLoader LogosLoader { get; set; }
        public static PresetsLoader PresetsLoader { get; set; }
        public static CreatorLoader CreatorLoader { get; set; }
        public static FontsLoader FontsLoader { get; set; }

        public static void Initialize()
        {
            if (!Directory.Exists(EditorPaths.DataPath))
                Directory.CreateDirectory(EditorPaths.DataPath);

            TemplateUpdater = new TemplateUpdater();

            TemplateUpdater.CheckInstallationFiles();

            FontsLoader = new FontsLoader(EditorPaths.FontsPath);

            Backgrounds = new BackgroundsLoader(EditorPaths.BackgroundsPath);
            Uniforms = new UniformsLoader($"{EditorPaths.TemplatePath}/TemplateInfo.json");

            ArmbandsLoader = new ArmbandsLoader(EditorPaths.ArmbandsPath);

            GlovesLoader = new GlovesLoader(EditorPaths.GlovesPath);
            ShoesLoader = new ShoesLoader(EditorPaths.ShoesPath);

            HolstersLoader = new HolstersLoader(EditorPaths.HolstersPath);

            LogosLoader = new LogosLoader(EditorPaths.LogosPath);

            PresetsLoader = new PresetsLoader(EditorPaths.TemplatePath);

            Customs = new CustomsLoader(EditorPaths.CustomsPath);

            CreatorLoader = new CreatorLoader(EditorPaths.TemplatePath);
        }
    }
}
