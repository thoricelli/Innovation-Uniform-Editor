using Innovation_Uniform_Editor_Backend.Drawers.ComponentDrawers.Bases;
using Innovation_Uniform_Editor_Backend.ImageEditors.Interface;
using Innovation_Uniform_Editor_Backend.Models;
using Innovation_Uniform_Editor_Backend.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Drawers.ComponentDrawers
{
    public class EmptyComponentDrawer : ComponentDrawerBase
    {
        public EmptyComponentDrawer(double endPercentage) : base(endPercentage, ColorDrawerTypes.EMPTY, BlendMode.None)
        {
        }
        public override void Draw(CustomColor current, IImageEditor upperImage, IImageEditor lowerImage, int index, double progress)
        {
            //Do nothing lol
        }
    }
}
