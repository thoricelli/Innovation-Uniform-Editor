﻿using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.ComponentDrawers;
using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.ComponentDrawers.Bases;
using Innovation_Uniform_Editor_Backend.Models;
using Innovation_Uniform_Editor_Backend.Models.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers
{
    public class UniformColorDrawer : ColorDrawer
    {
        private static List<ComponentDrawerBase> colorDrawerItems = new List<ComponentDrawerBase>()
        {
            new ColorComponentDrawer(0.26, ColorDrawerTypes.SOLID, ColorType.FirstColor, BlendMode.None),
            new FadeComponentDrawer(0.72, ColorDrawerTypes.FADE, BlendMode.None),
            new ColorComponentDrawer(1, ColorDrawerTypes.SOLID, ColorType.LastColor, BlendMode.None),
        };

        public UniformColorDrawer(ColorDrawerOptions options)
            : base(ModifyOptions(options))
        {
        }

        private static ColorDrawerOptions ModifyOptions(ColorDrawerOptions options)
        {
            options.ColorDrawerItems = colorDrawerItems;

            return options;
        }
    }
}
