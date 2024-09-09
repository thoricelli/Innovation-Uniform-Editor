using System;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor_Backend.Helpers
{
    public static class NamePressHelper
    {
        public static int Get(object sender, string baseName)
        {
            return Convert.ToInt32(((Control)sender).Name.Replace($"{baseName}_", ""));
        }
    }
}
