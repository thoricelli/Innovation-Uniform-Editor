using Innovation_Uniform_Editor_Backend.Drawers;
using Innovation_Uniform_Editor_Backend.Drawers.Interfaces;
using Innovation_Uniform_Editor_Backend.Globals;
using Innovation_Uniform_Editor_Backend.Helpers;
using Innovation_Uniform_Editor_Backend.Images;
using Innovation_Uniform_Editor_Backend.Loaders;
using Innovation_Uniform_Editor_Backend.Loaders.Interfaces;
using Innovation_Uniform_Editor_Backend.Models.Base;
using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor_Backend.Models
{

    //Result is also saved inside this folder for fast preview loading (downsized).
    //Add changing logo support!
    //Add username support!
    public class Custom : MenuItem, IOverlayAssets
    {
        [JsonIgnore]
        private UniformAssets _assets;
        [JsonIgnore]
        public CustomDrawer<Bitmap> Drawer { get; set; }
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
                    _uniformBasedOn = EditorMain.Uniforms.FindBy(UniformBasedOnId);
                return _uniformBasedOn;
            }
            set
            {
                UniformBasedOnId = value.Id;
                _uniformBasedOn = EditorMain.Uniforms.FindBy(UniformBasedOnId);
            }
        }
        public ulong UniformBasedOnId { get; set; }
        public Guid? HolsterId { get; set; }
        public Guid? ArmbandId { get; set; }
        public Guid? BottomId { get; set; }
        #endregion
        #region CUSTOM_SETTINGS
        public List<CustomColor> Colors { get; set; } = new List<CustomColor>();
        //private List<CustomColor> OldColors { get; set; } = new List<CustomColor>();
        private BackgroundImage _backgroundImage;
        public BackgroundImage BackgroundImage
        {
            get
            {
                return _backgroundImage;
            }
        }
        public Guid BackgroundImageGuid { get; set; }
        #endregion
        #region DRAWING
        [JsonIgnore]
        public Image Result
        {
            get
            {
                if (Drawer == null)
                    Initialize();

                if (_result == null || HasColorsChanged())
                {
                    _result = Drawer.Draw();
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
                return FileToBitmap.Convert($"{EditorPaths.CustomsPath}/" + Id + "/result.png");
            }
        }

        private Image _result;
        #endregion
        #region SAVING
        public void ExportUniform(string path)
        {
            if (path != string.Empty)
            {
                //Check if there are remaining issues? Should that even be here?
                DialogResult dialogResult = DialogResult.Yes;//MessageBox.Show("Are you sure you want to export with remaining issues?", "There are some remaining issues.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    Bitmap Capybara = FileToBitmap.Convert($"{EditorPaths.TemplateMiscPath}/Capybara.png");

                    byte[] value = Encoding.ASCII.GetBytes($"{EditorMain.ToolName} - {EditorMain.VersionString}");

                    PropertyItem prop = Capybara.GetPropertyItem(305);
                    prop.Len = value.Length;
                    prop.Value = value;

                    Result.SetPropertyItem(prop);

                    Result.Save(path, ImageFormat.Png);
                    MessageBox.Show("Your custom has successfully been exported!", "Export successful.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

            }
        }
        public void SaveUniform()
        {
            //See if it's already in JSONtoUniform or not
            if (EditorMain.Customs.FindBy(this.Id) == null)
            {
                EditorMain.Customs.Add(this);
            }

            //Save custom class to JSON file inside folder
            Directory.CreateDirectory($"{EditorPaths.CustomsPath}/" + Id);

            JsonSerializer serializer = new JsonSerializer()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            using (StreamWriter sw = new StreamWriter($"{EditorPaths.CustomsPath}/" + Id + "/info.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, this);
            }
            Image downSized = ImageHelper.resizeImage(Result, new Size(293, 280));
            downSized.Save($"{EditorPaths.CustomsPath}/" + Id + "/result.png", ImageFormat.Png);
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
            BackgroundImageGuid = bgs.Id;

            UpdateBackground();

            _result = null;
            UnsavedChanges = true;
        }
        //This is terrible, change this with an array please :(
        public void ChangeHolster(Holster holster)
        {
            if (holster != null)
                this.HolsterId = holster.Id;
            else
                ClearHolster();

            Initialize();
        }
        public void ClearHolster()
        {
            this.HolsterId = null;
            Initialize();
        }
        public void ChangeArmband(Armband armband)
        {
            if (armband != null)
                this.ArmbandId = armband.Id;
            else
                ClearArmband();

            Initialize();
        }
        public void ClearArmband()
        {
            this.ArmbandId = null;
            Initialize();
        }
        public void ChangeBottom(Bottom bottom)
        {
            if (bottom != null)
                this.BottomId = bottom.Id;
            else
                ClearBottom();

            Initialize();
        }
        public void ClearBottom()
        {
            this.BottomId = null;
            Initialize();
        }
        private void UpdateBackground()
        {
            _backgroundImage = EditorMain.Backgrounds.FindBy(BackgroundImageGuid);
            if (_backgroundImage != null)
                _assets.Background = new Bitmap(_backgroundImage.Image);
        }
        public void ClearBackground()
        {
            _backgroundImage = null;
            BackgroundImageGuid = new Guid();
            _assets.Background = null;

            _result = null;
            UnsavedChanges = true;
        }
        #endregion
        public Custom()
        {

        }
        public Custom(Uniform uniform)
        {
            this.ChangeUniform(uniform);
        }

        private void Initialize()
        {
            _result = null;

            _assets = UniformAssetsLoader.GetAssetsForUniform(UniformBasedOn);

            _assets.Bottom = LoadBitmapFromLoader(EditorMain.BottomsLoader, this.BottomId ?? UniformBasedOn.BottomId);
            _assets.Armband = LoadBitmapFromLoader(EditorMain.ArmbandsLoader, this.ArmbandId ?? UniformBasedOn.ArmbandId);
            _assets.Holster = LoadBitmapFromLoader(EditorMain.HolstersLoader, this.HolsterId ?? UniformBasedOn.HolsterId);

            UpdateBackground();

            if (Colors.Count != _assets.Selections.Count)
            {
                Colors = new List<CustomColor>(_assets.Selections.Count);

                for (int i = 0; i < _assets.Selections.Count; i++)
                {
                    Colors.Add(new CustomColor());
                }
            }

            Drawer = new CustomDrawer<Bitmap>(_assets, Colors);
        }

        private Bitmap LoadBitmapFromLoader<T>(IFindable<T, Guid> loader, Guid? guid)
        {
            if (guid.HasValue)
                return (Bitmap)(loader.FindBy(guid.Value) as ItemBase).Image;
            return null;
        }
        public void Clear()
        {
            _result = null;
            Drawer = null;
        }
    }
}
