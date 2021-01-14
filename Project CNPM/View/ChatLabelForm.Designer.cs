
namespace Project_CNPM.View
{
    partial class ChatLabelForm
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
            this.usernameView = new System.Windows.Forms.Label();
            this.msgView = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usernameView
            // 
            this.usernameView.AutoSize = true;
            this.usernameView.Location = new System.Drawing.Point(16, 13);
            this.usernameView.Name = "usernameView";
            this.usernameView.Size = new System.Drawing.Size(73, 20);
            this.usernameView.TabIndex = 0;
            this.usernameView.Text = "username";
            this.usernameView.Click += new System.EventHandler(this.label1_Click);
            // 
            // msgView
            // 
            this.msgView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msgView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.msgView.Location = new System.Drawing.Point(16, 33);
            this.msgView.Name = "msgView";
            this.msgView.Size = new System.Drawing.Size(609, 85);
            this.msgView.TabIndex = 1;
            this.msgView.Text = "msg";
            this.msgView.Resize += new System.EventHandler(this.msgView_Resize);
            // 
            // ChatLabelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.Controls.Add(this.msgView);
            this.Controls.Add(this.usernameView);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ChatLabelForm";
            this.Size = new System.Drawing.Size(643, 127);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameView;
        private System.Windows.Forms.Label msgView;
    }
}
