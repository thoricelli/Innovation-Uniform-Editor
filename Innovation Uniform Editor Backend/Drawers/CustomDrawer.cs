using Innovation_Uniform_Editor_Backend.Drawers.Base;
using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers;
using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases;
using Innovation_Uniform_Editor_Backend.Models;
using Innovation_Uniform_Editor_Backend.Models.Assets;
using Innovation_Uniform_Editor_Backend.Models.Base;
using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using Innovation_Uniform_Editor_Backend.Models.OverlayAssets;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

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

            _logoDrawer = new LogoDrawer(assets.Logos, custom);
            _shadingDrawer = new ShadingDrawer();

            List<Creator> creators = new List<Creator>() { custom.UniformBasedOn.Creator };

            AddIfCreditNotExists(custom.Holster, creators);
            AddIfCreditNotExists(custom.Armband, creators);
            AddIfCreditNotExists(custom.Glove, creators);
            AddIfCreditNotExists(custom.Shoe, creators);

            GraphicsDrawers = new List<BaseGraphicsDrawer>()
            {
                new BackgroundDrawer(assets.Background),
                new TextureDrawer(assets.Textures),
                new UniformColorDrawer(custom.Colors, assets.Selections, _shadingDrawer),

                _shadingDrawer,

                new OverlayDrawer(assets.Overlay),

                //Logo's.
                _logoDrawer,

                new TopDrawer(assets.Top),

                new ArmbandDrawer(assets.Armband),
                new HolsterDrawer(assets.Holster),

                new GloveDrawer(assets.Glove),
                new ShoeDrawer(assets.Shoe),
        
                //new UsernameDrawer(),

                new CreditsDrawer(creators),

                new LineTemplateDrawer(2, Color.Black, DashStyle.Solid),

                new WatermarkDrawer(EditorMain.Uniforms.waterMark)
            };
        }

        public void AddIfCreditNotExists(IHasCreators item, List<Creator> creators)
        {
            if (item == null)
                return;

            //If credit already exists, ignore.
            if (creators.Exists(x => item.Creators.Exists(y => x.Id == y.Id)))
                return;

            foreach (Creator itemCreators in item.Creators)
            {
                if (item != null && !creators.Exists(x => x.Id == itemCreators.Id))
                    creators.Add(itemCreators);
            }
        }
    }
}
