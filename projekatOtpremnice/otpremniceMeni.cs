using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace projekatOtpremnice
{
    public partial class otpremniceMeni : Form
    {
        public otpremniceMeni()
        {
            InitializeComponent();
        }

        private void otpremniceMeni_Load(object sender, EventArgs e)
        {
            provjera();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form pocetnaForma = new pocetnaForma();
            pocetnaForma.Show();

            this.Close();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form generisanjeOtpreminca = new generisanjeOtpremnica();
            generisanjeOtpreminca.Show();

            this.Close();
            this.Dispose();
        }

       

        private void pb_MouseEnter(object sender, System.EventArgs e) //izvrsava provjeru iz tajmera ako je kursor na picturebox
        {

            var taSlika = (PictureBox)sender;
            taSlika.BackColor = Color.LightSteelBlue;
        }
        private void pb_MouseLeave(object sender, System.EventArgs e) //izvrsava provjeru iz tajmera ako je kursor napustio picturebox
        {
            var taSlika = (PictureBox)sender;
            if (taSlika.Tag=="1")
            {
                taSlika.BackColor = Color.LightBlue;
            }
            else
            {
                taSlika.BackColor = Color.SteelBlue;
            }
        }

        private void klik_MouseClick(object sender, System.EventArgs e) //
        {

            //var taSlika = (PictureBox)sender;
            //taSlika.BackColor = Color.LightSteelBlue;
            var taSlika = (PictureBox)sender;
            if (taSlika.Tag != "1")
            {
                foreach (PictureBox pb in this.panel1.Controls)
                {
                    pb.Tag = "0";
                }
                taSlika.Tag = "1";
            }
        }

        private void provjera() //provjera koji je pictureBox aktivan
        {
            foreach (PictureBox pb in this.panel1.Controls)         //ovde dodati promjene tagova automatski
            {
                if (pb.Tag=="1")
                {
                    pb.BackColor = Color.LightSteelBlue;
                }
                else
                {
                    pb.BackColor = Color.SteelBlue;
                }

                foreach (PictureBox klik in this.panel1.Controls)
                {
                    klik.MouseClick += klik_MouseClick;
                }
            }
        } 

        //private void pictureBox2_Click(object sender, EventArgs e) //aktiviranje pictureboxa
        //{
        //    foreach (PictureBox pb in this.panel1.Controls)
        //    {
        //        pb.Tag = "0";
        //        pb.BackColor = Color.SteelBlue;
        //        pictureBox2.Tag = "1";

        //    }
        //}

        //private void pictureBox1_Click(object sender, EventArgs e)//aktiviranje pictureboxa
        //{
        //    foreach (PictureBox pb in this.panel1.Controls)
        //    {
        //        pb.Tag = "0";
        //        pb.BackColor = Color.SteelBlue;
        //        pictureBox1.Tag = "1";

        //    }
        //}

        //private void pictureBox3_Click(object sender, EventArgs e)//aktiviranje pictureboxa
        //{
        //    foreach (PictureBox pb in this.panel1.Controls)
        //    {
        //        pb.Tag = "0";
        //        pb.BackColor = Color.SteelBlue;
        //        pictureBox3.Tag = "1";
        //        pictureBox3.BackColor = Color.LightSteelBlue; 

        //    }
        //}


        private void panel1_Click(object sender, EventArgs e) //svaki click u panelu sa pictureboxovima provjerava koji je aktivan picturebox
        {
            provjera();
        }

        private void provjPanelaTimer_Tick(object sender, EventArgs e) //provjerava u real time da li je kursor na picturebox ili nije
        {
            foreach (PictureBox pb in this.panel1.Controls)
            {
                pb.MouseEnter += pb_MouseEnter;
              pb.MouseLeave += pb_MouseLeave;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        //    provjera();
        }
    }
}
