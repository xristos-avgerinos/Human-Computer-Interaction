using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErgasiaUI
{
    public partial class Form4 : Form
    {
        public static TimeSpan activitiesSumTime = new TimeSpan(00, 30, 00);
        public static RowStyle rowStyle;
        Random random;
        public static String imageloc;
        public static PictureBox box;
        
        public Form4()
        {
            InitializeComponent();
            Program.Activities.Add("ΚΑΦΕΣ");
            Form4.rowStyle = tableLayoutPanel1.RowStyles[tableLayoutPanel1.RowCount - 1];
            timer1.Enabled = true;
            label11.Text = DateTime.Now.ToString("HH:mm:ss");



        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //tableLayoutPanel1.Paint += tableLayoutPanel_Paint;
            pictureBox3.ImageLocation = "Images/car43.png";
            dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "HH:mm";
            dateTimePicker1.Value = new DateTime(2015, 02, 19, 0, 0, 0);
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.MouseWheel += new MouseEventHandler(dateTimePicker1_MouseWheel);
            dateTimePicker1.KeyDown += new KeyEventHandler(dateTimePicker1_KeyDown);
            dateTimePicker1.GotFocus += new EventHandler(dateTimePicker1_GotFocus);

        }
        

        void dateTimePicker1_GotFocus(object sender, EventArgs e)
        {
            SendKeys.Send("{right}");
        }


        void dateTimePicker1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                dateTimePicker1.Value = dateTimePicker1.Value.AddMinutes(1);
            else
                dateTimePicker1.Value = dateTimePicker1.Value.AddMinutes(-1);
        }

        void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 38)
            {
                dateTimePicker1.Value = dateTimePicker1.Value.AddMinutes(1);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyValue == 40)
            {
                dateTimePicker1.Value = dateTimePicker1.Value.AddMinutes(-1);
                e.SuppressKeyPress = true;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            TimeSpan difference;
            TimeSpan span1;
            if (tableLayoutPanel1.RowCount > 0)
            {
                String[] time1 = tableLayoutPanel1.GetControlFromPosition(2, 0).Text.Split('-');
                DateTime firstActivityTime = DateTime.ParseExact(time1[0].Trim(), "HH:mm", CultureInfo.CurrentCulture);
                time1 = tableLayoutPanel1.GetControlFromPosition(2, tableLayoutPanel1.RowCount - 1).Text.Split('-');
                DateTime lastActivityTime = DateTime.ParseExact(time1[1].Trim(), "HH:mm", CultureInfo.CurrentCulture);

                span1 = lastActivityTime.Subtract(firstActivityTime); //pairno thn diafora tis oras ekkinisis protis energeias kai termatismou teleytaias energeias oste na brethei posos xronos tis hmeras menei eleytheros
                if (span1 <= new TimeSpan(00, 00, 00))
                    span1 += TimeSpan.FromHours(24);

                difference = TimeSpan.FromHours(24) - span1;

                //MessageBox.Show(span1.ToString());
                //MessageBox.Show((dateTimePicker1.Value.TimeOfDay - difference).ToString());

            }
            else
            {
                difference = new TimeSpan(24, 00, 00);
                span1 = new TimeSpan(00, 00, 00);
            }

            if ((radioButton4.Checked == false && radioButton5.Checked == false && radioButton6.Checked==false)||
                (dateTimePicker1.Value.Hour == 00 && dateTimePicker1.Value.Minute == 00) ||
                string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please select activity,estimated time and transportaion method");

            }
            else if ( dateTimePicker1.Value.TimeOfDay > difference)
            {
                MessageBox.Show("Activity with estimated time: " + dateTimePicker1.Value.TimeOfDay + "overflows your daily plan");
            }
            else
            {
                Program.Activities.Add(textBox1.Text);
                activitiesSumTime = span1.Add(dateTimePicker1.Value.TimeOfDay);

                tableLayoutPanel1.RowCount++;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(rowStyle.SizeType, rowStyle.Height));
                
                //add six controls
                //init 6
                Button button = new Button();
                button.Size = button3.Size;
                button.Anchor = AnchorStyles.None;
                button.BackgroundImage = button3.BackgroundImage;
                button.BackgroundImageLayout = button3.BackgroundImageLayout;
                button.Cursor = button3.Cursor;
                button.FlatStyle = button3.FlatStyle;
                button.ForeColor = button3.ForeColor;
                button.Click += button3_Click;
                //1
                tableLayoutPanel1.Controls.Add(new PictureBox() { 
                    Size = pictureBox1.Size,
                    BackgroundImage = pictureBox1.BackgroundImage,
                    BackgroundImageLayout = pictureBox1.BackgroundImageLayout,
                    Anchor = AnchorStyles.None 
                }, 0, tableLayoutPanel1.RowCount - 1) ;
                //2
                tableLayoutPanel1.Controls.Add(new Label() { 
                    Text = textBox1.Text,
                    Size = label1.Size ,
                    Font = label1.Font,
                    Anchor = AnchorStyles.None,
                    TextAlign = ContentAlignment.MiddleCenter
                }, 1, tableLayoutPanel1.RowCount - 1);
                //3
                tableLayoutPanel1.Controls.Add(new Label() { 
                    Size = label2.Size,
                    Font = label2.Font,
                    Anchor = AnchorStyles.None, 
                    TextAlign = ContentAlignment.MiddleCenter 
                }, 2, tableLayoutPanel1.RowCount - 1);

                random = new Random();
                //4,5
                //walk
                if (radioButton4.Checked)
                {

                    tableLayoutPanel1.Controls.Add(new PictureBox()
                    {
                        Size = pictureBox2.Size,
                        ImageLocation = "Images/walk.png",
                        SizeMode = pictureBox2.SizeMode,
                        Anchor = AnchorStyles.None
                    }, 3, tableLayoutPanel1.RowCount - 1);
                    PictureBox pictureBox = new PictureBox()
                    {
                        Size = pictureBox3.Size,
                        Cursor = pictureBox3.Cursor,
                        ImageLocation = "Images/walk"+random.Next(1,3).ToString()+random.Next(1,4).ToString()+".png",
                        SizeMode = pictureBox3.SizeMode,
                        Anchor = AnchorStyles.None
                       
                    };
                    pictureBox.Click += pictureBox3_Click;
                    tableLayoutPanel1.Controls.Add(pictureBox, 4, tableLayoutPanel1.RowCount - 1);
                }
                //drive
                else if (radioButton5.Checked)
                {
                    tableLayoutPanel1.Controls.Add(new PictureBox()
                    {
                        Size = pictureBox2.Size,
                        ImageLocation = "Images/car.png",
                        SizeMode = pictureBox2.SizeMode,
                        Anchor = AnchorStyles.None
                    }, 3, tableLayoutPanel1.RowCount - 1);

                    PictureBox pictureBox = new PictureBox()
                    {
                        Size = pictureBox3.Size,
                        Cursor = pictureBox3.Cursor,
                        ImageLocation = "Images/car" + random.Next(3, 5).ToString() + random.Next(1, 4).ToString() + ".png",
                        SizeMode = pictureBox3.SizeMode,
                        Anchor = AnchorStyles.None

                    };
                    pictureBox.Click += pictureBox3_Click;
                    tableLayoutPanel1.Controls.Add(pictureBox, 4, tableLayoutPanel1.RowCount - 1);
                }
                //transport
                else if (radioButton6.Checked)
                {
                    tableLayoutPanel1.Controls.Add(new PictureBox()
                    {
                        Size = pictureBox2.Size,
                        ImageLocation = "Images/train.png",
                        SizeMode = pictureBox2.SizeMode,
                        Anchor = AnchorStyles.None
                    }, 3, tableLayoutPanel1.RowCount - 1);

                    PictureBox pictureBox = new PictureBox()
                    {
                        Size = pictureBox3.Size,
                        Cursor = pictureBox3.Cursor,
                        ImageLocation = "Images/trans" + random.Next(5, 7).ToString() + random.Next(1, 4).ToString() + ".png",
                        SizeMode = pictureBox3.SizeMode,
                        Anchor = AnchorStyles.None

                    };
                    pictureBox.Click += pictureBox3_Click;
                    tableLayoutPanel1.Controls.Add(pictureBox, 4, tableLayoutPanel1.RowCount - 1);
                }
                //6
                tableLayoutPanel1.Controls.Add(button, 5, tableLayoutPanel1.RowCount - 1);

                bool first_time = true;
                int row_index = 0;
                DateTime startTime = default(DateTime);
                DateTime endTime = new DateTime(0001, 1, 1, 8, 0, 0);
                
                for (int row=0; row<tableLayoutPanel1.RowCount-1; row++)
                {
                    
                    String [] Time = tableLayoutPanel1.GetControlFromPosition(2, row).Text.Split('-'); //pairno se mia lista thn ora ekkinisis kai termatismou tis energeias sto sygkekrimno row
                    
                    startTime = DateTime.ParseExact(Time[0].Trim(), "HH:mm", CultureInfo.CurrentCulture);
                    
                    endTime = DateTime.ParseExact(Time[1].Trim(), "HH:mm", CultureInfo.CurrentCulture);
                    
                    TimeSpan span = endTime.Subtract(startTime); //pairno thn diafora tis oras ekkinisis-termatismou oste na brethei to estimated time tiw energeias
                    
                    if (span < new TimeSpan(00, 00, 00))
                        span += TimeSpan.FromHours(24);

                    //MessageBox.Show("Time Difference (minutes): " + span);
                    if (dateTimePicker1.Value.TimeOfDay < span)
                    {
                        
                        //an to estimated time tis neas eggrafis einai ligotero apo kapoia allh tiw kanei swap oste na ginei tajinomhsh me tin pio mikrh energeia se diarkeia
                        SwapTwoRows(row, tableLayoutPanel1.RowCount - 1);
                        if (first_time)
                        {
                            //thetoume thn trith sthlh tis neas eggrafis(diladi thn vra ekkinhshs-termatismoy) me to time poy prokiptei apo to teleytaio row pou elejame
                            row_index = row;
                            DateTime start = startTime.Subtract(dateTimePicker1.Value.TimeOfDay);
                            DateTime end = startTime;
                            String time = start.ToString("HH:mm", CultureInfo.CurrentCulture) + " - " + end.ToString("HH:mm", CultureInfo.CurrentCulture);
                            tableLayoutPanel1.GetControlFromPosition(2, row).Text = time;
                            first_time = false;
                        }
                    }
                }
                if (first_time)
                {
                    //an den mphke pote sto pano if shmainei oti den xriasthke na ginei kapoio swap ara h eggrafh prepei na meinei sthn teleytaia grammh opou kai brisketai kai allazoyme to time analoga me th timh ths proteleytaias eggrafhs
                    DateTime start = endTime;
                    DateTime end = endTime.Add(dateTimePicker1.Value.TimeOfDay);
                    String time = start.ToString("HH:mm", CultureInfo.CurrentCulture) + " - " + end.ToString("HH:mm", CultureInfo.CurrentCulture);
                    tableLayoutPanel1.GetControlFromPosition(2, tableLayoutPanel1.RowCount - 1).Text = time; 
                }
                else //diaforetika simainei oti mpike kapou endiamesa stis ypoloipes eggrafes opote afairei apo oles tis eggrafes poy proigoyntai to estimated time tis neas eggrafis oste na ginei sosta h anadiatajh 
                {
                    for (int row = 0; row < row_index; row++)
                    {
                        String[] Time = tableLayoutPanel1.GetControlFromPosition(2, row).Text.Split('-');

                        startTime = DateTime.ParseExact(Time[0].Trim(), "HH:mm", CultureInfo.InvariantCulture);

                        endTime = DateTime.ParseExact(Time[1].Trim(), "HH:mm", CultureInfo.InvariantCulture);

                        startTime = startTime.Subtract(dateTimePicker1.Value.TimeOfDay);
                        endTime = endTime.Subtract(dateTimePicker1.Value.TimeOfDay);
                        String time = startTime.ToString("HH:mm", CultureInfo.CurrentCulture) + " - " + endTime.ToString("HH:mm", CultureInfo.CurrentCulture);
                        tableLayoutPanel1.GetControlFromPosition(2, row).Text = time;
                    }

                }
                

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
            
            e.Graphics.DrawRectangle(new Pen(Color.Blue), 1,1,875,53);
        }

        private void SwapControls(TableLayoutPanel tlp, TableLayoutPanelCellPosition cpos1, TableLayoutPanelCellPosition cpos2)
        {
            var ctl1 = tlp.GetControlFromPosition(cpos1.Column, cpos1.Row);
            var ctl2 = tlp.GetControlFromPosition(cpos2.Column, cpos2.Row);
            if (ctl1 != null) // position1 can be empty
                tlp.SetCellPosition(ctl1, cpos2);
            if (ctl2 != null) // position2 can be empty
                tlp.SetCellPosition(ctl2, cpos1);
        }

        private void SwapTwoRows(int row1, int row2)
        {
            SwapControls(tableLayoutPanel1, new TableLayoutPanelCellPosition(1, row1), new TableLayoutPanelCellPosition(1, row2));
            SwapControls(tableLayoutPanel1, new TableLayoutPanelCellPosition(2, row1), new TableLayoutPanelCellPosition(2, row2));
            SwapControls(tableLayoutPanel1, new TableLayoutPanelCellPosition(3, row1), new TableLayoutPanelCellPosition(3, row2));
            SwapControls(tableLayoutPanel1, new TableLayoutPanelCellPosition(4, row1), new TableLayoutPanelCellPosition(4, row2));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label11.Text = DateTime.Now.ToString("HH:mm:ss");
            if (tableLayoutPanel1.RowCount == 0)
            {
                pictureBox7.Visible = true;
                tableLayoutPanel1.BackColor = Color.Transparent;
            }
            else
            {
                pictureBox7.Visible = false;
                tableLayoutPanel1.BackColor = Color.White;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Control ctrl = (Control)sender;
            PictureBox pictureBox = (PictureBox)sender;
            Form4.box = pictureBox;
            Form4.imageloc = pictureBox.ImageLocation;
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello.I am Clio your virtual assistant.Let's create your daily plan!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, @"helpscribble\imgs\ergasia.chm", HelpNavigator.Topic, "html\\hs12.htm");
        }
    }
}
