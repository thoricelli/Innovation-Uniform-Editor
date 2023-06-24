namespace Innovation_Uniform_Editor.UI
{
    partial class BackgroundSelector
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackgroundSelector));
            this.flowLayoutBackgrounds = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBGTemplate = new System.Windows.Forms.PictureBox();
            this.contextBackground = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBackground = new System.Windows.Forms.Button();
            this.backgroundDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnClearCurrent = new System.Windows.Forms.Button();
            this.flowLayoutBackgrounds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBGTemplate)).BeginInit();
            this.contextBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutBackgrounds
            // 
            this.flowLayoutBackgrounds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutBackgrounds.AutoScroll = true;
            this.flowLayoutBackgrounds.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutBackgrounds.Controls.Add(this.pictureBGTemplate);
            this.flowLayoutBackgrounds.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutBackgrounds.Name = "flowLayoutBackgrounds";
            this.flowLayoutBackgrounds.Size = new System.Drawing.Size(681, 233);
            this.flowLayoutBackgrounds.TabIndex = 0;
            // 
            // pictureBGTemplate
            // 
            this.pictureBGTemplate.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBGTemplate.ContextMenuStrip = this.contextBackground;
            this.pictureBGTemplate.Location = new System.Drawing.Point(10, 10);
            this.pictureBGTemplate.Margin = new System.Windows.Forms.Padding(10);
            this.pictureBGTemplate.Name = "pictureBGTemplate";
            this.pictureBGTemplate.Size = new System.Drawing.Size(200, 210);
            this.pictureBGTemplate.TabIndex = 0;
            this.pictureBGTemplate.TabStop = false;
            this.pictureBGTemplate.Visible = false;
            // 
            // contextBackground
            // 
            this.contextBackground.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextBackground.Name = "contextBackground";
            this.contextBackground.Size = new System.Drawing.Size(129, 48);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(617, 261);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(536, 261);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBackground
            // 
            this.btnBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBackground.Location = new System.Drawing.Point(12, 261);
            this.btnBackground.Name = "btnBackground";
            this.btnBackground.Size = new System.Drawing.Size(114, 25);
            this.btnBackground.TabIndex = 3;
            this.btnBackground.Text = "Add background";
            this.btnBackground.UseVisualStyleBackColor = true;
            this.btnBackground.Click += new System.EventHandler(this.btnBackground_Click);
            // 
            // btnClearCurrent
            // 
            this.btnClearCurrent.Location = new System.Drawing.Point(444, 261);
            this.btnClearCurrent.Name = "btnClearCurrent";
            this.btnClearCurrent.Size = new System.Drawing.Size(86, 23);
            this.btnClearCurrent.TabIndex = 4;
            this.btnClearCurrent.Text = "Clear current";
            this.btnClearCurrent.UseVisualStyleBackColor = true;
            this.btnClearCurrent.Click += new System.EventHandler(this.btnClearCurrent_Click);
            // 
            // BackgroundSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 296);
            this.Controls.Add(this.btnClearCurrent);
            this.Controls.Add(this.btnBackground);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.flowLayoutBackgrounds);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BackgroundSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BackgroundSelector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BackgroundSelector_FormClosing);
            this.flowLayoutBackgrounds.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBGTemplate)).EndInit();
            this.contextBackground.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutBackgrounds;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBackground;
        private System.Windows.Forms.OpenFileDialog backgroundDialog;
        private System.Windows.Forms.PictureBox pictureBGTemplate;
        private System.Windows.Forms.ContextMenuStrip contextBackground;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button btnClearCurrent;
    }
}