namespace Innovation_Uniform_Editor.UI
{
    partial class Builder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Builder));
            this.picturePreview = new System.Windows.Forms.PictureBox();
            this.flowDrawerItem = new System.Windows.Forms.FlowLayoutPanel();
            this.flowItem = new System.Windows.Forms.FlowLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.chkVisible = new System.Windows.Forms.CheckBox();
            this.lblOpacity = new System.Windows.Forms.Label();
            this.trackOpacity = new System.Windows.Forms.TrackBar();
            this.btnChangeAsset = new System.Windows.Forms.Button();
            this.btnShift = new System.Windows.Forms.Button();
            this.lblArrow = new System.Windows.Forms.Label();
            this.flowDrawers = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExportLayers = new System.Windows.Forms.Button();
            this.folderExportLayered = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).BeginInit();
            this.flowDrawerItem.SuspendLayout();
            this.flowItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackOpacity)).BeginInit();
            this.flowDrawers.SuspendLayout();
            this.SuspendLayout();
            // 
            // picturePreview
            // 
            this.picturePreview.Location = new System.Drawing.Point(2, 33);
            this.picturePreview.Margin = new System.Windows.Forms.Padding(2, 3, 0, 3);
            this.picturePreview.Name = "picturePreview";
            this.picturePreview.Size = new System.Drawing.Size(195, 187);
            this.picturePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturePreview.TabIndex = 4;
            this.picturePreview.TabStop = false;
            // 
            // flowDrawerItem
            // 
            this.flowDrawerItem.Controls.Add(this.flowItem);
            this.flowDrawerItem.Controls.Add(this.lblArrow);
            this.flowDrawerItem.Location = new System.Drawing.Point(0, 0);
            this.flowDrawerItem.Margin = new System.Windows.Forms.Padding(0);
            this.flowDrawerItem.Name = "flowDrawerItem";
            this.flowDrawerItem.Size = new System.Drawing.Size(255, 380);
            this.flowDrawerItem.TabIndex = 6;
            this.flowDrawerItem.Visible = false;
            // 
            // flowItem
            // 
            this.flowItem.Controls.Add(this.lblName);
            this.flowItem.Controls.Add(this.picturePreview);
            this.flowItem.Controls.Add(this.chkVisible);
            this.flowItem.Controls.Add(this.lblOpacity);
            this.flowItem.Controls.Add(this.trackOpacity);
            this.flowItem.Controls.Add(this.btnChangeAsset);
            this.flowItem.Controls.Add(this.btnShift);
            this.flowItem.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowItem.Location = new System.Drawing.Point(3, 3);
            this.flowItem.Name = "flowItem";
            this.flowItem.Size = new System.Drawing.Size(200, 375);
            this.flowItem.TabIndex = 7;
            this.flowItem.WrapContents = false;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Margin = new System.Windows.Forms.Padding(0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(200, 30);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "NAME";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkVisible
            // 
            this.chkVisible.Checked = true;
            this.chkVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVisible.Location = new System.Drawing.Point(5, 226);
            this.chkVisible.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(190, 17);
            this.chkVisible.TabIndex = 8;
            this.chkVisible.Text = "Visible";
            this.chkVisible.UseVisualStyleBackColor = true;
            // 
            // lblOpacity
            // 
            this.lblOpacity.Location = new System.Drawing.Point(3, 246);
            this.lblOpacity.Name = "lblOpacity";
            this.lblOpacity.Size = new System.Drawing.Size(190, 13);
            this.lblOpacity.TabIndex = 10;
            this.lblOpacity.Text = "Opacity";
            // 
            // trackOpacity
            // 
            this.trackOpacity.LargeChange = 25;
            this.trackOpacity.Location = new System.Drawing.Point(3, 262);
            this.trackOpacity.Maximum = 100;
            this.trackOpacity.Name = "trackOpacity";
            this.trackOpacity.Size = new System.Drawing.Size(194, 45);
            this.trackOpacity.SmallChange = 5;
            this.trackOpacity.TabIndex = 9;
            this.trackOpacity.Value = 100;
            // 
            // btnChangeAsset
            // 
            this.btnChangeAsset.Location = new System.Drawing.Point(3, 313);
            this.btnChangeAsset.Name = "btnChangeAsset";
            this.btnChangeAsset.Size = new System.Drawing.Size(194, 23);
            this.btnChangeAsset.TabIndex = 7;
            this.btnChangeAsset.Text = "Change asset";
            this.btnChangeAsset.UseVisualStyleBackColor = true;
            // 
            // btnShift
            // 
            this.btnShift.Location = new System.Drawing.Point(3, 342);
            this.btnShift.Name = "btnShift";
            this.btnShift.Size = new System.Drawing.Size(194, 23);
            this.btnShift.TabIndex = 11;
            this.btnShift.Text = "Shift";
            this.btnShift.UseVisualStyleBackColor = true;
            this.btnShift.Visible = false;
            // 
            // lblArrow
            // 
            this.lblArrow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblArrow.Location = new System.Drawing.Point(206, 0);
            this.lblArrow.Margin = new System.Windows.Forms.Padding(0);
            this.lblArrow.Name = "lblArrow";
            this.lblArrow.Size = new System.Drawing.Size(45, 381);
            this.lblArrow.TabIndex = 8;
            this.lblArrow.Text = ">";
            this.lblArrow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowDrawers
            // 
            this.flowDrawers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowDrawers.AutoScroll = true;
            this.flowDrawers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowDrawers.Controls.Add(this.flowDrawerItem);
            this.flowDrawers.Location = new System.Drawing.Point(12, 12);
            this.flowDrawers.Name = "flowDrawers";
            this.flowDrawers.Size = new System.Drawing.Size(563, 773);
            this.flowDrawers.TabIndex = 7;
            // 
            // btnExportLayers
            // 
            this.btnExportLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportLayers.Location = new System.Drawing.Point(12, 791);
            this.btnExportLayers.Name = "btnExportLayers";
            this.btnExportLayers.Size = new System.Drawing.Size(135, 23);
            this.btnExportLayers.TabIndex = 8;
            this.btnExportLayers.Text = "Export layered images";
            this.btnExportLayers.UseVisualStyleBackColor = true;
            this.btnExportLayers.Click += new System.EventHandler(this.btnExportLayers_Click);
            // 
            // folderExportLayered
            // 
            this.folderExportLayered.Description = "Exports the individual layers of your custom.";
            // 
            // Builder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 825);
            this.Controls.Add(this.btnExportLayers);
            this.Controls.Add(this.flowDrawers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Builder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Builder";
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).EndInit();
            this.flowDrawerItem.ResumeLayout(false);
            this.flowItem.ResumeLayout(false);
            this.flowItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackOpacity)).EndInit();
            this.flowDrawers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picturePreview;
        private System.Windows.Forms.FlowLayoutPanel flowDrawerItem;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.FlowLayoutPanel flowItem;
        private System.Windows.Forms.Button btnChangeAsset;
        private System.Windows.Forms.Label lblArrow;
        private System.Windows.Forms.CheckBox chkVisible;
        private System.Windows.Forms.Label lblOpacity;
        private System.Windows.Forms.TrackBar trackOpacity;
        private System.Windows.Forms.FlowLayoutPanel flowDrawers;
        private System.Windows.Forms.Button btnShift;
        private System.Windows.Forms.Button btnExportLayers;
        private System.Windows.Forms.FolderBrowserDialog folderExportLayered;
    }
}