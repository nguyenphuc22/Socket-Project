using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Project_CNPM.Controller
{
    class AppSocketController
    {
         
        private string serverIPAddr;
        private int serverPort;
        public Socket clientSocket;

        // no parameter constructor ( local ) 
        public AppSocketController()
        {
            this.serverIPAddr = "127.0.0.1"; //Localhost IP
            this.serverPort = 2020; //Default server Port

            createSocket(); //Create a socket
        }
        // have parameter constructor
        public AppSocketController(string serverIPAddr, int serverPort)
        {
            this.serverIPAddr = serverIPAddr;
            this.serverPort = serverPort;
        }
        // init Socket
        public int createSocket()
        {
            clientSocket = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
            return 0;
        }
        // connect to Server no parameter ( Local )
        public bool connectToServer()
        {
            IPAddress  ipAddress = IPAddress.Parse(serverIPAddr);
            IPEndPoint  ServerIPEndPoint = new IPEndPoint(ipAddress, serverPort);

            try
            {
                clientSocket.Connect(ServerIPEndPoint);
            }
            catch (Exception e)
	        {
                // Display Error Here
                return false;
            }

            
            return true;

        }
        // connect to Server have parameter 
        public bool connectToServer(string serverIPAddr, int serverPort)
        {
            this.serverIPAddr = serverIPAddr;
            this.serverPort = serverPort;
            return connectToServer();
            
        }
        // send Message to server
        public int sendMessage(byte[] buff)
        {
            
            if(clientSocket != null)
                return clientSocket.Send(buff, buff.Length, SocketFlags.None); //Sent bytes
            return 0;
        }
        // send Message to server
        public int sendMessage(byte[] buff, int size)
        {
            return clientSocket.Send(buff, size, SocketFlags.None); //Sent bytes
        }
        public void onReceive(IAsyncResult ar)
        {
            // Not thing
        }
        public void onSend(IAsyncResult ar)
        {
            // Not thing
        }
        public void close()
        {
            this.clientSocket.Close();
        }

    }
}
