using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace projekatOtpremnice
{
    public partial class generisanjeOtpremnica : Form
    {
        public generisanjeOtpremnica()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form otpremniceMeni = new otpremniceMeni();
            otpremniceMeni.Show();

            this.Close();
            this.Dispose();
        }
    }
}
