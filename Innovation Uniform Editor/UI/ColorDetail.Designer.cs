namespace Innovation_Uniform_Editor.UI
{
    partial class ColorDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorDetail));
            this.btnColor_0 = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.flowColors = new System.Windows.Forms.FlowLayoutPanel();
            this.flowColorRemove = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblFade = new System.Windows.Forms.Label();
            this.lblRepeat = new System.Windows.Forms.Label();
            this.repeatNumeric = new System.Windows.Forms.NumericUpDown();
            this.flowColors.SuspendLayout();
            this.flowColorRemove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repeatNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // btnColor_0
            // 
            this.btnColor_0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColor_0.AutoSize = true;
            this.btnColor_0.Location = new System.Drawing.Point(2, 2);
            this.btnColor_0.Margin = new System.Windows.Forms.Padding(2);
            this.btnColor_0.Name = "btnColor_0";
            this.btnColor_0.Size = new System.Drawing.Size(187, 24);
            this.btnColor_0.TabIndex = 11;
            this.btnColor_0.Text = "Color 1";
            this.btnColor_0.UseVisualStyleBackColor = true;
            // 
            // btnDone
            // 
            this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDone.Location = new System.Drawing.Point(9, 228);
            this.btnDone.Margin = new System.Windows.Forms.Padding(2);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(216, 24);
            this.btnDone.TabIndex = 12;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlus.AutoSize = true;
            this.btnPlus.Location = new System.Drawing.Point(2, 35);
            this.btnPlus.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(215, 24);
            this.btnPlus.TabIndex = 13;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            // 
            // flowColors
            // 
            this.flowColors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowColors.AutoScroll = true;
            this.flowColors.Controls.Add(this.flowColorRemove);
            this.flowColors.Controls.Add(this.btnPlus);
            this.flowColors.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowColors.Location = new System.Drawing.Point(9, 28);
            this.flowColors.Margin = new System.Windows.Forms.Padding(2);
            this.flowColors.Name = "flowColors";
            this.flowColors.Size = new System.Drawing.Size(219, 170);
            this.flowColors.TabIndex = 14;
            // 
            // flowColorRemove
            // 
            this.flowColorRemove.Controls.Add(this.btnColor_0);
            this.flowColorRemove.Controls.Add(this.btnRemove);
            this.flowColorRemove.Location = new System.Drawing.Point(0, 3);
            this.flowColorRemove.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.flowColorRemove.Name = "flowColorRemove";
            this.flowColorRemove.Size = new System.Drawing.Size(219, 30);
            this.flowColorRemove.TabIndex = 14;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.AutoSize = true;
            this.btnRemove.Location = new System.Drawing.Point(193, 2);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(24, 24);
            this.btnRemove.TabIndex = 12;
            this.btnRemove.Text = "X";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // lblFade
            // 
            this.lblFade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFade.Location = new System.Drawing.Point(14, 7);
            this.lblFade.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFade.Name = "lblFade";
            this.lblFade.Size = new System.Drawing.Size(210, 19);
            this.lblFade.TabIndex = 15;
            this.lblFade.Text = "Add another color to create a fade effect.";
            this.lblFade.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRepeat
            // 
            this.lblRepeat.Location = new System.Drawing.Point(6, 203);
            this.lblRepeat.Name = "lblRepeat";
            this.lblRepeat.Size = new System.Drawing.Size(53, 20);
            this.lblRepeat.TabIndex = 16;
            this.lblRepeat.Text = "Repeat:";
            this.lblRepeat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // repeatNumeric
            // 
            this.repeatNumeric.Location = new System.Drawing.Point(54, 203);
            this.repeatNumeric.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.repeatNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.repeatNumeric.Name = "repeatNumeric";
            this.repeatNumeric.Size = new System.Drawing.Size(174, 20);
            this.repeatNumeric.TabIndex = 17;
            this.repeatNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.repeatNumeric.ValueChanged += new System.EventHandler(this.repeatNumeric_ValueChanged);
            // 
            // ColorDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 261);
            this.Controls.Add(this.repeatNumeric);
            this.Controls.Add(this.lblRepeat);
            this.Controls.Add(this.lblFade);
            this.Controls.Add(this.flowColors);
            this.Controls.Add(this.btnDone);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ColorDetail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Color detail";
            this.flowColors.ResumeLayout(false);
            this.flowColors.PerformLayout();
            this.flowColorRemove.ResumeLayout(false);
            this.flowColorRemove.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repeatNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnColor_0;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.FlowLayoutPanel flowColors;
        private System.Windows.Forms.Label lblFade;
        private System.Windows.Forms.FlowLayoutPanel flowColorRemove;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblRepeat;
        private System.Windows.Forms.NumericUpDown repeatNumeric;
    }
}