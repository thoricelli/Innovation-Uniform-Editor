using Innovation_Uniform_Editor_Backend.Globals;
using Innovation_Uniform_Editor_Backend.Helpers;
using Innovation_Uniform_Editor_Backend.Loaders;
using System.IO;

namespace Innovation_Uniform_Editor_Backend
{
    public static class EditorMain
    {
        public static BackgroundsLoader Backgrounds { get; set; }
        public static UniformsLoader Uniforms { get; set; }
        public static CustomsLoader Customs { get; set; }

        public static void Initialize()
        {
            if (!Directory.Exists(EditorPaths.DataPath))
                Directory.CreateDirectory(EditorPaths.DataPath);

            TemplateUpdater.CheckOnStartup();

            Backgrounds = new BackgroundsLoader(EditorPaths.BackgroundsPath);
            Uniforms = new UniformsLoader($"{EditorPaths.TemplatePath}/TemplateInfo.json");

            Customs = new CustomsLoader(EditorPaths.CustomsPath);
        }
    }
}
