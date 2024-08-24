using Innovation_Uniform_Editor.Classes;
using Innovation_Uniform_Editor.Enums;
using Innovation_Uniform_Editor.UI;
using System;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor
{
    public partial class Selector : Form
    {
        private UniformDropDown Handler;
        private ClothingPart part;

        private bool showParent = true;

        private Main parent;

        public Selector(ClothingPart cPart, Main main)
        {
            parent = main;
            part = cPart;
            Handler = new UniformDropDown(part);
            InitializeComponent();
        }

        private void Selector_Load(object sender, EventArgs e)
        {
            dropdownUniforms.DataSource = Handler.uniforms;

            boxPreview.Image = Handler.LoadUniformPreview();
        }

        private void dropdownUniforms_SelectedIndexChanged(object sender, EventArgs e)
        {
            Handler.UniformFromIndex((int)((ComboBox)sender).SelectedIndex);
            boxPreview.Image = Handler.LoadUniformPreview();

        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            boxPreview.Image = Handler.NextUniform();
            dropdownUniforms.SelectedIndex = Handler.currentUniform;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            boxPreview.Image = Handler.PreviousUniform();
            dropdownUniforms.SelectedIndex = Handler.currentUniform;
        }
        Editor editor;
        private void btnCreate_Click(object sender, EventArgs e)
        {
            //JSONtoUniform.
            Custom custom = new Custom();
            //JSONtoUniform.AddCustom(custom);
            custom.ChangeUniform(Handler.SelectedUniform);
            editor = new Editor(custom, parent);
            editor.Show();
            showParent = false;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Selector_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (showParent)
            {
                parent.Show();
            }
        }
    }
}
