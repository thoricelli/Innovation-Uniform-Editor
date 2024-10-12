using Innovation_Uniform_Editor.UI.Generic;
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

namespace Innovation_Uniform_Editor.UI.OverlayAssets
{
    public partial class HolsterSelector : Form
    {
        private GenericSelector<Holster, Guid> genericSelector;
        public HolsterSelector()
        {
            genericSelector = new GenericSelector<Holster, Guid>(this, EditorMain.HolstersLoader);
            InitializeComponent();
        }
    }
}
