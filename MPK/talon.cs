using System;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Xceed.Words.NET;

namespace MPK
{
    public partial class talon : Form
    {
        public talon()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);

            myConnection.Open();
        }
        string gpath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"/Receipt.docx";

        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=magazine.mdb;";
        private OleDbConnection myConnection;

        private void talon_Load(object sender, EventArgs e)
        {
            {


                string query = "SELECT last(Date) FROM Zapis";

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
                string query = "SELECT last(name) FROM Zapis";

                OleDbCommand command = new OleDbCommand(query, myConnection);


                OleDbDataReader reader = command.ExecuteReader();

                listBox2.Items.Clear();

                while (reader.Read())
                {
                    listBox2.Items.Add(reader[0].ToString() + " ");
                }


                reader.Close();
            }
            {


                string query = "SELECT last(user) FROM tblUser";

                OleDbCommand command = new OleDbCommand(query, myConnection);


                OleDbDataReader reader = command.ExecuteReader();

                listBox3.Items.Clear();

                while (reader.Read())
                {
                    listBox3.Items.Add(reader[0].ToString() + " ");
                }


                reader.Close();
            }
            {
                int today = DateTime.Now.Day;
                textBox1.Text = DateTime.Now.AddMonths(0).AddDays((today - 15)).ToString("dd.MM.yyyy");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                if (listBox1.Text != "")
                {
                    string userMessage = listBox1.Text;
                    string userMessage2 = listBox2.Text;
                    string datenow = textBox1.Text;
                    string adres = textBox2.Text;
                    string user = listBox3.Text;

                    DocX obj = DocX.Create(gpath);
                    obj.InsertParagraph("Магазин ремонта компьютеров                                               " + "Дата формирования заказа: " + datenow);
                    obj.InsertParagraph("Имя заказчика: " + user);
                    obj.InsertParagraph("Тип услуги: Ремонт Компьютера." + " Ремонт или замена: " + userMessage2 + ".");
                    obj.InsertParagraph("Дата Вашей записи: " + userMessage + ".");
                    obj.InsertParagraph("Наш адрес: " + adres);
                    obj.Save();
                    Process.Start("winword.exe", gpath);
                }
                else
                {

                    MessageBox.Show("Выберети строку даты и строку программы");
                }
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
                e.Graphics.DrawString("Печть в Word", font1, Brushes.White, pointF1);
            }
        }
    }
}
