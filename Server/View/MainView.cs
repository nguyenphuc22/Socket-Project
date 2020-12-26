using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class MainView : Form
    {
        public MainView()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text != "ON")
            {
                button1.Text = "ON";
                Load_Listview();
                Load_Log();
            }
            else
            {
                button1.Text = "OFF";
                Clear_Listview();
                Clear_Log();
            }
        }

        private void Load_Listview()
        {
            demo_user user_1 = new demo_user()
            {
                Name = "abc",
                Status = "online"
            };

            demo_user user_2 = new demo_user()
            {
                Name = "def",
                Status = "online"
            };

            string[] string_user_1 = { user_1.Name, user_1.Status };
            var listViewItemUser_1 = new ListViewItem(string_user_1);
            listView1.Items.Add(listViewItemUser_1);

            string[] string_user_2 = { user_2.Name, user_2.Status };
            var listViewItemUser_2 = new ListViewItem(string_user_2);
            listView1.Items.Add(listViewItemUser_2);
        }

        private void Clear_Listview()
        {
            listView1.Items.Clear();
        }

        private void Load_Log()
        {
            demo_message message_1 = new demo_message()
            {
                Type = "login",
                Name = "abc",
                Message = "has login",
            };
            demo_message message_2 = new demo_message()
            {
                Type = "chat",
                Name = "abc",
                Message = "sent a message to",
                Reciever = "def"
            };

            demo_message[] List = { message_1, message_2 };
            
            for (int i = 0; i < List.Length; i++)
            {
                if (List[i].Type == "login") 
                {
                    string message = "'" + List[i].Name + "' " + List[i].Message;
                    var ListLogMessage = new ListViewItem(message);
                    listView2.Items.Add(ListLogMessage);
                }
                else
                {
                    string message = "'" + List[i].Name + "' " + List[i].Message + " '" + List[i].Reciever + "'";
                    var ListLogMessage = new ListViewItem(message);
                    listView2.Items.Add(ListLogMessage);
                }
            }
        }

        private void Clear_Log()
        {
            listView2.Items.Clear();
        }
    }
}

public class demo_user
{
    public string Name;
    public string Status;
}

public class demo_message
{
    public string Type;
    public string Name;
    public string Message;
    public string Reciever;
}