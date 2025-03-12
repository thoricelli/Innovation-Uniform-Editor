using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using System.Drawing;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor.UI.Generic
{
    partial class GenericSelector<TType, TId> : Form where TType : IIdentifier<TId>, IPreviewable<Image>
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
        protected virtual void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenericSelector<TType, TId>));
            this.flowLayoutBackgrounds = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBGTemplate = new System.Windows.Forms.PictureBox();
            this.panelItem = new System.Windows.Forms.Panel();
            this.pictureItem = new System.Windows.Forms.PictureBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClearCurrent = new System.Windows.Forms.Button();
            this.flowLayoutBackgrounds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBGTemplate)).BeginInit();
            this.panelItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.flowLayoutBackgrounds.Controls.Add(this.panelItem);
            this.flowLayoutBackgrounds.Controls.Add(this.pictureBox1);
            this.flowLayoutBackgrounds.Location = new System.Drawing.Point(16, 15);
            this.flowLayoutBackgrounds.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutBackgrounds.Name = "flowLayoutBackgrounds";
            this.flowLayoutBackgrounds.Size = new System.Drawing.Size(935, 297);
            this.flowLayoutBackgrounds.TabIndex = 0;
            // 
            // pictureBGTemplate
            // 
            this.pictureBGTemplate.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBGTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBGTemplate.Location = new System.Drawing.Point(13, 12);
            this.pictureBGTemplate.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.pictureBGTemplate.Name = "pictureBGTemplate";
            this.pictureBGTemplate.Size = new System.Drawing.Size(266, 258);
            this.pictureBGTemplate.TabIndex = 0;
            this.pictureBGTemplate.TabStop = false;
            this.pictureBGTemplate.Visible = false;
            // 
            // panelItem
            // 
            this.panelItem.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelItem.Controls.Add(this.pictureItem);
            this.panelItem.Controls.Add(this.lblItem);
            this.panelItem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panelItem.Location = new System.Drawing.Point(305, 12);
            this.panelItem.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.panelItem.Name = "panelItem";
            this.panelItem.Size = new System.Drawing.Size(266, 258);
            this.panelItem.TabIndex = 6;
            // 
            // pictureItem
            // 
            this.pictureItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureItem.Location = new System.Drawing.Point(3, 2);
            this.pictureItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.pictureItem.Name = "pictureItem";
            this.pictureItem.Size = new System.Drawing.Size(261, 228);
            this.pictureItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureItem.TabIndex = 1;
            this.pictureItem.TabStop = false;
            // 
            // lblItem
            // 
            this.lblItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItem.Location = new System.Drawing.Point(3, 231);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(261, 27);
            this.lblItem.TabIndex = 0;
            this.lblItem.Text = "Item name";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(597, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(266, 258);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(851, 332);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 31);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(743, 332);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 31);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClearCurrent
            // 
            this.btnClearCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearCurrent.Location = new System.Drawing.Point(620, 332);
            this.btnClearCurrent.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearCurrent.Name = "btnClearCurrent";
            this.btnClearCurrent.Size = new System.Drawing.Size(115, 28);
            this.btnClearCurrent.TabIndex = 4;
            this.btnClearCurrent.Text = "Clear current";
            this.btnClearCurrent.UseVisualStyleBackColor = true;
            this.btnClearCurrent.Click += new System.EventHandler(this.btnClearCurrent_Click);
            // 
            // GenericSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 375);
            this.Controls.Add(this.btnClearCurrent);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.flowLayoutBackgrounds);
            this.ShowIcon = false;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GenericSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GenericSelector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BackgroundSelector_FormClosing);
            this.flowLayoutBackgrounds.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBGTemplate)).EndInit();
            this.panelItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        protected System.Windows.Forms.FlowLayoutPanel flowLayoutBackgrounds;
        protected System.Windows.Forms.Button btnOK;
        protected System.Windows.Forms.Button btnCancel;
        protected System.Windows.Forms.PictureBox pictureBGTemplate;
        protected System.Windows.Forms.Button btnClearCurrent;

        #endregion

        private Panel panelItem;
        private PictureBox pictureItem;
        private Label lblItem;
        protected PictureBox pictureBox1;
    }
}