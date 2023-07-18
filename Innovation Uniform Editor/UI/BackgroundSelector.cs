using Innovation_Uniform_Editor.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Innovation_Uniform_Editor.UI
{
    public partial class BackgroundSelector : Form
    {
        private bool KeepCurrent = false;
        public bool ClearCurrent = false;
        public BackgroundImage Background;
        public BackgroundSelector(BackgroundImage background)
        {
            Background = background;
            InitializeComponent();
            InitializeUniforms();
        }
        private void InitializeUniforms()
        {
            this.flowLayoutBackgrounds.Controls.Clear();
            foreach (BackgroundImage bg in JSONtoUniform.Backgrounds)
            {
                PictureBox picture = new PictureBox();
                picture.Location = new System.Drawing.Point(10, 10);
                picture.Margin = new System.Windows.Forms.Padding(10);
                picture.Name = bg.backgroundGUID.ToString();
                picture.Size = new System.Drawing.Size(200, 210);
                picture.TabIndex = 0;
                picture.TabStop = false;
                picture.Visible = true;
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                picture.ContextMenuStrip = this.contextBackground;

                picture.MouseDoubleClick += backgroundPicture_DoubleClick;
                picture.MouseClick += backgroundPicture_Click;

                picture.Image = bg.background;

                if (Background != null && bg.backgroundGUID == Background.backgroundGUID)
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
            } else
            {
                ClearCurrent = false;
                //Fix flicker!
                foreach (PictureBox picture in this.flowLayoutBackgrounds.Controls)
                {
                    picture.BorderStyle = BorderStyle.None;
                }

                bg.BorderStyle = BorderStyle.Fixed3D;
                Background = JSONtoUniform.FindBackgroundFromGuid(new Guid(bg.Name));
            }
            
        }

        private void backgroundPicture_DoubleClick(object sender, EventArgs e)
        {
            PictureBox bg = (PictureBox)sender;
            Background.backgroundGUID = new Guid(bg.Name);
            this.Close();
        }

        private void btnBackground_Click(object sender, EventArgs e)
        {
            backgroundDialog.ShowDialog();

            if (backgroundDialog.FileName != "")
            {
                Image resizedBackground = JSONtoUniform.resizeImage(Image.FromFile(backgroundDialog.FileName), new Size(585, 559));
                BackgroundImage bg = new BackgroundImage(null, resizedBackground);
                JSONtoUniform.Backgrounds.Add(bg);
                InitializeUniforms();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem deleteToolTip = (ToolStripMenuItem)sender;
            PictureBox background = (PictureBox)(deleteToolTip.Owner as ContextMenuStrip).SourceControl;

            background.Image.Dispose();
            background.Image = null;

            JSONtoUniform.DeleteBackgroundFromGuid(new Guid(background.Name));
            File.Delete("./Backgrounds/" + background.Name + ".png");
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
