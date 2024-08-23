using Cyotek.Windows.Forms;
using Innovation_Uniform_Editor.Classes;
using Innovation_Uniform_Editor.Classes.Helpers;
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
    public partial class ColorDetail : Form
    {
        private EventHandler onChanged;

        public event EventHandler ColorChanged
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

        private int _currentColorIndex = 0;

        private CustomColor _color;
        private ColorPickerDialog _pickerDialog;
        public ColorDetail(CustomColor color)
        {
            ColorPickerDialog dialog = new ColorPickerDialog();
            dialog.PreviewColorChanged += colorDialogueChanged;
            dialog.Validated += colorDialogueChanged;

            _pickerDialog = dialog;

            _color = color;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            this.flowColors.Controls.Clear();

            for (int i = 0; i < _color.Colors.Count; i++)
            {
                this.flowColors.Controls.Add(CreateColorButton(i, i != 0));
            }
            this.flowColors.Controls.Add(CreatePlusButton());

            repeatNumeric.Value = _color.Repeat;
        }
        private Button CreatePlusButton()
        {
            Button button = new Button();
            // 
            // btnPlus
            // 
            button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            button.AutoSize = true;
            button.Location = new System.Drawing.Point(2, 35);
            button.Margin = new System.Windows.Forms.Padding(2);
            button.Name = "btnPlus";
            button.Size = new System.Drawing.Size(215, 24);
            button.TabIndex = 13;
            button.Text = "+";
            button.UseVisualStyleBackColor = true;

            button.MouseClick += btnPlus_Click;

            return button;
        }
        private Control CreateColorButton(int index, bool delete = true)
        {
            Control result;

            Button btnColor = new Button();
            // 
            // btnColor_0
            // 
            btnColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            btnColor.AutoSize = true;
            btnColor.Margin = new System.Windows.Forms.Padding(2);
            btnColor.Name = $"btnColor_{index}";
            btnColor.Size = new System.Drawing.Size(187, 24);
            btnColor.TabIndex = 11;
            btnColor.Text = $"Color {index + 1}";
            btnColor.UseVisualStyleBackColor = true;

            btnColor.MouseClick += btnColor_Click;

            if (delete)
            {
                Button btnRemove = new Button();
                // 
                // btnRemove
                // 
                btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                btnRemove.AutoSize = true;
                btnRemove.Location = new System.Drawing.Point(193, 2);
                btnRemove.Margin = new System.Windows.Forms.Padding(2);
                btnRemove.Name = $"btnRemove_{index}";
                btnRemove.Size = new System.Drawing.Size(24, 24);
                btnRemove.TabIndex = 12;
                btnRemove.Text = "X";
                btnRemove.UseVisualStyleBackColor = true;

                btnRemove.MouseClick += btnRemove_Click;

                FlowLayoutPanel removePanel = new FlowLayoutPanel();
                // 
                // flowColorRemove
                // 
                removePanel.Controls.Add(btnColor);
                removePanel.Controls.Add(btnRemove);
                removePanel.Location = new System.Drawing.Point(0, 3);
                removePanel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
                removePanel.Name = "flowColorRemove";
                removePanel.Size = new System.Drawing.Size(219, 30);
                removePanel.TabIndex = 14;

                result = removePanel;
            } else
            {
                result = btnColor;
                btnColor.Size = new System.Drawing.Size(215, 24);
            }

            return result;
        }

        private void colorDialogueChanged(object sender, EventArgs e)
        {
            _color.ChangeColorAtIndex(_currentColorIndex, _pickerDialog.Color);
            onChanged?.Invoke(this, null);
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            int index = NamePressHelper.Get(sender, "btnColor");

            _currentColorIndex = index;

            _pickerDialog.Color = _color.Colors[index];
            _pickerDialog.ShowDialog();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int index = NamePressHelper.Get(sender, "btnRemove");
            _color.Colors.RemoveAt(index);
            Initialize();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            _color.Colors.Add(Color.Transparent);
            onChanged?.Invoke(this, null);
            Initialize();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void repeatNumeric_ValueChanged(object sender, EventArgs e)
        {
            _color.Repeat = Convert.ToInt32(((NumericUpDown)sender).Value);
            onChanged?.Invoke(this, null);
        }
    }
}
