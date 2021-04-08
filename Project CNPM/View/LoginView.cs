using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Project_CNPM.Controller;
using Project_CNPM.Model;

namespace Project_CNPM.View
{
    public partial class LoginView : Form
    {
        
        User user = new User();
        public LoginView()
        {
            
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            AppController.getObject().loginView = this;
        }

       
        

        public void Change_subtitle(string Warn_Msg)
        {
            label4.Text = Warn_Msg;
        }

        private void LoginView_Load(object sender, EventArgs e)
        {
            
        }

        public void Close_form()
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUserName_MouseEnter(object sender, EventArgs e)
        {
            if(txtUserName.Text == "Type Your UserName")
            {
                txtUserName.Text = "";
                txtUserName.ForeColor = Color.White;
            } 
        }

        private void txtUserName_MouseLeave(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length == 0)
            {
                txtUserName.Text = "Type Your UserName";
                txtUserName.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_MouseEnter(object sender, EventArgs e)
        {
            {
            if (txtPassword.Text == "Type Your Password")
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.White;
            }
        }

        private void txtPassword_MouseLeave(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length == 0)
            {
                txtPassword.Text = "Type Your Password";
                txtPassword.ForeColor = Color.Gray;
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label_signUp_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUserName.Text) || String.IsNullOrEmpty(txtPassword.Text) || txtPassword.Text == "Type Your Password" || txtUserName.Text == "Type Your Username")
            {
                label4.Text = "Empty Username or Password!";
            }
            else
            {
                user.Username = txtUserName.Text;
                user.Password = txtPassword.Text;
                AppController.getObject().signup(new ResquestSignupStruct(user.Username, user.Password));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUserName.Text) || String.IsNullOrEmpty(txtPassword.Text) || txtPassword.Text == "Type Your Password" || txtUserName.Text == "Type Your Username")
            {
                label4.Text = "Empty Username or Password!";
            }
            else
            {
                user.Username = txtUserName.Text;
                user.Password = txtPassword.Text;
                AppController.getObject().login(new RequestLoginStruct(user.Username,user.Password));
            }
        }

        private void label_signUp_MouseLeave(object sender, EventArgs e)
        {
            label_signUp.Font = new Font(label_signUp.Font.Name,label_signUp.Font.SizeInPoints, FontStyle.Regular);
        }

        private void label_signUp_MouseMove(object sender, MouseEventArgs e)
        {
            label_signUp.Font = new Font(label_signUp.Font.Name, label_signUp.Font.SizeInPoints, FontStyle.Underline);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(this, new EventArgs());
            }
        }
    }
}

public class User
{
    public string Username;
    public string Password;

    public User()
    {

    }
}