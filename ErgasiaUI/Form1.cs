using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgasiaUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=UIdatabase.mdb";
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            String query = "Select Username,Password From Users Where Username=@user and Password=@pass";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@user", textBox1.Text);
            command.Parameters.AddWithValue("@pass", textBox2.Text);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                this.Hide();
                Form2 form2 = new Form2();
                form2.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong username and/or password");
            }
            connection.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.ShowDialog();
            this.Close();
        }

       
    }
}
