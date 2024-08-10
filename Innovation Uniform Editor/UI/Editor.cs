using Cyotek.Windows.Forms;
using Innovation_Uniform_Editor.Classes;
using Innovation_Uniform_Editor.Classes.Models;
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
        List<ColorPickerDialog> colors = new List<ColorPickerDialog>();
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

            InitializeComponent();

            //int savedIndex = handler.currentUniform;

            SetupColors();

            dropdownUniforms.DataSource = Handler.uniforms;
            dropdownUniforms.SelectedIndex = index;

            idLabel.Text = $"ID: {OG.UniformBasedOnId}";

            pictureUniform.Image = custom.Result;
            pictureUniform.Refresh();

            doneLoading = true;
        }

        private ColorPickerDialog CreateDialog(string name)
        {
            ColorPickerDialog cd = new ColorPickerDialog();
            cd.Name = name;
            cd.PreviewColorChanged += UpdateColor;
            return cd;
        }

        public void UpdateColor(object sender, EventArgs e)
        {
            ColorPickerDialog cd = (ColorPickerDialog)sender;
            custom.ChangeColorAtIndex(
                Convert.ToInt32(
                    cd.Name.
                    Replace("color_", "")
                ), cd.Color
            );
            pictureUniform.Image = custom.Result;
            pictureUniform.Refresh();
        }

        private Button CreateButton(int index)
        {
            Button button = new Button();

            button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            button.Location = new System.Drawing.Point(2, 2);
            button.Margin = new System.Windows.Forms.Padding(2);
            button.Name = "color_" + index;
            button.Size = new System.Drawing.Size(188, 24);
            button.TabIndex = 11;
            button.Text = "Color " + index;
            button.UseVisualStyleBackColor = true;

            button.MouseClick += btnColor_Click;

            return button;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int colorIndex = Convert.ToInt32(button.Name.Replace("color_", ""));

            ColorPickerDialog cd = CreateDialog(colors[colorIndex].Name);
            cd.Color = colors[colorIndex].Color;
            colors[colorIndex] = cd;
            cd.Show();

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
                SetupColors();

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
            bgs = new BackgroundSelector(custom.backgroundImage, Assets.BackgroundsLoader);
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

        private void SetupColors()
        {
            colors = new List<ColorPickerDialog>();
            int indexStart = 0;
            for (int i = buttonsLayoutPanel.Controls.Count-1; i >= 1; i--)
            {
                if (i > custom.SelectionTemplates.Count)
                    buttonsLayoutPanel.Controls.RemoveAt(i);
                else
                    if (indexStart == 0)
                        indexStart = i;

            }
            //Setting up colordialogs
            for (int i = 0; i < custom.SelectionTemplates.Count; i++)
            {
                colors.Add(CreateDialog("color_" + i));
            }
            //Setting up the buttons.
            for (int i = indexStart; i < custom.SelectionTemplates.Count; i++)
            {
                buttonsLayoutPanel.Controls.Add(CreateButton(i));
            }
        }
    }
}
