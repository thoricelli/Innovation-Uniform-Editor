namespace Innovation_Uniform_Editor.UI
{
    partial class BackgroundSelector
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        protected override void InitializeComponent()
        {
            base.InitializeComponent();
            this.Text = "Background Selector";
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
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

            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);

            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { deleteToolStripMenuItem });
            this.menuStrip.Name = "menuStripItem";
            this.menuStrip.Size = new System.Drawing.Size(156, 158);
        }

        protected System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        protected System.Windows.Forms.Button btnBackground;
        protected System.Windows.Forms.ContextMenuStrip menuStrip;
        protected System.Windows.Forms.OpenFileDialog backgroundDialog;
        #endregion
    }
}