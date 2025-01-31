using Innovation_Uniform_Editor_Backend.Drawers.Base;
using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers;
using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases;
using Innovation_Uniform_Editor_Backend.Models;
using Innovation_Uniform_Editor_Backend.Models.Assets;
using System.Collections.Generic;

namespace Innovation_Uniform_Editor_Backend.Drawers
{
    /// <summary>
    /// Draws an Innovation Security custom.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomDrawer<T> : BaseGraphicComponentDrawer<T>
    {
        private LogoDrawer _logoDrawer;
        private Custom _custom;
        private ShadingDrawer _shadingDrawer;
        public CustomDrawer(UniformAssets assets, Custom custom)
        {
            /*
            How a custom is built up: (back to front)
            - Background

            - Textures (if any)
            (Textures can be shaded already if no source exists = add no shading to color)

            - Color(s) as OVERLAY -> separately masked.

            - Shading masked on top of the colored and/or textured layers
            (Since the vest is already shaded)

            - Overlay
            */

            _custom = custom;

            _logoDrawer = new LogoDrawer(custom.LogoPreset, assets.Logos);
            _shadingDrawer = new ShadingDrawer();

            GraphicsDrawers = new List<BaseGraphicsDrawer>()
            {
                new BackgroundDrawer(assets.Background),
                new TextureDrawer(assets.Textures),
                new UniformColorDrawer(custom.Colors, assets.Selections, _shadingDrawer),
                new OverlayDrawer(assets.Overlay),

                //Logo's.
                _logoDrawer,

                _shadingDrawer,

                new ArmbandDrawer(assets.Armband),
                new HolsterDrawer(assets.Holster),

                new GloveDrawer(assets.Glove),
                new ShoeDrawer(assets.Shoe),

                new TopDrawer(assets.Top),
        
                //new UsernameDrawer(),

                new WatermarkDrawer(EditorMain.Uniforms.waterMark)
            };
        }

        public override void RefreshAssets()
        {
            _logoDrawer.ChangePreset(_custom.LogoPreset);
            base.RefreshAssets();
        }
    }
}
