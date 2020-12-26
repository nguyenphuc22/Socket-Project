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

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox1.Text))
            {
                label4.Text = "Empty Username or Password!";
            }
            else
            {
                user.Username = textBox1.Text;
                user.Password = textBox2.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox1.Text))
            {
                label4.Text = "Empty Username or Password!";
            }
            else
            {
                user.Username = textBox1.Text;
                user.Password = textBox2.Text;
                AppController.getObject().login(new RequestLoginStruct(user.Username, user.Password));
            }
        }

        public void Change_subtitle(string Warn_Msg)
        {
            label4.Text = Warn_Msg;
        }

        private void LoginView_Load(object sender, EventArgs e)
        {
            
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