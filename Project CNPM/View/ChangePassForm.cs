using Project_CNPM.Controller;
using Project_CNPM.Model;
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
            string userName = AppController.getObject().userName;
            string currentPass = textBox1.Text;
            string newpassword = textBox2.Text;
            string configpassword = textBox3.Text;
            if (textBox2.Text != "")
            {
                if (textBox2.Text == textBox3.Text)
                {
                    //Back_end here
                    RequestChangePass request = new RequestChangePass(userName, currentPass, newpassword, configpassword);
                    AppController.getObject().changePass(request);
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void changePassNotification(string msg)
        {
            label2.Text = msg;
        }
    }
}
