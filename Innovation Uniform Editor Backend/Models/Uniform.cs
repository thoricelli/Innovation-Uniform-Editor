﻿using Innovation_Uniform_Editor_Backend.Enums;
using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Models
{
    public class Uniform : IIdentifier<ulong>, IOverlayAssets
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }
        public ClothingPart part { get; set; }
        #region Customization
        /*
         * If the uniform supports changing armbands, holsters, etc
         * I don't have the textures for some of the uniforms, so, they have customization disabled!
        */
        public bool CanBeCustomized { get; set; } = true;
        public Guid? HolsterId { get; set; }
        public Guid? ArmbandId { get; set; }
        public Guid? BottomId { get; set; }
        //TODO logo's!!
        #region USERNAMES
        //This should probably be presets instead.
        /*public PointF UsernamePosition { get; set; } = new PointF(471,124);
        public Color UsernameColor { get; set; } = Color.FromArgb(167, 167, 167, 255);
        public int UsernameSize { get; set; } = 10;*/

        #endregion
        #endregion

    }
}
