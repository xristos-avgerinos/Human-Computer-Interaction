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
    public partial class Form11 : Form
    {
        bool open = false;
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.ImageLocation = "Images/shocaseClosed.png";
            foreach (string activity in Program.Activities)
            {
                listBox1.Items.Add(activity);
            }
            if (listBox1.Items.Count == 0)
            {
                trackBar1.Visible = false;
            }
            else
            {
                trackBar1.Visible = true;
            }

        }


        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            if (listBox1.Items.Count > 0 && listBox1.SelectedIndex != -1)
            {
                label1.Visible = false;
                DialogResult dialogResult = MessageBox.Show("Do you wish to confirm this activity importance", "Importance", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    pictureBox4.Visible = true;
                    pictureBox1.Visible = true;
                    button1.Visible = true;
                    pictureBox1.BorderStyle = BorderStyle.FixedSingle;
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    pictureBox7.Visible = true;
                    if (trackBar1.Value == 0)
                    {
                        pictureBox1.ImageLocation = "Images/pantofles1.png";
                    }
                    else if (trackBar1.Value == 1)
                    {
                        pictureBox1.ImageLocation = "Images/athlitika1.png";
                    }else if(trackBar1.Value == 2)
                    {
                        pictureBox1.ImageLocation = "Images/sneaker1.png";
                    }else
                    {
                        pictureBox1.ImageLocation = "Images/moka1.png";
                    }
                }


            }
            else
            {
                label1.Visible = true;
            }
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form6 = new Form6();
            form6.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            if (open)
            {
                pictureBox5.Visible = false;
                pictureBox9.Visible= false;
                pictureBox6.Visible = false;
                pictureBox10.Visible = false;
                pictureBox2.ImageLocation = "Images/shocaseClosed.png";
                open = false;
            }
            else
            {
                pictureBox5.Visible = true;
                pictureBox9.Visible= true;
                pictureBox6.Visible = true;
                pictureBox10.Visible = true;
                pictureBox2.ImageLocation = "Images/shocaseOpened.png";
                open = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form12 form12 = new Form12();
            form12.ShowDialog();
            this.Close();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, @"helpscribble\imgs\ergasia.chm", HelpNavigator.Topic, "html\\hs17.htm");
        }
    }
}
