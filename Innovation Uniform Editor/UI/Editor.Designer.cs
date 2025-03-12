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
            this.exportToFile = new System.Windows.Forms.ToolStripMenuItem();
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
            this.saveCustom = new System.Windows.Forms.SaveFileDialog();
            this.idLabel = new System.Windows.Forms.Label();
            this.buttonsLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnWarnings = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.divide1 = new System.Windows.Forms.Label();
            this.btnManageHolsters = new System.Windows.Forms.Button();
            this.btnManageArmbands = new System.Windows.Forms.Button();
            this.btnManageGloves = new System.Windows.Forms.Button();
            this.btnManageShoes = new System.Windows.Forms.Button();
            this.btnLogoColors = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDrawDetail = new System.Windows.Forms.Button();
            this.saveToFile = new System.Windows.Forms.SaveFileDialog();
            this.btnOpenFolder = new System.Windows.Forms.Button();
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
            this.pictureUniform.Location = new System.Drawing.Point(9, 27);
            this.pictureUniform.Margin = new System.Windows.Forms.Padding(2);
            this.pictureUniform.Name = "pictureUniform";
            this.pictureUniform.Size = new System.Drawing.Size(526, 535);
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(736, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem1,
            this.exportToFile});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // downloadToolStripMenuItem1
            // 
            this.downloadToolStripMenuItem1.Name = "downloadToolStripMenuItem1";
            this.downloadToolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.downloadToolStripMenuItem1.Text = "Download";
            this.downloadToolStripMenuItem1.Click += new System.EventHandler(this.downloadToolStripMenuItem1_Click);
            // 
            // exportToFile
            // 
            this.exportToFile.Name = "exportToFile";
            this.exportToFile.Size = new System.Drawing.Size(128, 22);
            this.exportToFile.Text = "To file";
            this.exportToFile.Click += new System.EventHandler(this.exportToFile_Click);
            // 
            // newTabToolStripMenuItem
            // 
            this.newTabToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pantsToolStripMenuItem,
            this.shirtsToolStripMenuItem});
            this.newTabToolStripMenuItem.Name = "newTabToolStripMenuItem";
            this.newTabToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.newTabToolStripMenuItem.Text = "New tab";
            // 
            // pantsToolStripMenuItem
            // 
            this.pantsToolStripMenuItem.Name = "pantsToolStripMenuItem";
            this.pantsToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.pantsToolStripMenuItem.Text = "Pants";
            this.pantsToolStripMenuItem.Click += new System.EventHandler(this.pantsToolStripMenuItem_Click);
            // 
            // shirtsToolStripMenuItem
            // 
            this.shirtsToolStripMenuItem.Name = "shirtsToolStripMenuItem";
            this.shirtsToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.shirtsToolStripMenuItem.Text = "Shirts";
            this.shirtsToolStripMenuItem.Click += new System.EventHandler(this.shirtsToolStripMenuItem_Click);
            // 
            // dropdownUniforms
            // 
            this.dropdownUniforms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dropdownUniforms.DataSource = this.uniformBindingSource;
            this.dropdownUniforms.DisplayMember = "Name";
            this.dropdownUniforms.FormattingEnabled = true;
            this.dropdownUniforms.Location = new System.Drawing.Point(541, 541);
            this.dropdownUniforms.Name = "dropdownUniforms";
            this.dropdownUniforms.Size = new System.Drawing.Size(189, 21);
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
            this.menuEditor.Size = new System.Drawing.Size(189, 48);
            // 
            // redrawUniformToolStripMenuItem
            // 
            this.redrawUniformToolStripMenuItem.Name = "redrawUniformToolStripMenuItem";
            this.redrawUniformToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.redrawUniformToolStripMenuItem.Text = "Force redraw uniform";
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            // 
            // btnBackgroundImage
            // 
            this.btnBackgroundImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackgroundImage.Location = new System.Drawing.Point(0, 2);
            this.btnBackgroundImage.Margin = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.btnBackgroundImage.Name = "btnBackgroundImage";
            this.btnBackgroundImage.Size = new System.Drawing.Size(188, 24);
            this.btnBackgroundImage.TabIndex = 10;
            this.btnBackgroundImage.Text = "Select background image";
            this.btnBackgroundImage.UseVisualStyleBackColor = true;
            this.btnBackgroundImage.Click += new System.EventHandler(this.btnBackgroundImage_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsername.Location = new System.Drawing.Point(541, 514);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 20);
            this.lblUsername.TabIndex = 12;
            this.lblUsername.Text = "Username:";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUsername.Visible = false;
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(597, 515);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(132, 20);
            this.txtUsername.TabIndex = 11;
            this.txtUsername.Visible = false;
            // 
            // saveCustom
            // 
            this.saveCustom.DefaultExt = "png";
            this.saveCustom.FileName = "Custom";
            // 
            // idLabel
            // 
            this.idLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.idLabel.Location = new System.Drawing.Point(541, 515);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(189, 24);
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
            this.buttonsLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.buttonsLayoutPanel.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.buttonsLayoutPanel.Name = "buttonsLayoutPanel";
            this.buttonsLayoutPanel.Size = new System.Drawing.Size(190, 28);
            this.buttonsLayoutPanel.TabIndex = 15;
            // 
            // btnWarnings
            // 
            this.btnWarnings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWarnings.Location = new System.Drawing.Point(642, 486);
            this.btnWarnings.Name = "btnWarnings";
            this.btnWarnings.Size = new System.Drawing.Size(88, 23);
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
            this.flowLayoutPanel1.Controls.Add(this.divide1);
            this.flowLayoutPanel1.Controls.Add(this.btnManageHolsters);
            this.flowLayoutPanel1.Controls.Add(this.btnManageArmbands);
            this.flowLayoutPanel1.Controls.Add(this.btnManageGloves);
            this.flowLayoutPanel1.Controls.Add(this.btnManageShoes);
            this.flowLayoutPanel1.Controls.Add(this.btnLogoColors);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.btnDrawDetail);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(538, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(196, 212);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // divide1
            // 
            this.divide1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divide1.Location = new System.Drawing.Point(3, 34);
            this.divide1.Name = "divide1";
            this.divide1.Size = new System.Drawing.Size(190, 2);
            this.divide1.TabIndex = 18;
            // 
            // btnManageHolsters
            // 
            this.btnManageHolsters.Location = new System.Drawing.Point(3, 39);
            this.btnManageHolsters.Name = "btnManageHolsters";
            this.btnManageHolsters.Size = new System.Drawing.Size(189, 23);
            this.btnManageHolsters.TabIndex = 19;
            this.btnManageHolsters.Text = "Holsters";
            this.btnManageHolsters.UseVisualStyleBackColor = true;
            this.btnManageHolsters.Click += new System.EventHandler(this.btnManageHolsters_Click);
            // 
            // btnManageArmbands
            // 
            this.btnManageArmbands.Location = new System.Drawing.Point(3, 68);
            this.btnManageArmbands.Name = "btnManageArmbands";
            this.btnManageArmbands.Size = new System.Drawing.Size(189, 23);
            this.btnManageArmbands.TabIndex = 20;
            this.btnManageArmbands.Text = "Armbands";
            this.btnManageArmbands.UseVisualStyleBackColor = true;
            this.btnManageArmbands.Click += new System.EventHandler(this.btnManageArmbands_Click);
            // 
            // btnManageGloves
            // 
            this.btnManageGloves.Location = new System.Drawing.Point(3, 97);
            this.btnManageGloves.Name = "btnManageGloves";
            this.btnManageGloves.Size = new System.Drawing.Size(189, 23);
            this.btnManageGloves.TabIndex = 23;
            this.btnManageGloves.Text = "Gloves";
            this.btnManageGloves.UseVisualStyleBackColor = true;
            this.btnManageGloves.Click += new System.EventHandler(this.btnManageGloves_Click);
            // 
            // btnManageShoes
            // 
            this.btnManageShoes.Location = new System.Drawing.Point(3, 126);
            this.btnManageShoes.Name = "btnManageShoes";
            this.btnManageShoes.Size = new System.Drawing.Size(189, 23);
            this.btnManageShoes.TabIndex = 21;
            this.btnManageShoes.Text = "Shoes";
            this.btnManageShoes.UseVisualStyleBackColor = true;
            this.btnManageShoes.Click += new System.EventHandler(this.btnManageShoes_Click);
            // 
            // btnLogoColors
            // 
            this.btnLogoColors.Location = new System.Drawing.Point(3, 155);
            this.btnLogoColors.Name = "btnLogoColors";
            this.btnLogoColors.Size = new System.Drawing.Size(189, 23);
            this.btnLogoColors.TabIndex = 24;
            this.btnLogoColors.Text = "Logo colors";
            this.btnLogoColors.UseVisualStyleBackColor = true;
            this.btnLogoColors.Click += new System.EventHandler(this.btnLogoColors_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(3, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 2);
            this.label2.TabIndex = 22;
            // 
            // btnDrawDetail
            // 
            this.btnDrawDetail.Location = new System.Drawing.Point(3, 186);
            this.btnDrawDetail.Name = "btnDrawDetail";
            this.btnDrawDetail.Size = new System.Drawing.Size(188, 23);
            this.btnDrawDetail.TabIndex = 17;
            this.btnDrawDetail.Text = "Manage drawing";
            this.btnDrawDetail.UseVisualStyleBackColor = true;
            this.btnDrawDetail.Click += new System.EventHandler(this.btnDrawDetail_Click);
            // 
            // saveToFile
            // 
            this.saveToFile.DefaultExt = "iue";
            this.saveToFile.FileName = "Custom";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFolder.Location = new System.Drawing.Point(641, 515);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(88, 23);
            this.btnOpenFolder.TabIndex = 19;
            this.btnOpenFolder.Text = "Open folder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 571);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnWarnings);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.dropdownUniforms);
            this.Controls.Add(this.pictureUniform);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.SaveFileDialog saveCustom;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.FlowLayoutPanel buttonsLayoutPanel;
        private System.Windows.Forms.Button btnWarnings;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnDrawDetail;
        private System.Windows.Forms.Label divide1;
        private System.Windows.Forms.ToolStripMenuItem newTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pantsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shirtsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToFile;
        private System.Windows.Forms.Button btnManageHolsters;
        private System.Windows.Forms.Button btnManageArmbands;
        private System.Windows.Forms.Button btnManageShoes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnManageGloves;
        private System.Windows.Forms.Button btnLogoColors;
        private System.Windows.Forms.SaveFileDialog saveToFile;
        private System.Windows.Forms.Button btnOpenFolder;
    }
}