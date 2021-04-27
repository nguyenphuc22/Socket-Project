using Project_CNPM.Controller;
using Project_CNPM.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project_CNPM.View
{
    public partial class CreateGroupForm : Form
    {
        ArrayList Group_nembers = new ArrayList();

        public CreateGroupForm()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            AppController.getObject().search(new ResquestSearchStruct(textBox2.Text, AppController.getObject().userName));
        }

/*        public void SetListView(ArrayList user_data)
        {
            listView1.Items.Clear();
            for (int i = 0; i < user_data.Count; i++)
            {
                if (!user_data[i].ToString().Contains("Group:") && user_data[i].ToString() != AppController.getObject().userName)
                {
                    listView1.Items.Add(((RecentMessage)user_data[i]).userName) ;
                }
            }
        }*/

        private void button1_Click(object sender, EventArgs e)
        {

            /*  if (listView1.SelectedItems.Count >= 1)
               {
                   for (int i = 0; i < listView1.SelectedItems.Count; i++)
                   {
                       Group_nembers.Add(listView1.SelectedItems[i].Text);
                   }
               }

                  Group_nembers.Add(AppController.getObject().userName);
                  AppController.getObject().requestCreateGroup(new RequestCreateGroupStruct(textBox1.Text, Group_nembers));*/
            foreach (ListUser_1 control in flowLayoutPanel2.Controls)
            {
                if (control.isclicked == true)
                {
                    if (!Group_nembers.Contains(control.Username))
                    {
                        Group_nembers.Add(control.Username);
                    }
                }
                if(control.isclicked==false&& Group_nembers.Contains(control.Username))
                {
                    Group_nembers.Remove(control.Username);
                }

            }
            string a = "";
            for(int i = 0; i < Group_nembers.Count; i++)
            {
                a += Group_nembers[i].ToString()+"\n";
            }

            Group_nembers.Add(AppController.getObject().userName);
            AppController.getObject().requestCreateGroup(new RequestCreateGroupStruct(textBox1.Text, Group_nembers));
            AppController.getObject().mainView.Show();
            // System.Windows.Forms.MessageBox.Show(a);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // Hide();
            Dispose();
            AppController.getObject().mainView.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void CreateGroupForm_Load(object sender, EventArgs e)
        {
            AppController.getObject().createThreadListenMessageFromServer();
            AppController.getObject().search(new ResquestSearchStruct(textBox2.Text, AppController.getObject().userName));
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    /*    private void listView1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0) {
                if (!Group_nembers.Contains(listView1.SelectedItems[0].Text))
                {
                    Group_nembers.Add(listView1.SelectedItems[0].Text);
                }
            }

        }*/
        public void clear()
        {
            foreach (ListUser_1 control in flowLayoutPanel2.Controls)
            {
                flowLayoutPanel2.Controls.Clear();

            }
        }


        public void populateItem(ArrayList arr)
        {
            if (IsHandleCreated)
            {

                ListUser_1[] listusers = new ListUser_1[arr.Count];


                this.BeginInvoke((Action)(() =>
                {

                    for (int i = 0; i < arr.Count; i++)
                    {

                        listusers[i] = new ListUser_1();
                    // listusers[i].Click();

                    listusers[i].Username = ((RecentMessage)arr[i]).userName;
                    //   listusers[i].Recentmess = ((RecentMessage)arr[i]).lastMessage;
                    if (flowLayoutPanel2.Controls.Count < 0)
                        {
                            flowLayoutPanel2.Controls.Clear();
                        }
                        else
                        {
                            flowLayoutPanel2.Controls.Add(listusers[i]);
                        }



                    }
                }));
            }
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
