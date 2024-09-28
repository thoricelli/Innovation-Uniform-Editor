using Cyotek.Windows.Forms;
using Innovation_Uniform_Editor_Backend;
using Innovation_Uniform_Editor_Backend.Enums;
using Innovation_Uniform_Editor_Backend.Helpers;
using Innovation_Uniform_Editor_Backend.Models;
using System;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor.UI
{
    public partial class Editor : Form
    {
        private Custom custom = new Custom();

        private UniformDropDown Handler;

        private Main parent;

        private int _currentIndex;
        private ColorPickerDialog _pickerDialogue;
        private bool doneLoading = false;
        public Editor(Custom OG, Main main)
        {
            parent = main;
            custom = OG;
            Handler = new UniformDropDown(custom.UniformBasedOn.part);

            Initialize();
        }

        public Editor(Custom OG)
        {
            custom = OG;
            Handler = new UniformDropDown(custom.UniformBasedOn.part);

            Initialize();
        }

        private void Initialize()
        {
            int index = 0;

            for (int i = 0; i < Handler.uniforms.Count; i++)
            {
                if (Handler.uniforms[i].Id == custom.UniformBasedOn.Id)
                    index = i;
            }

            InitializeComponent();

            //int savedIndex = handler.currentUniform;

            SetupColors();

            _pickerDialogue = CreateDialog();

            dropdownUniforms.DataSource = Handler.uniforms;
            dropdownUniforms.SelectedIndex = index;

            idLabel.Text = $"ID: {custom.UniformBasedOn.Id}";

            RefreshImage();

            doneLoading = true;
        }

        private ColorPickerDialog CreateDialog()
        {
            ColorPickerDialog cd = new ColorPickerDialog();
            cd.PreviewColorChanged += UpdateColor;
            cd.Validated += UpdateColor;
            return cd;
        }

        public void UpdateColor(object sender, EventArgs e)
        {
            ColorPickerDialog cd = (ColorPickerDialog)sender;

            custom.ChangeFirstColorAtIndex(
                _currentIndex, cd.Color
            );
            RefreshImage();
        }

        private FlowLayoutPanel CreateButton(int index)
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();

            panel.AutoSize = true;
            //panel.Location = new System.Drawing.Point(2,2);
            panel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            panel.Name = "flowColor" + index;
            panel.Size = new System.Drawing.Size(257, 30);
            panel.TabIndex = 11;

            Button btnColor = new Button();
            Button btnExtra = new Button();

            btnColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btnColor.Location = new System.Drawing.Point(2, 2);
            btnColor.Margin = new System.Windows.Forms.Padding(2);
            btnColor.Name = "color_" + index;
            btnColor.Size = new System.Drawing.Size(157, 25);
            btnColor.TabIndex = 11;
            btnColor.Text = "Color " + index;
            btnColor.UseVisualStyleBackColor = true;

            btnColor.MouseClick += btnColor_Click;

            btnExtra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btnExtra.Location = new System.Drawing.Point(209, 2);
            btnExtra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            btnExtra.Name = "btnExtra_" + index;
            btnExtra.Size = new System.Drawing.Size(25, 25);
            btnExtra.TabIndex = 13;
            btnExtra.Text = "+";
            btnExtra.UseVisualStyleBackColor = true;

            btnExtra.MouseClick += btnExtra_Click;

            panel.Controls.Add(btnColor);
            panel.Controls.Add(btnExtra);

            return panel;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            int colorIndex = NamePressHelper.Get(sender, "color");

            _currentIndex = colorIndex;

            _pickerDialogue = CreateDialog();

            _pickerDialogue.Color = custom.Colors[colorIndex].GetColorAtIndex(0);

            _pickerDialogue.Show();
        }

        private void btnExtra_Click(object sender, EventArgs e)
        {
            int colorIndex = NamePressHelper.Get(sender, "btnExtra");

            ColorDetail detail = new ColorDetail(custom.Colors[colorIndex]);
            detail.ColorChanged += Detail_ColorChanged;
            detail.ShowDialog();

            RefreshImage();
        }

        private void Detail_ColorChanged(object sender, EventArgs e)
        {
            RefreshImage();
        }

        private void RefreshImage()
        {
            pictureUniform.Image = custom.Result;
            pictureUniform.Refresh();
        }

        private void Editor_Load(object sender, EventArgs e)
        {

        }
        private void Editor_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (parent != null)
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

                RefreshImage();
            }
        }
        SaveDialogue saveDialogue;
        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (custom.UnsavedChanges)
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
            bgs = new BackgroundSelector(custom.BackgroundImage, EditorMain.Backgrounds);
            bgs.ShowDialog();

            if (bgs.ClearCurrent || bgs.Background == null)
                custom.ClearBackground();
            else
                custom.ChangeBackground(bgs.Background);

            RefreshImage();
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
            int indexStart = 0;
            for (int i = buttonsLayoutPanel.Controls.Count - 1; i >= 1; i--)
            {
                if (i > custom.Colors.Count)
                    buttonsLayoutPanel.Controls.RemoveAt(i);
                else
                    if (indexStart == 0)
                    indexStart = i;

            }
            //Setting up the buttons.
            for (int i = indexStart; i < custom.Colors.Count; i++)
            {
                buttonsLayoutPanel.Controls.Add(CreateButton(i));
            }
        }
        private void btnWarnings_Click(object sender, EventArgs e)
        {
            Issues issues = new Issues();
            issues.Show();
        }

        private void btnSwitchType_Click(object sender, EventArgs e)
        {
            Selector selector = new Selector(ClothingPart.Pants, parent);
            selector.Show();
        }

        private void btnDrawDetail_Click(object sender, EventArgs e)
        {
            Builder builder = new Builder(custom.Drawer);
            builder.ColorChanged += Detail_ColorChanged;
            builder.Show();
        }

        private void pantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selector selector = new Selector(ClothingPart.Pants);
            selector.Show();
        }

        private void shirtsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selector selector = new Selector(ClothingPart.Shirts);
            selector.Show();
        }

        private void exportLayersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
