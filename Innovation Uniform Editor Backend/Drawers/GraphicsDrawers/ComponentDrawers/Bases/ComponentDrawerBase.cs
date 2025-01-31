using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.ComponentDrawers.Interfaces;
using Innovation_Uniform_Editor_Backend.ImageEditors.Interface;
using Innovation_Uniform_Editor_Backend.Models;
using Innovation_Uniform_Editor_Backend.Models.Enums;
using System;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.ComponentDrawers.Bases
{
    public abstract class ComponentDrawerBase : IComponentInterface
    {
        public static IImageEditor shading;
        public double EndYPercentage { get; set; }
        public ColorDrawerTypes Type { get; set; } = ColorDrawerTypes.EMPTY;
        protected BlendMode BlendMode { get; set; } = BlendMode.None;

        protected ComponentDrawerBase(double endPercentage, ColorDrawerTypes type, BlendMode blendMode)
        {
            EndYPercentage = endPercentage;
            Type = type;
            BlendMode = blendMode;
        }
        public virtual void Draw(CustomColor current, IImageEditor upperImage, IImageEditor lowerImage, int index, double progress)
        {
            //Do nothing
        }

        #region Blending modes & misc
        protected Color Blend(Color color, Color backColor, double amount)
        {
            byte r = (byte)(color.R * amount + backColor.R * (1 - amount));
            byte g = (byte)(color.G * amount + backColor.G * (1 - amount));
            byte b = (byte)(color.B * amount + backColor.B * (1 - amount));
            return Color.FromArgb(255, r, g, b);
        }
        //Took this from a stackoverflow post... it's not great, but works...
        protected Color Blend(Color ForeGround, Color BackGround)
        {
            if (ForeGround.A == 0)
                return BackGround;
            if (BackGround.A == 0)
                return ForeGround;
            if (ForeGround.A == 255)
                return ForeGround;

            int Alpha = ForeGround.A + 1;
            int A = ForeGround.A;

            int B = Alpha * ForeGround.B + (255 - Alpha) * BackGround.B >> 8;
            int G = Alpha * ForeGround.G + (255 - Alpha) * BackGround.G >> 8;
            int R = Alpha * ForeGround.R + (255 - Alpha) * BackGround.R >> 8;


            if (BackGround.A == 255)
                A = 255;
            if (R > 255)
                R = 255;
            if (G > 255)
                G = 255;
            if (B > 255)
                B = 255;

            return Color.FromArgb(Math.Abs(A), Math.Abs(R), Math.Abs(G), Math.Abs(B));
        }
        protected Color Overlay(Color ForeGround, Color Background)
        {
            if (Background.R > 0 && Background.B > 0 && Background.G > 0)
                return Color.FromArgb(
                        255,//OverlayPixel(ForeGround.A, Background.A),
                        OverlayPixel(ForeGround.R, Background.R),
                        OverlayPixel(ForeGround.G, Background.G),
                        OverlayPixel(ForeGround.B, Background.B)
                    );
            return ForeGround;
        }
        //Help.....
        protected int OverlayPixel(int upper, int lower)
        {
            if (lower < 128)
                return ClampColor(2 * upper * lower / 255);
            return ClampColor(255 - 2 * (255 - upper) * (255 - lower) / 255);
            //Can't be lower than 0 or higher than 255.
        }
        protected int ClampColor(int value)
        {
            return value < 0 ? 0 : value > 255 ? 255 : value;
        }
        protected Color GetColorFromCustomColor(CustomColor color)
        {
            return color.GetColorAtIndex(0);
        }
        #endregion
    }
}
