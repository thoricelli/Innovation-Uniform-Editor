using Innovation_Uniform_Editor.Classes.Models;
using Innovation_Uniform_Editor_Backend.Globals;
using Innovation_Uniform_Editor_Backend.Helpers;
using Innovation_Uniform_Editor_Backend.Loaders;
using System.IO;

namespace Innovation_Uniform_Editor_Backend
{
    public static class EditorMain
    {
        public static void Initialize()
        {
            if (!Directory.Exists(EditorPaths.DataPath))
                Directory.CreateDirectory(EditorPaths.DataPath);

            TemplateUpdater.CheckOnStartup();

            Assets.BackgroundsLoader = new BackgroundsLoader(EditorPaths.BackgroundsPath);
            Assets.UniformsLoader = new UniformsLoader($"{EditorPaths.TemplatePath}/TemplateInfo.json");

            Assets.CustomsLoader = new CustomsLoader(EditorPaths.CustomsPath);
        }
    }
}
