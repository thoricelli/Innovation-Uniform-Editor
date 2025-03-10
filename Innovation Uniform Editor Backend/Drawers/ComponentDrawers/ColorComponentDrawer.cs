﻿using Innovation_Uniform_Editor_Backend.Drawers.ComponentDrawers.Bases;
using Innovation_Uniform_Editor_Backend.Drawers.Interfaces;
using Innovation_Uniform_Editor_Backend.ImageEditors.Interface;
using Innovation_Uniform_Editor_Backend.Models;
using Innovation_Uniform_Editor_Backend.Models.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Drawers.ComponentDrawers
{
    /// <summary>
    /// Draws a solid color to a buffer.
    /// </summary>
    public class ColorComponentDrawer : ComponentDrawerBase
    {
        private ColorType colorType;
        public ColorComponentDrawer(double endPercentage, ColorDrawerTypes type, ColorType colorType, BlendMode blendMode) : base(endPercentage, type, blendMode)
        {
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

            Color resultColor = Overlay(
                currentColor,
                lowerImage.GetPixelColorAtIndex(index)
            );

            // Change pixel on result image.
            upperImage.ChangePixelColorAtIndex(index, resultColor);

            base.Draw(current, upperImage, lowerImage, index, progress);
        }
    }
}
