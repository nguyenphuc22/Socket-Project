using Project_CNPM.Model;
using Server.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Server.Controller
{
    class ServerController
    {
        private string path = @"Data Source=C:\Users\USER\OneDrive\Documents\GitHub\Socket-Project\Server\Data\database.db";
        public SocketController socketController;
        private Thread threadListenClient;
        private List<Socket> clientList;
        private List<ClientInfor> clientInforList = new List<ClientInfor>();
        private int serverPort;
        SQLiteConnection connnectData;

        //===================
        //View Class Here........
        //===================


        //Private Constructor.
        // LocalHost
        private ServerController()
        {
            // Create Socket LocalHost
            socketController = new SocketController();
            connnectData = new SQLiteConnection(path);
            connnectData.Open();
            serverPort = 2020;
            this.mutiSocket(socketController.serverSocket);

        }

        // Singleton Patter: Surely this class is unique
        private static ServerController instance = null;

        public static ServerController getObject()
        {

            if (instance == null)
            {
                instance = new ServerController();
            }
            return instance;

        }
        // Destructor . Delete Socket.
        ~ServerController()
        {

        }

        // Function Support
        // ==========================


        // ==========================


        // Main Calling
        // Function Listen Message From Server:
        public int createThreadListenMessageFromServer()
        {
            // Implement Here
            return 0;
        }
        // Function Login:
        public bool login(RequestLoginStruct request, Socket socket)
        {
            ResponseLoginStruct response;
            bool islogin = false;
            ArrayList array = new ArrayList(request.readData(connnectData));

            if (array.Count != 0)
            {
                // Dang nhap thanh cong
                response = new ResponseLoginStruct(true, "Login Success");
                islogin = true;
            }
            else
            {
                // Dang nhap that bai
                response = new ResponseLoginStruct(false, "Login Fail");
                islogin = false;
            }
            socket.Send(response.pack());
            return islogin;
        }    

            // Function SignUp:
        public void signup(ResquestSignupStruct request, Socket socket)
        {
            ResponseSignupStruct response;
            ArrayList data = new ArrayList(request.readData(connnectData));
            if (data.Count==0)
            {
                response = new ResponseSignupStruct(true, "Signup Success");
                request.writeData(connnectData);
            }
            else
            {
                response = new ResponseSignupStruct(false, "Username available!");
              
            }
            socket.Send(response.pack());
        }
            // Function Send Message Group:
            public int sendGroupMessage(RequestChatGroupStruct request)
            {
                request.writeData(connnectData);
                ArrayList listUserNameGroup = request.readData(connnectData);
                for(int i = 0; i < listUserNameGroup.Count; i++)
                {
                    getSocketByUsername(listUserNameGroup[i].ToString()).Send(request.pack());
                }
                return 0;
            }
            // Function Send Message Private: Gui di cho thang client khac
            public int sendPrivateMessage(RequestChatStruct request)
            {
                request.writeData(connnectData);
                getSocketByUsername(request.getRecUserName()).Send(request.pack());
                return 0;
            }
            // Function Request List Online:
            public int requestListOnlineUsers()
            {
                // Implement Here
                return 0;
            }
            // Function Request Send File Private:
            public int requestSendFilePrivate(string toUsername, string fileName, int iFileSize)
            {
                // Implement Here
                return 0;
            }
            // Function ReponseSend File Private
            public int responseSendFilePrivate(string toUsername, bool isAccept)
            {
                // Implement Here
                return 0;
            }
            // Function Request Send File Group:
            public int requestSendFileGroup(string toIdGroup, string fileName, int iFileSize)
            {
                // Implement Here
                return 0;
            }
            // Function ReponseSend File Group
            public int responseSendFileGroup(string toIdGroup, bool isAccept)
            {
                // Implement Here
                return 0;
            }
            // Function Send File Private
            public int sendPrivateFile(string toUsername, string fileName, string filePath)
            {
                // Implement Here
                return 0;
            }
            // Function Send File Group
            public int sendGroupFile(string toIdGroup, string fileName, string filePath)
            {
                // Implement Here
                return 0;
            }
            // Function response Profile;
            public int responseProfile(string userName, bool isAccept)
            {
                // Implement Here
                return 0;
            }
            // Function request Profile;
            public int requestProfile(string userName)
            {
                // Implement Here
                return 0;
            }
            // Function editProfile
            public int editProfile(string userName, string address, bool sex, string dayofbird)
            {
                // Implement Here
                return 0;
            }
            // Function response Profile;
            public int responseCreateGroup(string userName, bool isAccept)
            {
                // Implement Here
                return 0;
            }
            // Function request Profile;
            public int requestCreateGroup(string userName)
            {
                // Implement Here
                return 0;
            }
            // Function editProfile
            public int editCreateGroup(string userName, string address, bool sex, string dayofbird)
            {
                // Implement Here
                return 0;
            }
            public void search(ResquestSearchStruct resquest, Socket socket)
            {
                ArrayList data = resquest.readData(connnectData);
                ResponseSearchStruct response = new ResponseSearchStruct(data);
                socket.Send(response.pack());
            }
            public void historyMessage(RequestHistoryMessageStruct request, Socket socket)
            {
                ArrayList data = request.readData(connnectData);
                ResponseHistoryMesssageStruct response = new ResponseHistoryMesssageStruct(data);
                socket.Send(response.pack());
            }
            // Function Listen Message Client
            public void ListenClientMessage(object obj)
            {
                Socket client = obj as Socket;

                while (true)
                {
                    try
                    {
                        byte[] buff = new byte[1024];
                        client.Receive(buff);
                        ChatStruct msgReceived = ChatController.unpack(buff);
                        switch (msgReceived.messageType)
                        {
                            case ChatStruct.MessageType.LoginNotificationStruct:
                                {
                                    LoginNotificationStruct loginNotification = (LoginNotificationStruct)msgReceived;
                                    // Write Action Function here.........
                                    break;
                                }
                            case ChatStruct.MessageType.LogoutNotificationStruct:
                                {
                                    LogoutNotificationStruct logoutNotification = (LogoutNotificationStruct)msgReceived;
                                    // Write Action Function here.........
                                    break;
                                }
                            case ChatStruct.MessageType.PrivateFileStruct:
                                {
                                    PrivateFileStruct privateFile = (PrivateFileStruct)msgReceived;
                                    // Write Action Function here.........
                                    break;
                                }
                            case ChatStruct.MessageType.PrivateGroupMessageStruct:
                                {
                                    PrivateGroupMessageStruct PrivateGroupMessage = (PrivateGroupMessageStruct)msgReceived;
                                    // Write Action Function here.........
                                    break;

                                }
                            case ChatStruct.MessageType.PublicFileGroupStruct:
                                {
                                    PublicFileGroupStruct PublicFileGroup = (PublicFileGroupStruct)msgReceived;
                                    // Write Action Function here.........
                                    break;

                                }
                            case ChatStruct.MessageType.PublicGroupMessageStruct:
                                {
                                    PublicGroupMessageStruct PublicGroupMessage = (PublicGroupMessageStruct)msgReceived;
                                    // Write Action Function here.........
                                    break;

                                }
                            case ChatStruct.MessageType.RequestCreateGroupStruct:
                                {
                                    RequestCreateGroupStruct RequestCreateGroup = (RequestCreateGroupStruct)msgReceived;
                                    // Write Action Function here.........
                                    break;

                                }
                            case ChatStruct.MessageType.RequestLoginStruct:
                                {
                                    RequestLoginStruct RequestLogin = (RequestLoginStruct)msgReceived;
                                    if(login(RequestLogin, client))
                                    {
                                        clientInforList.Add(new ClientInfor(RequestLogin.getUserName(), client));
                                    }
                                
                                    break;

                                }
                            case ChatStruct.MessageType.ResponseLoginStruct:
                                {
                                    ResponseLoginStruct ResponseLogin = (ResponseLoginStruct)msgReceived;
                                    // Write Action Function here.........
                                    break;

                                }
                            case ChatStruct.MessageType.ResposeCreateGroupStruct:
                                {
                                    ResposeCreateGroupStruct ResposeCreateGroup = (ResposeCreateGroupStruct)msgReceived;
                                    // Write Action Function here.........
                                    break;

                                }
                            case ChatStruct.MessageType.ResposeProfileStruct:
                                {
                                    ResposeProfileStruct ResposeProfile = (ResposeProfileStruct)msgReceived;
                                    // Write Action Function here.........
                                    break;

                                }
                            case ChatStruct.MessageType.ResposeSignupStruct:
                                {
                                    ResposeSignupStruct ResposeSignup = (ResposeSignupStruct)msgReceived;
                                    // Write Action Function here.........
                                    break;

                                }
                            case ChatStruct.MessageType.ResquestProfileStruct:
                                {
                                    ResquestProfileStruct ResquestProfile = (ResquestProfileStruct)msgReceived;
                                    // Write Action Function here.........
                                    break;

                                }
                            case ChatStruct.MessageType.ResquestSearchStruct:
                                {
                                    ResquestSearchStruct ResquestSearch = (ResquestSearchStruct)msgReceived;
                                    search(ResquestSearch, client);
                                    break;

                                }
                            case ChatStruct.MessageType.ResquestSignupStruct:
                                {
                                    ResquestSignupStruct ResquestSignup = (ResquestSignupStruct)msgReceived;
                                    signup(ResquestSignup, client);
                                    // Write Action Function ere.........
                                    break;

                                }
                            case ChatStruct.MessageType.ResponseSignupStruct:
                                {
                                    ResponseSignupStruct ResponseSignup = (ResponseSignupStruct)msgReceived;
                                    // Write Action Function here.........
                                    break;  

                                }
                            case ChatStruct.MessageType.RequestChatStruct:
                                {
                                    RequestChatStruct RequestChat = (RequestChatStruct)msgReceived;
                                    this.sendPrivateMessage(RequestChat);
                                    break;
                                }
                            case ChatStruct.MessageType.ResponseChatStruct:
                                {
                                    ResponseChatStruct ResponseChat = (ResponseChatStruct)msgReceived;
                                    break;
                                }
                            case ChatStruct.MessageType.RequestChatGroupStruct:
                                {
                                    RequestChatGroupStruct requestChatGroup = (RequestChatGroupStruct)msgReceived;
                                    break;
                                }
                            case ChatStruct.MessageType.RequestHistoryMessage:
                                {
                                    RequestHistoryMessageStruct requestHistoryMessage = (RequestHistoryMessageStruct)msgReceived;
                                    historyMessage(requestHistoryMessage,client);
                                    break;
                                }
                        default:
                                break;
                        }
                    }
                    catch
                    {
                        // Check error if client close socket.
                        //clientList.Remove(client);
                        //client.Close();
                    }
                }
            }
            // Function Muti Socket
            public void mutiSocket(Socket s)
            {
                Socket server = s;
                clientList = new List<Socket>();
                threadListenClient = new Thread(() =>
                {
                    try
                    {
                        while (true)
                        {
                            server.Listen(100);
                            Socket client = server.Accept();
                            clientList.Add(client);

                            Thread receive = new Thread(ListenClientMessage);
                            receive.IsBackground = true;
                            receive.Start(client);
                        }
                    }
                    catch
                    {
                        server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        server.Bind(new IPEndPoint(IPAddress.Any, serverPort));

                    }

                });
                threadListenClient.IsBackground = true;
                threadListenClient.Start();
            }



            //Others
            List<string> getListClient()
            {
                return null;
            }
            List<string> getRegisteredClientList()
            {
                return null;
            }
            string getUsernameBySocket(Socket socket)
            {
                return null;
            }
            Socket getSocketByUsername(string userName)
            {
                foreach (ClientInfor client in clientInforList)
                {
                    if (client.isUserName(userName))
                        return client.getSocket();
                }
                return null;
            }
            void removeClientInfoByUsername(string userName)
            {

            }

            /// <summary>
            ///  The main entry point for the application.
            /// </summary>
            [STAThread]

            static void Main()
            {
                ServerController server = getObject();



                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainView());
            }
    }
}

