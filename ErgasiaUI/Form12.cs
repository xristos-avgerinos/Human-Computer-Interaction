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
    public partial class Form12 : Form
    {
        public static int items;
        public Form12()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form11 form11 = new Form11();
            form11.ShowDialog();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            if (pictureBox.BackColor == Color.DodgerBlue)
            {
                items--;
                pictureBox.BackColor = Color.White;
            }
            else
            {
                pictureBox.BackColor = Color.DodgerBlue;
                items++;
            }
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            items = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (items > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Do you wish to buy selected items?", "Check", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Form13 form13 = new Form13();
                    form13.Show();
                }
            }
            else
            {
                MessageBox.Show("Item list is empty!");   
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
