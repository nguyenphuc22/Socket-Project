using Project_CNPM.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project_CNPM.View
{
    public partial class ChangePassForm : Form
    {
        public ChangePassForm()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void ChangePassForm_Load(object sender, EventArgs e)
        {
            AppController.getObject().createThreadListenMessageFromServer();
            label2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (textBox2.Text == textBox3.Text)
                {
                    //Back_end here
                    
                    this.Hide();
                    AppController.getObject().mainView.Show();
                }
                else
                {
                    label2.Text = "Warn: Wrong confirmation password!";
                }
            }
            else
            {
                label2.Text = "Warn: New password cannot be empty!";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AppController.getObject().mainView.Show();
        }
    }
}
