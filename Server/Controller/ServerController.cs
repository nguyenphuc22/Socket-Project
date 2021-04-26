using Project_CNPM.Model;
using Server.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Server.Controller
{
    class ServerController
    {
        public string dataSource = "Data Source=";
        public string path = @"C:\Users\ADMIN\Desktop\Socket-Project\Server\Data\";
        public string fileName = "database.db";
        int filesize = 1024*1024*1024;
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
        // LocalHostC:\Users\ADMIN\Desktop\Socket-Project\Server\Controller\ServerController.cs
        private ServerController()
        {
            // Create Socket LocalHost
            socketController = new SocketController();
            connnectData = new SQLiteConnection(dataSource+path+fileName);
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

            

            if (array.Count != 0 )
            {
                // Dang nhap thanh cong
                response = new ResponseLoginStruct(true, "Login Success");
                islogin = true;
                foreach (ClientInfor client in clientInforList)
                {
                    if (client.isUserName(array[0].ToString()))
                    {
                        response = new ResponseLoginStruct(false, "Account was login");
                        islogin = false;
                    }
                }
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
            if (!request.checkSpecialCharacter())
            {
                response = new ResponseSignupStruct(false, "Username contains only letters and numbers !");
            }
            else
            {
                ArrayList data = new ArrayList(request.readData(connnectData));

                if (data.Count == 0)
                {
                    response = new ResponseSignupStruct(true, "Signup Success");
                    request.writeData(connnectData);
                }
                else
                {
                    response = new ResponseSignupStruct(false, "Username available!");

                }
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
                    if(getSocketByUsername(listUserNameGroup[i].ToString()) != null)
                    {
                        getSocketByUsername(listUserNameGroup[i].ToString()).Send(request.pack());

                    }
                }
                return 0;
            }
            // Function Send Message Private: Gui di cho thang client khac
            public int sendPrivateMessage(RequestChatStruct request)
            {


                request.writeData(connnectData);
                if (getSocketByUsername(request.getRecUserName().ToString()) != null)
                {
                    getSocketByUsername(request.getRecUserName().ToString()).Send(request.pack());

                }
            return 0;
            }
            // Function Request List Online:
            public int requestListOnlineUsers()
            {
                // Implement Here
                return 0;
            }
            // Function Request Send File Private:
            public int requestSendFilePrivate(RequestSendFileStruct request,Socket socket)
            {
            
            {
                request.writeData(connnectData);
                ResponseSendFileStruct response = new ResponseSendFileStruct(request.getsendUserName(), request.getrecUserName(), request.getPath());
                if (getSocketByUsername(response.getrecUserName().ToString()) != null)
                {
                    getSocketByUsername(response.getrecUserName()).Send(response.pack());

                }
            }
                return 0;
            }
            // Function ReponseSend File Private
            public int responseSendFilePrivate(string toUsername, bool isAccept)
            {
                // Implement Here
                return 0;
            }
            // Function Request Send File Group:
            public int requestSendFileGroup(RequestSendFileGroupStruct request, Socket socket)
            {
                request.writeData(connnectData);
                ResponseSendFileGroupStruct response = new ResponseSendFileGroupStruct(request.getSend(),request.getrecGroupName(),request.getfile());
                ArrayList listUserName = response.readData(connnectData);
                for(int i = 0; i < listUserName.Count; i++)
                {
                    if (getSocketByUsername(listUserName[i].ToString()) != null)
                    {
                        getSocketByUsername(listUserName[i].ToString()).Send(response.pack());

                    }
                }
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
            public int requestCreateGroup(RequestCreateGroupStruct request,Socket client)
            {
                ArrayList array = request.readData(connnectData);
                ResposeCreateGroupStruct respose;
                if (array.Count != 0)
                {
                    request.writeData(connnectData);
                    respose = new ResposeCreateGroupStruct(request.getNameGroup(), request.getArrayList(), true, "Create Group Success");
                }else
                {
                    respose = new ResposeCreateGroupStruct(request.getNameGroup(), request.getArrayList(), false, "Create Group Failed");
                }
                client.Send(respose.pack());
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
            public void requestRecFile(RequestRecFile request, Socket socket)
            {


                string[] splitedPath = request.getPath().Split(@"\");
                string fileName = splitedPath[splitedPath.Length - 1];
                byte[] data = File.ReadAllBytes(request.getPath());
                ResponseRecFile response = new ResponseRecFile(fileName, data);
                socket.Send(response.pack());
            }
            public void requestRecFileGroup(RequestRecFileGroup request, Socket socket)
            {
                string[] splitedPath = request.getPath().Split(@"\");
                string fileName = splitedPath[splitedPath.Length - 1];
                byte[] data = File.ReadAllBytes(request.getPath());
                ResponseRecFileGroup response = new ResponseRecFileGroup(fileName, data);
                socket.Send(response.pack());
            }
        public void changePass(RequestChangePass request, Socket socket)
        {

            if (!request.comparePass(connnectData))
            {
                ResponseChangePass response1 = new ResponseChangePass("Wrong Password!");
                socket.Send(response1.pack());
                return;
            }
            if (!request.compareNewPass())
            {
                ResponseChangePass response1 = new ResponseChangePass("New Password dose not match!");
                socket.Send(response1.pack());
                return;
            }
            request.writeData(connnectData);
            ResponseChangePass response = new ResponseChangePass("Change Password successfully!");
            socket.Send(response.pack());
        }
        public void logout(string userName)
        {
            
            foreach (ClientInfor client in clientInforList)
            {
                if(client.isUserName(userName))
                {
                    clientInforList.Remove(client);
                    
                }
            }
        }
        public void outGroup(RequestOutGroup request)
        {
            request.writeData(connnectData);
        }
        // Function Listen Message Client
        public void updProfile(RequestProfile request)
        {
            request.writeData(connnectData);
        }
        public void loadProfile(RequestLoadProfile request,Socket socket)
        {
            ArrayList a = request.readData(connnectData);
            ResponseLoadProfile response=(ResponseLoadProfile)a[0];
            socket.Send(response.pack());
        }
        public void ListenClientMessage(object obj)
            {
                Socket client = obj as Socket;

                while (true)
                {
                    try
                    {
                        byte[] buff = new byte[filesize];
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
                            case ChatStruct.MessageType.RequestLogoutStruct:
                                {
                                    RequestLogout logoutNotification = (RequestLogout)msgReceived;
                                    logout(logoutNotification.getUserName());
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
                                    requestCreateGroup(RequestCreateGroup,client);
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
                                    this.sendGroupMessage(requestChatGroup);
                                    
                                break;
                                }
                            case ChatStruct.MessageType.RequestHistoryMessage:
                                {
                                    RequestHistoryMessageStruct requestHistoryMessage = (RequestHistoryMessageStruct)msgReceived;
                                    historyMessage(requestHistoryMessage,client);
                                    break;
                                }
                            case ChatStruct.MessageType.RequestRecFile:
                                {
                                    RequestRecFile requestRec = (RequestRecFile)msgReceived;
                                    requestRecFile(requestRec, client);
                                    break;
                                }
                            case ChatStruct.MessageType.RequestSendFileStruct:
                                {
                                    RequestSendFileStruct request = (RequestSendFileStruct)msgReceived;
                                    this.requestSendFilePrivate(request, client);
                                    break;
                                }
                            case ChatStruct.MessageType.RequestRecFileGroup:
                                {
                                    RequestRecFileGroup requestRec = (RequestRecFileGroup)msgReceived;
                                    requestRecFileGroup(requestRec, client);
                                    break;
                                }
                            case ChatStruct.MessageType.RequestSendFileGroupStruct:
                                {
                                    RequestSendFileGroupStruct request = (RequestSendFileGroupStruct)msgReceived;
                                    this.requestSendFileGroup(request,client);
                                    break;
                                }
                            case ChatStruct.MessageType.RequestChangePass:
                                {
                                    RequestChangePass request = (RequestChangePass)msgReceived;
                                    this.changePass(request, client);

                                    break;
                                }
                            case ChatStruct.MessageType.RequestOutGroup:
                            {
                                RequestOutGroup request = (RequestOutGroup)msgReceived;
                                this.outGroup(request);
                                break;
                            }
                            case ChatStruct.MessageType.RequestProfile:
                            {
                                RequestProfile request = (RequestProfile)msgReceived;
                                this.updProfile(request);
                                break;
                            }
                        case ChatStruct.MessageType.RequestLoadProfile:
                            {
                                RequestLoadProfile request = (RequestLoadProfile)msgReceived;
                                this.loadProfile(request, client);
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

