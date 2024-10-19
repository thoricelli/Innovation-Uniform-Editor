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
    public partial class BottomSelector : GenericSelector<Bottom, Guid>
    {
        public BottomSelector() : base(EditorMain.BottomsLoader)
        {
        }
        public BottomSelector(Guid bottomId) : base(bottomId, EditorMain.BottomsLoader)
        {
        }
    }
}
