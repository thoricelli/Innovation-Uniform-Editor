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
            this.btnDone = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
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
            this.comboPresets.SelectedIndexChanged += new System.EventHandler(this.comboPresets_SelectedIndexChanged);
            // 
            // presetBindingSource
            // 
            this.presetBindingSource.DataSource = typeof(Innovation_Uniform_Editor_Backend.Models.Preset);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(15, 61);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(223, 23);
            this.btnDone.TabIndex = 17;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(223, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Manage presets (TODO)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // ColorsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 101);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnDone);
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
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.BindingSource presetBindingSource;
        private System.Windows.Forms.Button button2;
    }
}