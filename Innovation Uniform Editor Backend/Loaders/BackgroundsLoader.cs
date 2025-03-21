﻿using Innovation_Uniform_Editor_Backend.Helpers;
using Innovation_Uniform_Editor_Backend.Images;
using Innovation_Uniform_Editor_Backend.Loaders.Base;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Innovation_Uniform_Editor_Backend.Loaders
{
    public class BackgroundsLoader : Loader<BackgroundImage, Guid>
    {
        public BackgroundsLoader(string path) : base(path)
        {
        }
        /// <summary>
        /// Loads all existing background images from disk.
        /// </summary>
        public override void Load()
        {
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);

            string[] directories = Directory.GetFiles(_path, "*", SearchOption.TopDirectoryOnly);
            foreach (string image in directories)
            {
                BackgroundImage bg = new BackgroundImage(Path.GetFileName(image).Replace(".png", ""));
                Add(bg);
            }
        }
        /// <summary>
        /// Adds a new background image from an image.
        /// </summary>
        /// <param name="image">The image to turn into a background image.</param>
        public void Add(Image image)
        {
            BackgroundImage newBackground = new BackgroundImage(image);
            image.Save(_path + "/" + newBackground.Id + ".png", ImageFormat.Png);
            Add(newBackground);
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
            Add(resizedBackground);
        }

        public override void DeleteBy(Guid guid)
        {
            string path = $"{_path}/{guid}.png";
            if (File.Exists(path))
                File.Delete(path);
            base.DeleteBy(guid);
        }
    }
}
