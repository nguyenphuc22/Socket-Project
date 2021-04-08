
namespace Project_CNPM.View
{
    partial class ListUser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.avatar = new System.Windows.Forms.PictureBox();
            this.userName = new System.Windows.Forms.Label();
            this.recentMes = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // avatar
            // 
            this.avatar.Location = new System.Drawing.Point(0, 0);
            this.avatar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.avatar.Name = "avatar";
            this.avatar.Size = new System.Drawing.Size(89, 89);
            this.avatar.TabIndex = 0;
            this.avatar.TabStop = false;
            this.avatar.Click += new System.EventHandler(this.ListUser_Click);
            this.avatar.MouseEnter += new System.EventHandler(this.ListUser_MouseEnter);
            this.avatar.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // userName
            // 
            this.userName.ForeColor = System.Drawing.Color.White;
            this.userName.Location = new System.Drawing.Point(22, 15);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(114, 31);
            this.userName.TabIndex = 1;
            this.userName.Text = "username";
            this.userName.Click += new System.EventHandler(this.ListUser_Click);
            this.userName.MouseEnter += new System.EventHandler(this.ListUser_MouseEnter);
            this.userName.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // recentMes
            // 
            this.recentMes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.recentMes.ForeColor = System.Drawing.Color.White;
            this.recentMes.Location = new System.Drawing.Point(22, 57);
            this.recentMes.Name = "recentMes";
            this.recentMes.Size = new System.Drawing.Size(114, 31);
            this.recentMes.TabIndex = 2;
            this.recentMes.Text = "recentmessage";
            this.recentMes.Click += new System.EventHandler(this.ListUser_Click);
            this.recentMes.MouseEnter += new System.EventHandler(this.ListUser_MouseEnter);
            this.recentMes.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.userName);
            this.panel1.Controls.Add(this.recentMes);
            this.panel1.Location = new System.Drawing.Point(92, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 89);
            this.panel1.TabIndex = 3;
            this.panel1.Click += new System.EventHandler(this.ListUser_Click);
            this.panel1.MouseEnter += new System.EventHandler(this.ListUser_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // ListUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.avatar);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ListUser";
            this.Size = new System.Drawing.Size(325, 87);
            this.Click += new System.EventHandler(this.ListUser_Click);
            this.DragLeave += new System.EventHandler(this.ListUser_DragLeave);
            this.MouseEnter += new System.EventHandler(this.ListUser_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox avatar;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Label recentMes;
        private System.Windows.Forms.Panel panel1;
    }
}
