using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;


namespace bright
{
    public partial class Form1 : Form
    {
        Bitmap originBmp;
        public Form1()
        {
            InitializeComponent();
            originBmp = new Bitmap(pictureBox1.Image);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double value = trackBar1.Value;
            if (value != 0)
            {
                Bitmap bmp = new Bitmap(originBmp);
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
                IntPtr ptr = bmpData.Scan0;
                byte[] rgbValues = new byte[bmpData.Stride * bmp.Height];
                Marshal.Copy(ptr, rgbValues, 0, rgbValues.Length);
                for (int i = 0; i < rgbValues.Length; i += 4)
                {
                    double b = rgbValues[i];
                    b += value;
                    if (b > 255)
                        b = 255;
                    else if (b < 0)
                        b = 0;
                    rgbValues[i] = Convert.ToByte(b);

                }
                Marshal.Copy(rgbValues, 0, ptr, rgbValues.Length);
                bmp.UnlockBits(bmpData);
                pictureBox1.Image = bmp;
            }
            else
            {
                pictureBox1.Image = originBmp;
            }
            
        
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            double value = trackBar2.Value;
            if (value != 0)
            {
                Bitmap bmp = new Bitmap(originBmp);
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
                IntPtr ptr = bmpData.Scan0;
                byte[] rgbValues = new byte[bmpData.Stride * bmp.Height];
                Marshal.Copy(ptr, rgbValues, 0, rgbValues.Length);
                for (int i = 0; i < rgbValues.Length; i += 4)
                {
                    double g = rgbValues[i+1];
                    g += value;
                    if (g > 255)
                        g = 255;
                    else if (g < 0)
                        g = 0;
                    rgbValues[i+1] = Convert.ToByte(g);
                }
                Marshal.Copy(rgbValues, 0, ptr, rgbValues.Length);
                bmp.UnlockBits(bmpData);
                pictureBox1.Image = bmp;
            }
            else
            {
                pictureBox1.Image = originBmp;
            }

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            double value = trackBar3.Value;
            if (value != 0)
            {
                Bitmap bmp = new Bitmap(originBmp);
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
                IntPtr ptr = bmpData.Scan0;
                byte[] rgbValues = new byte[bmpData.Stride * bmp.Height];
                Marshal.Copy(ptr, rgbValues, 0, rgbValues.Length);
                for (int i = 0; i < rgbValues.Length; i += 4)
                {
                    double r = rgbValues[i+2];
                    r += value;
                    if (r > 255)
                        r = 255;
                    else if (r < 0)
                        r = 0;
                    rgbValues[i+2] = Convert.ToByte(r);
                }
                Marshal.Copy(rgbValues, 0, ptr, rgbValues.Length);
                bmp.UnlockBits(bmpData);
                pictureBox1.Image = bmp;
            }
            else
            {
                pictureBox1.Image = originBmp;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(originBmp);
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            byte[] rgbValues = new byte[bmpData.Stride * bmp.Height];
            Marshal.Copy(ptr, rgbValues, 0, rgbValues.Length);
            double I;
            for (int i = 0; i < rgbValues.Length; i += 4)
            {
                I = 0.299 * rgbValues[i + 2] + 0.587 * rgbValues[i + 1] + 0.114 * rgbValues[i];
                if (I > 255)
                    I = 255;
                rgbValues[i] = Convert.ToByte(I);
                rgbValues[i+1] = Convert.ToByte(I);
                rgbValues[i+2] = Convert.ToByte(I);
            }
            Marshal.Copy(rgbValues, 0, ptr, rgbValues.Length);
            bmp.UnlockBits(bmpData);
            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(originBmp);
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            byte[] rgbValues = new byte[bmpData.Stride * bmp.Height];
            Marshal.Copy(ptr, rgbValues, 0, rgbValues.Length);
            double I;
            for (int i = 0; i < rgbValues.Length; i += 4)
            {
                I = 0.22 * rgbValues[i + 2] + 0.76 * rgbValues[i + 1] + 0.02 * rgbValues[i];
                if (I > 255)
                    I = 255;
                rgbValues[i] = Convert.ToByte(I);
                rgbValues[i + 1] = Convert.ToByte(I);
                rgbValues[i + 2] = Convert.ToByte(I);
            }
            Marshal.Copy(rgbValues, 0, ptr, rgbValues.Length);
            bmp.UnlockBits(bmpData);
            pictureBox1.Image = bmp;
        }
    }
}
