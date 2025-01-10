using Innovation_Uniform_Editor_Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor.UI
{
    public partial class ColorsView : Form
    {
        public ColorsView()
        {
            InitializeComponent();

            comboPresets.DataSource = EditorMain.PresetsLoader.GetAll();
        }

        private void presetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
