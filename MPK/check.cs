using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace MPK
{
    public partial class check : Form
    {
        public check()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();

           button1.Click += Button1_Click;
           openFileDialog1.Filter = "Text files(*.docx)|*.docx|All files(*.*)|*.*";
           saveFileDialog1.Filter = "Text files(*.docx)|*.docx|All files(*.*)|*.*";


        }
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=magazine.mdb;";
        private OleDbConnection myConnection;

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Check_Load(object sender, EventArgs e)
        {
            string query = "SELECT tovar FROM zakaz";

                OleDbCommand command = new OleDbCommand(query, myConnection);


                OleDbDataReader reader = command.ExecuteReader();

                listBox2.Items.Clear();

                while (reader.Read())
                {
                    listBox2.Items.Add(reader[0].ToString() + " ");
                }


                reader.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, listBox2.Text);
            MessageBox.Show("Файл сохранен");
        }
    }
}

