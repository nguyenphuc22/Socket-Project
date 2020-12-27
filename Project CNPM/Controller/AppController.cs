using Project_CNPM.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.SQLite;
using Project_CNPM.View;
using System.Net.Sockets;

namespace Project_CNPM.Controller
{
    class AppController
    {
        //===================
        //View Class Here........
        public LoginView loginView = null;
        public MainView mainView = null;
        //===================

        public string userName;
        public Thread threadListenClient;
        public AppSocketController appSocketController;
        
        // Function Support
        // ==========================



        // ==========================

        //Private Constructor.
        private AppController()
        {
            
            appSocketController = new AppSocketController();
            
        }
        // Singleton Patter: Surely this class is unique
        private static AppController instance = null;
        public static AppController getObject()
        {
            {
                if (instance == null)
                {
                    instance = new AppController();
                }
                return instance;
            }
        }
        // Destructor . Delete Socket.
        ~AppController()
        {
            //appSocketController.close();
        }

        // Main Calling
        // Function Listen Message From Server:
        public void listenMessageFromServer(object obj)
        {
            Socket client = obj as Socket;
            while (true)
            {
                byte[] buff = new byte[1024];
                int revc = -1;

                try
                {
                    revc = client.Receive(buff);

                }
                catch
                {
                    MessageBox.Show("Server has just disconnected!", "Server Down");
                    this.appSocketController.clientSocket = null;
                    Application.Exit();
                }
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
                            // Write Action Function here.........
                            break;

                        }
                    case ChatStruct.MessageType.ResponseLoginStruct:
                        {
                            ResponseLoginStruct ResponseLogin = (ResponseLoginStruct)msgReceived;
                            AppController.getObject().loginView.Change_subtitle(ResponseLogin.getMsg());

                            if (ResponseLogin.isSuccess())
                            {
                                AppController.getObject().loginView.Close_form();
                                AppController.getObject().loginView.Hide();


                                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                                Application.EnableVisualStyles();
                                Application.SetCompatibleTextRenderingDefault(false);
                                Application.Run(new MainView());

                            }
                            
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
                            // Write Action Function here.........
                            break;

                        }
                    case ChatStruct.MessageType.ResquestSignupStruct:
                        {
                            ResquestSignupStruct ResquestSignup = (ResquestSignupStruct)msgReceived;
                            // Write Action Function here.........
                            break;

                        }
                    case ChatStruct.MessageType.ResponseSignupStruct:
                        {
                            ResponseSignupStruct ResponseSignup = (ResponseSignupStruct)msgReceived;
                            AppController.getObject().loginView.Change_subtitle(ResponseSignup.getMsg());
                            break;
                            // Write Action Function here.........dd

                        }
                    case ChatStruct.MessageType.ResposeSearchStruct:
                        {
                            ResponseSearchStruct responseSearch = (ResponseSearchStruct)msgReceived;
                            break;
                        }
                    default:
                        break;
                }
            }
        }
        public void createThreadListenMessageFromServer()
        {
            // Implement Here
            Thread listen = new Thread(listenMessageFromServer);
            listen.IsBackground = true;
            listen.Start(this.appSocketController.clientSocket);
        }
        // Function Login:
        public void login(RequestLoginStruct request)
        {
            this.userName = request.getUserName();
            appSocketController.sendMessage(request.pack());
        }
        // Function SignUp:
        public void signup(ResquestSignupStruct request)
        {
            // Implement Here
            appSocketController.sendMessage(request.pack());

        }
        // Function Send Message Group:
        public int sendGroupMessage(string message,string idGroup)
        {
            // Implement Here
            return 0;
        }
        // Function Send Message Private:
        public int sendPrivateMessage(string toUsername, String message)
        {
            // Implement Here
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
        public int editProfile(string userName,string address,bool sex,string dayofbird)
        {
            // Implement Here
            return 0;
        }
        // Function response Profile;
        public int responseCreateGroup(string groupName, bool isAccept)
        {
            // Implement Here
            return 0;
        }
        // Function request Profile;
        public int requestCreateGroup(string groupName,ArrayList arrUserName)
        {
            RequestCreateGroupStruct request = new RequestCreateGroupStruct(groupName, arrUserName);
            appSocketController.sendMessage(request.pack());
            // Implement Here
            return 0;
        }
        // Function editProfile
        public int editCreateGroup(string userName, string address, bool sex, string dayofbird)
        {
            // Implement Here
            return 0;
        }

        public void search(ResquestSearchStruct resquest) 
        {
            this.appSocketController.sendMessage(resquest.pack());
        }


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppController appController = getObject();
            if(appController.appSocketController.connectToServer())
            {
                // Connect Succesful
                appController.createThreadListenMessageFromServer();

                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoginView());
                
            } else
            {
                // Connect Fail
                MessageBox.Show("Connection Errors", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            

        }
    }
}
