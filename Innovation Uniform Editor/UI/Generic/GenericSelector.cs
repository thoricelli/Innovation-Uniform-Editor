using Innovation_Uniform_Editor_Backend.Loaders.Base;
using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor.UI.Generic
{
    public partial class GenericSelector<TType, TId> : Form where TType : IIdentifier<TId>, IPreviewable<Image>
    {
        private bool KeepCurrent = false;
        public bool ClearCurrent = false;
        public TType item;
        protected Loader<TType, TId> _loader;
        public GenericSelector(Loader<TType, TId> loader)
        {
            this._loader = loader;
            InitializeComponent();
            Initialize();
        }
        public GenericSelector(TType item, Loader<TType, TId> loader)
        {
            this.item = item;
            this._loader = loader;
            InitializeComponent();
            Initialize();
        }
        public GenericSelector(TId id, Loader<TType, TId> loader)
        {
            this.item = loader.FindBy(id);
            this._loader = loader;
            InitializeComponent();
            Initialize();
        }

        public virtual void Initialize()
        {
            this.flowLayoutBackgrounds.Controls.Clear();

            List<TType> list = _loader.GetAll();

            for (int i = 0; i < list.Count; i++)
            {
                TType bg = list[i];

                Control control = CreateItemControl(bg, i);

                this.flowLayoutBackgrounds.Controls.Add(control);
            }
        }

        protected virtual Control CreateItemControl(TType bg, int i)
        {
            PictureBox picture = new PictureBox();
            picture.Location = new System.Drawing.Point(10, 10);
            picture.Margin = new System.Windows.Forms.Padding(10);
            picture.Name = i.ToString();
            picture.Size = new System.Drawing.Size(200, 210);
            picture.TabIndex = 0;
            picture.TabStop = false;
            picture.Visible = true;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.BorderStyle = BorderStyle.FixedSingle;

            picture.MouseDoubleClick += backgroundPicture_DoubleClick;
            picture.MouseClick += backgroundPicture_Click;

            picture.Image = bg.Image;

            if (item != null && bg.Id.Equals(item.Id))
                picture.BorderStyle = BorderStyle.Fixed3D;

            return picture;
        }

        protected virtual void backgroundPicture_Click(object sender, EventArgs e)
        {
            PictureBox bg = (PictureBox)sender;
            if (bg.BorderStyle != BorderStyle.FixedSingle)
            {
                bg.BorderStyle = BorderStyle.FixedSingle;
                item = default;
                ClearCurrent = true;
            }
            else
            {
                ClearCurrent = false;
                //Fix flicker!

                ResetBorderStyle(flowLayoutBackgrounds.Controls);

                bg.BorderStyle = BorderStyle.Fixed3D;
                item = _loader.GetByIndex(int.Parse(bg.Name));
            }

        }

        private void ResetBorderStyle(Control.ControlCollection collection)
        {
            foreach (object item in collection)
            {
                if (item is PictureBox)
                    ((PictureBox)item).BorderStyle = BorderStyle.FixedSingle;
                if (item is Panel)
                {
                    ResetBorderStyle(((Panel)item).Controls);
                }
            }
        }

        protected virtual void backgroundPicture_DoubleClick(object sender, EventArgs e)
        {
            PictureBox bg = (PictureBox)sender;
            item.Id = _loader.GetByIndex(int.Parse(bg.Name)).Id;
            this.Close();
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

            Initialize();
        }

        protected virtual void btnCancel_Click(object sender, EventArgs e)
        {
            this.item = default;
            this.Close();
        }

        protected virtual void btnOK_Click(object sender, EventArgs e)
        {
            KeepCurrent = true;
            this.Close();
        }

        protected virtual void BackgroundSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!KeepCurrent)
                this.item = default;
        }

        protected virtual void btnClearCurrent_Click(object sender, EventArgs e)
        {
            ClearCurrent = true;
            this.Close();
        }
    }
}
