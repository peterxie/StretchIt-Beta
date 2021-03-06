﻿using System;
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
            this.color_bitmap = new WriteableBitmap(640, 480, 96.0, 96.0, PixelFormats.Bgr32, null);
            frame = new Frame_t(GlobalVar.TEMP_GESTURE_FILE);
            makeColor();
            saveImage();
            this.BackgroundImage = Image.FromFile(GlobalVar.TEMP_GESTURE_IMAGE_FILE);
            this.Visible = true;
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
            this.color_bitmap.WritePixels(
                new Int32Rect(0, 0, this.color_bitmap.PixelWidth, this.color_bitmap.PixelHeight),
                this.color_pixels,
                this.color_bitmap.PixelWidth * sizeof(int),
                0);
            
            // create a png bitmap encoder which knows how to save a .png file
            BitmapEncoder encoder = new PngBitmapEncoder();

            // create frame from the writable bitmap and add to encoder
            encoder.Frames.Add(BitmapFrame.Create(this.color_bitmap));

            // write the new file to disk
            try
            {
                using (FileStream fs = new FileStream(GlobalVar.TEMP_GESTURE_IMAGE_FILE, FileMode.Create))
                {
                    encoder.Save(fs);
                    fs.Close();
                }
            }
            catch (IOException)
            {
                  
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GestureImage
            // 
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Name = "GestureImage";
            this.Text = "Gesture Image";
            this.ResumeLayout(false);

        }

        //Not sure we need this anymore since we are overwriting the png
        private void GestureImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.BackgroundImage = null;
            this.Update();
        }
    }
}
