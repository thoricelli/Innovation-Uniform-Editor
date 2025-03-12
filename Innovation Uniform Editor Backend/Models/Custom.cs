using Innovation_Uniform_Editor_Backend.Drawers;
using Innovation_Uniform_Editor_Backend.Globals;
using Innovation_Uniform_Editor_Backend.Helpers;
using Innovation_Uniform_Editor_Backend.Images;
using Innovation_Uniform_Editor_Backend.Loaders;
using Innovation_Uniform_Editor_Backend.Loaders.Interfaces;
using Innovation_Uniform_Editor_Backend.Models.Assets;
using Innovation_Uniform_Editor_Backend.Models.Base;
using Innovation_Uniform_Editor_Backend.Models.Interfaces;
using Innovation_Uniform_Editor_Backend.Models.OverlayAssets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
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
        public Guid[] LogoPresets { get; set; }
        public Guid? HolsterId { get; set; }
        public Guid? ArmbandId { get; set; }
        public Guid? ShoeId { get; set; }
        public Guid? GloveId { get; set; }
        public Version MinimumVersion { get; set; } = EditorMain.Version;
        private List<Preset> _presets { get; set; }
        [JsonIgnore]
        public List<Preset> Presets 
        { 
            get
            {
                if (_presets == null)
                {
                    if (UniformBasedOn.LogoIds != null)
                    {
                        if (LogoPresets == null)
                            _presets = EditorMain.PresetsLoader.FindAllBy(UniformBasedOn.LogoIds.Select(x => x.Preset.Id).ToList());
                        else
                            _presets = EditorMain.PresetsLoader.FindAllBy(LogoPresets.ToList());
                    }
                    else
                        _presets = new List<Preset>();
                }
                return _presets;
            }
        }
        private Holster _holster;
        [JsonIgnore]
        public Holster Holster 
        { 
            get
            {
                Guid? holsterId = this.HolsterId.HasValue ? this.HolsterId : this.UniformBasedOn.HolsterId;

                if (!holsterId.HasValue)
                    return null;

                if (_holster == null)
                    _holster = EditorMain.HolstersLoader.FindBy(holsterId.Value);
                return _holster;
            } 
        }
        private Armband _armband;
        [JsonIgnore]
        public Armband Armband
        {
            get
            {
                Guid? armbandId = this.ArmbandId.HasValue ? this.ArmbandId : this.UniformBasedOn.ArmbandId;

                if (!armbandId.HasValue)
                    return null;

                if (_armband == null)
                    _armband = EditorMain.ArmbandsLoader.FindBy(armbandId.Value);
                return _armband;
            }
        }
        private Glove _glove;
        [JsonIgnore]
        public Glove Glove
        {
            get
            {
                Guid? gloveId = this.GloveId.HasValue ? this.GloveId : this.UniformBasedOn.GloveId;

                if (!gloveId.HasValue)
                    return null;

                if (_glove == null)
                    _glove = EditorMain.GlovesLoader.FindBy(gloveId.Value);
                return _glove;
            }
        }
        private Shoe _shoe;
        [JsonIgnore]
        public Shoe Shoe
        {
            get
            {
                Guid? shoeId = this.ShoeId.HasValue ? this.ShoeId : this.UniformBasedOn.ShoeId;

                if (!shoeId.HasValue)
                    return null;

                if (_shoe == null)
                    _shoe = EditorMain.ShoesLoader.FindBy(shoeId.Value);
                return _shoe;
            }
        }
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
        public Guid? BackgroundImageGuid { get; set; }
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
            SaveJsonToFile($"{EditorPaths.CustomsPath}/{Id}/info.json");

            Image downSized = ImageHelper.resizeImage(Result, new Size(293, 280));
            downSized.Save($"{EditorPaths.CustomsPath}/" + Id + "/result.png", ImageFormat.Png);
            UnsavedChanges = false;
        }
        public void SaveJsonToFile(string filepath)
        {
            JsonSerializer serializer = new JsonSerializer()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            using (StreamWriter sw = new StreamWriter(filepath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, this);
            }
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

                Colors = new List<CustomColor>();

                this.LogoPresets = null;

                this.GloveId = null;
                this._glove = null;

                this.GloveId = null;
                this._shoe = null;

                this.ArmbandId = null;
                this._armband = null;

                this.HolsterId = null;
                this._holster = null;

                Initialize();
            }
        }
        public void ChangeBackground(BackgroundImage bgs)
        {
            BackgroundImageGuid = bgs.Id;

            UpdateBackground();

            _result = null;
            UnsavedChanges = true;

            UnsavedChanges = true;
            Initialize();
        }
        public void ChangeLogoPresetAtIndex(int index, Preset preset)
        {
            Guid security = EditorMain.PresetsLoader.FindBy(new Guid("ae418e5f-65ba-4f00-84f1-a69ea34d568e")).Id;

            if (LogoPresets == null)
                LogoPresets = UniformBasedOn.LogoIds.Select(x => x.PresetGuid.HasValue ? x.PresetGuid.Value : security).ToArray();

            LogoPresets[index] = preset.Id;

            _presets[index] = preset;

            UnsavedChanges = true;
        }
        //This is terrible, change this with an array please :(
        public void ChangeHolster(Holster holster)
        {
            if (holster != null)
            {
                this.HolsterId = holster.Id;
                Initialize();
            }
            else
                ClearHolster();

            UnsavedChanges = true;
        }
        public void ClearHolster()
        {
            this.HolsterId = null;

            UnsavedChanges = true;
            Initialize();
        }
        public void ChangeArmband(Armband armband)
        {
            if (armband != null)
            {
                this.ArmbandId = armband.Id;
                Initialize();
            }
            else
                ClearArmband();

            UnsavedChanges = true;
        }
        public void ClearArmband()
        {
            this.ArmbandId = null;

            UnsavedChanges = true;
            Initialize();
        }
        public void ChangeShoe(Shoe shoe)
        {
            if (shoe != null)
            {
                this.ShoeId = shoe.Id;
                Initialize();
            }
            else
                ClearShoe();

            UnsavedChanges = true;
        }
        public void ClearShoe()
        {
            this.ShoeId = null;

            UnsavedChanges = true;
            Initialize();
        }

        public void ChangeGlove(Glove glove)
        {
            if (glove != null)
            {
                this.GloveId = glove.Id;
                Initialize();
            }
            else
                ClearGlove();

            UnsavedChanges = true;
        }
        public void ClearGlove()
        {
            this.GloveId = null;

            UnsavedChanges = true;
            Initialize();
        }
        private void UpdateBackground()
        {
            if (BackgroundImageGuid.HasValue)
                _backgroundImage = EditorMain.Backgrounds.FindBy(BackgroundImageGuid.Value);
            if (_backgroundImage != null)
                _assets.Background = new Bitmap(_backgroundImage.Image);
        }
        public void ClearBackground()
        {
            _backgroundImage = null;
            BackgroundImageGuid = null;
            _assets.Background = null;

            _result = null;
            UnsavedChanges = true;

            Initialize();
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

            this._presets = null;

            this._glove = null;
            this._shoe = null;
            this._armband = null;
            this._holster = null;

            _assets = UniformAssetsLoader.GetAssetsForUniform(UniformBasedOn);

            _assets.Glove = LoadBitmapFromLoader(EditorMain.GlovesLoader, this.GloveId ?? UniformBasedOn.GloveId);
            _assets.Shoe = LoadBitmapFromLoader(EditorMain.ShoesLoader, this.ShoeId ?? UniformBasedOn.ShoeId);
            _assets.Armband = LoadBitmapFromLoader(EditorMain.ArmbandsLoader, this.ArmbandId ?? UniformBasedOn.ArmbandId);
            _assets.Holster = LoadBitmapFromLoader(EditorMain.HolstersLoader, this.HolsterId ?? UniformBasedOn.HolsterId);

            UpdateBackground();

            if (UniformBasedOn.Colors != null && Colors.Count <= 0 && UniformBasedOn.Colors.Count() > 0)
                Colors = new List<CustomColor>(UniformBasedOn.Colors);
            else
            {
                if (Colors.Count != _assets.Selections.Count)
                {
                    Colors = new List<CustomColor>(_assets.Selections.Count);

                    for (int i = 0; i < _assets.Selections.Count; i++)
                    {
                        Colors.Add(new CustomColor());
                    }
                }
            }

            Drawer = new CustomDrawer<Bitmap>(_assets, this);
        }

        private Bitmap LoadBitmapFromLoader<T>(IFindable<T, Guid> loader, Guid? guid)
        {
            if (guid.HasValue)
                return (Bitmap)(loader.FindBy(guid.Value) as ItemBase<Guid>).Image;
            return null;
        }
        public void Clear()
        {
            _result = null;
            Drawer = null;
        }
    }
}
