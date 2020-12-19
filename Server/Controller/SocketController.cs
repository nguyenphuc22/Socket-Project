using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Server.Controller
{
    class SocketController
    {
        private string serverIPAddr;
        private int serverPort;
        public Socket clientSocket;

        // no parameter constructor ( local ) 
        public SocketController()
        {

        }
        // have parameter constructor
        public SocketController(string serverIPAddr, int serverPort)
        {

        }
        // init Socket
        public int createServer()
        {

            return 0;
        }
        // send Message to server
        public int sendMessage(ArrayList buff)
        {

            return 0;
        }
        // send Message to server
        public int sendMessage(ArrayList buff, int size)
        {
            return 0;
        }
        public void onReceive(IAsyncResult ar)
        {

        }
        public void onSend(IAsyncResult ar)
        {

        }
    }
}
