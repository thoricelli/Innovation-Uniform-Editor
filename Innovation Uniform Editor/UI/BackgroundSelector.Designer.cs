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
        protected override void InitializeComponent()
        {
            base.InitializeComponent();
            this.Text = "BackgroundSelector";
            // 
            // btnBackground
            // 
            this.btnBackground = new System.Windows.Forms.Button();
            this.btnBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBackground.Location = new System.Drawing.Point(12, 261);
            this.btnBackground.Name = "btnBackground";
            this.btnBackground.Size = new System.Drawing.Size(114, 25);
            this.btnBackground.TabIndex = 3;
            this.btnBackground.Text = "Add background";
            this.btnBackground.UseVisualStyleBackColor = true;
            this.btnBackground.Click += new System.EventHandler(this.btnBackground_Click);
            this.Controls.Add(this.btnBackground);
            this.backgroundDialog = new System.Windows.Forms.OpenFileDialog();
        }

        protected System.Windows.Forms.Button btnBackground;
        protected System.Windows.Forms.OpenFileDialog backgroundDialog;
        #endregion
    }
}