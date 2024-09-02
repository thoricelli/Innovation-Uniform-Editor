using Innovation_Uniform_Editor_Backend.Models;

namespace Innovation_Uniform_Editor
{
    partial class Selector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Selector));
            this.boxPreview = new System.Windows.Forms.PictureBox();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSelector = new System.Windows.Forms.Label();
            this.dropdownUniforms = new System.Windows.Forms.ComboBox();
            this.uniformBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.boxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uniformBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // boxPreview
            // 
            this.boxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxPreview.Location = new System.Drawing.Point(38, 69);
            this.boxPreview.Margin = new System.Windows.Forms.Padding(2);
            this.boxPreview.Name = "boxPreview";
            this.boxPreview.Size = new System.Drawing.Size(432, 436);
            this.boxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.boxPreview.TabIndex = 0;
            this.boxPreview.TabStop = false;
            // 
            // btnLeft
            // 
            this.btnLeft.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLeft.Location = new System.Drawing.Point(8, 275);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(2);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(22, 24);
            this.btnLeft.TabIndex = 1;
            this.btnLeft.Text = "<";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRight.Location = new System.Drawing.Point(478, 275);
            this.btnRight.Margin = new System.Windows.Forms.Padding(2);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(22, 24);
            this.btnRight.TabIndex = 2;
            this.btnRight.Text = ">";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(425, 529);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 24);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Create!";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(8, 529);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSelector
            // 
            this.lblSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelector.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelector.Location = new System.Drawing.Point(8, 7);
            this.lblSelector.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelector.Name = "lblSelector";
            this.lblSelector.Size = new System.Drawing.Size(492, 21);
            this.lblSelector.TabIndex = 5;
            this.lblSelector.Text = "Uniform selector";
            this.lblSelector.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dropdownUniforms
            // 
            this.dropdownUniforms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dropdownUniforms.DataSource = this.uniformBindingSource;
            this.dropdownUniforms.DisplayMember = "Name";
            this.dropdownUniforms.FormattingEnabled = true;
            this.dropdownUniforms.Location = new System.Drawing.Point(8, 31);
            this.dropdownUniforms.Name = "dropdownUniforms";
            this.dropdownUniforms.Size = new System.Drawing.Size(492, 21);
            this.dropdownUniforms.TabIndex = 7;
            this.dropdownUniforms.ValueMember = "Id";
            this.dropdownUniforms.SelectedIndexChanged += new System.EventHandler(this.dropdownUniforms_SelectedIndexChanged);
            // 
            // uniformBindingSource
            // 
            this.uniformBindingSource.DataSource = typeof(Uniform);
            // 
            // Selector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 561);
            this.Controls.Add(this.dropdownUniforms);
            this.Controls.Add(this.lblSelector);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.boxPreview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Selector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selector";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Selector_FormClosed);
            this.Load += new System.EventHandler(this.Selector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.boxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uniformBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox boxPreview;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSelector;
        private System.Windows.Forms.ComboBox dropdownUniforms;
        private System.Windows.Forms.BindingSource uniformBindingSource;
    }
}