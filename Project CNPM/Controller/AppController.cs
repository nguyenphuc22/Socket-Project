using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace Project_CNPM.Controller
{
    class AppController
    {
        public AppController appSocket;

        //===================
        //View Class Here........
        //===================

        public string userName;
        public Thread threadListenClient;

        // Function Support
        // ==========================


        // ==========================

        //Private Constructor.
        private AppController()
        {

        }
        // Singleton Patter: Surely this class is unique
        private static AppController instance = null;
        public static AppController Instance
        {
            get
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

        }

        // Main Calling
        // Function Listen Message From Server:
        public int createThreadListenMessageFromServer()
        {
            // Implement Here
            return 0;
        }
        // Function Login:
        public int login(string userName, string passWord)
        {
            // Implement Here
            return 0;
        }
        // Function SignUp:
        public int signup(string userName, string passWord)
        {
            // Implement Here
            return 0;
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

        


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainView());
        }
    }
}
