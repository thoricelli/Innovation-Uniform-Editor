using Innovation_Uniform_Editor_Backend;
using Innovation_Uniform_Editor_Backend.Models;
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
        private EventHandler<Preset> onChanged;

        public event EventHandler<Preset> PresetChanged
        {
            add
            {
                onChanged += value;
            }
            remove
            {
                onChanged -= value;
            }
        }
        public ColorsView(Preset preset)
        {
            InitializeComponent();

            List<Preset> presets = EditorMain.PresetsLoader.GetAll();

            comboPresets.DataSource = presets;
            comboPresets.SelectedIndex = presets.IndexOf(preset);
        }

        private void comboPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            onChanged?.Invoke(this, (Preset)comboPresets.SelectedValue);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
