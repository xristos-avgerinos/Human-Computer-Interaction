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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Check if Username and Password are not null or contain space
            if (!string.IsNullOrEmpty(textBox1.Text) && !(textBox1.Text.Contains(" ")) && !string.IsNullOrEmpty(textBox2.Text) && !(textBox2.Text.Contains(" ")))
            {
                //Saving to DATABASE
                String connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=UIdatabase.mdb";
                OleDbConnection connection = new OleDbConnection(connectionString);
                connection.Open();


                String Query = "INSERT INTO Users ([Username],[Password]) VALUES (@name,@pass)";
                OleDbCommand cmd = new OleDbCommand(Query, connection);

                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                cmd.ExecuteNonQuery();


                connection.Close();

                label4.Text = "Account Created Succesfully";
                label4.ForeColor = Color.Green;
                label4.Visible = true;

            }
            else if (string.IsNullOrEmpty(textBox1.Text) || textBox1.Text.Contains(" "))//Username is NULL or contains SPACE
            {
                label4.Text = "Username is NULL or contains space";
                label4.Visible = true;
                label4.ForeColor = Color.Red;

            }
            else if (string.IsNullOrEmpty(textBox2.Text) || textBox2.Text.Contains(" "))//Pass is NULL or contains SPACE 
            {
                label4.Text = "Password is NULL or contains space";
                label4.Visible = true;
                label4.ForeColor = Color.Red;

            }
            
        }
    }
}
