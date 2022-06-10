using System;
using System.Windows.Forms;

namespace MPK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRem FormRem = new FormRem();
            FormRem.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRem FormRem = new FormRem();
            FormRem.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPro FormPro = new FormPro();
            FormPro.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPro FormPro = new FormPro();
            FormPro.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMag FormMag = new FormMag();
            FormMag.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMag FormMag = new FormMag();
            FormMag.Show();
        }
    }
}
