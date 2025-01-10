namespace Innovation_Uniform_Editor.UI
{
    partial class ColorsView
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
            this.lblColors = new System.Windows.Forms.Label();
            this.comboPresets = new System.Windows.Forms.ComboBox();
            this.presetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.presetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblColors
            // 
            this.lblColors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblColors.Location = new System.Drawing.Point(12, 9);
            this.lblColors.Name = "lblColors";
            this.lblColors.Size = new System.Drawing.Size(226, 13);
            this.lblColors.TabIndex = 15;
            this.lblColors.Text = "Preset";
            this.lblColors.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboPresets
            // 
            this.comboPresets.DataSource = this.presetBindingSource;
            this.comboPresets.DisplayMember = "Name";
            this.comboPresets.FormattingEnabled = true;
            this.comboPresets.Location = new System.Drawing.Point(15, 34);
            this.comboPresets.Name = "comboPresets";
            this.comboPresets.Size = new System.Drawing.Size(223, 21);
            this.comboPresets.TabIndex = 16;
            // 
            // presetBindingSource
            // 
            this.presetBindingSource.DataSource = typeof(Innovation_Uniform_Editor_Backend.Models.Preset);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(223, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Manage presets (TODO)";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ColorsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 101);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboPresets);
            this.Controls.Add(this.lblColors);
            this.Name = "ColorsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ColorsView";
            ((System.ComponentModel.ISupportInitialize)(this.presetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblColors;
        private System.Windows.Forms.ComboBox comboPresets;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource presetBindingSource;
    }
}