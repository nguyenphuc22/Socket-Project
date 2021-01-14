using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project_CNPM.View
{
    public partial class ChatLabel : UserControl
    {
        private string msgValue;
        private string usernameValue;
        public ChatLabel()
        {
            if(!DesignMode)
            {
                InitializeComponent();
            }
            msgValue = "";
            usernameValue = "";
        }

        public ChatLabel(string msg,string username,TypeMsg msgType)
        {
            msgValue = msg;
            usernameValue = username;
            this.msg.Text  = msg;
            this.username.Text  = username;

            if(msgType.ToString() == "In")
            {
                this.BackColor = Color.FromArgb(215, 228, 242);
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

            this.Height = msg.Height + msg.Top;
        }

        private void ChatLabel_Resize(object sender, EventArgs e)
        {
            Setheight(this.msg);
        }
    }
}
