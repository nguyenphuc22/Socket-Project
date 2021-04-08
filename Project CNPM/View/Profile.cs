using Project_CNPM.Controller;
using Project_CNPM.Model;
using Project_CNPM.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project_CNPM.View
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
            changeUsr.Text= AppController.getObject().userName;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void changePhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void editPhone_Click(object sender, EventArgs e)
        {

        }

        private void changePicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowHelp = true;
            openFileDialog1.Filter = "img( *.jpg *.jpeg *.png )| *.jpg; *.jpeg; *.png";
            openFileDialog1.ShowDialog();
            
        }
    }
}
