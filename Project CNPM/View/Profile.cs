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
using System.Collections;
using System.IO;


namespace Project_CNPM.View
{
    public partial class Profile : Form
    {
        string path;
        byte[] img;
        public Profile()
        {
            
        

            InitializeComponent();
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, 136, 136);
            pictureBox1.Region = new Region(path);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            AppController.getObject().loadProfile(new RequestLoadProfile(AppController.getObject().userName));
            //   changeUsr.Text= AppController.getObject().userName;


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

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        public void setprofile(byte[] d,string a,string b, string c)
        {
            pictureBox1.Image = ByteToImage(d);
            img = d;
            changeUsr.Text = a;
            changePhone.Text = b;
            changeMail.Text = c;
        }

        private void changeMailButton_Click(object sender, EventArgs e)
        {
            AppController.getObject().requestProfile(new RequestProfile(AppController.getObject().userName,File.ReadAllBytes("path"), changeUsr.Text, changePhone.Text, changeMail.Text));
        }

        private void changeMailButton_Click_1(object sender, EventArgs e)
        {
            if (path != null)
            {
                AppController.getObject().requestProfile(new RequestProfile((AppController.getObject().userName).ToString(), File.ReadAllBytes(path), (changeUsr.Text).ToString(), (changePhone.Text).ToString(), (changeMail.Text).ToString()));
            }
            else
            {
                AppController.getObject().requestProfile(new RequestProfile((AppController.getObject().userName).ToString(), img, (changeUsr.Text).ToString(), (changePhone.Text).ToString(), (changeMail.Text).ToString()));

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowHelp = true;
            openFileDialog1.Filter = "img( *.jpg *.jpeg *.png )| *.jpg; *.jpeg; *.png";

            openFileDialog1.ShowDialog();
            path = openFileDialog1.FileName;

        }
    }
}
