using Innovation_Uniform_Editor_Backend.ImageEditors.Interface;
using Innovation_Uniform_Editor_Backend.Models;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.ComponentDrawers.Interfaces
{
    public interface IComponentInterface
    {
        /// <summary>
        /// Draw a component
        /// </summary>
        /// <param name="current">The current custom color.</param>
        /// <param name="upperImage">The (result) / upper image.</param>
        /// <param name="lowerImage">The image below this layer.</param>
        /// <param name="index">The current pixel index.</param>
        /// <param name="progress">The current progress of this component</param>
        void Draw(CustomColor current, IImageEditor upperImage, IImageEditor lowerImage, int index, double progress);
    }
}
