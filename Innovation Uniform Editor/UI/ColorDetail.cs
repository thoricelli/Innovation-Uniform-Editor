using Cyotek.Windows.Forms;
using Innovation_Uniform_Editor.Classes;
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
        private CustomColor _color;
        public ColorDetail(CustomColor color)
        {
            InitializeComponent();
        }
        private void Initialize()
        {

        }
        private Button CreateColorButton()
        {
            Button btnColor = new Button();
            return btnColor;
        }

        private ColorPickerDialog CreateDialog(string name)
        {
            ColorPickerDialog cd = new ColorPickerDialog();
            cd.Name = name;
            cd.PreviewColorChanged += UpdateColor;
            return cd;
        }

        public void UpdateColor(object sender, EventArgs e)
        {
            ColorPickerDialog cd = (ColorPickerDialog)sender;
            _color.Colors[Convert.ToInt32(
                    cd.Name.
                    Replace("color_", "")
                )] = cd.Color;
        }
    }
}
