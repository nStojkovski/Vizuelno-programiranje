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
            this.label1 = new System.Windows.Forms.Label();
            this.PlayButton = new System.Windows.Forms.Button();
            this.HelpButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rbeasy = new System.Windows.Forms.RadioButton();
            this.rbmedium = new System.Windows.Forms.RadioButton();
            this.rbhard = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Magneto", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(188, 26);
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
            this.PlayButton.Size = new System.Drawing.Size(239, 73);
            this.PlayButton.TabIndex = 1;
            this.PlayButton.Text = "Играј";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // HelpButton
            // 
            this.HelpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HelpButton.Location = new System.Drawing.Point(456, 419);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(239, 73);
            this.HelpButton.TabIndex = 2;
            this.HelpButton.Text = "Помош";
            this.HelpButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(277, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "© Никола² ®™";
            // 
            // rbeasy
            // 
            this.rbeasy.AutoSize = true;
            this.rbeasy.BackColor = System.Drawing.Color.Transparent;
            this.rbeasy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbeasy.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.rbeasy.Location = new System.Drawing.Point(12, 396);
            this.rbeasy.Name = "rbeasy";
            this.rbeasy.Size = new System.Drawing.Size(71, 20);
            this.rbeasy.TabIndex = 4;
            this.rbeasy.TabStop = true;
            this.rbeasy.Text = "Лесно";
            this.rbeasy.UseVisualStyleBackColor = false;
            // 
            // rbmedium
            // 
            this.rbmedium.AutoSize = true;
            this.rbmedium.BackColor = System.Drawing.Color.Transparent;
            this.rbmedium.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbmedium.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.rbmedium.Location = new System.Drawing.Point(89, 396);
            this.rbmedium.Name = "rbmedium";
            this.rbmedium.Size = new System.Drawing.Size(81, 20);
            this.rbmedium.TabIndex = 5;
            this.rbmedium.TabStop = true;
            this.rbmedium.Text = "Средно";
            this.rbmedium.UseVisualStyleBackColor = false;
            // 
            // rbhard
            // 
            this.rbhard.AutoSize = true;
            this.rbhard.BackColor = System.Drawing.Color.Transparent;
            this.rbhard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbhard.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.rbhard.Location = new System.Drawing.Point(179, 396);
            this.rbhard.Name = "rbhard";
            this.rbhard.Size = new System.Drawing.Size(72, 20);
            this.rbhard.TabIndex = 6;
            this.rbhard.TabStop = true;
            this.rbhard.Text = "Тешко";
            this.rbhard.UseVisualStyleBackColor = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Battleship_v1.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(707, 504);
            this.Controls.Add(this.rbhard);
            this.Controls.Add(this.rbmedium);
            this.Controls.Add(this.rbeasy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(723, 542);
            this.MinimumSize = new System.Drawing.Size(723, 542);
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbeasy;
        private System.Windows.Forms.RadioButton rbmedium;
        private System.Windows.Forms.RadioButton rbhard;
    }
}