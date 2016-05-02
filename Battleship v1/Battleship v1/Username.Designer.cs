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
            this.usernameTB = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.saveUsername = new System.Windows.Forms.CheckBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.rbVnesi = new System.Windows.Forms.RadioButton();
            this.rbIzberi = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // usernameTB
            // 
            this.usernameTB.Location = new System.Drawing.Point(24, 48);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(176, 20);
            this.usernameTB.TabIndex = 1;
            this.usernameTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usernameTB_KeyDown);
            this.usernameTB.Validating += new System.ComponentModel.CancelEventHandler(this.usernameTB_Validating);
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(139, 144);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(126, 23);
            this.OK.TabIndex = 2;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // saveUsername
            // 
            this.saveUsername.AutoSize = true;
            this.saveUsername.Location = new System.Drawing.Point(24, 74);
            this.saveUsername.Name = "saveUsername";
            this.saveUsername.Size = new System.Drawing.Size(71, 17);
            this.saveUsername.TabIndex = 3;
            this.saveUsername.Text = "Запомни";
            this.saveUsername.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.CausesValidation = false;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(232, 48);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(197, 82);
            this.listBox1.TabIndex = 4;
            // 
            // rbVnesi
            // 
            this.rbVnesi.AutoSize = true;
            this.rbVnesi.CausesValidation = false;
            this.rbVnesi.Location = new System.Drawing.Point(24, 25);
            this.rbVnesi.Name = "rbVnesi";
            this.rbVnesi.Size = new System.Drawing.Size(144, 17);
            this.rbVnesi.TabIndex = 6;
            this.rbVnesi.TabStop = true;
            this.rbVnesi.Text = "Внеси корисничко име:";
            this.rbVnesi.UseVisualStyleBackColor = true;
            this.rbVnesi.CheckedChanged += new System.EventHandler(this.rbVnesi_CheckedChanged);
            // 
            // rbIzberi
            // 
            this.rbIzberi.AutoSize = true;
            this.rbIzberi.CausesValidation = false;
            this.rbIzberi.Location = new System.Drawing.Point(232, 25);
            this.rbIzberi.Name = "rbIzberi";
            this.rbIzberi.Size = new System.Drawing.Size(206, 17);
            this.rbIzberi.TabIndex = 7;
            this.rbIzberi.TabStop = true;
            this.rbIzberi.Text = "Избери постоечко корисничко име:";
            this.rbIzberi.UseVisualStyleBackColor = true;
            this.rbIzberi.CheckedChanged += new System.EventHandler(this.rbIzberi_CheckedChanged);
            // 
            // Username
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 177);
            this.Controls.Add(this.rbIzberi);
            this.Controls.Add(this.rbVnesi);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.saveUsername);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.usernameTB);
            this.Name = "Username";
            this.Text = "Username";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox usernameTB;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.CheckBox saveUsername;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.RadioButton rbVnesi;
        private System.Windows.Forms.RadioButton rbIzberi;
    }
}