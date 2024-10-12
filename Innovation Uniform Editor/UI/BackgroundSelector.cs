using Innovation_Uniform_Editor_Backend.Images;
using Innovation_Uniform_Editor_Backend.Loaders;
using System;
using System.IO;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor.UI
{
    public partial class BackgroundSelector : Form
    {
        private bool KeepCurrent = false;
        public bool ClearCurrent = false;
        public BackgroundImage Background;
        private BackgroundsLoader _loader;
        public BackgroundSelector(BackgroundImage background, BackgroundsLoader loader)
        {
            this._loader = loader;
            Background = background;
            InitializeComponent();
            InitializeUniforms();
        }
        private void InitializeUniforms()
        {
            this.flowLayoutBackgrounds.Controls.Clear();
            foreach (BackgroundImage bg in _loader.GetAll())
            {
                PictureBox picture = new PictureBox();
                picture.Location = new System.Drawing.Point(10, 10);
                picture.Margin = new System.Windows.Forms.Padding(10);
                picture.Name = bg.Id.ToString();
                picture.Size = new System.Drawing.Size(200, 210);
                picture.TabIndex = 0;
                picture.TabStop = false;
                picture.Visible = true;
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                picture.ContextMenuStrip = this.contextBackground;

                picture.MouseDoubleClick += backgroundPicture_DoubleClick;
                picture.MouseClick += backgroundPicture_Click;

                picture.Image = bg.Image;

                if (Background != null && bg.Id == Background.Id)
                    picture.BorderStyle = BorderStyle.Fixed3D;

                this.flowLayoutBackgrounds.Controls.Add(picture);
            }
        }

        private void backgroundPicture_Click(object sender, EventArgs e)
        {
            PictureBox bg = (PictureBox)sender;
            if (bg.BorderStyle != BorderStyle.None)
            {
                bg.BorderStyle = BorderStyle.None;
                Background = null;
                ClearCurrent = true;
            }
            else
            {
                ClearCurrent = false;
                //Fix flicker!
                foreach (PictureBox picture in this.flowLayoutBackgrounds.Controls)
                {
                    picture.BorderStyle = BorderStyle.None;
                }

                bg.BorderStyle = BorderStyle.Fixed3D;
                Background = _loader.FindBy(new Guid(bg.Name));
            }

        }

        private void backgroundPicture_DoubleClick(object sender, EventArgs e)
        {
            PictureBox bg = (PictureBox)sender;
            Background.Id = new Guid(bg.Name);
            this.Close();
        }

        private void btnBackground_Click(object sender, EventArgs e)
        {
            backgroundDialog.ShowDialog();

            if (backgroundDialog.FileName != "")
            {
                _loader.Add(backgroundDialog.FileName);
                InitializeUniforms();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem deleteToolTip = (ToolStripMenuItem)sender;
            PictureBox background = (PictureBox)(deleteToolTip.Owner as ContextMenuStrip).SourceControl;

            background.Image.Dispose();
            background.Image = null;

            Guid backgroundId = new Guid(background.Name);

            _loader.DeleteBy(backgroundId);

            if (Background != null && Background.Id == backgroundId)
                ClearCurrent = true;

            InitializeUniforms();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Background = null;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            KeepCurrent = true;
            this.Close();
        }

        private void BackgroundSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!KeepCurrent)
                this.Background = null;
        }

        private void btnClearCurrent_Click(object sender, EventArgs e)
        {
            ClearCurrent = true;
            this.Close();
        }
    }
}
