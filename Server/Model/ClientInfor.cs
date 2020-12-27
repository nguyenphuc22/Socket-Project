using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Server.Model
{
    class ClientInfor
    {
        String userName;
        Socket socket;

        public ClientInfor(String userName,Socket socket)
        {
            this.userName = userName;
            this.socket = socket;
        }
        public bool isUserName(string userName)
        {
            if (this.userName == null)
                return false;
            if (userName == this.userName)
            {
                return true;
            }
            return false;
        }
        
        public Socket getSocket()
        {
            if (this.socket == null)
                return null;
            return this.socket;
        }
    }
}
