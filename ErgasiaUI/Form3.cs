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
        //Saving to DATABASE
        String connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=UIdatabase.mdb";
        OleDbConnection connection;
        public bool eye_icon = false;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
             connection = new OleDbConnection(connectionString);
             
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;

            //Check if Username and Password are not null or contain space
            if (!string.IsNullOrEmpty(textBox1.Text) && !(textBox1.Text.Contains(" ")) && !string.IsNullOrEmpty(textBox2.Text) && !(textBox2.Text.Contains(" ")) && (checkBox1.Checked))
            {
                
                connection.Open();


                String Query = "INSERT INTO Users ([Username],[Password]) VALUES (@name,@pass)";
                OleDbCommand cmd = new OleDbCommand(Query, connection);

                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                cmd.ExecuteNonQuery();


                connection.Close();

                MessageBox.Show("Account was succesfully created!");
                this.Hide();
                Form2 form2 = new Form2();
                form2.ShowDialog();
                this.Close();
            }
            else if (string.IsNullOrEmpty(textBox1.Text) || textBox1.Text.Contains(" "))//Username is NULL or contains SPACE
            {
                label3.Text = "Username is NULL or contains space";
                label3.Visible= true;
                label3.ForeColor = Color.Red;

            }
            else if (string.IsNullOrEmpty(textBox2.Text) || textBox2.Text.Contains(" "))//Pass is NULL or contains SPACE 
            {
                label4.Text = "Password is NULL or contains space";
                label4.Visible = true;
                label4.ForeColor = Color.Red;

            }
            else if (!checkBox1.Checked)
            {
                label5.Text = "You have to agree with the Terms and Conditions";
                label5.Visible = true;
                label5.ForeColor = Color.Red;

            }

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (!eye_icon)
            {
                eye_icon = true;
                pictureBox5.ImageLocation = "Images/eye.png";
                textBox2.PasswordChar = '\0';
            }
            else
            {
                eye_icon = false;
                pictureBox5.ImageLocation = "Images/no_eye.png";
                textBox2.PasswordChar = '*';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }
    }
}
