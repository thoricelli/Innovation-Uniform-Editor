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
        private UniformAssets _assets;
        private List<CustomColor> _colors;

        public CustomDrawer(UniformAssets assets, List<CustomColor> colors)
        {
            _assets = assets;
            _colors = colors;


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

            GraphicsDrawers = new List<BaseGraphicsDrawer>()
            {
                new BackgroundDrawer(_assets.Background),
                new TextureDrawer(_assets.Textures),
                new ColorDrawer(_colors, _assets.Selections),
                new OverlayDrawer(_assets.Overlay),

                //Logo's.
                //new LogoDrawer(colors, assets.Selections),

                new ArmbandDrawer(_assets.Armband),
                new BottomDrawer(_assets.Bottom),
                new HolsterDrawer(_assets.Holster),

                new TopDrawer(_assets.Top),
        
                //new UsernameDrawer(),

                new WatermarkDrawer(EditorMain.Uniforms.waterMark)
            };
        }
    }
}
