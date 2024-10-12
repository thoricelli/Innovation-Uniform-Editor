using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor.UI.Generic
{
    public partial class GenericSelector<TType, TId>
    {
        public void InitializeComponent(IContainer components)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenericSelector<TType, TId>));
            this.flowLayoutBackgrounds = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBGTemplate = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClearCurrent = new System.Windows.Forms.Button();
            this.flowLayoutBackgrounds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBGTemplate)).BeginInit();
            original.SuspendLayout();
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
            // 
            // GenericSelector
            // 
            original.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            original.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            original.ClientSize = new System.Drawing.Size(704, 296);
            original.Controls.Add(this.btnClearCurrent);
            original.Controls.Add(this.btnCancel);
            original.Controls.Add(this.btnOK);
            original.Controls.Add(this.flowLayoutBackgrounds);
            //original.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            original.Name = "GenericSelector";
            original.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            original.Text = "GenericSelector";
            original.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BackgroundSelector_FormClosing);
            this.flowLayoutBackgrounds.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBGTemplate)).EndInit();
            original.ResumeLayout(false);


            InitializeUniforms();
        }

        private System.Windows.Forms.FlowLayoutPanel flowLayoutBackgrounds;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pictureBGTemplate;
        private System.Windows.Forms.Button btnClearCurrent;


    }
}
