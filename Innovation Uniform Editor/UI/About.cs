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
            System.Diagnostics.Process.Start("https://drive.google.com/drive/u/0/folders/1y_KfLgIWMa8FFW2Rz3BFr4H4zPqNytIH");
        }
    }
}
