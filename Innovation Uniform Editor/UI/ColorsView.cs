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
        List<Preset> presets;
        public ColorsView(Custom custom)
        {
            InitializeComponent();

            presets = EditorMain.PresetsLoader.GetAll();

            for (int i = 0; i < custom.Presets.Count; i++)
            {
                Preset preset = custom.Presets[i];

                presetsLayoutPanel.Controls.Add(CreatePresetFlowLayoutPanel(preset, i));
            }

        }

        private void comboPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            onChanged?.Invoke(sender, (Preset)((ComboBox)sender).SelectedValue);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private FlowLayoutPanel CreatePresetFlowLayoutPanel(Preset preset, int index)
        {
            ComboBox comboPresets = new ComboBox();
            Label lblLogo = new Label();
            FlowLayoutPanel presetLayoutPanel = new FlowLayoutPanel();

            BindingSource presetBinding = new BindingSource();
            presetBinding.DataSource = presets;
            comboPresets.DataSource = presetBinding;
            comboPresets.DisplayMember = "Name";
            presetBinding.Position = presets.IndexOf(preset);

            // 
            // comboPresets
            // 
            comboPresets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            comboPresets.DisplayMember = "Name";
            comboPresets.FormattingEnabled = true;
            comboPresets.Location = new System.Drawing.Point(3, 26);
            comboPresets.Name = $"comboPreset_{index}";
            comboPresets.Size = new System.Drawing.Size(363, 21);
            comboPresets.TabIndex = 16;
            comboPresets.SelectedIndexChanged += comboPresets_SelectedIndexChanged;
            // 
            // lblLogo
            // 
            lblLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            lblLogo.Location = new System.Drawing.Point(3, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new System.Drawing.Size(363, 23);
            lblLogo.TabIndex = 15;
            lblLogo.Text = $"Logo {index}";
            lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // presetLayoutPanel
            // 
            presetLayoutPanel.Controls.Add(lblLogo);
            presetLayoutPanel.Controls.Add(comboPresets);
            presetLayoutPanel.Location = new System.Drawing.Point(3, 3);
            presetLayoutPanel.Name = "presetLayoutPanel";
            presetLayoutPanel.Size = new System.Drawing.Size(366, 58);
            presetLayoutPanel.TabIndex = 22;

            
            return presetLayoutPanel;
        }
    }
}
