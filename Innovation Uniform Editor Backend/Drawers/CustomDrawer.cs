using Innovation_Uniform_Editor_Backend.Drawers.Base;
using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers;
using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases;
using Innovation_Uniform_Editor_Backend.Models;
using Innovation_Uniform_Editor_Backend.Models.Assets;
using Innovation_Uniform_Editor_Backend.Models.Interfaces;
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

            ColorDrawerOptions options = new ColorDrawerOptions
            {
                Colors = custom.Colors,
                Selections = assets.Selections,
                ShadingDrawer = _shadingDrawer,
                Texture = assets.Textures,
                ShadingAmount = custom.UniformBasedOn.ShadingAmount
            };

            GraphicsDrawers = new List<BaseGraphicsDrawer>()
            {
                custom.UniformBasedOn.GloveId == null ? new GloveDrawer(assets.Glove) : null,

                new BackgroundDrawer(assets.Background),
                new TextureDrawer(assets.Textures),
                new UniformColorDrawer(options),

                _shadingDrawer,

                new OverlayDrawer(assets.Overlay),
                
                //When original uniform has glove, that means the color will extend to the fully, which means we want to draw it ABOVE.
                custom.UniformBasedOn.GloveId != null ? new GloveDrawer(assets.Glove) : null,
                new ShoeDrawer(assets.Shoe),

                //Logo's.
                _logoDrawer,

                new ArmbandDrawer(assets.Armband),

                new TopDrawer(assets.Top),

                new HolsterDrawer(assets.Holster),
        
                //new UsernameDrawer(),

                new CreditsDrawer(creators),

                new LineTemplateDrawer(2, Color.Black, DashStyle.Solid),

                new WatermarkDrawer(EditorMain.Uniforms.waterMark)
            };
        }

        private void AddIfCreditNotExists(IHasCreators item, List<Creator> creators)
        {
            if (item == null)
                return;

            if (creators.Count <= 0)
                return;

            //If credit already exists, ignore.
            if (creators.Exists(x => item.Creators.Exists(y => x.Id == y.Id)))
                return;

            Creator creatorToAdd = null;
            int index = 0;

            do
            {
                //Let's only add one name, we don't need all of them one there as credit.
                if (item != null && !creators.Exists(x => x.Id == item.Creators[index].Id))
                    creatorToAdd = item.Creators[index];

                index++;
            } while (item.Creators.Count > index && creatorToAdd != null);

            if (creatorToAdd != null)
                creators.Add(creatorToAdd);
        }
    }
}
