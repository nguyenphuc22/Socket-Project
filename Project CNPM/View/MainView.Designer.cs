namespace Project_CNPM {     partial class MainView     {         /// <summary>         ///  Required designer variable.         /// </summary>         private System.ComponentModel.IContainer components = null;          /// <summary>         ///  Clean up any resources being used.         /// </summary>         /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>         protected override void Dispose(bool disposing)         {             if (disposing && (components != null))             {                 components.Dispose();             }             base.Dispose(disposing);         }          #region Windows Form Designer generated code          /// <summary>         ///  Required method for Designer support - do not modify         ///  the contents of this method with the code editor.         /// </summary>         private void InitializeComponent()         {             System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_chatMenu = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chatLabelForm1 = new Project_CNPM.View.ChatLabelForm();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.profile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_SignOut = new System.Windows.Forms.Button();
            this.button_createGroup = new System.Windows.Forms.Button();
            this.button_changpass = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(442, 695);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(516, 47);
            this.textBox2.TabIndex = 4;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.button6_KeyDown);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.button6_KeyPress);
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.Location = new System.Drawing.Point(964, 699);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(46, 43);
            this.button6.TabIndex = 5;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_chatMenu);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Location = new System.Drawing.Point(905, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(108, 98);
            this.panel2.TabIndex = 8;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // button_chatMenu
            // 
            this.button_chatMenu.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_chatMenu.FlatAppearance.BorderSize = 0;
            this.button_chatMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_chatMenu.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_chatMenu.Image = ((System.Drawing.Image)(resources.GetObject("button_chatMenu.Image")));
            this.button_chatMenu.Location = new System.Drawing.Point(39, 0);
            this.button_chatMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_chatMenu.Name = "button_chatMenu";
            this.button_chatMenu.Size = new System.Drawing.Size(67, 54);
            this.button_chatMenu.TabIndex = 0;
            this.button_chatMenu.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.button_chatMenu.UseVisualStyleBackColor = true;
            this.button_chatMenu.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(-1, 61);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(111, 33);
            this.button8.TabIndex = 1;
            this.button8.Text = "Leave Group";
            this.button8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(381, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(632, 54);
            this.panel3.TabIndex = 9;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 28);
            this.label1.TabIndex = 10;
            this.label1.Text = "Example";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(380, 695);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 61);
            this.button2.TabIndex = 12;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.AutoScroll = true;
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.panel4.Controls.Add(this.chatLabelForm1);
            this.panel4.Location = new System.Drawing.Point(381, 62);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(632, 626);
            this.panel4.TabIndex = 13;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // chatLabelForm1
            // 
            this.chatLabelForm1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatLabelForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.chatLabelForm1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.chatLabelForm1.Location = new System.Drawing.Point(16, 16);
            this.chatLabelForm1.Name = "chatLabelForm1";
            this.chatLabelForm1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chatLabelForm1.Size = new System.Drawing.Size(371, 94);
            this.chatLabelForm1.TabIndex = 0;
            this.chatLabelForm1.Load += new System.EventHandler(this.chatLabelForm1_Load_1);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 61);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(374, 695);
            this.flowLayoutPanel1.TabIndex = 14;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.profile);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button_SignOut);
            this.panel1.Controls.Add(this.button_createGroup);
            this.panel1.Controls.Add(this.button_changpass);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 247);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // profile
            // 
            this.profile.FlatAppearance.BorderSize = 0;
            this.profile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profile.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.profile.ForeColor = System.Drawing.Color.White;
            this.profile.Location = new System.Drawing.Point(-1, 147);
            this.profile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.profile.Name = "profile";
            this.profile.Size = new System.Drawing.Size(374, 49);
            this.profile.TabIndex = 7;
            this.profile.Text = "Profile";
            this.profile.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.profile.UseVisualStyleBackColor = true;
            this.profile.Click += new System.EventHandler(this.profile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(294, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Example";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(0, -1);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 54);
            this.button1.TabIndex = 0;
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_SignOut
            // 
            this.button_SignOut.FlatAppearance.BorderSize = 0;
            this.button_SignOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_SignOut.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_SignOut.ForeColor = System.Drawing.Color.White;
            this.button_SignOut.Location = new System.Drawing.Point(0, 191);
            this.button_SignOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_SignOut.Name = "button_SignOut";
            this.button_SignOut.Size = new System.Drawing.Size(374, 43);
            this.button_SignOut.TabIndex = 5;
            this.button_SignOut.Text = "Sign out";
            this.button_SignOut.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button_SignOut.UseVisualStyleBackColor = true;
            this.button_SignOut.Click += new System.EventHandler(this.button5_Click);
            // 
            // button_createGroup
            // 
            this.button_createGroup.FlatAppearance.BorderSize = 0;
            this.button_createGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_createGroup.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_createGroup.ForeColor = System.Drawing.Color.White;
            this.button_createGroup.Location = new System.Drawing.Point(1, 105);
            this.button_createGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_createGroup.Name = "button_createGroup";
            this.button_createGroup.Size = new System.Drawing.Size(374, 49);
            this.button_createGroup.TabIndex = 4;
            this.button_createGroup.Text = "Create Group";
            this.button_createGroup.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button_createGroup.UseVisualStyleBackColor = true;
            this.button_createGroup.Click += new System.EventHandler(this.button4_Click);
            // 
            // button_changpass
            // 
            this.button_changpass.FlatAppearance.BorderSize = 0;
            this.button_changpass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_changpass.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_changpass.ForeColor = System.Drawing.Color.White;
            this.button_changpass.Location = new System.Drawing.Point(0, 61);
            this.button_changpass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_changpass.Name = "button_changpass";
            this.button_changpass.Size = new System.Drawing.Size(374, 47);
            this.button_changpass.TabIndex = 3;
            this.button_changpass.Text = "Change password";
            this.button_changpass.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button_changpass.UseVisualStyleBackColor = true;
            this.button_changpass.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(47)))), ((int)(((byte)(61)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(73, 13);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(266, 27);
            this.textBox1.TabIndex = 1;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(1022, 755);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel4);
            this.MaximumSize = new System.Drawing.Size(1040, 802);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainView_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainView_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }          #endregion         private System.Windows.Forms.TextBox textBox2;         private System.Windows.Forms.Button button6;         private System.Windows.Forms.Panel panel2;         private System.Windows.Forms.Button button8;         private System.Windows.Forms.Button button_chatMenu;         private System.Windows.Forms.Panel panel3;         private System.Windows.Forms.Label label1;         private System.Windows.Forms.Button button2;         private System.Windows.Forms.Panel panel4;         private View.ChatLabelForm chatLabelForm1;         private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;         private System.Windows.Forms.Panel panel1;         private System.Windows.Forms.Label label2;         private System.Windows.Forms.Button button1;         private System.Windows.Forms.Button button_SignOut;         private System.Windows.Forms.Button button_createGroup;         private System.Windows.Forms.Button button_changpass;         private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button profile;
    } }  