using System;
using System.Collections.Generic;
using System.Text;

namespace Project_CNPM
{
    class RecentMessage
    {
        public string userName;
        public string lastMessage;
        public byte[] image;
        public RecentMessage(string username, string lastmessage, byte[] image)
        {
            this.userName = username;
            this.lastMessage = lastmessage;
            this.image = image;
        }
        public RecentMessage()
        {
            this.userName = "";
            this.lastMessage = "";
            this.image = new byte[0];
        }
    }


}
