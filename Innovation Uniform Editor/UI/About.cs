using System.Windows.Forms;

namespace Innovation_Uniform_Editor.UI
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void linkTemplates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkTemplates.LinkVisited = true;
            System.Diagnostics.Process.Start("https://drive.google.com/drive/u/4/folders/14IGxQ6BWsEz_FTUMhRD7z6xL9z1F6KOT");
        }
    }
}
