using System;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MPK
{
    public partial class FormMag : Form
    {
        public FormMag()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);

            myConnection.Open();
        }
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=magazine.mdb;";
        private OleDbConnection myConnection;
        private void FormMag_Load(object sender, EventArgs e)
        {
            {


                string query = "SELECT name FROM acqu";

                OleDbCommand command = new OleDbCommand(query, myConnection);


                OleDbDataReader reader = command.ExecuteReader();

                listBox1.Items.Clear();

                while (reader.Read())
                {
                    listBox1.Items.Add(reader[0].ToString() + " ");
                }


                reader.Close();
            }
            {
                string query = "SELECT avail FROM acqu";

                OleDbCommand command = new OleDbCommand(query, myConnection);


                OleDbDataReader reader = command.ExecuteReader();

                listBox2.Items.Clear();

                while (reader.Read())
                {
                    listBox2.Items.Add(reader[0].ToString() + " в наличии");
                }


                reader.Close();
            }
            {
                string query = "SELECT price FROM acqu";

                OleDbCommand command = new OleDbCommand(query, myConnection);


                OleDbDataReader reader = command.ExecuteReader();

                listBox3.Items.Clear();

                while (reader.Read())
                {
                    listBox3.Items.Add(reader[0].ToString() + " ₽ ");
                }


                reader.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //if (dataGridView1.SelectedRows.Count != 1)
            //{
            //    MessageBox.Show("Выберите строку!", "Внимание!");
            //    return;
            //}


            //int index = dataGridView1.SelectedRows[0].Index;


            //if (dataGridView1.Rows[index].Cells[0].Value == null)
            //{
            //    MessageBox.Show("Не все данные введены!", "Внимание!");
            //    return;
            //}



            //string tovar = dataGridView1.Rows[index].Cells[0].Value.ToString();


            //string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=magazine.mdb";
            //OleDbConnection dbConnection = new OleDbConnection(connectionString);


            //dbConnection.Open();
            //string query = "INSERT INTO zakaz VALUES ('" + tovar + "')";
            //OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);


            //if (dbCommand.ExecuteNonQuery() != 1)
            //    MessageBox.Show("Заказ оформлен!");
            //else
            //    MessageBox.Show("Заказ оформлен!");
            MessageBox.Show("Заказ оформлен!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            Form1 Form1 = new Form1();
            Form1.Show();
            FormCheck FormCheck = new FormCheck();
            FormCheck.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Form1 = new Form1();
            Form1.Show();
        }

        private void button2_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(new Point(0, 10), new Point(200, 10), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 255, 255, 255));
            Pen pen = new Pen(linGrBrush);
            e.Graphics.FillRectangle(linGrBrush, 0, 0, button2.Width, button2.Height);
            using (Font font1 = new Font("Comic Sans MS", 22, FontStyle.Bold, GraphicsUnit.Pixel))
            {
                PointF pointF1 = new PointF(button2.Width / 10, button2.Height / 100);
                e.Graphics.DrawString("Купить", font1, Brushes.White, pointF1);
            }
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(new Point(0, 10), new Point(200, 10), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(255, 255, 255, 255));
            Pen pen = new Pen(linGrBrush);
            e.Graphics.FillRectangle(linGrBrush, 0, 0, button1.Width, button1.Height);
            using (Font font1 = new Font("Comic Sans MS", 22, FontStyle.Bold, GraphicsUnit.Pixel))
            {
                PointF pointF1 = new PointF(button1.Width / 5, button1.Height / 100);
                e.Graphics.DrawString("Назад", font1, Brushes.White, pointF1);
            }
        }
    }
}
