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
    public partial class Form4 : Form
    {
        public static RowStyle rowStyle;

        public Form4()
        {
            InitializeComponent();
            //tableLayoutPanel1.Paint += tableLayoutPanel_Paint;
            Form4.rowStyle = tableLayoutPanel1.RowStyles[tableLayoutPanel1.RowCount - 1]; 
        }

        private void Form4_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if((radioButton4.Checked == false && radioButton5.Checked == false && radioButton6.Checked==false)||
                (numericUpDown1.Value == 0 ||
                string.IsNullOrEmpty(textBox1.Text)))
            {
                MessageBox.Show("You need to select both activity, transportation method and estimated time");

            }
            else
            {
                tableLayoutPanel1.RowCount++;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(rowStyle.SizeType, rowStyle.Height));
                //tableLayoutPanel1.Paint += tableLayoutPanel_Paint;
                //add six controls
                Button button = new Button();
                button.Size = button3.Size;
                button.Anchor = AnchorStyles.None;
                //button.BackgroundImage = button3.BackgroundImage;
                button.Click += button3_Click;
                tableLayoutPanel1.Controls.Add(new PictureBox() { Size = pictureBox1.Size, Anchor = AnchorStyles.None }, 0, tableLayoutPanel1.RowCount - 1) ;
                tableLayoutPanel1.Controls.Add(new Label() { Text = textBox1.Text, Size = label1.Size ,Anchor = AnchorStyles.None,TextAlign = ContentAlignment.MiddleCenter }, 1, tableLayoutPanel1.RowCount - 1);
                tableLayoutPanel1.Controls.Add(new Label() { Text = numericUpDown1.Value.ToString(), Size = label1.Size, Anchor = AnchorStyles.None, TextAlign = ContentAlignment.MiddleCenter }, 2, tableLayoutPanel1.RowCount - 1);
                if (radioButton4.Checked)
                {
                    tableLayoutPanel1.Controls.Add(new PictureBox() { Size = pictureBox1.Size, BackColor = Color.Red, Anchor = AnchorStyles.None }, 3, tableLayoutPanel1.RowCount - 1);
                }
                else if (radioButton5.Checked)
                {
                    tableLayoutPanel1.Controls.Add(new PictureBox() { Size = pictureBox1.Size, BackColor = Color.Blue, Anchor = AnchorStyles.None }, 3, tableLayoutPanel1.RowCount - 1);
                }
                else if (radioButton6.Checked)
                {
                    tableLayoutPanel1.Controls.Add(new PictureBox() { Size = pictureBox1.Size, BackColor = Color.Yellow, Anchor = AnchorStyles.None }, 3, tableLayoutPanel1.RowCount - 1);
                }
                tableLayoutPanel1.Controls.Add(new PictureBox() { Size = pictureBox1.Size, Anchor = AnchorStyles.None }, 4, tableLayoutPanel1.RowCount - 1);
                tableLayoutPanel1.Controls.Add(button, 5, tableLayoutPanel1.RowCount - 1);



            }
            
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Get Row
            Control ctrl = (Control)sender;
            int  row =tableLayoutPanel1.GetRow(ctrl);
            TableLayoutHelper.RemoveArbitraryRow(tableLayoutPanel1,row);
        }
        public static class TableLayoutHelper
        {
            //afairei ta rowss(tablelayoutpanel1,row)
            public static void RemoveArbitraryRow(TableLayoutPanel panel, int rowIndex)
            {
                if (rowIndex >= panel.RowCount)
                {
                    return;
                }

                // delete all controls of row that we want to delete
                for (int i = 0; i < panel.ColumnCount; i++)
                {
                    var control = panel.GetControlFromPosition(i, rowIndex);
                    panel.Controls.Remove(control);
                }

                // move up row controls that comes after row we want to remove
                for (int i = rowIndex + 1; i < panel.RowCount; i++)
                {
                    for (int j = 0; j < panel.ColumnCount; j++)
                    {
                        var control = panel.GetControlFromPosition(j, i);
                        if (control != null)
                        {
                            panel.SetRow(control, i - 1);
                        }
                    }
                }

                var removeStyle = panel.RowCount - 1;

                if (panel.RowStyles.Count > removeStyle)
                    panel.RowStyles.RemoveAt(removeStyle);

                panel.RowCount--;
            }
        }
        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.DrawRectangle(new Pen(Color.Blue), 1,1,875,65);

        }
    }
}
