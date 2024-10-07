using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy;
using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases;
using Innovation_Uniform_Editor_Backend.Drawers.Interfaces;
using Innovation_Uniform_Editor_Backend.ImageEditors;
using Innovation_Uniform_Editor_Backend.ImageEditors.Factory;
using Innovation_Uniform_Editor_Backend.ImageEditors.Interface;
using Innovation_Uniform_Editor_Backend.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Innovation_Uniform_Editor_Backend.Drawers
{
    public class CustomDrawer<T> : IDrawable<T>
    {
        private readonly Point DIMENSIONS = new Point(585, 559);

        private T asset;

        private IImageEditor _result;

        //I hate GDI
        private Bitmap bitmap;

        private UniformAssets _assets;

        private List<CustomColor> _colors = new List<CustomColor>();

        public List<BaseGraphicsDrawer> GraphicsDrawers;

        public CustomDrawer(UniformAssets assets, List<CustomColor> colors)
        {
            if (typeof(T) == typeof(Bitmap))
                bitmap = new Bitmap(DIMENSIONS.X, DIMENSIONS.Y);

            _result = ImageFactory.CreateImageEditor<T>(DIMENSIONS.X, DIMENSIONS.Y);

            _assets = assets;
            
            _colors = colors;

            Initialize();
        }

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
        private void Initialize()
        {
            GraphicsDrawers = new List<BaseGraphicsDrawer>()
            {
                new BackgroundDrawer(_assets.Background),
                new TextureDrawer(_assets.Textures),
                new ColorDrawer(_colors, _assets.Selections),
                new OverlayDrawer(_assets.Overlay),
                
                //Logo's

                new ArmbandDrawer(_assets.Armband),
                new BottomDrawer(_assets.Bottom),
                new HolsterDrawer(_assets.Holster),

                new TopDrawer(_assets.Top),
                
                //new UsernameDrawer(),

                new WatermarkDrawer(EditorMain.Uniforms.waterMark)
            };
        }
        public T Draw()
        {
            Type typeOfT = typeof(T);

            if (typeOfT == typeof(Bitmap))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                    g.Clear(Color.Transparent);

                    foreach (BaseGraphicsDrawer drawer in GraphicsDrawers)
                    {
                        drawer.DrawToGraphics(g, bitmap);
                    }
                }
                return (T)(object)bitmap;
            }

            return default(T);
        }
        public void ExportLayered(string path)
        {
            for (int i = 0; i < GraphicsDrawers.Count; i++)
            {
                BaseGraphicsDrawer drawer = GraphicsDrawers[i];

                Bitmap result = drawer.GetResult();

                result.Save($"{path}/{i} - {drawer.Name}.png");
            }
        }
    }
}
