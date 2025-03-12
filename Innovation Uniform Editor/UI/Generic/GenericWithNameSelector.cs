using Innovation_Uniform_Editor_Backend.Loaders.Base;
using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using System.Drawing;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor.UI.Generic
{
    public abstract class GenericWithNameSelector<TType, TId> : GenericSelector<TType, TId> where TType : IIdentifier<TId>, IPreviewable<Image>, INamable
    {
        protected GenericWithNameSelector(Loader<TType, TId> loader) : base(loader)
        {
        }

        protected GenericWithNameSelector(TType item, Loader<TType, TId> loader) : base(item, loader)
        {
        }

        protected GenericWithNameSelector(TId id, Loader<TType, TId> loader) : base(id, loader)
        {
        }

        protected override Control CreateItemControl(TType bg, int i)
        {
            Label label = new Label();

            label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            label.Location = new System.Drawing.Point(2, 75);
            label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label.Name = "itemName";
            label.Size = new System.Drawing.Size(195, 20);
            label.TabIndex = 0;
            label.Text = bg.Name;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BorderStyle = BorderStyle.None;
            label.TabStop = false;

            PictureBox picture = new PictureBox();

            picture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            picture.Image = bg.Image;
            picture.Location = new System.Drawing.Point(2, 2);
            picture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            picture.Name = i.ToString();
            picture.Size = new System.Drawing.Size(195, 70);
            picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picture.TabIndex = 1;
            picture.TabStop = false;
            picture.BorderStyle = BorderStyle.FixedSingle;

            Panel template = new Panel();

            template.BackColor = System.Drawing.SystemColors.Control;
            template.Controls.Add(label);
            template.Controls.Add(picture);
            template.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            template.Location = new System.Drawing.Point(19, 303);
            template.Margin = new System.Windows.Forms.Padding(15, 4, 4, 4);
            template.Name = "panelItem";
            template.Size = new System.Drawing.Size(220, 250);
            template.TabIndex = 4;
            template.BorderStyle = BorderStyle.None;

            picture.MouseDoubleClick += backgroundPicture_DoubleClick;
            picture.MouseClick += backgroundPicture_Click;

            if (item != null && bg.Id.Equals(item.Id))
                picture.BorderStyle = BorderStyle.Fixed3D;

            return template;
        }

        protected override void InitializeComponent()
        {
            base.InitializeComponent();
            //Forms is so fucking buggy.
            this.ClientSize = new System.Drawing.Size(800, 375);
        }
    }
}
