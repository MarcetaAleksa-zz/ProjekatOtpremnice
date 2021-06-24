using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekatOtpremnice
{
    public partial class pocetnaForma : Form
    {
        public pocetnaForma()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form otpremniceMeni = new otpremniceMeni();

            otpremniceMeni.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form servisMeni = new Form();

            servisMeni.Show();
            this.Hide();
        }
    }
}
