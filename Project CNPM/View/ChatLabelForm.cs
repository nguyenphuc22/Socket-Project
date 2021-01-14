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
    public partial class ChatLabelForm : UserControl
    {
        public string msgValue;
        public string userNameValue;
        public ChatLabelForm()
        {
            InitializeComponent();
            AppController.getObject().createThreadListenMessageFromServer();
            msgValue = "";
            userNameValue = "";
        }

        public ChatLabelForm(string msg,string username,TypeMsg type)
        {
            
            InitializeComponent();
            AppController.getObject().createThreadListenMessageFromServer();
            this.msgValue = msg;
            this.userNameValue = username;
            this.msgView.Text = msg;
            this.usernameView.Text = username;
            if(type.ToString() == "In")
            {
                this.BackColor = Color.FromArgb(0, 120, 215);
            }
            else
            {
                this.BackColor = Color.FromArgb(108, 105, 108);
            }
        }

        void Setheight(Label _label)
        {
            Size maxSize = new Size(495, int.MaxValue);
            Graphics g = CreateGraphics();
            SizeF size = g.MeasureString(_label.Text, _label.Font, _label.Width);

            _label.Height = int.Parse(Math.Round(size.Height + 2, 0).ToString());
            this.Height = msgView.Height + 10;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void msgView_Resize(object sender, EventArgs e)
        {
            Setheight(this.msgView);
        }
    }
}
