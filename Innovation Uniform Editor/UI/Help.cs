﻿using System.Windows.Forms;

namespace Innovation_Uniform_Editor.UI
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://discord.gg/6hmMXfgQrR");
        }
    }
}
