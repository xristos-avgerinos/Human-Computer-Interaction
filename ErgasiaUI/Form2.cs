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
    public partial class Form2 : Form
    {
        String connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=UIdatabase.mdb";
        OleDbConnection connection;
        String Username;
        String Picture;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(String username,String picture)
        {
            InitializeComponent();
            Username = username;
            Picture = picture;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection(connectionString);
            label3.Text = Username;
            pictureBox8.ImageLocation = Picture;
            label2.Text = DateTime.Now.ToString();
            openFileDialog1.InitialDirectory = "c:\\";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox10.Visible)
            {
                pictureBox10.Visible = false;
            }
            else
            {
                pictureBox10.Visible = true;
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 form5 = new Form5();
            form5.ShowDialog();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form6 = new Form6();
            form6.ShowDialog();
            this.Close();
        }

        private void planYourDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
            this.Close();
        }

        private void manageYourDevicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 form5 = new Form5();
            form5.ShowDialog();
            this.Close();
        }

        private void feedYourPetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form6 = new Form6();
            form6.ShowDialog();
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("outlook.exe");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox8.ImageLocation = openFileDialog1.FileName;

                connection.Open();

                //UPDATE  DATABASE
                String Query = "UPDATE Users SET Picture = @pic WHERE Username = @user";
                OleDbCommand cmd = new OleDbCommand(Query, connection);

                cmd.Parameters.AddWithValue("@pic", openFileDialog1.FileName);
                cmd.Parameters.AddWithValue("@user", Username);
                cmd.ExecuteNonQuery();


                connection.Close();

                //System.IO.File.Copy(openFileDialog1.FileName, "images\\user_icon.png", true);

            }
        }
    }
}
