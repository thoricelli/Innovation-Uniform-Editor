﻿using Innovation_Uniform_Editor_Backend.Globals;
using Innovation_Uniform_Editor_Backend.Loaders;
using Innovation_Uniform_Editor_Backend.Loaders.OverlayAssets;
using Innovation_Uniform_Editor_Backend.Updater;
using System.IO;

namespace Innovation_Uniform_Editor_Backend
{
    public static class EditorMain
    {
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
