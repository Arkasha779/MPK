using System;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MPK
{
    public partial class FormReg : Form
    {
        public FormReg()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);

            myConnection.Open();
        }
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=magazine.mdb;";
        private OleDbConnection myConnection;

        private void button2_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count != 1)
            //{
            //    MessageBox.Show("Выберите строку!", "Внимание!");
            //    return;
            //}

            //int index = dataGridView1.SelectedRows[0].Index;

            //if (dataGridView1.Rows[index].Cells[0].Value == null ||
            //    dataGridView1.Rows[index].Cells[1].Value == null ||
            //    dataGridView1.Rows[index].Cells[2].Value == null ||
            //    dataGridView1.Rows[index].Cells[3].Value == null ||
            //    dataGridView1.Rows[index].Cells[4].Value == null ||
            //    dataGridView1.Rows[index].Cells[5].Value == null)
            //{
            //    MessageBox.Show("Не все данные введены!", "Внимание!");
            //    return;
            //}

            //string user = dataGridView1.Rows[index].Cells[0].Value.ToString();
            //string pass = dataGridView1.Rows[index].Cells[1].Value.ToString();
            //string name = dataGridView1.Rows[index].Cells[2].Value.ToString();
            //string secname = dataGridView1.Rows[index].Cells[3].Value.ToString();
            //string patr = dataGridView1.Rows[index].Cells[4].Value.ToString();
            //string adress = dataGridView1.Rows[index].Cells[5].Value.ToString();

            //string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=magazine.mdb";
            //OleDbConnection dbConnection = new OleDbConnection(connectionString);

            //dbConnection.Open();
            //string query = "INSERT INTO tblUser VALUES ('" + user + "', '" + pass + "','" + name + "','" + secname + "','" + patr + "','" + adress + "')";
            //OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

            //if (dbCommand.ExecuteNonQuery() != 1)
            //    MessageBox.Show("Вы не зарегистрированы!");
            //else
            //    MessageBox.Show("Вы зарегистрированы!");
            //this.Hide();
            //FormA FormA = new FormA();
            //FormA.Show();

            //dbConnection.Close();
            MessageBox.Show("Вы зарегистрированы!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            Form1 Form1 = new Form1();
            Form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormA FormA = new FormA();
            FormA.Show();
        }

        private void button2_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(new Point(0, 10), new Point(200, 10), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 255, 255, 255));
            Pen pen = new Pen(linGrBrush);
            e.Graphics.FillRectangle(linGrBrush, 0, 0, button2.Width, button2.Height);
            using (Font font1 = new Font("Comic Sans MS", 22, FontStyle.Bold, GraphicsUnit.Pixel))
            {
                PointF pointF1 = new PointF(button2.Width / 10, button2.Height / 200);
                e.Graphics.DrawString("Регистрация", font1, Brushes.White, pointF1);
            }
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(new Point(0, 10), new Point(200, 10), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 255, 255, 255));
            Pen pen = new Pen(linGrBrush);
            e.Graphics.FillRectangle(linGrBrush, 0, 0, button1.Width, button1.Height);
            using (Font font1 = new Font("Comic Sans MS", 22, FontStyle.Bold, GraphicsUnit.Pixel))
            {
                PointF pointF1 = new PointF(button1.Width / 100, button1.Height / 200);
                e.Graphics.DrawString("Назад", font1, Brushes.White, pointF1);
            }
        }
    }
}
