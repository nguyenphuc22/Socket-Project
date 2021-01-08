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
        ArrayList Group_nembers;

        public CreateGroupForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            AppController.getObject().search(new ResquestSearchStruct(textBox1.Text, AppController.getObject().userName));
        }

        public void SetListView(ArrayList user_data)
        {
            listView1.Items.Clear();
            for (int i = 0; i < user_data.Count; i++)
            {
                if (!user_data[i].ToString().Contains("Group:"))
                {
                    listView1.Items.Add(user_data[i].ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count >= 1)
            {
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    Group_nembers.Add(listView1.SelectedItems[i].SubItems[0].Text);
                }
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
