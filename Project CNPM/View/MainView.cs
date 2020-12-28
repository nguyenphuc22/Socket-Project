using Project_CNPM.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_CNPM.Model;
using System.Collections;



namespace Project_CNPM
{
    public partial class MainView : Form
    {
        public MainView()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AppController.getObject().createThreadListenMessageFromServer();
            AppController.getObject().search(new ResquestSearchStruct(textBox1.Text, AppController.getObject().userName));
        }

        public string s_msg;

        public void open_panel1()
        {
            this.panel1.Size = new Size(this.panel1.Width, 303);
        }

        public void close_panel1()
        {
            this.panel1.Size = new Size(this.panel1.Width, 72);
        }

        public void open_panel2()
        {
            this.panel2.Size = new Size(this.panel2.Width, 303);
        }

        public void close_panel2()
        {
            this.panel2.Size = new Size(this.panel2.Width, 72);
        }

        public void SetListView(ArrayList user_data)
        {
            listView1.Items.Clear();
            for(int i = 0; i < user_data.Count; i++)
            {
                listView1.Items.Add(user_data[i].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.panel1.Size.Height == 72)
            {
                open_panel1();
                button1.Text = "▼";
            }
            else
            {
                close_panel1();
                button1.Text = "≡";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            close_panel1();
            AppController.getObject().search(new ResquestSearchStruct(textBox1.Text, AppController.getObject().userName));
        }

        private void close_panel1_leave(object sender, EventArgs e)
        {
            close_panel1();
        }

        

        private void button7_Click(object sender, EventArgs e)
        {
            if (this.panel2.Size.Height == 72)
            {
                open_panel2();
                button7.Text = "▼";
            }
            else
            {
                close_panel2();
                button7.Text = "≡";
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count >= 1)
            {
                label1.Text = listView1.SelectedItems[0].SubItems[0].Text;
                AppController.getObject().loadMessage(new RequestHistoryMessageStruct(AppController.getObject().userName, listView1.SelectedItems[0].SubItems[0].Text));
            }
        }

        public void SetListView2(ArrayList message_data)
        {
            listView2.Items.Clear();
            for (int i = 0; i < message_data.Count; i++)
            {
                if (message_data[i].ToString().Contains(AppController.getObject().userName))
                {
                    ListViewItem sender = new ListViewItem("");
                    sender.SubItems.Add(message_data[i].ToString());
                    listView2.Items.Add(sender);
                }
                else
                {
                    ListViewItem recievcer = new ListViewItem(message_data[i].ToString());
                    recievcer.SubItems.Add("");
                    listView2.Items.Add(recievcer);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(!label1.Text.Contains("Group:"))
            {
                AppController.getObject().sendPrivateMessage(new RequestChatStruct(AppController.getObject().userName, label1.Text ,textBox2.Text));
                SetListItem2_send_msg(AppController.getObject().userName + ":" + textBox2.Text);
            }else
            {
                AppController.getObject().sendGroupMessage(new RequestChatGroupStruct(AppController.getObject().userName, label1.Text.Substring(6),textBox2.Text));
                SetListItem2_send_msg(AppController.getObject().userName + ":" + textBox2.Text);
            }
        }

        public void SetListItem2_send_msg(string message_data)
        {
                if (message_data.ToString().Contains(AppController.getObject().userName+":"))
                {
                    ListViewItem sender = new ListViewItem("");
                    sender.SubItems.Add(message_data.ToString());
                    listView2.Items.Add(sender);
                }
                else
                {
                    ListViewItem recievcer = new ListViewItem(message_data.ToString());
                    recievcer.SubItems.Add("");
                    listView2.Items.Add(recievcer);
                }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowHelp = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string strfilename = openFileDialog1.FileName;

                MessageBox.Show(strfilename);
            }
        }
    }
}

