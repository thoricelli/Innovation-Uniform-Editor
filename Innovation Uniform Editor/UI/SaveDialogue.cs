using System;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor.UI
{
    public enum saveType
    {
        Save,
        Do_Not_Save,
        Cancel
    }
    public partial class SaveDialogue : Form
    {
        public saveType save = saveType.Cancel;
        public SaveDialogue()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save = saveType.Save;
            this.Close();
        }

        private void btnNoSave_Click(object sender, EventArgs e)
        {
            save = saveType.Do_Not_Save;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            save = saveType.Cancel;
            this.Close();
        }
    }
}
