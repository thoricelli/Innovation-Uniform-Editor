using Innovation_Uniform_Editor_Backend.Globals;
using Innovation_Uniform_Editor_Backend.Helpers;
using Innovation_Uniform_Editor_Backend.Loaders;
using Innovation_Uniform_Editor_Backend.Loaders.OverlayAssets;
using Innovation_Uniform_Editor_Backend.Models.Enums;
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
        public static Version Version { get; } = new Version(0, 8, 0);
        public static VersionType VersionType { get; } = VersionType.Preview;
        public static string VersionString { get; } = 
            VersionType == VersionType.Release ? 
            Version.ToString() : 
            $"{Version} ({VersionType} BUILD)";
        #endregion
        public static BackgroundsLoader Backgrounds { get; set; }
        public static UniformsLoader Uniforms { get; set; }
        public static CustomsLoader Customs { get; set; }
        public static ArmbandsLoader ArmbandsLoader { get; set; }
        public static GlovesLoader GlovesLoader { get; set; }
        public static ShoesLoader ShoesLoader { get; set; }
        public static HolstersLoader HolstersLoader { get; set; }
        public static LogosLoader LogosLoader { get; set; }
        public static PresetsLoader PresetsLoader { get; set; }
        public static FontFamily Neuropol { get; set; }
        public static FontFamily SmallestPixel7 { get; set; }

        public static void Initialize()
        {
            if (!Directory.Exists(EditorPaths.DataPath))
                Directory.CreateDirectory(EditorPaths.DataPath);

            TemplateUpdater.CheckOnStartup();

            Backgrounds = new BackgroundsLoader(EditorPaths.BackgroundsPath);
            Uniforms = new UniformsLoader($"{EditorPaths.TemplatePath}/TemplateInfo.json");

            Customs = new CustomsLoader(EditorPaths.CustomsPath);

            ArmbandsLoader = new ArmbandsLoader(EditorPaths.ArmbandsPath);

            GlovesLoader = new GlovesLoader(EditorPaths.GlovesPath);
            ShoesLoader = new ShoesLoader(EditorPaths.ShoesPath);

            HolstersLoader = new HolstersLoader(EditorPaths.HolstersPath);

            LogosLoader = new LogosLoader(EditorPaths.LogosPath);

            PresetsLoader = new PresetsLoader(EditorPaths.TemplatePath);

            PrivateFontCollection collection = new PrivateFontCollection();
            collection.AddFontFile($"{EditorPaths.FontsPath}/Neuropol.otf");
            collection.AddFontFile($"{EditorPaths.FontsPath}/smallest_pixel-7.ttf");

            Neuropol = new FontFamily("Neuropol", collection);
            SmallestPixel7 = new FontFamily("Smallest Pixel-7", collection);
        }
    }
}
