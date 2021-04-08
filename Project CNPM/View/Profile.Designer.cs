
namespace Project_CNPM.View
{
    partial class Profile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.changeUsr = new System.Windows.Forms.TextBox();
            this.changePhone = new System.Windows.Forms.TextBox();
            this.changePicture = new System.Windows.Forms.Button();
            this.changeMail = new System.Windows.Forms.TextBox();
            this.changeMailButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(101, 33);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(136, 160);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // changeUsr
            // 
            this.changeUsr.Location = new System.Drawing.Point(61, 252);
            this.changeUsr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.changeUsr.Name = "changeUsr";
            this.changeUsr.Size = new System.Drawing.Size(201, 27);
            this.changeUsr.TabIndex = 1;
            this.changeUsr.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // changePhone
            // 
            this.changePhone.Location = new System.Drawing.Point(61, 312);
            this.changePhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.changePhone.Name = "changePhone";
            this.changePhone.Size = new System.Drawing.Size(201, 27);
            this.changePhone.TabIndex = 2;
            this.changePhone.TextChanged += new System.EventHandler(this.changePhone_TextChanged);
            // 
            // changePicture
            // 
            this.changePicture.Location = new System.Drawing.Point(123, 201);
            this.changePicture.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.changePicture.Name = "changePicture";
            this.changePicture.Size = new System.Drawing.Size(86, 31);
            this.changePicture.TabIndex = 5;
            this.changePicture.Text = "button1";
            this.changePicture.UseVisualStyleBackColor = true;
            this.changePicture.Click += new System.EventHandler(this.changePicture_Click);
            // 
            // changeMail
            // 
            this.changeMail.Location = new System.Drawing.Point(61, 367);
            this.changeMail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.changeMail.Name = "changeMail";
            this.changeMail.Size = new System.Drawing.Size(201, 27);
            this.changeMail.TabIndex = 6;
            // 
            // changeMailButton
            // 
            this.changeMailButton.Location = new System.Drawing.Point(123, 402);
            this.changeMailButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.changeMailButton.Name = "changeMailButton";
            this.changeMailButton.Size = new System.Drawing.Size(79, 31);
            this.changeMailButton.TabIndex = 7;
            this.changeMailButton.Text = "button2";
            this.changeMailButton.UseVisualStyleBackColor = true;
            this.changeMailButton.Click += new System.EventHandler(this.changeMailButton_Click_1);
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 439);
            this.Controls.Add(this.changeMailButton);
            this.Controls.Add(this.changeMail);
            this.Controls.Add(this.changePicture);
            this.Controls.Add(this.changePhone);
            this.Controls.Add(this.changeUsr);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Profile";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox changeUsr;
        private System.Windows.Forms.TextBox changePhone;
        private System.Windows.Forms.Button changePicture;
        private System.Windows.Forms.TextBox changeMail;
        private System.Windows.Forms.Button changeMailButton;
    }
}