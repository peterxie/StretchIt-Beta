using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace StretchIt
{
    public partial class GestureImage : Form
    {
        private WriteableBitmap color_bitmap;
        private byte[] color_pixels;
        Frame_t frame;

        public GestureImage()
        {
            InitializeComponent();

            this.color_pixels = new byte[1228800];
            this.color_bitmap = new WriteableBitmap(480, 640, 96.0, 96.0, PixelFormats.Bgr32, null);
            Frame_t frame = new Frame_t(@"../../Gestures/gesture.txt");
            makeColor();
            saveImage();
            this.BackgroundImage = Image.FromFile(@"../../Gestures/gesture.txt");
        }


        private void makeColor()
        {
            const int BlueIndex = 0;
            const int GreenIndex = 1;
            const int RedIndex = 2;

            short[] depth_pixels = frame.getPixels();

            for (int depthIndex = 0, colorIndex = 0;
                depthIndex < depth_pixels.Length && colorIndex < this.color_pixels.Length;
                depthIndex++, colorIndex += 4)
            {
                if (depth_pixels[depthIndex] > 100)
                {
                    this.color_pixels[colorIndex + BlueIndex] = 255;
                    this.color_pixels[colorIndex + GreenIndex] = 0;
                    this.color_pixels[colorIndex + RedIndex] = 0;
                }
                else if (depth_pixels[depthIndex] < -100)
                {
                    this.color_pixels[colorIndex + BlueIndex] = 0;
                    this.color_pixels[colorIndex + GreenIndex] = 255;
                    this.color_pixels[colorIndex + RedIndex] = 0;
                }
                else
                {
                    this.color_pixels[colorIndex + BlueIndex] = 255;
                    this.color_pixels[colorIndex + GreenIndex] = 255;
                    this.color_pixels[colorIndex + RedIndex] = 255;
                }
            }
            return;
        }

        private void saveImage()
        {
            // create a png bitmap encoder which knows how to save a .png file
            BitmapEncoder encoder = new PngBitmapEncoder();

            // create frame from the writable bitmap and add to encoder
            encoder.Frames.Add(BitmapFrame.Create(this.color_bitmap));

            string path = @"../../Gestures/gesture.png";

            // write the new file to disk
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                encoder.Save(fs);
            }
        }
    }
}
