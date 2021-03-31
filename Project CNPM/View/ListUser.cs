﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Project_CNPM.View
{
    public partial class ListUser : UserControl
    {
        public ListUser()
        {
            InitializeComponent();
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, 96, 96);
            avatar.Region = new Region(path);
            avatar.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private string _username;
        private string _recentmess;
        private Image _ava;
        [Category("custom")]
        public string Username
        {
            get { return _username; }
            set { _username = value; userName.Text = value; }
        }
        [Category("custom")]
        public string Recentmess
        {
            get { return _recentmess; }
            set { _recentmess = value; recentMes.Text = value; }
        }
        [Category("custom")]
        public Image Ava
        {

            get { return _ava; }
            set { _ava = value; avatar.Image = value;  }
            
        }

        private void ListUser_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void ListUser_DragLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void ListUser_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
    }
}