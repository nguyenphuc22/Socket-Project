using Project_CNPM.Controller;
using Project_CNPM.Model;
using Project_CNPM.View;
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Project_CNPM
{
    public partial class MainView : Form
    {
        int sizbar = 54;
        int height = 30;

        public MainView()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            chatLabelForm1.Visible = true;

            chatLabelForm_old = chatLabelForm1;
            // populateItem()

        }

        ChatLabelForm chatLabelForm_old = new ChatLabelForm();

        public void addInMessage(string msg, string username, bool isfile)
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    //perform on the UI thread
                    ChatLabelForm chatLabelForm = new ChatLabelForm(msg, username, TypeMsg.In, isfile, label1.Text);
                    chatLabelForm.Location = chatLabelForm1.Location;

                    chatLabelForm.Anchor = chatLabelForm1.Anchor;
                    chatLabelForm.Size = chatLabelForm1.Size;
                    chatLabelForm.Top = chatLabelForm_old.Bottom + 10;



                    chatLabelForm.Height += height;


                    panel4.Controls.Add(chatLabelForm);
                    panel4.VerticalScroll.Value = panel4.VerticalScroll.Maximum;

                    chatLabelForm_old = chatLabelForm;
                });
            }
            else
            {
                ChatLabelForm chatLabelForm = new ChatLabelForm(msg, username, TypeMsg.In, isfile, label1.Text);
                chatLabelForm.Location = chatLabelForm1.Location;

                chatLabelForm.Anchor = chatLabelForm1.Anchor;
                chatLabelForm.Size = chatLabelForm1.Size;
                chatLabelForm.Top = chatLabelForm_old.Bottom + 10;


                chatLabelForm.Height += height;


                panel4.Controls.Add(chatLabelForm);
                panel4.VerticalScroll.Value = panel4.VerticalScroll.Maximum;

                chatLabelForm_old = chatLabelForm;
            }



        }
        public void addOutMessage(string msg, string username, bool isfile)
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    ChatLabelForm chatLabelForm = new ChatLabelForm(msg, username, TypeMsg.Out, isfile, label1.Text);
                    chatLabelForm.Location = chatLabelForm1.Location;

                    chatLabelForm.Size = chatLabelForm1.Size;
                    chatLabelForm.Anchor = chatLabelForm1.Anchor;
                    chatLabelForm.Top = chatLabelForm_old.Bottom + 10;

                    chatLabelForm.Height += height;
                    chatLabelForm.Left = 226;

                    panel4.Controls.Add(chatLabelForm);
                    panel4.VerticalScroll.Value = panel4.VerticalScroll.Maximum;


                    chatLabelForm_old = chatLabelForm;

                });
            }
            else
            {
                ChatLabelForm chatLabelForm = new ChatLabelForm(msg, username, TypeMsg.Out, isfile, label1.Text);
                chatLabelForm.Location = chatLabelForm1.Location;


                chatLabelForm.Size = chatLabelForm1.Size;
                chatLabelForm.Anchor = chatLabelForm1.Anchor;
                chatLabelForm.Top = chatLabelForm_old.Bottom + 10;

                chatLabelForm.Height += height;

                chatLabelForm.Left = 226;


                panel4.Controls.Add(chatLabelForm);
                panel4.VerticalScroll.Value = panel4.VerticalScroll.Maximum;


                chatLabelForm_old = chatLabelForm;

            }
        }

        public void setLabel1(String text)
        {
            label1.Text = text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AppController.getObject().createThreadListenMessageFromServer();
            AppController.getObject().search(new ResquestSearchStruct("", AppController.getObject().userName));
            label2.Text = AppController.getObject().userName;
            panel1.Height = sizbar;
            panel2.Height = sizbar;

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
            int size_wi = this.panel1.Size.Height + button_SignOut.Size.Height + button_createGroup.Size.Height + button_changpass.Size.Height + profile.Size.Height;
            this.panel1.Size = new Size(this.panel1.Width, size_wi);
        }

        public void close_panel1()
        {
            this.panel1.Size = new Size(this.panel1.Width, 54);
        }

        public void open_panel2()
        {
            int height = this.panel2.Size.Height + this.button_chatMenu.Size.Height;
            this.panel2.Size = new Size(this.panel2.Width, height);
        }

        public void close_panel2()
        {
            this.panel2.Size = new Size(this.panel2.Width, 54);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (this.panel1.Size.Height == sizbar)
            {
                open_panel1();
            }
            else
            {
                close_panel1();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            AppController.getObject().search(new ResquestSearchStruct(textBox1.Text, AppController.getObject().userName));
        }

        private void close_panel1_leave(object sender, EventArgs e)
        {
            close_panel1();
        }



        private void button7_Click(object sender, EventArgs e)
        {
            if (this.panel2.Size.Height == sizbar)
            {
                open_panel2();
                
            }
            else
            {
                close_panel2();
                
            }
        }


        public void SetListView2(ArrayList message_data, ArrayList username_data)
        {
            //listView2.Items.Clear();
            panel4.Controls.Clear();
            chatLabelForm_old = chatLabelForm1;
            for (int i = 0; i < message_data.Count  ; i++)
            {
                if (username_data[i].ToString() == AppController.getObject().userName)
                {
                    if (message_data[i].ToString().Contains(":\\"))
                    {
                        addOutMessage(message_data[i].ToString(), username_data[i].ToString(), true);
                    }
                    else
                    {

                        addOutMessage(message_data[i].ToString(), username_data[i].ToString(), false);
                    }
                }
                else
                {
                    if (message_data[i].ToString().Contains(":\\"))
                    {
                        addInMessage(message_data[i].ToString(), username_data[i].ToString(), true);

                    }
                    else
                    {
                        addInMessage(message_data[i].ToString(), username_data[i].ToString(), false);

                    }
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //SQL injection
            if (textBox2.Text.Contains("'")||textBox2.Text=="\r\n")
            {
                MessageBox.Show("Do not enter special characters");
                return;
            }
            
            if (!label1.Text.Contains("Group:"))
            {
                
                string spaceMsg = textBox2.Text.Replace(" ", "");
                if (textBox2.Text.Length != 0 && spaceMsg.Length != 0)
                {
                    AppController.getObject().sendPrivateMessage(new RequestChatStruct(AppController.getObject().userName, label1.Text, textBox2.Text.Replace("\r\n","")));
                    SetListItem2_send_msg(textBox2.Text, AppController.getObject().userName, label1.Text);
                    textBox2.Clear();
                }
            }
            else
            {
                string spaceMsg = textBox2.Text.Replace(" ", "");
                if (textBox2.Text.Length != 0 && spaceMsg.Length != 0)
                {
                    AppController.getObject().sendGroupMessage(new RequestChatGroupStruct(AppController.getObject().userName, label1.Text.Substring(6), textBox2.Text.Replace("\r\n", "")));
                    SetListItem2_send_msg(textBox2.Text, AppController.getObject().userName, label1.Text);
                    textBox2.Clear();
                }
            }
            textBox2.Clear();
        }

        public void SetListItem2_send_msg(string message_data, string userName, string recMessage)
        {
            if (label1.Text == recMessage)
            {
                foreach (ListUser c in flowLayoutPanel1.Controls)
                {
                    if (c.Username == recMessage)
                    {
                        c.setpanel("blue");
                    }
                }
                if (userName == label2.Text.ToString())
                {
                    if (message_data.ToString().Contains(":\\"))
                    {
                        addOutMessage(message_data, userName, true);

                    }
                    else
                    {
                        addOutMessage(message_data, userName, false);

                    }
                }
                else
                {
                    if (message_data.ToString().Contains(":\\"))
                    {
                        addInMessage(message_data, userName, true);

                    }
                    else
                    {
                        addInMessage(message_data, userName, false);

                    }
                }
            }
            else
            {


                foreach (ListUser c in flowLayoutPanel1.Controls)
                {
                    if (c.Username == recMessage)
                    {
                        c.setpanel("black");

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
                    SetListItem2_send_msg(strfilename, AppController.getObject().userName, label1.Text);
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

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
        public void clear()
        {
            foreach (ListUser control in flowLayoutPanel1.Controls)
            {
                flowLayoutPanel1.Controls.Clear();
               
            }
        }
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
        public void populateItem(ArrayList arr)
        {
            
            ListUser[] listusers = new ListUser[arr.Count];

            this.BeginInvoke((Action)(() =>
            {

                for (int i = 0; i < arr.Count; i++)
                {

                    listusers[i] = new ListUser();
                    byte[] im = ((RecentMessage)arr[i]).image;
                    byte[] a = new byte[0];
                    if (im.Length != 0)
                    {
                    listusers[i].Ava = ByteToImage(im); 
                    }
                    listusers[i].Username = ((RecentMessage)arr[i]).userName;
                    listusers[i].Recentmess = ((RecentMessage)arr[i]).lastMessage;
                    if (flowLayoutPanel1.Controls.Count < 0)
                    {
                        flowLayoutPanel1.Controls.Clear();
                    }
                    else
                    {
                        flowLayoutPanel1.Controls.Add(listusers[i]);
                    }

                    


                }
            }));
        }



        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {


        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            AppController.getObject().logout(new RequestLogout(AppController.getObject().userName));
            System.Windows.Forms.Application.Exit();

        }

        private void chatLabelForm1_Load_1(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button6_Click(this, new EventArgs());
            }
        }

        private void button6_KeyDown(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                MessageBox.Show(" Enter pressed ");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void profile_Click(object sender, EventArgs e)
        {
            AppController.getObject().profile = new View.Profile();
            AppController.getObject().profile.ShowDialog();
        }
    }
}

