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
        public OpenFileDialog open = null;
        public ChangePassForm change = null;
        public CreateGroupForm create = null;
        public Profile profile = null;
        public int sizeFile = 1024 * 1024 * 25;
        //===================
        string Path = @"E:\Socket-Project-main\Project CNPM\Data\";
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
            logout(new RequestLogout(userName));
        }

        // Main Calling
        // Function Listen Message From Server:
        public void listenMessageFromServer(object obj)
            {
            Socket client = obj as Socket;
            while (true)
            {
                byte[] buff = new byte[sizeFile];
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
                            //LoginNotificationStruct loginNotification = (LoginNotificationStruct)msgReceived;
                            // Write Action Function here.........
                            break;
                        }
                    case ChatStruct.MessageType.RequestLogoutStruct:
                        {
                            RequestLogout logoutNotification = (RequestLogout)msgReceived;
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
                                
                                AppController.getObject().loginView.Hide();
                                AppController.getObject().mainView = new MainView();
                                AppController.getObject().mainView.ShowDialog();
                            }
                            
                            break;

                        }
                    case ChatStruct.MessageType.ResposeCreateGroupStruct:
                        {
                            ResposeCreateGroupStruct ResposeCreateGroup = (ResposeCreateGroupStruct)msgReceived;
                            if(ResposeCreateGroup.isSuccess())
                            {
                                MessageBox.Show(ResposeCreateGroup.getMsg(), "Create Succ");
                            }
                            else
                            {
                                MessageBox.Show(ResposeCreateGroup.getMsg(), "Fail");
                            }
                            AppController.getObject().mainView.Show();
                            AppController.getObject().create.Hide();
                            search(new ResquestSearchStruct("", userName));
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
                            this.mainView.clear();
                            this.mainView.populateItem(responseSearch.getData());
                            
                            break;
                        }
                    case ChatStruct.MessageType.RequestChatStruct:
                        {
                            RequestChatStruct requestChat = (RequestChatStruct)msgReceived;
                            // call function set msg view
                            getObject().mainView.SetListItem2_send_msg(requestChat.getMessage(), requestChat.getSendUserName(), requestChat.getSendUserName());
                            break;
                        }
                    case ChatStruct.MessageType.ResponseChatStruct:
                        {
                            ResponseChatStruct responseSearch = (ResponseChatStruct)msgReceived;
                            getObject().mainView.SetListItem2_send_msg(responseSearch.getMessage(), responseSearch.getrecUserName(), responseSearch.getrecUserName());
                            break;
                        }
                    case ChatStruct.MessageType.RequestChatGroupStruct:
                        {
                            RequestChatGroupStruct requestChatGroup = (RequestChatGroupStruct)msgReceived;
                            getObject().mainView.SetListItem2_send_msg(requestChatGroup.getMessage(), requestChatGroup.getRecGroupName(), requestChatGroup.getRecGroupName());
                            break;
                        }
                    case ChatStruct.MessageType.ResponseHistoryMesssage:
                        {
                            ResponseHistoryMesssageStruct responseHistoryMesssage = (ResponseHistoryMesssageStruct)msgReceived;
                            AppController.getObject().mainView.SetListView2(responseHistoryMesssage.getDataMess(),responseHistoryMesssage.getUsername());
                            break;
                        }
                    case ChatStruct.MessageType.ResponseRecFile:
                        {

                            ResponseRecFile responseRec = (ResponseRecFile)msgReceived;
                            responseRec.writeData(this.Path);
                            break;
                        }
                    case ChatStruct.MessageType.ResponseRecFileGroup:
                        {
                            ResponseRecFileGroup responseRec = (ResponseRecFileGroup)msgReceived;
                            responseRec.writeData(this.Path);
                            MessageBox.Show("Download File Success!");
                            break;
                        }
                    case ChatStruct.MessageType.ResponseSendFileStruct:
                        {
                            ResponseSendFileStruct response = (ResponseSendFileStruct)msgReceived;
                            AppController.getObject().mainView.SetListItem2_send_msg(response.getFileName(), this.userName, response.getSendUserName());
                            break;
                        }
                    case ChatStruct.MessageType.ResponseSendFileGroupStruct:
                        {
                            ResponseSendFileGroupStruct response = (ResponseSendFileGroupStruct)msgReceived;
                            AppController.getObject().mainView.SetListItem2_send_msg(response.getFileName(), this.userName,response.getRecGroupName());
                            break;
                        }
                    case ChatStruct.MessageType.ResponseChangePass:
                        {
                            ResponseChangePass response = (ResponseChangePass)msgReceived;
                            AppController.getObject().change.changePassNotification(response.getMsg());
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
        public int sendGroupMessage(RequestChatGroupStruct request)
        {
            appSocketController.sendMessage(request.pack());
            return 0;
        }
        // Function Send Message Private:
        public int sendPrivateMessage(RequestChatStruct request)
        {

            appSocketController.sendMessage(request.pack());
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
        public int sendPrivateFile(RequestSendFileStruct request)
        {
                appSocketController.sendMessage(request.pack());
            // Implement Here
            return 0;
        }
        // Function Send File Group
        public int sendGroupFile(RequestSendFileGroupStruct request)
        {
            appSocketController.sendMessage(request.pack());
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

        public void loadMessage(RequestHistoryMessageStruct request)
        {
            this.appSocketController.sendMessage(request.pack());
        }
        public void requestRecFile(RequestRecFile request)
        {

            this.appSocketController.sendMessage(request.pack());
        }
        public void requestRecFileGroup(RequestRecFileGroup request)
        {
            this.appSocketController.sendMessage(request.pack());
        }
        public void changePass(RequestChangePass request)
        {
            // Implement Here
            appSocketController.sendMessage(request.pack());

        }
        public void logout(RequestLogout request)
        {
            appSocketController.sendMessage(request.pack());
        }
        public void outGroup(RequestOutGroup request)
        {
            appSocketController.sendMessage(request.pack());
        }
        public void requestCreateGroup(RequestCreateGroupStruct request)
        {
            appSocketController.sendMessage(request.pack());
        }
        public void requestProfile(RequestProfile request)
        {
            appSocketController.sendMessage(request.pack());
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
