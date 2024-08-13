using Innovation_Uniform_Editor.Classes.Helpers;
using Innovation_Uniform_Editor.Classes.Images;
using Innovation_Uniform_Editor.Classes.Loaders.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Innovation_Uniform_Editor.Classes.Loaders
{
    public class BackgroundsLoader : Loader<BackgroundImage, Guid>
    {
        public BackgroundsLoader(string path) : base(path)
        {
        }
        /// <summary>
        /// Loads all existing background images from disk.
        /// </summary>
        protected override void Load()
        {
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);

            string[] directories = Directory.GetFiles(_path, "*", SearchOption.TopDirectoryOnly);
            foreach (string image in directories)
            {
                BackgroundImage bg = new BackgroundImage(image.Replace(_path, "").Replace(".png", ""));
                this.Add(bg);
            }
        }
        /// <summary>
        /// Adds a new background image from an image.
        /// </summary>
        /// <param name="image">The image to turn into a background image.</param>
        public void Add(Image image)
        {
            this.Add(new BackgroundImage(image));
        }
        /// <summary>
        /// Loads and adds a new background from path.
        /// </summary>
        /// <param name="path">Path to an image.</param>
        public void Add(string path)
        {
            FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read);
            Image resizedBackground = ImageHelper.resizeImage(Image.FromStream(fs), new Size(585, 559));
            fs.Close();
            this.Add(resizedBackground);
        }

        public override void DeleteBy(Guid guid)
        {
            string path = this._path + guid;
            if (File.Exists(path))
                File.Delete(path);
            base.DeleteBy(guid);
        }
    }
}
