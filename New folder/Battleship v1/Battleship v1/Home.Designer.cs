namespace Battleship_v1
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.label1 = new System.Windows.Forms.Label();
            this.PlayButton = new System.Windows.Forms.Button();
            this.HelpButton1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.loadGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Magneto", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(186, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "BATTLESHIP";
            // 
            // PlayButton
            // 
            this.PlayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlayButton.Location = new System.Drawing.Point(12, 419);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(213, 73);
            this.PlayButton.TabIndex = 1;
            this.PlayButton.Text = "Нова игра";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // HelpButton1
            // 
            this.HelpButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HelpButton1.Location = new System.Drawing.Point(482, 419);
            this.HelpButton1.Name = "HelpButton1";
            this.HelpButton1.Size = new System.Drawing.Size(213, 73);
            this.HelpButton1.TabIndex = 2;
            this.HelpButton1.Text = "Помош";
            this.HelpButton1.UseVisualStyleBackColor = true;
            this.HelpButton1.Click += new System.EventHandler(this.HelpButton1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(249, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "© Никола² ®™ 2016";
            // 
            // loadGame
            // 
            this.loadGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadGame.Location = new System.Drawing.Point(248, 419);
            this.loadGame.Name = "loadGame";
            this.loadGame.Size = new System.Drawing.Size(213, 73);
            this.loadGame.TabIndex = 7;
            this.loadGame.Text = "Зачувана игра";
            this.loadGame.UseVisualStyleBackColor = true;
            this.loadGame.Click += new System.EventHandler(this.loadGame_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Battleship_v1.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(707, 504);
            this.Controls.Add(this.loadGame);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HelpButton1);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(723, 542);
            this.MinimumSize = new System.Drawing.Size(723, 542);
            this.Name = "Home";
            this.Text = "Дома";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button HelpButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button loadGame;
    }
}