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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorsView));
            this.btnDone = new System.Windows.Forms.Button();
            this.mainLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.presetsLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.presetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.presetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(3, 3);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(366, 23);
            this.btnDone.TabIndex = 17;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.AutoSize = true;
            this.mainLayoutPanel.Controls.Add(this.presetsLayoutPanel);
            this.mainLayoutPanel.Controls.Add(this.flowLayoutPanel1);
            this.mainLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.mainLayoutPanel.Margin = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.Size = new System.Drawing.Size(378, 102);
            this.mainLayoutPanel.TabIndex = 21;
            // 
            // presetsLayoutPanel
            // 
            this.presetsLayoutPanel.AutoSize = true;
            this.presetsLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.presetsLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.presetsLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.presetsLayoutPanel.Name = "presetsLayoutPanel";
            this.presetsLayoutPanel.Size = new System.Drawing.Size(0, 0);
            this.presetsLayoutPanel.TabIndex = 18;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.btnDone);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 9);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(372, 29);
            this.flowLayoutPanel1.TabIndex = 19;
            // 
            // presetBindingSource
            // 
            this.presetBindingSource.DataSource = typeof(Innovation_Uniform_Editor_Backend.Models.Preset);
            // 
            // ColorsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(393, 133);
            this.Controls.Add(this.mainLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ColorsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ColorsView";
            this.mainLayoutPanel.ResumeLayout(false);
            this.mainLayoutPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.presetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.BindingSource presetBindingSource;
        private System.Windows.Forms.FlowLayoutPanel mainLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel presetsLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}