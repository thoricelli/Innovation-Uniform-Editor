using Innovation_Uniform_Editor_Backend.Models;
using System.Drawing;

namespace Innovation_Uniform_Editor.UI
{
    partial class Editor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.pictureUniform = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportLayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pantsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shirtsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dropdownUniforms = new System.Windows.Forms.ComboBox();
            this.uniformBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuEditor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.redrawUniformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBackgroundImage = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.chkElite = new System.Windows.Forms.CheckBox();
            this.saveCustom = new System.Windows.Forms.SaveFileDialog();
            this.idLabel = new System.Windows.Forms.Label();
            this.buttonsLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.chkFading = new System.Windows.Forms.CheckBox();
            this.btnWarnings = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewTab = new System.Windows.Forms.Button();
            this.btnDrawDetail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUniform)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uniformBindingSource)).BeginInit();
            this.menuEditor.SuspendLayout();
            this.buttonsLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureUniform
            // 
            this.pictureUniform.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureUniform.Location = new System.Drawing.Point(12, 33);
            this.pictureUniform.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureUniform.Name = "pictureUniform";
            this.pictureUniform.Size = new System.Drawing.Size(701, 658);
            this.pictureUniform.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureUniform.TabIndex = 0;
            this.pictureUniform.TabStop = false;
            this.pictureUniform.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.newTabToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(981, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem1,
            this.exportLayersToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // downloadToolStripMenuItem1
            // 
            this.downloadToolStripMenuItem1.Name = "downloadToolStripMenuItem1";
            this.downloadToolStripMenuItem1.Size = new System.Drawing.Size(177, 26);
            this.downloadToolStripMenuItem1.Text = "Download";
            this.downloadToolStripMenuItem1.Click += new System.EventHandler(this.downloadToolStripMenuItem1_Click);
            // 
            // exportLayersToolStripMenuItem
            // 
            this.exportLayersToolStripMenuItem.Name = "exportLayersToolStripMenuItem";
            this.exportLayersToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.exportLayersToolStripMenuItem.Text = "Export layers";
            this.exportLayersToolStripMenuItem.Visible = false;
            this.exportLayersToolStripMenuItem.Click += new System.EventHandler(this.exportLayersToolStripMenuItem_Click);
            // 
            // newTabToolStripMenuItem
            // 
            this.newTabToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pantsToolStripMenuItem,
            this.shirtsToolStripMenuItem});
            this.newTabToolStripMenuItem.Name = "newTabToolStripMenuItem";
            this.newTabToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.newTabToolStripMenuItem.Text = "New tab";
            // 
            // pantsToolStripMenuItem
            // 
            this.pantsToolStripMenuItem.Name = "pantsToolStripMenuItem";
            this.pantsToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.pantsToolStripMenuItem.Text = "Pants";
            this.pantsToolStripMenuItem.Click += new System.EventHandler(this.pantsToolStripMenuItem_Click);
            // 
            // shirtsToolStripMenuItem
            // 
            this.shirtsToolStripMenuItem.Name = "shirtsToolStripMenuItem";
            this.shirtsToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.shirtsToolStripMenuItem.Text = "Shirts";
            this.shirtsToolStripMenuItem.Click += new System.EventHandler(this.shirtsToolStripMenuItem_Click);
            // 
            // dropdownUniforms
            // 
            this.dropdownUniforms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dropdownUniforms.DataSource = this.uniformBindingSource;
            this.dropdownUniforms.DisplayMember = "Name";
            this.dropdownUniforms.FormattingEnabled = true;
            this.dropdownUniforms.Location = new System.Drawing.Point(721, 666);
            this.dropdownUniforms.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dropdownUniforms.Name = "dropdownUniforms";
            this.dropdownUniforms.Size = new System.Drawing.Size(251, 24);
            this.dropdownUniforms.TabIndex = 9;
            this.dropdownUniforms.ValueMember = "Id";
            this.dropdownUniforms.SelectedIndexChanged += new System.EventHandler(this.dropdownUniforms_SelectedIndexChanged);
            // 
            // uniformBindingSource
            // 
            this.uniformBindingSource.DataSource = typeof(Innovation_Uniform_Editor_Backend.Models.Uniform);
            // 
            // menuEditor
            // 
            this.menuEditor.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redrawUniformToolStripMenuItem,
            this.downloadToolStripMenuItem});
            this.menuEditor.Name = "menuEditor";
            this.menuEditor.Size = new System.Drawing.Size(221, 52);
            // 
            // redrawUniformToolStripMenuItem
            // 
            this.redrawUniformToolStripMenuItem.Name = "redrawUniformToolStripMenuItem";
            this.redrawUniformToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.redrawUniformToolStripMenuItem.Text = "Force redraw uniform";
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(220, 24);
            this.downloadToolStripMenuItem.Text = "Download";
            // 
            // btnBackgroundImage
            // 
            this.btnBackgroundImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackgroundImage.Location = new System.Drawing.Point(0, 2);
            this.btnBackgroundImage.Margin = new System.Windows.Forms.Padding(0, 2, 3, 2);
            this.btnBackgroundImage.Name = "btnBackgroundImage";
            this.btnBackgroundImage.Size = new System.Drawing.Size(251, 30);
            this.btnBackgroundImage.TabIndex = 10;
            this.btnBackgroundImage.Text = "Select background image";
            this.btnBackgroundImage.UseVisualStyleBackColor = true;
            this.btnBackgroundImage.Click += new System.EventHandler(this.btnBackgroundImage_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsername.Location = new System.Drawing.Point(721, 633);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(77, 25);
            this.lblUsername.TabIndex = 12;
            this.lblUsername.Text = "Username:";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUsername.Visible = false;
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(796, 634);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(175, 22);
            this.txtUsername.TabIndex = 11;
            this.txtUsername.Visible = false;
            // 
            // chkElite
            // 
            this.chkElite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkElite.Location = new System.Drawing.Point(720, 599);
            this.chkElite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkElite.Name = "chkElite";
            this.chkElite.Size = new System.Drawing.Size(99, 30);
            this.chkElite.TabIndex = 13;
            this.chkElite.Text = "Elite Logo";
            this.chkElite.UseVisualStyleBackColor = true;
            this.chkElite.Visible = false;
            // 
            // saveCustom
            // 
            this.saveCustom.DefaultExt = "png";
            this.saveCustom.FileName = "Custom";
            // 
            // idLabel
            // 
            this.idLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.idLabel.Location = new System.Drawing.Point(721, 634);
            this.idLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(252, 30);
            this.idLabel.TabIndex = 14;
            this.idLabel.Text = "0";
            this.idLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonsLayoutPanel
            // 
            this.buttonsLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonsLayoutPanel.AutoSize = true;
            this.buttonsLayoutPanel.Controls.Add(this.btnBackgroundImage);
            this.buttonsLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.buttonsLayoutPanel.Location = new System.Drawing.Point(3, 4);
            this.buttonsLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 4, 4, 4);
            this.buttonsLayoutPanel.Name = "buttonsLayoutPanel";
            this.buttonsLayoutPanel.Size = new System.Drawing.Size(254, 34);
            this.buttonsLayoutPanel.TabIndex = 15;
            // 
            // chkFading
            // 
            this.chkFading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFading.Location = new System.Drawing.Point(864, 601);
            this.chkFading.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkFading.Name = "chkFading";
            this.chkFading.Size = new System.Drawing.Size(101, 30);
            this.chkFading.TabIndex = 16;
            this.chkFading.Text = "One color";
            this.chkFading.UseVisualStyleBackColor = true;
            this.chkFading.Visible = false;
            // 
            // btnWarnings
            // 
            this.btnWarnings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWarnings.Location = new System.Drawing.Point(859, 635);
            this.btnWarnings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnWarnings.Name = "btnWarnings";
            this.btnWarnings.Size = new System.Drawing.Size(117, 28);
            this.btnWarnings.TabIndex = 17;
            this.btnWarnings.Text = "Warnings: (1)";
            this.btnWarnings.UseVisualStyleBackColor = true;
            this.btnWarnings.Visible = false;
            this.btnWarnings.Click += new System.EventHandler(this.btnWarnings_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.buttonsLayoutPanel);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.btnNewTab);
            this.flowLayoutPanel1.Controls.Add(this.btnDrawDetail);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(717, 33);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(261, 123);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(4, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 2);
            this.label1.TabIndex = 18;
            this.label1.Visible = false;
            // 
            // btnNewTab
            // 
            this.btnNewTab.Location = new System.Drawing.Point(4, 48);
            this.btnNewTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNewTab.Name = "btnNewTab";
            this.btnNewTab.Size = new System.Drawing.Size(252, 28);
            this.btnNewTab.TabIndex = 16;
            this.btnNewTab.Text = "New tab";
            this.btnNewTab.UseVisualStyleBackColor = true;
            this.btnNewTab.Visible = false;
            this.btnNewTab.Click += new System.EventHandler(this.btnSwitchType_Click);
            // 
            // btnDrawDetail
            // 
            this.btnDrawDetail.Location = new System.Drawing.Point(4, 84);
            this.btnDrawDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDrawDetail.Name = "btnDrawDetail";
            this.btnDrawDetail.Size = new System.Drawing.Size(251, 28);
            this.btnDrawDetail.TabIndex = 17;
            this.btnDrawDetail.Text = "Manage drawing";
            this.btnDrawDetail.UseVisualStyleBackColor = true;
            this.btnDrawDetail.Click += new System.EventHandler(this.btnDrawDetail_Click);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 703);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnWarnings);
            this.Controls.Add(this.chkFading);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.chkElite);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.dropdownUniforms);
            this.Controls.Add(this.pictureUniform);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Editor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Editor_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Editor_FormClosed);
            this.Load += new System.EventHandler(this.Editor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureUniform)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uniformBindingSource)).EndInit();
            this.menuEditor.ResumeLayout(false);
            this.buttonsLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureUniform;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ComboBox dropdownUniforms;
        private System.Windows.Forms.BindingSource uniformBindingSource;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip menuEditor;
        private System.Windows.Forms.ToolStripMenuItem redrawUniformToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.Button btnBackgroundImage;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.CheckBox chkElite;
        private System.Windows.Forms.SaveFileDialog saveCustom;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.FlowLayoutPanel buttonsLayoutPanel;
        private System.Windows.Forms.CheckBox chkFading;
        private System.Windows.Forms.Button btnWarnings;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnNewTab;
        private System.Windows.Forms.Button btnDrawDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem newTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pantsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shirtsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportLayersToolStripMenuItem;
    }
}