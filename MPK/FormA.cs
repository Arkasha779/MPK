using System;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MPK
{
    public partial class FormA : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        public FormA()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string usr = txtUser.Text;
            string psw = txtPass.Text;
            con = new OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source=magazine.mdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            string str = "SELECT * FROM tblUser where user='" + txtUser.Text + "' AND pass='" + txtPass.Text + "'";
            cmd.CommandText = str;

            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Добро пожаловать: " + txtUser.Text, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form1 Form1 = new Form1();
                Form1.Show();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormReg FormReg = new FormReg();
            FormReg.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Form1 = new Form1();
            Form1.Show();
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(new Point(0, 10), new Point(200, 10), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 255, 255, 255));
            Pen pen = new Pen(linGrBrush);
            e.Graphics.FillRectangle(linGrBrush, 0, 0, button1.Width, button1.Height);
            using (Font font1 = new Font("Comic Sans MS", 22, FontStyle.Bold, GraphicsUnit.Pixel))
            {
                PointF pointF1 = new PointF(button1.Width / 5, button1.Height / 6);
                e.Graphics.DrawString("Вход", font1, Brushes.White, pointF1);
            }
        }

        private void button2_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(new Point(0, 10), new Point(200, 10), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 255, 255, 255));
            Pen pen = new Pen(linGrBrush);
            e.Graphics.FillRectangle(linGrBrush, 0, 0, button2.Width, button2.Height);
            using (Font font1 = new Font("Comic Sans MS", 22, FontStyle.Bold, GraphicsUnit.Pixel))
            {
                PointF pointF1 = new PointF(button2.Width / 100, button2.Height / 6);
                e.Graphics.DrawString("Регистрация", font1, Brushes.White, pointF1);
            }
        }
    }
}
