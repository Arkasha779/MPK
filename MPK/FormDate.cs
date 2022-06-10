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
    public partial class FormDate : Form
    {
        public FormDate()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);

            myConnection.Open();
        }
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=magazine.mdb;";
        private OleDbConnection myConnection;

        private void FormDate_Load(object sender, EventArgs e)
        {
            string query = "SELECT data FROM data";

            OleDbCommand command = new OleDbCommand(query, myConnection);


            OleDbDataReader reader = command.ExecuteReader();

            listBox1.Items.Clear();

            while (reader.Read())
            {
                listBox1.Items.Add(reader[0].ToString() + " ");
            }


            reader.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
