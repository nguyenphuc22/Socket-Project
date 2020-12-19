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
        public Socket serverSocket;

        // no parameter constructor ( local ) 
        public SocketController()
        {
            serverIPAddr = "127.0.0.1"; //Localhost IP
            serverPort = 2015; //Default server Port
            createSoket(); //Create a socket
        }
        // have parameter constructor
        public SocketController(string serverIPAddr, int serverPort)
        {
            this.serverIPAddr = serverIPAddr;
            this.serverPort = serverPort;
        }
        // init Socket
        public int createSoket()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            return 0;
        }
        // send Message to server
        public int sendMessage(byte[] buff)
        {
            if (serverSocket != null)
                return serverSocket.Send(buff, buff.Length, SocketFlags.None); //Sent bytes
            return 0;
        }
        // send Message to server
        public int sendMessage(byte[] buff, int size)
        {
            return serverSocket.Send(buff, size, SocketFlags.None); //Sent bytes
        }
        public void onReceive(IAsyncResult ar)
        {
            // Not thing
        }
        public void onSend(IAsyncResult ar)
        {
            // Not thing
        }
    }
}
