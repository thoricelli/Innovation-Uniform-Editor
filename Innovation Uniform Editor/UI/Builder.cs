using Innovation_Uniform_Editor_Backend.Drawers;
using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases;
using Innovation_Uniform_Editor_Backend.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor.UI
{
    public partial class Builder : Form
    {
        private EventHandler onChanged;

        public event EventHandler ColorChanged
        {
            add
            {
                onChanged += value;
            }
            remove
            {
                onChanged -= value;
            }
        }

        private CustomDrawer<Bitmap> _customDrawer;
        public Builder(CustomDrawer<Bitmap> customDrawer)
        {
            _customDrawer = customDrawer;
            
            InitializeComponent();

            BuildDrawerViews();
        }
        private void BuildDrawerViews()
        {
            for (int i = 0; i < _customDrawer.GraphicsDrawers.Count; i++)
            {
                BaseGraphicsDrawer drawer = _customDrawer.GraphicsDrawers[i];

                if (drawer.HasAsset())
                {
                    // 
                    // lblName
                    // 
                    Label name = new Label
                    {
                        Location = new System.Drawing.Point(0, 0),
                        Margin = new System.Windows.Forms.Padding(0),
                        Name = "lblName",
                        Size = new System.Drawing.Size(200, 30),
                        TabIndex = 0,
                        Text = drawer.Name,
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    };

                    // 
                    // picturePreview
                    // 
                    PictureBox picturePreview = new PictureBox
                    {
                        Location = new System.Drawing.Point(2, 33),
                        Margin = new System.Windows.Forms.Padding(2, 3, 0, 3),
                        Name = "picturePreview",
                        Size = new System.Drawing.Size(195, 187),
                        TabIndex = 4,
                        TabStop = false,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Image = drawer.GetResult()
                    };

                    // 
                    // chkVisible
                    // 
                    CheckBox visible = new CheckBox
                    {
                        Checked = drawer.Visible,
                        CheckState = drawer.Visible ? System.Windows.Forms.CheckState.Checked : CheckState.Unchecked,
                        Location = new System.Drawing.Point(5, 226),
                        Margin = new System.Windows.Forms.Padding(5, 3, 3, 3),
                        Name = $"chkVisible_{i}",
                        Size = new System.Drawing.Size(190, 17),
                        TabIndex = 8,
                        Text = "Visible",
                        UseVisualStyleBackColor = true,
                    };

                    visible.Click += Visible_Click;

                    // 
                    // lblOpacity
                    // 
                    Label opacity = new Label
                    {
                        Location = new System.Drawing.Point(3, 246),
                        Name = "lblOpacity",
                        Size = new System.Drawing.Size(190, 13),
                        TabIndex = 10,
                        Text = "Opacity"
                    };

                    // 
                    // trackOpacity
                    // 
                    TrackBar trackBarOpacity = new TrackBar
                    {
                        LargeChange = 25,
                        Location = new System.Drawing.Point(3, 262),
                        Maximum = 100,
                        Name = "trackOpacity",
                        Size = new System.Drawing.Size(194, 45),
                        SmallChange = 5,
                        TabIndex = 9,
                        Value = Convert.ToInt32(drawer.Transparency * 100)
                    };

                    // 
                    // btnChangeAsset
                    // 
                    Button changeAsset = new Button
                    {
                        Location = new System.Drawing.Point(3, 313),
                        Name = "btnChangeAsset",
                        Size = new System.Drawing.Size(194, 23),
                        TabIndex = 7,
                        Text = "Change asset",
                        UseVisualStyleBackColor = true
                    };

                    // 
                    // lblArrow
                    // 
                    Label arrow = new Label
                    {
                        Location = new System.Drawing.Point(206, 0),
                        Margin = new System.Windows.Forms.Padding(0),
                        Name = "lblArrow",
                        Size = new System.Drawing.Size(45, 378),
                        TabIndex = 8,
                        Text = ">",
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    };

                    // 
                    // flowItem
                    // 
                    FlowLayoutPanel item = new FlowLayoutPanel();

                    item.Controls.Add(name);
                    item.Controls.Add(picturePreview);
                    item.Controls.Add(visible);
                    //item.Controls.Add(opacity);
                    //item.Controls.Add(trackBarOpacity);

                    //if (drawer is BaseAssetDrawer<Bitmap>)
                    //item.Controls.Add(changeAsset);

                    item.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
                    item.Location = new System.Drawing.Point(3, 3);
                    item.Name = "flowItem";
                    item.Size = new System.Drawing.Size(200, 375);
                    item.TabIndex = 7;
                    item.WrapContents = false;

                    // 
                    // flowDrawerItem
                    // 
                    FlowLayoutPanel drawerItem = new FlowLayoutPanel();

                    drawerItem.Controls.Add(item);
                    drawerItem.Controls.Add(arrow);
                    drawerItem.Location = new System.Drawing.Point(0, 0);
                    drawerItem.Margin = new System.Windows.Forms.Padding(0);
                    drawerItem.Name = "flowDrawerItem";
                    drawerItem.Size = new System.Drawing.Size(255, 380);
                    drawerItem.TabIndex = 6;

                    this.flowDrawers.Controls.Add(drawerItem);

                    picturePreview.Refresh();
                }
            }
        }

        private void Visible_Click(object sender, EventArgs e)
        {
            BaseGraphicsDrawer gd = _customDrawer.GraphicsDrawers[NamePressHelper.Get(sender, "chkVisible")];
            gd.Visible = ((CheckBox)sender).Checked;
            RefreshImage();
        }

        private void RefreshImage()
        {
            onChanged.Invoke(this, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnExportLayers_Click(object sender, EventArgs e)
        {
            DialogResult result = folderExportLayered.ShowDialog();

            if (result == DialogResult.OK)
            {
                _customDrawer.ExportLayered(folderExportLayered.SelectedPath);
                MessageBox.Show("Files exported!", "Export successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
