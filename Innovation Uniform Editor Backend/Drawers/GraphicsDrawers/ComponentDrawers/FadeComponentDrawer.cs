﻿using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.ComponentDrawers.Bases;
using Innovation_Uniform_Editor_Backend.ImageEditors.Interface;
using Innovation_Uniform_Editor_Backend.Models;
using Innovation_Uniform_Editor_Backend.Models.Enums;
using System;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.ComponentDrawers
{
    /// <summary>
    /// Draws a faded color to a buffer.
    /// </summary>
    public class FadeComponentDrawer : ComponentDrawerBase
    {
        public FadeComponentDrawer(double endPercentage, ColorDrawerTypes type, BlendMode blendMode) : base(endPercentage, type, blendMode)
        {
        }

        public override void Draw(CustomColor current, IImageEditor upperImage, IImageEditor lowerImage, IImageEditor texture, int index, double progress, float transparency)
        {
            Color textureColor = texture.GetPixelColorAtIndex(index);

            Color fade = FadePixel(current, progress);

            if (textureColor.A != 0)
                fade = Overlay(fade, lowerImage.GetPixelColorAtIndex(index));

            upperImage.ChangePixelColorAtIndex(index, fade);

            base.Draw(current, upperImage, lowerImage, texture, index, progress, transparency);
        }

        private Color FadePixel(CustomColor color, double progress)
        {
            if (progress < 1 && color.Colors != null && color.Colors.Count > 1)
            {
                //For every repeat, we want the progress to restart back to zero.
                double progressRepeat = progress * 1;//color.Repeat;
                double progressWithRepeat = progressRepeat - Math.Truncate(progressRepeat);

                //More colors = less time for each color to fade
                double colorProgress =
                    progressWithRepeat == 0 ?
                    0 : progressWithRepeat / ((double)1 / (color.Colors.Count - 1));

                //First number is the index, everything beyond the decimal is the fade progress.
                int currentIndex = Convert.ToInt32(Math.Floor(colorProgress));
                double currentFadeAmount = colorProgress - Math.Truncate(colorProgress);

                Color currentColor = color.Colors[currentIndex];
                Color fadeToColor = color.Colors[currentIndex + 1];

                return Blend(fadeToColor, currentColor, currentFadeAmount);
            }
            else if (color.Colors != null)
            {
                return color.GetColorAtIndex(0);
            }
            return Color.Transparent;
        }
    }
}
