﻿using Innovation_Uniform_Editor.UI.Generic;
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
    public partial class ArmbandSelector : GenericSelector<Armband, Guid>
    {
        public ArmbandSelector() : base(EditorMain.ArmbandsLoader)
        {
        }
        public ArmbandSelector(Guid armbandId) : base(armbandId, EditorMain.ArmbandsLoader)
        {
        }
    }
}
