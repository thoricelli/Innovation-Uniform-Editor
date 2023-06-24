using Innovation_Uniform_Editor.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Innovation_Uniform_Editor.Classes
{
    public class BackgroundImage
    {
        public BackgroundImage(string guid = null, Image newBackground = null)
        {
            this.backgroundGUID = guid == null ? Guid.NewGuid() : new Guid(guid);
            if (newBackground != null)
            {
                newBackground.Save("./Backgrounds/" + this.backgroundGUID + ".png", ImageFormat.Png);
            }
        }
        [JsonIgnore]
        public Image background { 
            get { return Image.FromFile("./Backgrounds/" + this.backgroundGUID + ".png"); }
        }
        public Guid backgroundGUID;
    }
    public class Uniform
    {
        public UInt64 Id { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }   
        public ClothingPart part { get; set; }
    }

    //Result is also saved inside this folder for fast preview loading (downsized).
    //Add changing logo support!
    //Add username support!
    public class Custom : MenuItem
    {
        [JsonIgnore]
        public bool unsavedChanges = false;

        #region IDENTIFIERS+INFO
        [JsonIgnore]
        public Uniform UniformBasedOn {
            get {
                return JSONtoUniform.FindFromId(this.UniformBasedOnId);
            }
            set
            {
                this.UniformBasedOnId = value.Id;
            }
        }
        public ulong UniformBasedOnId { get; set; }
        #endregion
        #region CUSTOM_SETTINGS
        public Color Primary { get; set; }
        private Color OldPrimary { get; set; }
        public Color Secondary { get; set; }
        private Color OldSecondary { get; set; }
        public BackgroundImage BackgroundImage
        {
            get
            {
                return JSONtoUniform.FindBackgroundFromGuid(this.BackgroundImageGuid);
            }
        }
        private Guid BackgroundImageGuid;
        #endregion
        #region ASSETS
        [JsonIgnore]
        private string basePath { 
            get 
            { 
                return UniformBasedOn != null ? 
                    "./Templates/Normal/" + UniformBasedOn.part.ToString() + "/" + this.UniformBasedOn.Id
                    : "./Templates/Normal/ERROR"; 
            } 
        }
        
        [JsonIgnore]
        public Image overlay { get { return Image.FromFile(basePath + "/Overlay.png"); } }
        [JsonIgnore]
        public Image SelectionTemplate { get { return Image.FromFile(basePath + "/Selection_Template.png"); } }
        [JsonIgnore]
        public Image SecondarySelectionTemplate { 
        get 
            { 
                return File.Exists(basePath + "/Selection_Template_Secondary.png") == true 
                    ? Image.FromFile(basePath + "/Selection_Template_Secondary.png") 
                    : null; 
            } 
        }
        #endregion
        #region DRAWING
        [JsonIgnore]
        public Image Result 
        {
            get
            {
                if (_result == null || (OldPrimary != Primary || OldSecondary != Secondary))
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

                    There is a problem with some of the pixels, FIX THIS!!
                    */

                    Bitmap fullResult = new Bitmap(585, 559);

                    Rectangle fullImage = new Rectangle(0, 0, fullResult.Size.Width, fullResult.Size.Height);

                    using (Graphics g = Graphics.FromImage(fullResult))
                    {
                        if (this.BackgroundImage != null)
                            g.DrawImage(this.BackgroundImage.background, Point.Empty);

                        Bitmap Colored = CreateMask(Primary, Secondary, SelectionTemplate, SecondarySelectionTemplate);

                        g.DrawImage(Colored, fullImage);
                        g.DrawImage(overlay, Point.Empty);
                    }

                    _result = fullResult;

                    return _result;
                } else
                {
                    return _result;
                }
            }
            set { _result = value; }
        }
        [JsonIgnore]
        public Image PreviewImage
        {
            get 
            { 
                if (File.Exists("./Customs/" + Guid + "/result.png"))
                {
                    Image img;
                    using (var bmpTemp = new Bitmap("./Customs/" + Guid + "/result.png"))
                    {
                        img = new Bitmap(bmpTemp);
                    }
                    return img;
                }
                return this.Result;
            }
        }

        private Image _result;
        /*
         OPTIONS:
         - PRIMARY COLOR
         - SECONDARY COLOR
         - TEXTURE: TODO
         - BACKGROUND IMAGE: INSIDE FOLDER.
         - ...
         */

        #region MASKING
        /*
         All of this to prevent it from having to recalculate the entire uniform.
         Recalculating lots of times is very costly and resource heavy.
         */

        private List<int[]> pixelsMaskPrimary = new List<int[]>();
        private List<int[]> pixelsMaskSecondary = new List<int[]>();

        private Bitmap shading = new Bitmap(Image.FromFile("./Templates/Misc/Shading_Template.png"));
        private Bitmap shadingMasked;

        private Bitmap CreateMask(Color colorPrimary, Color colorSecondary, Image maskPrimary, Image maskSecondary)
        {
            Bitmap Colored = null;

            bool calculateMask = false;

            OldPrimary = Primary;
            OldSecondary = Secondary;

            Bitmap colorTemplate = new Bitmap(maskPrimary.Width, maskPrimary.Height);

            Bitmap bitmapMask = new Bitmap(maskPrimary);
            Bitmap bitmapMaskSecondary = null;
            if (maskSecondary != null)
            {
                bitmapMaskSecondary = new Bitmap(maskSecondary);
            }

            if (shadingMasked == null)
            {
                shadingMasked = new Bitmap(shading.Width, shading.Height);
                calculateMask = true;
            }

            if (pixelsMaskPrimary.Count == 0)
            {
                #region PRIMARY
                pixelsMaskPrimary = CreateColorDataFromMask(bitmapMask, calculateMask, colorTemplate, colorPrimary);
                #endregion
                #region SECONDARY
                if (bitmapMaskSecondary != null)
                {
                    pixelsMaskSecondary = CreateColorDataFromMask(bitmapMaskSecondary, calculateMask, colorTemplate, colorPrimary);
                }
                #endregion
            }
            else
            {
                foreach (int[] pixels in pixelsMaskPrimary)
                {
                    if (calculateMask)
                    {
                        shadingMasked.SetPixel(pixels[0], pixels[1], shading.GetPixel(pixels[0], pixels[1]));
                    }
                    colorTemplate.SetPixel(pixels[0], pixels[1], colorPrimary);
                }

                if (maskSecondary != null)
                {
                    foreach (int[] pixels in pixelsMaskSecondary)
                    {
                        colorTemplate.SetPixel(pixels[0], pixels[1], colorSecondary);
                    }
                }
            }

            Colored = new Bitmap(Math.Max(colorTemplate.Width, shadingMasked.Width),
                             Math.Max(colorTemplate.Height, shadingMasked.Height));
            using (Graphics g = Graphics.FromImage(Colored))
            {
                g.DrawImage(colorTemplate, Point.Empty);
                g.DrawImage(shadingMasked, Point.Empty);
            }
            return Colored;
        }

        private List<int[]> CreateColorDataFromMask(Bitmap bitmapMask, bool calculateMask, Bitmap colorTemplate, Color color)
        {
            List<int[]> pixelMask = new List<int[]>();

            BitmapData bitmapMaskData = bitmapMask.LockBits(
                        new Rectangle(0, 0, bitmapMask.Width, bitmapMask.Height),
                        ImageLockMode.ReadOnly,
                        bitmapMask.PixelFormat
                    );

            byte[] bitmapMaskBytes = new byte[bitmapMaskData.Stride * bitmapMask.Height];

            Marshal.Copy(bitmapMaskData.Scan0, bitmapMaskBytes, 0, bitmapMaskBytes.Length);

            bitmapMask.UnlockBits(bitmapMaskData);

            int pixelSize = Image.GetPixelFormatSize(bitmapMask.PixelFormat);

            int x = 0;
            int y = 0;

            for (int i = 0; i < bitmapMaskBytes.Length; i += pixelSize / 8)
            {
                byte[] pixelData = new byte[3];
                Array.Copy(bitmapMaskBytes, i, pixelData, 0, 3);

                if (pixelData[0] == 0)
                {
                    pixelMask.Add(new int[2] { x, y });
                    if (calculateMask)
                    {
                        shadingMasked.SetPixel(x, y, shading.GetPixel(x, y));
                    }
                    colorTemplate.SetPixel(x, y, color);
                }

                x++;
                if (x >= bitmapMask.Width)
                {
                    x = 0;
                    y++;
                }
            }
            return pixelMask;
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
            //Save custom class to JSON file inside folder
            Directory.CreateDirectory("./Customs/" + Guid);

            JsonSerializer serializer = new JsonSerializer()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            using (StreamWriter sw = new StreamWriter(@"./Customs/" + Guid + "/info.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, this);
            }
            //TODO: Save lowered result for faster loading!
            Result.Save("./Customs/" + Guid + "/result.png", ImageFormat.Png);
            unsavedChanges = false;
        }

        private static Image ScaleImage(Image image, int height)
        {
            double ratio = (double)height / image.Height;
            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            image.Dispose();
            return newImage;
        }
        #endregion
        #region CHANGING_COLORS+UNIFORM
        public void ChangePrimaryColor(Color color)
        {
            Primary = color;
            unsavedChanges = true;
        }
        public void ChangeSecondaryColor(Color color)
        {
            Secondary = color;
            unsavedChanges = true;
        }
        public void ChangeUniform(Uniform uniform)
        {
            if (UniformBasedOn == null || UniformBasedOn.Id != uniform.Id)
            {
                UniformBasedOn = uniform;

                _result = null;
                pixelsMaskPrimary = new List<int[]>();
                shadingMasked = null;

                unsavedChanges = true;
            }
        }
        public void ChangeBackground(BackgroundImage bgs, bool clear)
        {
            if (bgs != null)
                BackgroundImageGuid = bgs.backgroundGUID;
            if (clear)
                BackgroundImageGuid = new Guid(); //Find a way to empty out the backgroundImage.
            _result = null;
            unsavedChanges = true;
        }
        #endregion
    }
}
