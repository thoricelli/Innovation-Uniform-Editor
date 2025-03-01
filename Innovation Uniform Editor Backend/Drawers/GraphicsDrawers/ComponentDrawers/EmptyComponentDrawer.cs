using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.ComponentDrawers.Bases;
using Innovation_Uniform_Editor_Backend.ImageEditors.Interface;
using Innovation_Uniform_Editor_Backend.Models;
using Innovation_Uniform_Editor_Backend.Models.Enums;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.ComponentDrawers
{
    public class EmptyComponentDrawer : ComponentDrawerBase
    {
        public EmptyComponentDrawer(double endPercentage) : base(endPercentage, ColorDrawerTypes.EMPTY, BlendMode.None)
        {
        }
        public override void Draw(CustomColor current, IImageEditor upperImage, IImageEditor lowerImage, int index, double progress, float transparency)
        {
            //Do nothing lol
        }
    }
}
