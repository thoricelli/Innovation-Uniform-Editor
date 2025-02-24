using Innovation_Uniform_Editor_Backend.Drawers.GraphicsDrawers.Legacy.Bases;
using Innovation_Uniform_Editor_Backend.Drawers.Interfaces;
using Innovation_Uniform_Editor_Backend.ImageEditors.Factory;
using Innovation_Uniform_Editor_Backend.ImageEditors.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Innovation_Uniform_Editor_Backend.Drawers.Base
{
    public abstract class BaseGraphicComponentDrawer<T> : IDrawable<T>
    {
        protected readonly Point DIMENSIONS = new Point(585, 559);

        protected T asset;

        protected IImageEditor _result;

        //I hate GDI
        protected Bitmap bitmap;

        public List<BaseGraphicsDrawer> GraphicsDrawers;

        public BaseGraphicComponentDrawer()
        {
            if (typeof(T) == typeof(Bitmap))
                bitmap = new Bitmap(DIMENSIONS.X, DIMENSIONS.Y);

            _result = ImageFactory.CreateImageEditor<T>(DIMENSIONS.X, DIMENSIONS.Y);

            GraphicsDrawers = new List<BaseGraphicsDrawer>();
        }
        public virtual T Draw()
        {
            RefreshAssets();

            Type typeOfT = typeof(T);

            if (typeOfT == typeof(Bitmap))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.SmoothingMode = SmoothingMode.HighSpeed;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;

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

        public virtual void RefreshAssets()
        {

        }
        public virtual void ExportLayered(string path)
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
