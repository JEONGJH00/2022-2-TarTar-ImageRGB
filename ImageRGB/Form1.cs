using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageRGB
{
    public partial class Form1 : Form
    {
        Image Dental;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Dental = pictureBox1.Image.Clone() as Image;
        }

        private Bitmap PictureBoxReset()

        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureBox1.Image.Dispose(); //데이터를 드랍시킨다.

            pictureBox1.Image = Dental.Clone() as Image; //복사본을 가져온다.



            Bitmap tmp = pictureBox1.Image as Bitmap;

            //픽셀정보를 알아오기 위하여 비트맵을 얻어온다.         

            return tmp;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap tmp = PictureBoxReset();



            int width = tmp.Width;

            int height = tmp.Height;



            Color colorData;

            for (int i = 0; i < width; i++)

            {

                for (int j = 0; j < height; j++)

                {

                    colorData = tmp.GetPixel(i, j);

                    RColorConvert(ref colorData);

                    tmp.SetPixel(i, j, colorData);

                }

            }

        }

        private void RColorConvert(ref Color src)

        {

            if (src.R < 70)
            {

                int res = (src.R + src.G + src.B) / 3;

                src = Color.FromArgb(res, res, res);

            }
            else if (src.B > 90)
            {


                src = Color.FromArgb(255, 255, 255);
            }

            else if (src.G > 100)
            {


                src = Color.FromArgb(255, 51, 153);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap tmp = PictureBoxReset();



            int width = tmp.Width;

            int height = tmp.Height;



            Color colorData;

            for (int i = 0; i < width; i++)

            {

                for (int j = 0; j < height; j++)

                {

                    colorData = tmp.GetPixel(i, j);

                    GColorConvert(ref colorData);

                    tmp.SetPixel(i, j, colorData);

                }

            }
            
        }
        private void GColorConvert(ref Color src)

        {

            if ((src.G < src.R) || (src.G < src.B)) //그린 성분이 상대적으로 적다면 회색화

            {

                int res = (src.R + src.G + src.B) / 3;

                src = Color.FromArgb(res, res, res);

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap tmp = PictureBoxReset();



            int width = tmp.Width;

            int height = tmp.Height;



            Color colorData;

            for (int i = 0; i < width; i++)

            {

                for (int j = 0; j < height; j++)

                {

                    colorData = tmp.GetPixel(i, j);

                    BColorConvert(ref colorData);

                    tmp.SetPixel(i, j, colorData);

                }

            }
            
        }
        private void BColorConvert(ref Color src)

        {

            if ((src.B < src.R) || (src.B < src.G)) //블루 성분이 상대적으로 적다면 회색화

            {

                int res = (src.R + src.G + src.B) / 3;

                src = Color.FromArgb(res, res, res);

            }

        }
        
    }
}
