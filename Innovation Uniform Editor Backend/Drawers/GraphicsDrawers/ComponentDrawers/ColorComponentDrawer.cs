using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.ComponentDrawers.Bases;
using Innovation_Uniform_Editor_Backend.ImageEditors.Interface;
using Innovation_Uniform_Editor_Backend.Models;
using Innovation_Uniform_Editor_Backend.Models.Enums;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.ComponentDrawers
{
    /// <summary>
    /// Draws a solid color to a buffer.
    /// </summary>
    public class ColorComponentDrawer : ComponentDrawerBase
    {
        private ColorType colorType;
        private BlendMode blendMode;
        public ColorComponentDrawer(double endPercentage, ColorDrawerTypes type, ColorType colorType, BlendMode blendMode) : base(endPercentage, type, blendMode)
        {
            this.blendMode = blendMode;
            this.colorType = colorType;
        }

        public override void Draw(CustomColor current, IImageEditor upperImage, IImageEditor lowerImage, int index, double progress)
        {
            // Overlay pixel with color from lower layer.

            Color currentColor = Color.Transparent;

            switch (colorType)
            {
                case ColorType.FirstColor:
                    currentColor = GetColorFromCustomColor(current);
                    break;
                case ColorType.LastColor:
                    currentColor = current.GetColorAtIndex(current.Colors.Count - 1);
                    break;
            }

            Color lowerImageColor = lowerImage.GetPixelColorAtIndex(index);
            Color resultColor = currentColor;

            switch (blendMode) 
            {
                case BlendMode.Overlay:
                    resultColor = Overlay(
                        currentColor,
                        lowerImageColor
                    );
                    break;
                case BlendMode.Blend:
                    resultColor = Blend(
                        currentColor, 
                        lowerImageColor
                    );
                    break;
            }

            // Change pixel on result image.
            upperImage.ChangePixelColorAtIndex(index, resultColor);

            base.Draw(current, upperImage, lowerImage, index, progress);
        }
    }
}
