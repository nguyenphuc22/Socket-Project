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
using System.IO;
using Project_CNPM.View;
using Microsoft.VisualBasic;

namespace Project_CNPM
{
    public partial class MainView : Form
    {
        public MainView()
        {
                InitializeComponent();
                CheckForIllegalCrossThreadCalls = false;
                chatLabelForm_old = chatLabelForm1;
        }
        
        ChatLabelForm chatLabelForm_old = new ChatLabelForm();

        public void addInMessage(string msg, string username)
        {
           
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    //perform on the UI thread
                    ChatLabelForm chatLabelForm = new ChatLabelForm(msg, username, TypeMsg.In);
                    chatLabelForm.Anchor = chatLabelForm1.Anchor;
                    chatLabelForm.Location = chatLabelForm1.Location;
                    chatLabelForm.Size = chatLabelForm1.Size;
                    chatLabelForm.Top = chatLabelForm_old.Bottom + 10;

                    panel4.Controls.Add(chatLabelForm);
                    panel4.VerticalScroll.Value = panel4.VerticalScroll.Maximum;

                    chatLabelForm_old = chatLabelForm;
                });
            }
            else
            {
                //perform on the UI thread
                ChatLabelForm chatLabelForm = new ChatLabelForm(msg, username, TypeMsg.In);
                chatLabelForm.Anchor = chatLabelForm1.Anchor;
                chatLabelForm.Location = chatLabelForm1.Location;
                chatLabelForm.Size = chatLabelForm1.Size;
                chatLabelForm.Top = chatLabelForm_old.Bottom + 10;

                panel4.Controls.Add(chatLabelForm);
                panel4.VerticalScroll.Value = panel4.VerticalScroll.Maximum;

                chatLabelForm_old = chatLabelForm;
            }



        }
        public void addOutMessage(string msg, string username)
        {
            
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    ChatLabelForm chatLabelForm = new ChatLabelForm(msg, username, TypeMsg.Out);
                    chatLabelForm.Location = chatLabelForm1.Location;
                    chatLabelForm.Left += 20;
                    chatLabelForm.Size = chatLabelForm1.Size;
                    chatLabelForm.Anchor = chatLabelForm1.Anchor;
                    chatLabelForm.Top = chatLabelForm_old.Bottom + 10;


                    panel4.Controls.Add(chatLabelForm);
                    panel4.VerticalScroll.Value = panel4.VerticalScroll.Maximum;

                    chatLabelForm_old = chatLabelForm;

                });
            }
            else
            {
                ChatLabelForm chatLabelForm = new ChatLabelForm(msg, username, TypeMsg.Out);
                chatLabelForm.Location = chatLabelForm1.Location;
                chatLabelForm.Left += 20;
                chatLabelForm.Size = chatLabelForm1.Size;
                chatLabelForm.Anchor = chatLabelForm1.Anchor;
                chatLabelForm.Top = chatLabelForm_old.Bottom + 10;


                panel4.Controls.Add(chatLabelForm);
                panel4.VerticalScroll.Value = panel4.VerticalScroll.Maximum;

                chatLabelForm_old = chatLabelForm;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AppController.getObject().createThreadListenMessageFromServer();
            AppController.getObject().search(new ResquestSearchStruct(textBox1.Text, AppController.getObject().userName));
            label2.Text = AppController.getObject().userName;
            panel1.Height = 96;
            panel2.Height = 96;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.Equals((sender as Button).Name, @"CloseButton"))
            {
                AppController.getObject().logout(new RequestLogout(AppController.getObject().userName));

            }
            else
            {
                // Then assume that X has been clicked and act accordingly.
                AppController.getObject().logout(new RequestLogout(AppController.getObject().userName));
            }
        }

        public string s_msg;

        public void open_panel1()
        {
            this.panel1.Size = new Size(this.panel1.Width, 406);
        }

        public void close_panel1()
        {
            this.panel1.Size = new Size(this.panel1.Width, 96);
        }

        public void open_panel2()
        {
            this.panel2.Size = new Size(this.panel2.Width, 199);
        }

        public void close_panel2()
        {
            this.panel2.Size = new Size(this.panel2.Width, 96);
        }

        public void SetListView(ArrayList user_data)
        {
            listView1.Items.Clear();
            for (int i = 0; i < user_data.Count; i++)
            {
                if (user_data[i].ToString() != label2.Text)
                {
                    listView1.Items.Add(user_data[i].ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.panel1.Size.Height == 96)
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
            if (this.panel2.Size.Height == 96)
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
                Font n_font = new Font(listView1.SelectedItems[0].SubItems[0].Font, FontStyle.Regular);
                listView1.SelectedItems[0].SubItems[0].Font = n_font;
                label1.Text = listView1.SelectedItems[0].SubItems[0].Text;
                AppController.getObject().loadMessage(new RequestHistoryMessageStruct(AppController.getObject().userName, listView1.SelectedItems[0].SubItems[0].Text));
            }
        }

        public void SetListView2(ArrayList message_data,ArrayList username_data)
        {
            //listView2.Items.Clear();
            
            for (int i = 0; i < message_data.Count; i++)
            {
                if (username_data[i].ToString() == AppController.getObject().userName)
                {
                    if (message_data[i].ToString().Contains(":\\"))
                    {
                        addOutMessage(message_data[i].ToString(), username_data[i].ToString());
                    }
                    else
                    {

                        addOutMessage(message_data[i].ToString(), username_data[i].ToString());
                    }
                }
                else
                {
                    if (message_data[i].ToString().Contains(":\\"))
                    {
                        addInMessage(message_data[i].ToString(), username_data[i].ToString());
                        
                    }
                    else
                    {
                        addInMessage(message_data[i].ToString(), username_data[i].ToString());
                       
                    }
                }
            }
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!label1.Text.Contains("Group:"))
            {
                string spaceMsg = textBox2.Text.Replace(" ", "");
                if (textBox2.Text.Length != 0 && spaceMsg.Length!=0)
                { 
                    AppController.getObject().sendPrivateMessage(new RequestChatStruct(AppController.getObject().userName, label1.Text, textBox2.Text));
                    SetListItem2_send_msg(textBox2.Text, AppController.getObject().userName, label1.Text);
                    textBox2.Clear();
                } 
            }
            else
            {
                string spaceMsg = textBox2.Text.Replace(" ", "");
                if (textBox2.Text.Length != 0 && spaceMsg.Length != 0)
                {
                    AppController.getObject().sendGroupMessage(new RequestChatGroupStruct(AppController.getObject().userName, label1.Text.Substring(6), textBox2.Text));
                    SetListItem2_send_msg(textBox2.Text, AppController.getObject().userName, label1.Text);
                    textBox2.Clear();
                }
            }
            textBox2.Clear();
        }

        public void SetListItem2_send_msg(string message_data,string userName,string recMessage)
        {
            if(label1.Text == recMessage)
            {
                if (userName == label2.Text.ToString())
                {
                    if (message_data.ToString().Contains(":\\"))
                    {
                        addOutMessage(message_data,userName);
                        
                    }
                    else
                    {
                        addOutMessage(message_data,userName);
                        
                    }
                }
                else
                {
                    if (message_data.ToString().Contains(":\\"))
                    {
                        addInMessage(message_data,userName);
                        
                    }
                    else
                    {
                        addInMessage(message_data, userName);
                        
                    }
                }
            } 
            else
            {
                for (int j = 0; j < listView1.Items.Count; j++)
                {
                    if (listView1.Items[j].Text == recMessage)
                    {
                        Font n_font = new Font(listView1.Items[j].Font, FontStyle.Bold);
                        listView1.Items[j].Font = n_font;
                    }
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowHelp = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string strfilename = openFileDialog1.FileName;

                if (label1.Text.Contains("Group:"))
                {
                    SetListItem2_send_msg(strfilename, AppController.getObject().userName,  label1.Text);
                    int indexNumber = label1.Text.IndexOf(":");
                    string nameGroup = label1.Text.Substring(indexNumber + 1);
                    AppController.getObject().sendGroupFile(new RequestSendFileGroupStruct(AppController.getObject().userName, nameGroup, strfilename,
                        File.ReadAllBytes(strfilename)));
                }
                else
                {
                    var request = new RequestSendFileStruct(AppController.getObject().userName, label1.Text, strfilename,
                         File.ReadAllBytes(strfilename));
                    if (request.checkFileSize())
                    {
                        SetListItem2_send_msg(strfilename, AppController.getObject().userName, label1.Text);
                        AppController.getObject().sendPrivateFile(request);
                    }
                    

                }
            }
        }


        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (listView2.SelectedItems.Count >= 1)
            {
                if (listView2.SelectedItems[0].SubItems.Count >= 1)
                {
                    if (label1.Text.Contains("Group:"))
                    {
                        if (listView2.SelectedItems[0].SubItems[0].Text != "")
                        {
                            if (listView2.SelectedItems[0].ForeColor == Color.DarkBlue)
                            {
                                int indexNumber = listView2.SelectedItems[0].SubItems[0].Text.IndexOf(":");
                                string path = listView2.SelectedItems[0].SubItems[0].Text.Substring(indexNumber + 1);
                                string nameGroup = label1.Text.Substring(label1.Text.IndexOf(":") + 1);
                                AppController.getObject().requestRecFileGroup(new RequestRecFileGroup(nameGroup, path));
                            }
                        }
                        if (listView2.SelectedItems[0].SubItems[1].Text != "")
                        {
                            if (listView2.SelectedItems[0].ForeColor == Color.DarkBlue)
                            {
                                int indexNumber = listView2.SelectedItems[0].SubItems[1].Text.IndexOf(":");
                                string path = listView2.SelectedItems[0].SubItems[1].Text.Substring(indexNumber + 1);
                                string nameGroup = label1.Text.Substring(label1.Text.IndexOf(":") + 1);
                                AppController.getObject().requestRecFileGroup(new RequestRecFileGroup(nameGroup, path));
                            }
                        }
                    }
                    else
                    {
                        if (listView2.SelectedItems[0].SubItems[0].Text != "")
                        {
                            if (listView2.SelectedItems[0].ForeColor == Color.DarkBlue)
                            {
                                int indexNumber = listView2.SelectedItems[0].SubItems[0].Text.IndexOf(":");
                                string path = listView2.SelectedItems[0].SubItems[0].Text.Substring(indexNumber + 1);
                                AppController.getObject().requestRecFile(new RequestRecFile(AppController.getObject().userName, path));
                            }
                        }
                        if (listView2.SelectedItems[0].SubItems[1].Text != "")
                        {
                            if (listView2.SelectedItems[0].ForeColor == Color.DarkBlue)
                            {
                                int indexNumber = listView2.SelectedItems[0].SubItems[1].Text.IndexOf(":");
                                string path = listView2.SelectedItems[0].SubItems[1].Text.Substring(indexNumber + 1);
                                AppController.getObject().requestRecFile(new RequestRecFile(AppController.getObject().userName, path));
                            }
                        }
                    }
                }
            }
            */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AppController.getObject().change = new View.ChangePassForm();
            AppController.getObject().change.ShowDialog();
            //chuyen form sang doi pass
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AppController.getObject().logout(new RequestLogout(AppController.getObject().userName));
            AppController.getObject().loginView.Show();
            AppController.getObject().mainView.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string groupName = label1.Text.Substring(label1.Text.IndexOf(":") + 1);
            var request = new RequestOutGroup(groupName, AppController.getObject().userName);
            AppController.getObject().outGroup(request);
            //this.listView2.Clear();
            AppController.getObject().search(new ResquestSearchStruct("", AppController.getObject().userName));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            AppController.getObject().create = new View.CreateGroupForm();
            AppController.getObject().create.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void chatLabelForm1_Load(object sender, EventArgs e)
        {

        }
    }
}

