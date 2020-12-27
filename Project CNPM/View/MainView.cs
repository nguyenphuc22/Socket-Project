using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_CNPM
{
    public partial class MainView : Form
    {
        public MainView()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public string s_msg;

        public void open_panel1()
        {
            this.panel1.Size = new Size(this.panel1.Width, 303);
        }

        public void close_panel1()
        {
            this.panel1.Size = new Size(this.panel1.Width, 72);
        }

        public void open_panel2()
        {
            this.panel2.Size = new Size(this.panel2.Width, 303);
        }

        public void close_panel2()
        {
            this.panel2.Size = new Size(this.panel2.Width, 72);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.panel1.Size.Height == 72)
            {
                open_panel1();
                button1.Text = "▼";
            }
            else
            {
                close_panel1();
                button1.Text = "≡";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            close_panel1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            close_panel1();
            s_msg = textBox1.Text;
        }

        private void close_panel1_leave(object sender, EventArgs e)
        {
            close_panel1();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (this.panel2.Size.Height == 72)
            {
                open_panel2();
                button7.Text = "▼";
            }
            else
            {
                close_panel2();
                button7.Text = "≡";
            }
        }
    }
}

