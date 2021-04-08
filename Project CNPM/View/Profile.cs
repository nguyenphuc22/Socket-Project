﻿using Project_CNPM.Controller;
using Project_CNPM.Model;
using Project_CNPM.View;
using System;
using System.IO;
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
           // changeUsr.Text= AppController.getObject().userName;
          //setprofile("anhtu","1","2");
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

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }
        public void setprofile( byte[]d ,string a, string b, string c)
        {
            pictureBox1.Image = ByteToImage(d);
            changeUsr.Text = a;
            changePhone.Text = b;
            changeMail.Text = c;
        }
    }
}