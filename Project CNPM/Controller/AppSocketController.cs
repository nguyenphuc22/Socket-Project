using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

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

        }
        // have parameter constructor
        public AppSocketController(string serverIPAddr, int serverPort)
        {
            
        }
        // init Socket
        public int createSocket()
        {

            return 0;
        }
        // connect to Server no parameter ( Local )
        public int connectToServer()
        {

            return 0;
        }
        // connect to Server have parameter 
        public int connectToServer(string serverIPAddr, int serverPort)
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
