using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Innovation_Uniform_Editor.Classes.Models;

namespace Innovation_Uniform_Editor.Classes.Images
{
    public class BackgroundImage : IIdentifier<Guid>
    {
        public BackgroundImage()
        {

        }
        public BackgroundImage(string guid)
        {
            this.Id = new Guid(guid);
        }
        public BackgroundImage(Image newBackground)
        {
            this.Id = Guid.NewGuid();
        }
        //JSONtoUniform.backgroundMask
        [JsonIgnore]
        public Bitmap background
        {
            get
            {
                if (_background == null)
                {
                    calculateBackgroundMasked();
                }
                return _background;
            }
        }
        private Bitmap _background;
        private void calculateBackgroundMasked()
        {
            _background = new Bitmap(Assets.UniformsLoader.backgroundMask.Width, Assets.UniformsLoader.backgroundMask.Height);
            BitmapData bitmapMaskData = Assets.UniformsLoader.backgroundMask.LockBits(
                        new Rectangle(0, 0, Assets.UniformsLoader.backgroundMask.Width, Assets.UniformsLoader.backgroundMask.Height),
                        ImageLockMode.ReadOnly,
                        Assets.UniformsLoader.backgroundMask.PixelFormat
                    );
            byte[] bitmapMaskBytes = new byte[bitmapMaskData.Stride * Assets.UniformsLoader.backgroundMask.Height];
            Marshal.Copy(bitmapMaskData.Scan0, bitmapMaskBytes, 0, bitmapMaskBytes.Length);

            Assets.UniformsLoader.backgroundMask.UnlockBits(bitmapMaskData);

            int pixelSize = Image.GetPixelFormatSize(Assets.UniformsLoader.backgroundMask.PixelFormat);

            int x = 0;
            int y = 0;

            Bitmap backgroundOGStored = backgroundOG;

            for (int i = 0; i < bitmapMaskBytes.Length; i += pixelSize / 8)
            {
                byte[] pixelData = new byte[3];
                Array.Copy(bitmapMaskBytes, i, pixelData, 0, 3);

                if (pixelData[0] == 0)
                {
                    _background.SetPixel(x, y, backgroundOGStored.GetPixel(x, y));
                }

                x++;
                if (x >= _background.Width)
                {
                    x = 0;
                    y++;
                }
            }
        }
        [JsonIgnore]
        private Bitmap backgroundOG
        {
            get
            {
                if (!File.Exists("./Backgrounds/" + this.Id + ".png"))
                    TemplateUpdater.CheckForUpdates(true);
                FileStream fs = File.Open("./Backgrounds/" + this.Id + ".png", FileMode.Open, FileAccess.Read);
                Bitmap returnResult = new Bitmap(Image.FromStream(fs));
                fs.Close();
                return returnResult;
            }
        }

        public Guid Id { get; set; }
    }
}
