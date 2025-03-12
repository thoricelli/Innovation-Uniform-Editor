using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.ComponentDrawers.Bases;
using Innovation_Uniform_Editor_Backend.ImageEditors.Interface;
using Innovation_Uniform_Editor_Backend.Models;
using Innovation_Uniform_Editor_Backend.Models.Enums;
using System.Collections.Generic;
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

        public override void Draw(CustomColor current, IImageEditor upperImage, IImageEditor lowerImage, IImageEditor texture, int index, double progress, float transparency)
        {
            // Overlay pixel with color from lower layer.
            if (current.Colors == null)
            {
                //TODO remove this
                current.Colors = new List<Color>() { Color.Transparent };
            }
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

            if (resultColor.A == 0)
                resultColor = lowerImageColor;

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

            Color textureColor = texture.GetPixelColorAtIndex(index);

            if (textureColor.A != 0)
                resultColor = Overlay(
                        currentColor,
                        lowerImageColor
                    );

            // Change pixel on result image.
            if (transparency != 1f)
                resultColor = Color.FromArgb((int)(transparency * 255), resultColor.R, resultColor.G, resultColor.B);

            upperImage.ChangePixelColorAtIndex(index, resultColor);

            base.Draw(current, upperImage, lowerImage, texture, index, progress, transparency);
        }
    }
}
