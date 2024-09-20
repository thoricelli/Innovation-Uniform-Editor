using Innovation_Uniform_Editor_Backend.Globals;
using Innovation_Uniform_Editor_Backend.Helpers;
using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace Innovation_Uniform_Editor_Backend.Images
{
    public class BackgroundImage : IIdentifier<Guid>
    {
        public BackgroundImage()
        {

        }
        public BackgroundImage(string guid)
        {
            Id = new Guid(guid);
        }
        public BackgroundImage(Image newBackground)
        {
            Id = Guid.NewGuid();
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
            _background = new Bitmap(EditorMain.Uniforms.backgroundMask.Width, EditorMain.Uniforms.backgroundMask.Height);
            BitmapData bitmapMaskData = EditorMain.Uniforms.backgroundMask.LockBits(
                        new Rectangle(0, 0, EditorMain.Uniforms.backgroundMask.Width, EditorMain.Uniforms.backgroundMask.Height),
                        ImageLockMode.ReadOnly,
                        EditorMain.Uniforms.backgroundMask.PixelFormat
                    );
            byte[] bitmapMaskBytes = new byte[bitmapMaskData.Stride * EditorMain.Uniforms.backgroundMask.Height];
            Marshal.Copy(bitmapMaskData.Scan0, bitmapMaskBytes, 0, bitmapMaskBytes.Length);

            EditorMain.Uniforms.backgroundMask.UnlockBits(bitmapMaskData);

            int pixelSize = Image.GetPixelFormatSize(EditorMain.Uniforms.backgroundMask.PixelFormat);

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
                if (!File.Exists($"{EditorPaths.BackgroundsPath}/" + Id + ".png"))
                    TemplateUpdater.CheckForUpdates(true);
                FileStream fs = File.Open($"{EditorPaths.BackgroundsPath}/" + Id + ".png", FileMode.Open, FileAccess.Read);
                Bitmap returnResult = new Bitmap(Image.FromStream(fs));
                fs.Close();
                return returnResult;
            }
        }

        public Guid Id { get; set; }
    }
}
