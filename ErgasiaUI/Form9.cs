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
    
    public partial class Form9 : Form
    {
        public static bool ON = false;
        public static string room = "Images/kitchen";//default room
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            //init values
            numericUpDown1.Value = Home.Kitchen.temperature;
            trackBar1.Value = Home.Kitchen.flowRate;
            listBox2.SelectedItem = "        Low"; //null exception if not hardcoded
            label3.Text = listBox2.SelectedItem.ToString();
            label2.Text = numericUpDown1.Value.ToString();
            timer1.Enabled = true;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Form9.room = "Images/kitchen";
            pictureBox1.ImageLocation = Home.Kitchen.TemperaturePhoto;
            trackBar1.Value = Home.Kitchen.flowRate;
            numericUpDown1.Value = Home.Kitchen.temperature;
            
          

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9.room = "Images/living";
            pictureBox1.ImageLocation = Home.LivingRoom.TemperaturePhoto;
            trackBar1.Value = Home.LivingRoom.flowRate;
            numericUpDown1.Value = Home.LivingRoom.temperature;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {   Form9.room = "Images/bedroom";
            pictureBox1.ImageLocation = Home.Bedroom.TemperaturePhoto;
            trackBar1.Value = Home.Bedroom.flowRate;
            numericUpDown1.Value = Home.Bedroom.temperature;
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (ON)
            {
                pictureBox3.ImageLocation = "Images/temperatureOff.png";
                pictureBox8.Visible = false;
                pictureBox2.Visible = false;
                listBox1.Visible = false;
                listBox2.Visible = false;
                numericUpDown1.Visible = false;
                trackBar1.Visible = false;
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;
                pictureBox9.Visible = false;
                pictureBox10.Visible = false;
                ON = false;
                timer1.Enabled = false;

            }
            else
            {
                pictureBox3.ImageLocation = "Images/temperature.png";
                pictureBox8.Visible = true;
                pictureBox2.Visible = true;
                listBox1.Visible = true;
                listBox2.Visible = true;
                pictureBox6.Visible = true;
                pictureBox7.Visible = true;
                pictureBox9.Visible = true;
                pictureBox10.Visible = true;
                numericUpDown1.Visible = true;
                trackBar1.Visible = true;
                ON = true;
                timer1.Enabled = true;

            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(numericUpDown1.Value>=18 && numericUpDown1.Value <= 25)
            {
                listBox1.SelectedItem = "       Cold";
                pictureBox1.ImageLocation = room + "Cold.png";
                


            }
            else if(numericUpDown1.Value > 25 && numericUpDown1.Value <= 27) {
                listBox1.SelectedItem = "       Auto";
                pictureBox1.ImageLocation = room + ".png";
                
            }
            else
            {
                listBox1.SelectedItem = "        Hot";
                pictureBox1.ImageLocation = room + "Hot.png";
                
            }
            if (room.Equals("Images/kitchen"))
            {

                Home.Kitchen.temperature = numericUpDown1.Value;
                Home.Kitchen.TemperaturePhoto = pictureBox1.ImageLocation;
            }
            else if (room.Equals("Images/living"))
            {

                Home.LivingRoom.temperature = numericUpDown1.Value;
                Home.LivingRoom.TemperaturePhoto = pictureBox1.ImageLocation;

            }
            else
            {

                Home.Bedroom.temperature = numericUpDown1.Value;
                Home.Bedroom.TemperaturePhoto = pictureBox1.ImageLocation;
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (trackBar1.Value <= 1)
            {
                listBox2.SelectedItem = "        Low";
                
            }
            else if(trackBar1.Value>1 && trackBar1.Value <= 3)
            {
                listBox2.SelectedItem = "     Medium";
                
            }
            else
            {
                listBox2.SelectedItem = "        High";
               
            }
            if (room.Equals("Images/kitchen"))
            {

               
                Home.Kitchen.flowRate = trackBar1.Value;
                Home.Kitchen.TemperaturePhoto = pictureBox1.ImageLocation;
            }
            else if (room.Equals("Images/living"))
            {

                
                Home.LivingRoom.flowRate = trackBar1.Value;
                Home.LivingRoom.TemperaturePhoto = pictureBox1.ImageLocation;

            }
            else
            {

                
                Home.Bedroom.flowRate = trackBar1.Value;
                Home.Bedroom.TemperaturePhoto = pictureBox1.ImageLocation;
            }
        }

        

        private void listBox1_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem.Equals("       Cold"))
            {
                numericUpDown1.Value = 18;
                pictureBox1.ImageLocation = room + "Cold.png";
                

            }
            else if(listBox1.SelectedItem.Equals("       Auto"))
            {
                numericUpDown1.Value = 26;
                pictureBox1.ImageLocation = room + ".png";
                
            }
            else
            {
                numericUpDown1.Value = 30;
                pictureBox1.ImageLocation = room + "Hot.png";
                
            }
            //checkRoom();
        }

        private void listBox2_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem.Equals("        Low"))
            {
                trackBar1.Value = 0;
               
            }
            else if (listBox2.SelectedItem.Equals("     Medium"))
            {
                trackBar1.Value = 2;
               
            }
            else
            {
                trackBar1.Value = 4;
              
            }
            //checkRoom();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = listBox2.SelectedItem.ToString();
            label2.Text = numericUpDown1.Value.ToString();
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
