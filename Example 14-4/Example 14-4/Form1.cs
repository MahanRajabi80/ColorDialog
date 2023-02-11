using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Example_14_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //---------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer1 = new Timer();
            timer1.Interval = 1000;//1 seconds
            timer1.Enabled = true;
            timer1.Tick += new EventHandler(timer1_Tick);
        }
        //---------------------------------------------------------------------
        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            if(r.Next(2)==0)//button
            {
                Button b = new Button();
                b.Text = "Click Me!";
                b.Location = new Point(r.Next(this.Width - 100), r.Next(this.Height - 100));
                this.Controls.Add(b);
                b.Click += new EventHandler(button_label_Click);
                b.BringToFront();
            }
            else//label
	        {
                Label l = new Label();
                l.Text = "Click Me!";
                l.Location = new Point(r.Next(this.Width - 100), r.Next(this.Height - 100));
                this.Controls.Add(l);
                l.Click += new EventHandler(button_label_Click);
                l.BringToFront();
	        }
        }
        //---------------------------------------------------------------------
        private void button_label_Click(object sender, EventArgs e)
        {
            Control ctrl=(Control)sender;
            ColorDialog colorDialog1 = new ColorDialog();
            if(ctrl.GetType().Name=="Button")
                colorDialog1.Color=ctrl.BackColor;
            else//label
                colorDialog1.Color=ctrl.ForeColor;
            //--
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                if (ctrl.GetType().Name == "Button")
                    ctrl.BackColor = colorDialog1.Color;
                else//label
                    ctrl.ForeColor = colorDialog1.Color;        
        }
    }
}
