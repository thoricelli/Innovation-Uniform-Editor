using Innovation_Uniform_Editor.Classes.Images;
using Innovation_Uniform_Editor.Classes.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor.Classes
{

    //Result is also saved inside this folder for fast preview loading (downsized).
    //Add changing logo support!
    //Add username support!
    public class Custom : MenuItem
    {
        [JsonIgnore]
        public bool unsavedChanges = false;

        #region IDENTIFIERS+INFO
        [JsonIgnore]
        public Uniform UniformBasedOn
        {
            get
            {
                return Assets.UniformsLoader.FindBy(this.UniformBasedOnId);
            }
            set
            {
                this.UniformBasedOnId = value.Id;
            }
        }
        public ulong UniformBasedOnId { get; set; }
        #endregion
        #region CUSTOM_SETTINGS
        public List<Color> Colors { get; set; } = new List<Color>();
        private List<Color> OldColors { get; set; } = new List<Color>();
        public BackgroundImage backgroundImage
        {
            get
            {
                return Assets.BackgroundsLoader.FindBy(this.BackgroundImageGuid);
            }
        }
        public Guid BackgroundImageGuid;
        #endregion
        #region ASSETS
        [JsonIgnore]
        private string basePath
        {
            get
            {
                return UniformBasedOn != null ?
                    "./Templates/Normal/" + UniformBasedOn.part.ToString() + "/" + this.UniformBasedOn.Id
                    : "./Templates/Normal/ERROR";
            }
        }

        [JsonIgnore]
        public Image overlay
        {
            get
            {
                if (!File.Exists(basePath + "/Overlay.png"))
                    TemplateUpdater.CheckForUpdates(true);
                FileStream fs = File.Open(basePath + "/Overlay.png", FileMode.Open, FileAccess.Read);
                Image img = Image.FromStream(fs);
                fs.Close();
                return img;
            }
        }
        [JsonIgnore]
        public Image texture
        {
            get
            {
                if (!File.Exists(basePath + "/texture.png"))
                    return null;
                FileStream fs = File.Open(basePath + "/texture.png", FileMode.Open, FileAccess.Read);
                Image img = Image.FromStream(fs);
                fs.Close();
                return img;
            }
        }
        [JsonIgnore]
        public List<Image> SelectionTemplates;
        #endregion
        #region DRAWING
        private Bitmap shading;
        private Bitmap shadingMasked;
        [JsonIgnore]
        public Image Result
        {
            get
            {
                if (_result == null || HasColorsChanged())
                {
                    /*
                     Images to be loaded in this order:
                    - Background image (Also probably has to be masked...)

                    (Already combined)
                    - Masked secondary
                    - Masked shading secondary

                    (Already combined)
                    - Masked primary
                    - Masked shading primary

                    - Overlay
                    */

                    Bitmap fullResult = new Bitmap(585, 559);

                    Rectangle fullImage = new Rectangle(0, 0, fullResult.Size.Width, fullResult.Size.Height);

                    using (Graphics g = Graphics.FromImage(fullResult))
                    {
                        if (this.backgroundImage != null)
                            g.DrawImage(this.backgroundImage.background, fullImage);

                        Bitmap Colored = CreateMask(Colors, SelectionTemplates);

                        g.DrawImage(Colored, fullImage);
                        if (this.texture != null)
                        {
                            g.DrawImage(this.texture.SetOpacity(0.8F), fullImage);
                        }
                        if (this.UniformBasedOn.Shading)
                            g.DrawImage(shadingMasked, Point.Empty);
                        g.DrawImage(overlay, fullImage);
                        g.DrawImage(Assets.UniformsLoader.waterMark, fullImage);
                    }

                    _result = fullResult;

                    return _result;
                }
                else
                {
                    return _result;
                }
            }
            set { _result = value; }
        }
        private bool HasColorsChanged()
        {
            return true;
            //return Enumerable.SequenceEqual(Colors, OldColors);
        }
        [JsonIgnore]
        public Image PreviewImage
        {
            get
            {
                if (File.Exists("./Customs/" + Id + "/result.png"))
                {
                    Image img;
                    using (var bmpTemp = new Bitmap("./Customs/" + Id + "/result.png"))
                    {
                        img = new Bitmap(bmpTemp);
                    }
                    return img;
                }
                return this.Result;
            }
        }

        private Image _result;

        #region MASKING
        private void LoadSelectionTemplates()
        {
            Colors = new List<Color>();
            SelectionTemplates = new List<Image>();

            FileStream fs = File.Open(basePath + "/Selection_Template.png", FileMode.Open, FileAccess.Read);
            SelectionTemplates = new List<Image>() { Image.FromStream(fs) };
            fs.Close();
            Colors.Add(new Color());
            if (File.Exists(basePath + "/Selection_Template_Secondary.png"))
            {
                fs = File.Open(basePath + "/Selection_Template_Secondary.png", FileMode.Open, FileAccess.Read);
                SelectionTemplates.Add(Image.FromStream(fs));
                fs.Close();
                Colors.Add(new Color());
            }

            string[] otherSelections = Directory.GetFiles(basePath, "Selection_Template_*.png", SearchOption.TopDirectoryOnly);

            List<string> otherSelectionsList = otherSelections.ToList<string>();
            otherSelectionsList.RemoveAll(e => e.Contains("Selection_Template_Secondary"));

            foreach (string path in otherSelectionsList)
            {
                fs = File.Open(path, FileMode.Open, FileAccess.Read);
                SelectionTemplates.Add(Image.FromStream(fs));
                fs.Close();
                Colors.Add(new Color());
            }
        }

        private List<Image> coloredLayers = new List<Image>();
        private Bitmap CreateMask(List<Color> colors, List<Image> masks)
        {
            if (shading == null)
            {
                FileStream fs = File.Open("./Templates/Misc/Shading_Template.png", FileMode.Open, FileAccess.Read);
                shading = new Bitmap(Image.FromStream(fs));
                fs.Close();
            }
            if (coloredLayers.Count == 0)
            {
                for (int i = 0; i < masks.Count; i++)
                {
                    coloredLayers.Add(null);
                }
            }

            Bitmap Colored;

            Bitmap colorTemplate = new Bitmap(masks[0].Width, masks[0].Height);

            Colored = new Bitmap(colorTemplate.Width, colorTemplate.Height);

            bool drawShading = false;

            if (shadingMasked == null)
            {
                shadingMasked = new Bitmap(shading.Width, shading.Height);
                drawShading = true;
            }

            using (Graphics g = Graphics.FromImage(colorTemplate))
            {
                for (int i = 0; i < masks.Count; i++)
                {
                    Image mask = masks[i];
                    Color color = colors[i];
                    Color oldColor = OldColors.ElementAtOrDefault(i);
                    if (color != oldColor || coloredLayers[i] == null)
                    {
                        Image layer = ColorLayer(new Bitmap(mask), color, drawShading);
                        g.DrawImage(layer, Point.Empty);
                        coloredLayers[i] = layer;
                    }
                    else
                    {
                        g.DrawImage(coloredLayers[i], Point.Empty);
                    }
                }
            }

            using (Graphics g = Graphics.FromImage(Colored))
            {
                g.DrawImage(colorTemplate, Point.Empty);
            }


            OldColors = colors.ToList();
            return Colored;
        }

        private Image ColorLayer(Bitmap ColorMask, Color color, bool drawShading)
        {
            Bitmap Colored = new Bitmap(ColorMask.Width, ColorMask.Height);

            BitmapData bitmapMaskData = ColorMask.LockBits(
                        new Rectangle(0, 0, ColorMask.Width, ColorMask.Height),
                        ImageLockMode.ReadOnly,
                        ColorMask.PixelFormat
                    );

            byte[] bitmapMaskBytes = new byte[bitmapMaskData.Stride * ColorMask.Height];

            Marshal.Copy(bitmapMaskData.Scan0, bitmapMaskBytes, 0, bitmapMaskBytes.Length);

            ColorMask.UnlockBits(bitmapMaskData);

            int pixelSize = Image.GetPixelFormatSize(ColorMask.PixelFormat);

            int x = 0;
            int y = 0;

            for (int i = 0; i < bitmapMaskBytes.Length; i += pixelSize / 8)
            {
                byte[] pixelData = new byte[3];
                Array.Copy(bitmapMaskBytes, i, pixelData, 0, 3);

                if (pixelData[0] == 0)
                {
                    Colored.SetPixel(x, y, color);
                    if (drawShading)
                        shadingMasked.SetPixel(x, y, shading.GetPixel(x, y));
                }

                x++;
                if (x >= ColorMask.Width)
                {
                    x = 0;
                    y++;
                }
            }
            return Colored;
        }
        #endregion
        #endregion
        #region SAVING
        public void ExportUniform(string path)
        {
            if (path != "")
            {
                this.Result.Save(path, ImageFormat.Png);
                MessageBox.Show("Your custom has successfully been exported!", "Export successful.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void SaveUniform()
        {
            //See if it's already in JSONtoUniform or not
            if (JSONtoUniform.FindCustomFromGuid(this.Id) == null)
            {
                JSONtoUniform.AddCustom(this);
            }

            //Save custom class to JSON file inside folder
            Directory.CreateDirectory("./Customs/" + Id);

            JsonSerializer serializer = new JsonSerializer()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            using (StreamWriter sw = new StreamWriter(@"./Customs/" + Id + "/info.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, this);
            }
            Image downSized = JSONtoUniform.resizeImage(Result, new Size(293, 280));
            downSized.Save("./Customs/" + Id + "/result.png", ImageFormat.Png);
            unsavedChanges = false;
        }
        #endregion
        #region CHANGING_COLORS+UNIFORM
        public void ChangeColorAtIndex(int index, Color color)
        {
            Colors[index] = color;
            unsavedChanges = true;
        }
        public void ChangeUniform(Uniform uniform)
        {
            if (UniformBasedOn == null || UniformBasedOn.Id != uniform.Id)
            {
                UniformBasedOn = uniform;

                _result = null;
                shadingMasked = null;
                OldColors = new List<Color>();
                coloredLayers = new List<Image>();

                unsavedChanges = true;

                LoadSelectionTemplates();
            }
        }
        public void ChangeBackground(BackgroundImage bgs, bool clear)
        {
            if (bgs != null)
                BackgroundImageGuid = bgs.Id;
            if (clear)
                BackgroundImageGuid = new Guid(); //Find a way to empty out the backgroundImage.
            _result = null;
            unsavedChanges = true;
        }
        #endregion
    }
}
