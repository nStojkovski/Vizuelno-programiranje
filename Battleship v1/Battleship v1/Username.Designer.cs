namespace Battleship_v1
{
    partial class Username
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
            this.label1 = new System.Windows.Forms.Label();
            this.usernameTB = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.saveUsername = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter your username:";
            // 
            // usernameTB
            // 
            this.usernameTB.Location = new System.Drawing.Point(24, 48);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(342, 20);
            this.usernameTB.TabIndex = 1;
            this.usernameTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usernameTB_KeyDown);
            this.usernameTB.Validating += new System.ComponentModel.CancelEventHandler(this.usernameTB_Validating);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(291, 119);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 2;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // saveUsername
            // 
            this.saveUsername.AutoSize = true;
            this.saveUsername.Location = new System.Drawing.Point(25, 74);
            this.saveUsername.Name = "saveUsername";
            this.saveUsername.Size = new System.Drawing.Size(126, 17);
            this.saveUsername.TabIndex = 3;
            this.saveUsername.Text = "Remember username";
            this.saveUsername.UseVisualStyleBackColor = true;
            // 
            // Username
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 154);
            this.Controls.Add(this.saveUsername);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.usernameTB);
            this.Controls.Add(this.label1);
            this.Name = "Username";
            this.Text = "Username";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usernameTB;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.CheckBox saveUsername;
    }
}