using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgasiaUI
{
    public partial class Form10 : Form
    {
        public static bool ON = false;
        public static string room = "Images/kitchen";//default room
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (ON)
            {
                pictureBox3.ImageLocation = "Images/lightsOff.png";
                pictureBox10.Visible = false;
                foreach(Control control in panel2.Controls)
                {
                    control.Visible = false;
                }
                foreach (Control control in panel4.Controls)
                {
                    control.Visible = false;
                }
                ON = false;
                

            }
            else
            {
                pictureBox3.ImageLocation = "Images/lightsOn.png";
                foreach (Control control in panel2.Controls)
                {
                    control.Visible = true;
                }
                foreach (Control control in panel4.Controls)
                {
                    control.Visible = true;
                }

                ON = true;
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form10.room = "Images/kitchen";
            pictureBox1.ImageLocation = Home.Kitchen.LightsPhoto;
            label1.Text = Home.Kitchen.color;
            label2.Text = Home.Kitchen.brightness;
            if (Home.Kitchen.color.Equals("Default"))
            {
                panel1.BackColor = Color.Gainsboro;
            }
            else
            {
                panel1.BackColor = Color.FromName(Home.Kitchen.color);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form10.room = "Images/living";
            pictureBox1.ImageLocation = Home.LivingRoom.LightsPhoto;
            label1.Text = Home.LivingRoom.color;
            label2.Text = Home.LivingRoom.brightness;
            if (Home.LivingRoom.color.Equals("Default"))
            {
                panel1.BackColor = Color.Gainsboro;
            }
            else
            {
                panel1.BackColor = Color.FromName(Home.LivingRoom.color);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form10.room = "Images/bedroom";
            pictureBox1.ImageLocation = Home.Bedroom.LightsPhoto;
            label1.Text = Home.Bedroom.color;
            label2.Text = Home.Bedroom.brightness;
            if (Home.Bedroom.color.Equals("Default"))
            {
                panel1.BackColor = Color.Gainsboro;
            }
            else
            {
                panel1.BackColor = Color.FromName(Home.Bedroom.color);
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)//blue
            {
                pictureBox1.ImageLocation = room + "Cold.png";
                label1.Text = "Blue";
                panel1.BackColor = Color.Blue;
            }
            else if (radioButton2.Checked)//green
            {
                pictureBox1.ImageLocation = room + "Green.png";
                label1.Text = "Green";
                panel1.BackColor = Color.Green;
            }
            else if (radioButton3.Checked)//purple
            {
                pictureBox1.ImageLocation = room + "Blue.png"; //to ebala sta Resources lathos kai bariemai na to alaksw
                label1.Text = "Purple";
                panel1.BackColor = Color.Purple;
            }
            else //default
            {
                pictureBox1.ImageLocation = room + ".png";
                label1.Text = "Default";
                panel1.BackColor = Color.Gainsboro;
            }
            if (room.Equals("Images/kitchen"))
            {
                Home.Kitchen.color = label1.Text;
                Home.Kitchen.LightsPhoto = pictureBox1.ImageLocation;
            }
            else if (room.Equals("Images/living"))
            {

                Home.LivingRoom.color = label1.Text;
                Home.LivingRoom.LightsPhoto = pictureBox1.ImageLocation;

            }
            else
            {

                Home.Bedroom.color = label1.Text;
                Home.Bedroom.LightsPhoto = pictureBox1.ImageLocation;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (radioButton5.Checked) //100%
            {
                pictureBox1.ImageLocation = room + ".png";
                label2.Text = "100%";

            }else if (radioButton6.Checked)//66%
            {
                pictureBox1.ImageLocation = room + "66.png";
                label2.Text = "66%";
            }
            else//33%
            {
                pictureBox1.ImageLocation = room + "33.png";
                label2.Text = "33%";
            }
            if (room.Equals("Images/kitchen"))
            {
                Home.Kitchen.brightness = label2.Text;
                Home.Kitchen.LightsPhoto = pictureBox1.ImageLocation;
            }
            else if (room.Equals("Images/living"))
            {

                Home.LivingRoom.brightness = label2.Text;
                Home.LivingRoom.LightsPhoto = pictureBox1.ImageLocation;

            }
            else
            {

                Home.Bedroom.brightness = label2.Text;
                Home.Bedroom.LightsPhoto = pictureBox1.ImageLocation;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form6 = new Form6();
            form6.ShowDialog();
            this.Close();
        }
    }
}
