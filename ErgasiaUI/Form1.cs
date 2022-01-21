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
        String connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=UIdatabase.mdb";
        OleDbConnection connection;
        public bool eye_icon = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection(connectionString);
            pictureBox4.ImageLocation = "Images/eye.png";
            //pictureBox4.ImageLocation = "Images/visa.png";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            //Check if Username and Password are not null or contain space
            if (!string.IsNullOrEmpty(textBox1.Text) && !(textBox1.Text.Contains(" ")) && !string.IsNullOrEmpty(textBox2.Text) && !(textBox2.Text.Contains(" ")))
            {

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
                    label5.Text = "Couldn't find account";
                    label5.Visible = true;
                    label5.ForeColor = Color.Red;
                }
                connection.Close();
            }
            else if (string.IsNullOrEmpty(textBox1.Text) || textBox1.Text.Contains(" "))//Username is NULL or contains SPACE
            {
                label3.Text = "Username is NULL or contains space";
                label3.Visible = true;
                label3.ForeColor = Color.Red;

            }
            else if (string.IsNullOrEmpty(textBox2.Text) || textBox2.Text.Contains(" "))//Pass is NULL or contains SPACE 
            {
                label4.Text = "Password is NULL or contains space";
                label4.Visible = true;
                label4.ForeColor = Color.Red;

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.ShowDialog();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (!eye_icon)
            {
                eye_icon = true;
                pictureBox4.ImageLocation = "Images/eye.png";
                textBox2.PasswordChar = '\0';
            }
            else
            {
                eye_icon = false;
                pictureBox4.ImageLocation = "Images/no_eye.png";
                textBox2.PasswordChar = '*';
            }
        }
    }
}
