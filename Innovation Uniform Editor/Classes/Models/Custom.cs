using Innovation_Uniform_Editor.Classes.Drawers;
using Innovation_Uniform_Editor.Classes.Drawers.Interfaces;
using Innovation_Uniform_Editor.Classes.Helpers;
using Innovation_Uniform_Editor.Classes.Images;
using Innovation_Uniform_Editor.Classes.Loaders;
using Innovation_Uniform_Editor.Classes.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor.Classes
{

    //Result is also saved inside this folder for fast preview loading (downsized).
    //Add changing logo support!
    //Add username support!
    public class Custom : MenuItem
    {
        [JsonIgnore]
        private UniformAssets _assets;
        [JsonIgnore]
        private IDrawable _drawer;
        [JsonIgnore]
        public bool UnsavedChanges { get; set; } = false;

        #region IDENTIFIERS+INFO
        private Uniform _uniformBasedOn;
        [JsonIgnore]
        public Uniform UniformBasedOn
        {
            get
            {
                if (_uniformBasedOn == null)
                    _uniformBasedOn = Assets.UniformsLoader.FindBy(this.UniformBasedOnId);
                return _uniformBasedOn;
            }
            set
            {
                this.UniformBasedOnId = value.Id;
                _uniformBasedOn = Assets.UniformsLoader.FindBy(this.UniformBasedOnId);
            }
        }
        public ulong UniformBasedOnId { get; set; }
        #endregion
        #region CUSTOM_SETTINGS
        public List<CustomColor> Colors { get; set; } = new List<CustomColor>();
        //private List<CustomColor> OldColors { get; set; } = new List<CustomColor>();
        private BackgroundImage _backgroundImage;
        public BackgroundImage BackgroundImage { get { return _backgroundImage; } }
        public Guid BackgroundImageGuid;
        #endregion
        #region DRAWING
        [JsonIgnore]
        public Image Result
        {
            get
            {
                if (this._drawer == null)
                    Initialize();

                if (_result == null || HasColorsChanged())
                {
                    _result = _drawer.Draw();
                }
                return _result;
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
                return FileToBitmap.Convert("./Customs/" + Id + "/result.png");
            }
        }

        private Image _result;
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
            if (Assets.CustomsLoader.FindBy(this.Id) == null)
            {
                Assets.CustomsLoader.Add(this);
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
            Image downSized = ImageHelper.resizeImage(Result, new Size(293, 280));
            downSized.Save("./Customs/" + Id + "/result.png", ImageFormat.Png);
            UnsavedChanges = false;
        }
        #endregion
        #region CHANGING_COLORS+UNIFORM
        public void ChangeFirstColorAtIndex(int index, Color color)
        {
            Colors[index].ChangeColorAtIndex(0, color);
            UnsavedChanges = true;
        }
        public void ChangeUniform(Uniform uniform)
        {
            if (UniformBasedOn == null || UniformBasedOn.Id != uniform.Id)
            {
                UniformBasedOn = uniform;

                UnsavedChanges = true;

                Initialize();
            }
        }
        public void ChangeBackground(BackgroundImage bgs)
        {
            if (bgs != null)
            {
                BackgroundImageGuid = bgs.Id;
                _backgroundImage = Assets.BackgroundsLoader.FindBy(this.BackgroundImageGuid);

                _assets.Background = _backgroundImage.background;
            }
            else
            {
                _backgroundImage = null;
            }

            _result = null;
            UnsavedChanges = true;
        }
        public void ClearBackground()
        {
            BackgroundImageGuid = new Guid();
            _result = null;
            UnsavedChanges = true;
        }
        #endregion
        private void Initialize()
        {
            _result = null;

            _assets = UniformAssetsLoader.GetAssetsForUniform(this.UniformBasedOn);

            if (this.Colors.Count != _assets.Selections.Count)
            {
                Colors = new List<CustomColor>(_assets.Selections.Count);

                for (int i = 0; i < _assets.Selections.Count; i++)
                {
                    Colors.Add(new CustomColor());
                }
            }

            _drawer = new CustomDrawer(_assets, Colors);
        }
    }
}
