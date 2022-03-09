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
    public partial class Form8 : Form
    {
        double counter = 0;
        Random random;
        public static List<string> strings = new List<string>()
            {
                "Pet urined carpet",
                "Pet damaged the door",
                "Pet broke the vase",
                "Pet damaged the sofa",
                "Pet droped water bowl",
                "Pet droped food bowl"
            };

        public Form8()
        {
            InitializeComponent();
        }

        private async void Form8_Load(object sender, EventArgs e)
        {
            pictureBox6.ImageLocation = "Images/AutoFeedOff.png";
            random = new Random();
            pictureBox1.ImageLocation = "Images/home"+random.Next(1,4).ToString()+".png";
            pictureBox3.ImageLocation = "Images/food" + random.Next(1, 6).ToString() + ".png";
            pictureBox4.ImageLocation = "Images/water" + random.Next(1, 6).ToString() + ".png";
            await Task.Delay(300);
            if(Form4.activitiesSumTime > new TimeSpan(08, 00, 00))
            {
                DialogResult dialogResult = MessageBox.Show("It seems your daily plan activities are overflowing 8 hours.Do you wish to turn autofeed on?","Attention", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    pictureBox6.ImageLocation = "Images/AutoFeedOn.png";
                }
                else
                {
                    pictureBox6.ImageLocation = "Images/AutoFeedOff.png";
                }
          
            }
            if ((pictureBox3.ImageLocation == "Images/food1.png") && (pictureBox4.ImageLocation == "Images/water1.png"))
            {
                DialogResult dialogResult = MessageBox.Show("Food and water amount is low.Do you wish to refill?", "Attention!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    pictureBox3.ImageLocation = "Images/food5.png";
                    pictureBox4.ImageLocation = "Images/water5.png";
                }
                else if (dialogResult == DialogResult.No)
                {
                    label2.Visible = true;
                    label1.Visible = true;
                }
               
            }
            else if (pictureBox3.ImageLocation == "Images/food1.png")
            {

                DialogResult dialogResult = MessageBox.Show("Food amount is low.Do you wish to refill?", "Attention!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    pictureBox3.ImageLocation = "Images/food5.png";
                }
                else if (dialogResult == DialogResult.No)
                {
                    label2.Visible = true;
                }
            }else if(pictureBox4.ImageLocation == "Images/water1.png")
            {
                DialogResult dialogResult = MessageBox.Show("Water amount is low.Do you wish to refill?", "Attention!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    pictureBox4.ImageLocation = "Images/water5.png";
                }
                else if (dialogResult == DialogResult.No)
                {
                    label1.Visible = true;
                }
            }
            timer1.Enabled = true;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox4.ImageLocation = "Images/water5.png";
            if (label1.Visible)
            {
                label1.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox3.ImageLocation = "Images/food5.png";
            if (label2.Visible)
            {
                label2.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox4.ImageLocation = "Images/water5.png";
            pictureBox3.ImageLocation = "Images/food5.png";
            if (label1.Visible)
            {
                label1.Visible = false;
            }
            if (label2.Visible)
            {
                label2.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;
            if(counter % 10 == 0)
            {
                if(strings.Count != 0)
                {
                    string elem = strings.First();
                    listBox1.Items.Add(elem);
                    strings.Remove(elem);
                    if (elem.Equals("Pet droped water bowl"))
                    {
                        pictureBox4.ImageLocation = "Images/water1.png";
                        label1.Visible = true;
                    }
                    else if (elem.Equals("Pet droped food bowl"))
                    {
                        pictureBox3.ImageLocation = "Images/food1.png";
                        label2.Visible = true;
                    }
                }
                else
                {
                    timer1.Enabled = false;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (pictureBox6.ImageLocation.Equals("Images/AutoFeedOff.png"))
            {
                pictureBox6.ImageLocation = "Images/AutoFeedOn.png";
            }
            else
            {
                pictureBox6.ImageLocation = "Images/AutoFeedOff.png";
            }
        }
    }
}
