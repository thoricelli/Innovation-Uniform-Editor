using Innovation_Uniform_Editor.Classes.Globals;
using Innovation_Uniform_Editor.Classes.Loaders;
using Innovation_Uniform_Editor.Classes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor.Classes
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
