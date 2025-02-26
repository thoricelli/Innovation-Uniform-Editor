using Innovation_Uniform_Editor.UI;
using Innovation_Uniform_Editor_Backend;
using Innovation_Uniform_Editor_Backend.Enums;
using Innovation_Uniform_Editor_Backend.Loaders;
using Innovation_Uniform_Editor_Backend.Models;
using Innovation_Uniform_Editor_Backend.Updater;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using MenuItem = Innovation_Uniform_Editor_Backend.Models.MenuItem;

namespace Innovation_Uniform_Editor
{
    public partial class Main : Form
    {
        private string _customPath;
        public Main(string customPath = "")
        {
            InitializeComponent();

            _customPath = customPath;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            EditorMain.Initialize();

            string updateStr = "Check for updates";

            BackgroundWorker backgroundWorker = new BackgroundWorker();

            backgroundWorker.DoWork += new DoWorkEventHandler(
            delegate (object o, DoWorkEventArgs args)
            {
                //BackgroundWorker b = o as BackgroundWorker;

                updateTemplatesToolStripMenuItem.Text = EditorMain.TemplateUpdater.IsOutdated() ? updateStr + " (1)" : updateStr;
            });

            backgroundWorker.RunWorkerAsync();

            LoadCustomsAndGroups();
        }

        public void LoadCustomsAndGroups()
        {
            flowMain.Controls.Clear();

            //TODO: This should be replaced by only loading the uniform that was changed.
            EditorMain.Customs.Load();

            foreach (MenuItem item in EditorMain.Customs.GetAll())
            {
                if (item is Group)
                {
                    //Add group /w calculated size (elements * size) || size of window
                    //Add items to that group
                    //Add group to the flowmain.

                    /*this.groupTemplate.Controls.Add(this.flowLayoutPanel1);
                     this.groupTemplate.Location = new System.Drawing.Point(7, 7);
                     this.groupTemplate.Name = "groupTemplate";
                     this.groupTemplate.Size = new System.Drawing.Size(917, 289);
                     this.groupTemplate.TabIndex = 1;
                     this.groupTemplate.TabStop = false;
                     this.groupTemplate.Text = "Custom - Yellow";

                     this.flowLayoutPanel1.AutoSize = true;
                     this.flowLayoutPanel1.Controls.Add(this.panel1);
                     this.flowLayoutPanel1.Controls.Add(this.panel2);
                     this.flowLayoutPanel1.Controls.Add(this.panel3);
                     this.flowLayoutPanel1.Controls.Add(this.panel4);
                     this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 19);
                     this.flowLayoutPanel1.Name = "flowLayoutPanel1";
                     this.flowLayoutPanel1.Size = new System.Drawing.Size(912, 262);
                     this.flowLayoutPanel1.TabIndex = 0;*/
                }
                else
                {
                    Custom uniform = item as Custom;
                    flowMain.Controls.Add(CreateTemplatePanel(uniform));
                }
            }
        }

        Selector selector;

        private void pantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selector = new Selector(ClothingPart.Pants, this);

            selector.Show();

            this.Hide();
        }

        private void shirtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selector = new Selector(ClothingPart.Shirts, this);

            selector.Show();

            this.Hide();
        }

        private void pantsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selector = new Selector(ClothingPart.Pants, this);

            selector.Show();

            this.Hide();
        }

        private void shirtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selector = new Selector(ClothingPart.Shirts, this);

            selector.Show();

            this.Hide();
        }
        About about;
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about = new About();
            about.ShowDialog();
        }
        UI.Help help;
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            help = new UI.Help();
            help.ShowDialog();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                HandleTextBoxData((TextBox)sender);
            }
        }

        private void TextBox_LostFocus(object sender, System.EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.ReadOnly == false)
                HandleTextBoxData(textBox);
        }

        private void HandleTextBoxData(TextBox textBox)
        {
            textBox.Enabled = false;
            textBox.Enabled = true;
            textBox.ReadOnly = true;
            textBox.BorderStyle = BorderStyle.None;

            Custom custom = EditorMain.Customs.FindBy(new Guid(textBox.Parent.Name));
            custom.Name = textBox.Text;
            custom.SaveUniform();
        }

        private void TextBox_MouseLeave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.SelectionLength <= 0 && textBox.ReadOnly == true)
            {
                textBox.Enabled = false;
                textBox.Enabled = true;
                textBox.ReadOnly = true;
                textBox.BorderStyle = BorderStyle.None;
            }
        }

        private Panel CreateTemplatePanel(Custom custom)
        {
            TextBox textBox = new TextBox();

            textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            textBox.Location = new System.Drawing.Point(2, 75);
            textBox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            textBox.Name = "customName";
            textBox.Size = new System.Drawing.Size(195, 20);
            textBox.TabIndex = 0;
            textBox.Text = custom.Name == null ? "Your Custom" : custom.Name;
            textBox.ReadOnly = true;
            textBox.TextAlign = HorizontalAlignment.Center;
            textBox.BorderStyle = BorderStyle.None;
            textBox.TabStop = false;
            textBox.KeyDown += TextBox_KeyDown;
            textBox.LostFocus += TextBox_LostFocus;
            textBox.MouseLeave += TextBox_MouseLeave;
            textBox.MouseDoubleClick += TextBox_MouseDoubleClick;

            PictureBox picture = new PictureBox();

            picture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            picture.Image = custom.PreviewImage;
            picture.Location = new System.Drawing.Point(2, 2);
            picture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            picture.Name = "preview";
            picture.Size = new System.Drawing.Size(195, 70);
            picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picture.TabIndex = 1;
            picture.TabStop = false;
            picture.MouseDoubleClick += Picture_MouseDoubleClick;
            picture.MouseClick += Picture_MouseClick;

            Panel template = new Panel();

            template.BackColor = System.Drawing.SystemColors.Control;
            template.ContextMenuStrip = this.contextMenuCustom;
            template.Controls.Add(textBox);
            template.Controls.Add(picture);
            template.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            template.Location = new System.Drawing.Point(19, 303);
            template.Margin = new System.Windows.Forms.Padding(15, 4, 4, 4);
            template.Name = custom.Id.ToString();
            template.Size = new System.Drawing.Size(220, 250);
            template.TabIndex = 4;

            return template;
        }

        private void TextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RenameHandler((Panel)(sender as TextBox).Parent);
        }

        private void Picture_MouseClick(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            //Listen for left arrow and right arrow
            PictureBox picture = sender as PictureBox;

            //picture.BorderStyle = picture.BorderStyle == BorderStyle.None ? BorderStyle.Fixed3D : BorderStyle.None;
        }

        private void Picture_MouseDoubleClick(object sender, EventArgs e)
        {
            LaunchEditor((Panel)(sender as PictureBox).Parent);
        }

        Editor editor;
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchEditor((Panel)(editToolStripMenuItem.Owner as ContextMenuStrip).SourceControl);
        }

        private void LaunchEditor(Panel panel)
        {
            LaunchEditor(EditorMain.Customs.FindBy(new Guid(panel.Name)));
        }
        private void LaunchEditor(Custom custom)
        {
            editor = new Editor(custom, this);

            this.Hide();
            editor.Show();
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameHandler((Panel)(editToolStripMenuItem.Owner as ContextMenuStrip).SourceControl);
        }

        private void RenameHandler(Panel panel)
        {
            TextBox textBox = (TextBox)panel.Controls[0];

            if (textBox.BorderStyle != BorderStyle.Fixed3D)
                textBox.BorderStyle = BorderStyle.Fixed3D;
            textBox.SelectAll();
            textBox.ReadOnly = false;
            textBox.Focus();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel panel = (Panel)(editToolStripMenuItem.Owner as ContextMenuStrip).SourceControl;
            EditorMain.Customs.DeleteBy(new Guid(panel.Name));
            panel.Dispose();
        }

        public void ShowWLoad()
        {
            Visible = true;
            LoadCustomsAndGroups();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportCustom.ShowDialog();
            Panel panel = (Panel)(editToolStripMenuItem.Owner as ContextMenuStrip).SourceControl;
            Custom custom = EditorMain.Customs.FindBy(new Guid(panel.Name));
            custom.ExportUniform(exportCustom.FileName);
        }

        //Two customs can't be the same position though...
        //Also needs resorting.
        //Headache...
        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel panel = (Panel)(editToolStripMenuItem.Owner as ContextMenuStrip).SourceControl;
            Custom custom = EditorMain.Customs.FindBy(new Guid(panel.Name));
            if (custom.Position > 0)
            {
                custom.Position--;
                flowMain.Controls.SetChildIndex((Control)panel, custom.Position);
            }
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel panel = (Panel)(editToolStripMenuItem.Owner as ContextMenuStrip).SourceControl;
            Custom custom = EditorMain.Customs.FindBy(new Guid(panel.Name));
            if (custom.Position < EditorMain.Customs.GetAll().Count - 1)
            {
                custom.Position++;
                flowMain.Controls.SetChildIndex((Control)panel, custom.Position);
            }
        }

        private void newGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateTemplatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Would you like to update the uniform templates?", "Template updating", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                TemplateUpdateStatus result = EditorMain.TemplateUpdater.CheckAndUpdate();

                switch (result)
                {
                    case TemplateUpdateStatus.SUCCESS:
                        EditorMain.Initialize();
                        MessageBox.Show("Templates have been updated.", "Updated.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case TemplateUpdateStatus.UP_TO_DATE:
                        MessageBox.Show("Templates are already up-to-date!", "Up-to-date", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
        }

        private void newPantsTooltip_Click(object sender, EventArgs e)
        {
            selector = new Selector(ClothingPart.Pants, this);

            selector.Show();

            this.Hide();
        }

        private void newShirtsTooltip_Click(object sender, EventArgs e)
        {
            selector = new Selector(ClothingPart.Shirts, this);

            selector.Show();

            this.Hide();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openCustomDialogue.ShowDialog();

            PreviewFile(openCustomDialogue.FileName);
        }

        private void PreviewFile(string path)
        {
            LaunchEditor(CustomsLoader.LoadFromFile(path));
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            if (_customPath != string.Empty)
                PreviewFile(_customPath);
        }
    }
}
