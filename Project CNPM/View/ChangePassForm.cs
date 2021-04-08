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
            string currentPass = textBox_CurretPass.Text;
            string newpassword = textBox_NewPass.Text;
            string configpassword = textBox_ConfirmPass.Text;
            if (textBox_NewPass.Text != "")
            {
                if (textBox_NewPass.Text == textBox_ConfirmPass.Text)
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

        private void textBox_CurretPass_MouseLeave(object sender, EventArgs e)
        {
            if (textBox_CurretPass.Text.Length == 0)
            {
                textBox_CurretPass.Text = "Type Your UserName";
                textBox_CurretPass.ForeColor = Color.Gray;
            }
        }

        private void textBox_CurretPass_MouseEnter(object sender, EventArgs e)
        {
            if (textBox_CurretPass.Text == "Type Your UserName")
            {
                textBox_CurretPass.Text = "";
                textBox_CurretPass.ForeColor = Color.White;
            }
        }

        private void textBox_NewPass_MouseLeave(object sender, EventArgs e)
        {
            if (textBox_NewPass.Text.Length == 0)
            {
                textBox_NewPass.Text = "Type Your UserName";
                textBox_NewPass.ForeColor = Color.Gray;
            }
        }

        private void textBox_NewPass_MouseEnter(object sender, EventArgs e)
        {
            if (textBox_NewPass.Text == "Type Your UserName")
            {
                textBox_NewPass.Text = "";
                textBox_NewPass.ForeColor = Color.White;
            }
        }

        private void textBox_ConfirmPass_MouseLeave(object sender, EventArgs e)
        {
            if (textBox_ConfirmPass.Text.Length == 0)
            {
                textBox_ConfirmPass.Text = "Type Your UserName";
                textBox_ConfirmPass.ForeColor = Color.Gray;
            }
        }

        private void textBox_ConfirmPass_MouseEnter(object sender, EventArgs e)
        {
            if (textBox_ConfirmPass.Text == "Type Your UserName")
            {
                textBox_ConfirmPass.Text = "";
                textBox_ConfirmPass.ForeColor = Color.White;
            }
        }

        private void textBox_CurretPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_NewPass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
