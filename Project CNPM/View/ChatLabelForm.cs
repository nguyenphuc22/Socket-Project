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
    public partial class ChatLabelForm : UserControl
    {
        string msgValue;
        string userNameValue;
        bool isFile;
        string recName;
        public ChatLabelForm()
        {
            InitializeComponent();
            AppController.getObject().createThreadListenMessageFromServer();
            msgValue = "";
            userNameValue = "";
        }

        public ChatLabelForm(string msg,string username,TypeMsg type,bool isFile,string recName)
        {
            
            InitializeComponent();
            //AppController.getObject().createThreadListenMessageFromServer();
            this.msgValue = msg;
            this.userNameValue = username;
            this.msgView.Text = msg;
            this.usernameView.Text = username;
            this.isFile = isFile;
            this.type.Left = this.usernameView.Right + 10;
            this.recName = recName;
            

            

            if (type.ToString() == "In")
            {
                this.BackColor = Color.FromArgb(0, 120, 215);
            }
            else
            {
                this.type.Left = 200;
                this.usernameView.Left = this.type.Right + this.usernameView.Size.Width + 10;
                this.BackColor = Color.FromArgb(108, 105, 108);
            }
            if (isFile)
            {
                this.type.Text = "File";
            }else
            {
                this.type.Text = "Message";
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

        public bool msgIsFile()
        {
            return this.isFile;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void msgView_Resize(object sender, EventArgs e)
        {
            Setheight(this.msgView);
        }

        private void msgView_Click(object sender, EventArgs e)
        {
            if(this.recName.Contains("Group:"))
            {
                string nameGroup = this.recName.Substring(this.recName.IndexOf(":") + 1);       
                AppController.getObject().requestRecFileGroup(new RequestRecFileGroup(nameGroup, this.msgValue));
            }
            else
            {
                AppController.getObject().requestRecFileGroup(new RequestRecFileGroup(AppController.getObject().userName, this.msgValue));
            }
        }
    }
}
