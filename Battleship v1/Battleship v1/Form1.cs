using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship_v1
{
    public partial class Form1 : Form
    {
        Grid user = new Grid();
        Grid comp = new Grid();
        List<String> fields = new List<String>();
        List<String> hitfields = new List<String>();
        List<String> destroyed = new List<String>();
        int userCounter = 0;
        int compCounter = 0;
        int timer = 0;
        bool finished;
        bool exited = false;
        public Form1()
        {
            bool close = false;
            bool save = false;
            Home form = new Home();
            if (form.ShowDialog() == DialogResult.OK){}
            else
            {
                close = true;
            }
            if (!close)
            {
                comp = new Grid(user.getM());
                StartPosition = FormStartPosition.CenterScreen;
                InitializeComponent();
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        fields.Add(i + "" + j);
                    }
                }
                Username popup = new Username();
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    username.Text = popup.getUsername();
                    if (popup.getSave())
                    {
                        save = true;
                    }
                }
                if (save)
                {
                    File.AppendAllText("..\\..\\Resources\\username\\pending.txt", username.Text);
                }
                SelectShips shipForm = new SelectShips();
                if (shipForm.ShowDialog() == DialogResult.OK)
                {
                    user = shipForm.getUser();
                }
                computer.Text = "Computer";
                finished = false;
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (user.get(i, j) != 0)
                        {
                            Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\o.jpg");
                        }
                    }
                }
                turnBox.Text = username.Text + "'s turn";
                timer1.Start();
            }
            else
            {
                this.Shown += new EventHandler(MyForm_CloseOnStart);
            }
        }
        private void MyForm_CloseOnStart(object sender, EventArgs e)
        {
            this.Close();
        }
        private void comGridField_Hit(object sender, EventArgs e)
        {
            if(!finished)
            {
                int i, j;
                var button = (Button)sender;
                string name = button.Name.Substring(1);
                i = Convert.ToInt16(name) / 10;
                j = Convert.ToInt16(name) % 10;
                if (comp.get(i, j) == 0)
                {
                    button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\x.jpg");
                    button.Enabled = false;
                    turnBox.ResetText();
                    turnBox.AppendText("Computer's turn");
                    System.Threading.Thread.Sleep(700);
                    comHit();
                }
                else
                {
                    button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\texture.jpg");
                    button.Enabled = false;
                    userCounter++;
                    if (userCounter == 14)
                    {
                        timer1.Stop();
                        MessageBox.Show("You won, " + username.Text + "! Congratulations! The game was played " + timerBox.Text);
                        finished = true;
                        turnBox.ResetText();
                        turnBox.AppendText(username.Text + " won!");
                      }
                }
            }

        }
        private void userGridField_Hit(object sender, EventArgs e)
        {
            if (!finished)
            {
                int i, j;
                var button = (Button)sender;
                string name = button.Name.Substring(1);
                i = Convert.ToInt16(name) / 10;
                j = Convert.ToInt16(name) % 10;
                if (user.get(i, j) == 0)
                {
                    button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\x.jpg");
                    button.Enabled = false;
                    turnBox.Text = username.Text + "'s turn";
                }
                else
                {
                    destroyed.Add(i + "" + j);
                    button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\texture.jpg");
                    button.Enabled = false;
                    compCounter++;
                    if (compCounter == 14)
                    {
                        timer1.Stop();
                        MessageBox.Show("The computer won... Sorry. The game was played " + timerBox.Text);
                        finished = true;
                        turnBox.ResetText();
                        turnBox.AppendText("Computer won.");
                    }
                    removeImpossible();
                    if (validHit(i - 1, j) && fields.Contains((i - 1) + "" + j)) hitfields.Add((i - 1) + "" + j);
                    if (validHit(i, j - 1) && fields.Contains(i + "" + (j - 1))) hitfields.Add(i + "" + (j - 1));
                    if (validHit(i + 1, j) && fields.Contains((i + 1) + "" + j)) hitfields.Add((i + 1) + "" + j);
                    if (validHit(i, j + 1) && fields.Contains(i + "" + (j + 1))) hitfields.Add(i + "" + (j + 1));
                    System.Threading.Thread.Sleep(700);
                    comHit();
                }
            }
        }
        private void comHit()
        {
            if(!finished)
            {
                Random rand = new Random();
                if (hitfields.Count == 0)
                {
                    int i = rand.Next(0, fields.Count);
                    Button button = (Button)this.Controls.Find("u" + fields.ElementAt(i), true).FirstOrDefault();
                    fields.RemoveAt(i);
                    button.Enabled = true;
                    button.PerformClick();
                }
                else
                {
                    int i = rand.Next(0, hitfields.Count);
                    Button button = (Button)this.Controls.Find("u" + hitfields.ElementAt(i), true).FirstOrDefault();
                    fields.Remove(hitfields.ElementAt(i));
                    hitfields.RemoveAt(i);
                    button.Enabled = true;
                    button.PerformClick();
                }
            }
        }
        private bool validHit(int a, int b)
        {
            if (a < 1 || a > 8) return false;
            else if (b < 1 || b > 8) return false;
            else return true;
        }
        private void removeImpossible()
        {
            string s;
            int i, j;
            for(int k=0; k<fields.Count; k++)
            {
                s = fields.ElementAt(k);
                i = Convert.ToInt16(s) / 10;
                j = Convert.ToInt16(s) % 10;
                if(!fields.Contains((i+1) + "" + j) && !fields.Contains(i + "" + (j+1)) && !fields.Contains((i - 1) + "" + j) && !fields.Contains(i + "" + (j - 1))
                   && !destroyed.Contains((i + 1) + "" + j) && !destroyed.Contains(i + "" + (j + 1)) && !destroyed.Contains((i - 1) + "" + j) && !destroyed.Contains(i + "" + (j - 1))
                    )
                {
                    fields.Remove(i + "" + j);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer++;
            timerBox.Text = String.Format("{0:00}", timer / 60) + ":" + String.Format("{0:00}", timer % 60);
        }
    }
}
