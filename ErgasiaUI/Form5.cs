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
    public partial class Form5 : Form
    {
       
        public Form5()
        {
            InitializeComponent();
        }
      

        private void Form5_Load(object sender, EventArgs e)
        {
            //pictureBox1.ImageLocation = Form4.imageloc;
            string result = Form4.imageloc.Remove(Form4.imageloc.Length - 5); //Images/walk12.png --> Images/walk1
            
            pictureBox1.ImageLocation = result + "1.png";
            pictureBox2.ImageLocation = result + "2.png";
            pictureBox3.ImageLocation = result + "3.png";
            //default
            Form4.box.ImageLocation = pictureBox1.ImageLocation;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Visible)
            {
                pictureBox1.Visible = false;
                button2.Visible = true;
                pictureBox2.Visible = true;
                Form4.box.ImageLocation = pictureBox2.ImageLocation;

            }else
            {
                pictureBox2.Visible = false;
                button1.Visible = false;
                pictureBox3.Visible = true;
                Form4.box.ImageLocation = pictureBox3.ImageLocation;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Visible)
            {
                pictureBox2.Visible = false;
                pictureBox1.Visible = true;
                button2.Visible = false;
                Form4.box.ImageLocation = pictureBox1.ImageLocation;
            }
            else
            {
                pictureBox3.Visible = false;
                pictureBox2.Visible = true;
                button1.Visible = true;
                Form4.box.ImageLocation = pictureBox2.ImageLocation;

            }
        }
    }
}
