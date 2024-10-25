using Innovation_Uniform_Editor.UI.Generic;
using Innovation_Uniform_Editor_Backend;
using Innovation_Uniform_Editor_Backend.Images;
using Innovation_Uniform_Editor_Backend.Loaders;
using Innovation_Uniform_Editor_Backend.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor.UI
{
    public partial class BackgroundSelector : GenericSelector<BackgroundImage, Guid>
    {
        public BackgroundSelector(BackgroundImage background, BackgroundsLoader loader) : base(background, loader)
        {
        }

        private void btnBackground_Click(object sender, EventArgs e)
        {
            backgroundDialog.ShowDialog();

            if (backgroundDialog.FileName != "")
            {
                ((BackgroundsLoader)_loader).Add(backgroundDialog.FileName);
            }
        }
    }
}
