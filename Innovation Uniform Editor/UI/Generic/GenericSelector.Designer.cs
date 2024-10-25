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
            this.flowLayoutBackgrounds = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBGTemplate = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClearCurrent = new System.Windows.Forms.Button();
            this.flowLayoutBackgrounds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBGTemplate)).BeginInit();
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
            this.pictureBGTemplate.Location = new System.Drawing.Point(10, 10);
            this.pictureBGTemplate.Margin = new System.Windows.Forms.Padding(10);
            this.pictureBGTemplate.Name = "pictureBGTemplate";
            this.pictureBGTemplate.Size = new System.Drawing.Size(200, 210);
            this.pictureBGTemplate.TabIndex = 0;
            this.pictureBGTemplate.TabStop = false;
            this.pictureBGTemplate.Visible = false;
            this.pictureBGTemplate.BorderStyle = BorderStyle.FixedSingle;
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
            // btnClearCurrent
            // 
            this.btnClearCurrent.Location = new System.Drawing.Point(444, 261);
            this.btnClearCurrent.Name = "btnClearCurrent";
            this.btnClearCurrent.Size = new System.Drawing.Size(86, 23);
            this.btnClearCurrent.TabIndex = 4;
            this.btnClearCurrent.Text = "Clear current";
            this.btnClearCurrent.UseVisualStyleBackColor = true;
            this.btnClearCurrent.Click += new System.EventHandler(this.btnClearCurrent_Click);
            this.btnClearCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // GenericSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 296);
            this.Controls.Add(this.btnClearCurrent);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.flowLayoutBackgrounds);
            //original.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GenericSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GenericSelector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BackgroundSelector_FormClosing);
            this.flowLayoutBackgrounds.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBGTemplate)).EndInit();
            this.ResumeLayout(false);
        }

        protected System.Windows.Forms.FlowLayoutPanel flowLayoutBackgrounds;
        protected System.Windows.Forms.Button btnOK;
        protected System.Windows.Forms.Button btnCancel;
        protected System.Windows.Forms.PictureBox pictureBGTemplate;
        protected System.Windows.Forms.Button btnClearCurrent;

        #endregion
    }
}