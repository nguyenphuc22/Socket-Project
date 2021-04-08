
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
            this.editName = new System.Windows.Forms.Button();
            this.editPhone = new System.Windows.Forms.Button();
            this.changePicture = new System.Windows.Forms.Button();
            this.changeMail = new System.Windows.Forms.TextBox();
            this.changeMailButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(88, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 120);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // changeUsr
            // 
            this.changeUsr.Location = new System.Drawing.Point(53, 189);
            this.changeUsr.Name = "changeUsr";
            this.changeUsr.Size = new System.Drawing.Size(176, 23);
            this.changeUsr.TabIndex = 1;
            this.changeUsr.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // changePhone
            // 
            this.changePhone.Location = new System.Drawing.Point(53, 234);
            this.changePhone.Name = "changePhone";
            this.changePhone.Size = new System.Drawing.Size(176, 23);
            this.changePhone.TabIndex = 2;
            this.changePhone.TextChanged += new System.EventHandler(this.changePhone_TextChanged);
            // 
            // editName
            // 
            this.editName.Location = new System.Drawing.Point(235, 189);
            this.editName.Name = "editName";
            this.editName.Size = new System.Drawing.Size(30, 23);
            this.editName.TabIndex = 3;
            this.editName.Text = "button1";
            this.editName.UseVisualStyleBackColor = true;
            this.editName.Click += new System.EventHandler(this.button1_Click);
            // 
            // editPhone
            // 
            this.editPhone.Location = new System.Drawing.Point(235, 234);
            this.editPhone.Name = "editPhone";
            this.editPhone.Size = new System.Drawing.Size(30, 23);
            this.editPhone.TabIndex = 4;
            this.editPhone.Text = "button2";
            this.editPhone.UseVisualStyleBackColor = true;
            this.editPhone.Click += new System.EventHandler(this.editPhone_Click);
            // 
            // changePicture
            // 
            this.changePicture.Location = new System.Drawing.Point(108, 151);
            this.changePicture.Name = "changePicture";
            this.changePicture.Size = new System.Drawing.Size(75, 23);
            this.changePicture.TabIndex = 5;
            this.changePicture.Text = "button1";
            this.changePicture.UseVisualStyleBackColor = true;
            this.changePicture.Click += new System.EventHandler(this.changePicture_Click);
            // 
            // changeMail
            // 
            this.changeMail.Location = new System.Drawing.Point(53, 275);
            this.changeMail.Name = "changeMail";
            this.changeMail.Size = new System.Drawing.Size(176, 23);
            this.changeMail.TabIndex = 6;
            // 
            // changeMailButton
            // 
            this.changeMailButton.Location = new System.Drawing.Point(235, 274);
            this.changeMailButton.Name = "changeMailButton";
            this.changeMailButton.Size = new System.Drawing.Size(30, 23);
            this.changeMailButton.TabIndex = 7;
            this.changeMailButton.Text = "button2";
            this.changeMailButton.UseVisualStyleBackColor = true;
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 329);
            this.Controls.Add(this.changeMailButton);
            this.Controls.Add(this.changeMail);
            this.Controls.Add(this.changePicture);
            this.Controls.Add(this.editPhone);
            this.Controls.Add(this.editName);
            this.Controls.Add(this.changePhone);
            this.Controls.Add(this.changeUsr);
            this.Controls.Add(this.pictureBox1);
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
        private System.Windows.Forms.Button editName;
        private System.Windows.Forms.Button editPhone;
        private System.Windows.Forms.Button changePicture;
        private System.Windows.Forms.TextBox changeMail;
        private System.Windows.Forms.Button changeMailButton;
    }
}