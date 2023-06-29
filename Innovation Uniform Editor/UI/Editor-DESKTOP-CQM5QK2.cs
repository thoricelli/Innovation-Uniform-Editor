using Cyotek.Windows.Forms;
using Innovation_Uniform_Editor.Classes;
using Innovation_Uniform_Editor.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Innovation_Uniform_Editor.UI
{
    public partial class Editor : Form
    {
        private Custom custom = new Custom();

        private UniformDropDown Handler;

        private Main parent;
        ColorPickerDialog colorPrimary = new ColorPickerDialog();
        ColorPickerDialog colorSecondary = new ColorPickerDialog();

        private bool doneLoading = false;
        public Editor(Custom OG, Main main)
        {
            parent = main;
            custom = OG;
            Handler = new UniformDropDown(custom.UniformBasedOn.part);

            int index = 0;

            for (int i = 0; i < Handler.uniforms.Count; i++)
            {
                if (Handler.uniforms[i].Id == OG.UniformBasedOn.Id)
                    index = i;
            }

            //int savedIndex = handler.currentUniform;

            colorPrimary.PreviewColorChanged += UpdateColorPrimary;
            colorSecondary.PreviewColorChanged += UpdateColorSecondary;

            InitializeComponent();

            dropdownUniforms.DataSource = Handler.uniforms;
            dropdownUniforms.SelectedIndex = index;

            idLabel.Text = $"ID: {OG.UniformBasedOnId}";

            pictureUniform.Image = custom.Result;
            pictureUniform.Refresh();

            doneLoading = true;
        }

        public void UpdateColorPrimary(object sender, EventArgs e)
        {
            custom.ChangePrimaryColor(colorPrimary.Color);
            pictureUniform.Image = custom.Result;
            pictureUniform.Refresh();
        }
        public void UpdateColorSecondary(object sender, EventArgs e)
        {
            custom.ChangeSecondaryColor(colorSecondary.Color);
            pictureUniform.Image = custom.Result;
            pictureUniform.Refresh();
        }

        private void btnPrimary_Click(object sender, EventArgs e)
        {
            colorPrimary.ShowDialog();
            custom.ChangePrimaryColor(colorPrimary.Color);
            pictureUniform.Image = custom.Result;
            pictureUniform.Refresh();
        }

        private void btnSecondary_Click(object sender, EventArgs e)
        {
            colorSecondary.ShowDialog();
            custom.ChangeSecondaryColor(colorSecondary.Color);
            pictureUniform.Image = custom.Result;
            pictureUniform.Refresh();
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            
        }
        private void Editor_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.ShowWLoad();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        /*private void changeUniformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selector selector = new Selector(part);
            selector.Show();
            this.Close();
        }*/

        private void dropdownUniforms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (doneLoading)
            {
                Handler.UniformFromIndex(((ComboBox)sender).SelectedIndex);
                custom.ChangeUniform(Handler.SelectedUniform);

                //InitializeCustom();

                idLabel.Text = $"ID: {Handler.SelectedUniform.Id}";

                pictureUniform.Image = custom.Result;
                pictureUniform.Refresh();
            }
        }
        SaveDialogue saveDialogue;
        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (custom.unsavedChanges)
            {
                saveDialogue = new SaveDialogue();
                saveDialogue.ShowDialog();
                if (saveDialogue.save == saveType.Cancel)
                {
                    e.Cancel = true;
                }
                else if (saveDialogue.save == saveType.Save)
                {
                    custom.SaveUniform();
                }
            }
        }

        BackgroundSelector bgs;
        private void btnBackgroundImage_Click(object sender, EventArgs e)
        {
            bgs = new BackgroundSelector(custom.BackgroundImage);
            bgs.ShowDialog();
            custom.ChangeBackground(bgs.Background, bgs.ClearCurrent);
            pictureUniform.Image = custom.Result;
            pictureUniform.Refresh();
        }

        private void downloadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveCustom.ShowDialog();

            custom.ExportUniform(saveCustom.FileName);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            custom.SaveUniform();
            //MessageBox.Show("Your custom has been saved!", "Save successful.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
