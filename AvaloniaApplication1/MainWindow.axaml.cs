using Avalonia.Controls;
using Innovation_Uniform_Editor_Backend;
using Innovation_Uniform_Editor_Backend.Models;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Bitmap = Avalonia.Media.Imaging.Bitmap;

namespace AvaloniaApplication1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EditorMain.Initialize();

            Custom custom = new Custom();
            custom.ChangeUniform(EditorMain.Uniforms.GetAll()[0]);

            Avalonia.Controls.Image? image = this.FindControl<Avalonia.Controls.Image>("TEST");

            using (MemoryStream memory = new MemoryStream())
            {
                custom.Result.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                //AvIrBitmap is our new Avalonia compatible image. You can pass this to your view
                Avalonia.Media.Imaging.Bitmap AvIrBitmap = new Avalonia.Media.Imaging.Bitmap(memory);
                image.Source = AvIrBitmap;
            }
        }
    }
}