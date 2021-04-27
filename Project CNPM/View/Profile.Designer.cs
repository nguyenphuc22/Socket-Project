
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
            this.changeMail = new System.Windows.Forms.TextBox();
            this.changeMailButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(99, 57);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(136, 136);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // changeUsr
            // 
            this.changeUsr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.changeUsr.ForeColor = System.Drawing.SystemColors.Window;
            this.changeUsr.Location = new System.Drawing.Point(61, 252);
            this.changeUsr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.changeUsr.Name = "changeUsr";
            this.changeUsr.Size = new System.Drawing.Size(201, 27);
            this.changeUsr.TabIndex = 1;
            this.changeUsr.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // changePhone
            // 
            this.changePhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.changePhone.ForeColor = System.Drawing.SystemColors.Window;
            this.changePhone.Location = new System.Drawing.Point(61, 312);
            this.changePhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.changePhone.Name = "changePhone";
            this.changePhone.Size = new System.Drawing.Size(201, 27);
            this.changePhone.TabIndex = 2;
            this.changePhone.TextChanged += new System.EventHandler(this.changePhone_TextChanged);
            // 
            // changeMail
            // 
            this.changeMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.changeMail.ForeColor = System.Drawing.SystemColors.Window;
            this.changeMail.Location = new System.Drawing.Point(61, 367);
            this.changeMail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.changeMail.Name = "changeMail";
            this.changeMail.Size = new System.Drawing.Size(201, 27);
            this.changeMail.TabIndex = 6;
            // 
            // changeMailButton
            // 
            this.changeMailButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeMailButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.changeMailButton.Location = new System.Drawing.Point(123, 402);
            this.changeMailButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.changeMailButton.Name = "changeMailButton";
            this.changeMailButton.Size = new System.Drawing.Size(79, 31);
            this.changeMailButton.TabIndex = 7;
            this.changeMailButton.Text = "Update";
            this.changeMailButton.UseVisualStyleBackColor = true;
            this.changeMailButton.Click += new System.EventHandler(this.changeMailButton_Click_1);
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(345, 439);
            this.Controls.Add(this.changeMailButton);
            this.Controls.Add(this.changeMail);
            this.Controls.Add(this.changePhone);
            this.Controls.Add(this.changeUsr);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Profile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.TextBox changeMail;
        private System.Windows.Forms.Button changeMailButton;
    }
}