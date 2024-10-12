using Innovation_Uniform_Editor_Backend.Images;
using Innovation_Uniform_Editor_Backend.Loaders;
using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor.UI.Generic
{
    /// <summary>
    /// This is a generic selector, it's purpose is to have an easy to use form to select between a list of objects
    /// All of these objects have a preview, they follow a certain interface, and the selected will be returned (and also must be fed to this form)
    /// 
    /// Aka:
    /// Simple selector (not a form in of itself).
    /// Feed the current selection, and it'll give you the current selected back.
    /// </summary>
    public partial class GenericSelector<TType, TId> where TType : IIdentifier<TId>, IPreviewable<Image>
    {
        private bool KeepCurrent = false;
        public bool ClearCurrent = false;
        public TType item;
        private Loader<TType, TId> _loader;

        private Form original;

        public GenericSelector(Form original, Loader<TType, TId> loader)
        {
            this.original = original;
            this._loader = loader;
        }
        protected virtual void InitializeUniforms()
        {
            this.flowLayoutBackgrounds.Controls.Clear();

            List<TType> list = _loader.GetAll();

            for (int i = 0; i < list.Count; i++)
            {
                TType bg = list[i];

                PictureBox picture = new PictureBox();
                picture.Location = new System.Drawing.Point(10, 10);
                picture.Margin = new System.Windows.Forms.Padding(10);
                picture.Name = i.ToString();
                picture.Size = new System.Drawing.Size(200, 210);
                picture.TabIndex = 0;
                picture.TabStop = false;
                picture.Visible = true;
                picture.SizeMode = PictureBoxSizeMode.StretchImage;

                picture.MouseDoubleClick += backgroundPicture_DoubleClick;
                picture.MouseClick += backgroundPicture_Click;

                picture.Image = bg.Image;

                if (item != null && bg.Id.Equals(item.Id))
                    picture.BorderStyle = BorderStyle.Fixed3D;

                this.flowLayoutBackgrounds.Controls.Add(picture);
            }
        }

        protected virtual void backgroundPicture_Click(object sender, EventArgs e)
        {
            PictureBox bg = (PictureBox)sender;
            if (bg.BorderStyle != BorderStyle.None)
            {
                bg.BorderStyle = BorderStyle.None;
                item = default;
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
                item = _loader.GetByIndex(int.Parse(bg.Name));
            }

        }

        protected virtual void backgroundPicture_DoubleClick(object sender, EventArgs e)
        {
            PictureBox bg = (PictureBox)sender;
            item.Id = _loader.GetByIndex(int.Parse(bg.Name)).Id;
            original.Close();
        }

        protected virtual void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem deleteToolTip = (ToolStripMenuItem)sender;
            PictureBox background = (PictureBox)(deleteToolTip.Owner as ContextMenuStrip).SourceControl;

            background.Image.Dispose();
            background.Image = null;

            TId backgroundId = _loader.GetByIndex(int.Parse(background.Name)).Id;

            _loader.DeleteBy(backgroundId);

            if (item != null && item.Id.Equals(backgroundId))
                ClearCurrent = true;

            InitializeUniforms();
        }

        protected virtual void btnCancel_Click(object sender, EventArgs e)
        {
            this.item = default;
            original.Close();
        }

        protected virtual void btnOK_Click(object sender, EventArgs e)
        {
            KeepCurrent = true;
            original.Close();
        }

        protected virtual void BackgroundSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!KeepCurrent)
                this.item = default;
        }

        protected virtual void btnClearCurrent_Click(object sender, EventArgs e)
        {
            ClearCurrent = true;
            original.Close();
        }
    }
}
