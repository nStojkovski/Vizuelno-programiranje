using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Battleship_v1
{
    public partial class Form1 : Form
    {
        Grid user = new Grid();
        Grid comp = new Grid();
        List<String> fields = new List<String>();
        List<String> hitfields = new List<String>();
        List<String> medhitfields = new List<String>();
        List<String> hit = new List<String>();
        List<String> destroyed = new List<String>();
        List<String> comfields = new List<String>();
        int userCounter = 0;
        int compCounter = 0;
        int hardCounter = 0;
        int hardness;
        int timer = 0;
        bool finished;
        bool turn = true;
        bool newgame;
        public Form1()
        {
            bool close = false;
            bool save = false;
            Home form = new Home();
            SoundPlayer ofortuna = new SoundPlayer(@"..\..\Resources\sounds\ofortuna.wav");
            ofortuna.PlayLooping();
            if (form.ShowDialog() == DialogResult.OK)
            {
                newgame = form.getNewGame();
            }
            else
            {
                close = true;
            }
            if (!close)
            {
                if (newgame)
                {
                    StartPosition = FormStartPosition.CenterScreen;
                    InitializeComponent();
                    comp = new Grid(user.getM());
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
                        hardness = shipForm.getHardness();
                    }
                    ofortuna.Stop();
                    computer.Text = "Компјутер";
                    finished = false;
                    RefreshGrid();
                    turnBox.Text = username.Text + " е на ред.";
                    timer1.Start();
                    //this.BackgroundImage = System.Drawing.Image.FromFile(@"..\..\Resources\main-background.jpg");
                }
                else
                {
                    ofortuna.Stop();
                    StartPosition = FormStartPosition.CenterScreen;
                    InitializeComponent();
                    comp = new Grid("compgrid");
                    user = new Grid("usergrid");
                    string line;
                    var file = new System.IO.StreamReader("..\\..\\Resources\\saved-game\\fields.txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        fields.Add(line);
                    }
                    file.Close();
                    file = new System.IO.StreamReader("..\\..\\Resources\\saved-game\\hitfields.txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        hitfields.Add(line);
                    }
                    file.Close();
                    file = new System.IO.StreamReader("..\\..\\Resources\\saved-game\\hit.txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        hit.Add(line);
                    }
                    file.Close();
                    file = new System.IO.StreamReader("..\\..\\Resources\\saved-game\\destroyed.txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        destroyed.Add(line);
                    }
                    file.Close();
                    file = new System.IO.StreamReader("..\\..\\Resources\\saved-game\\medhitfields.txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        medhitfields.Add(line);
                    }
                    file.Close();
                    file = new System.IO.StreamReader("..\\..\\Resources\\saved-game\\comfields.txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        comfields.Add(line);
                    }
                    file.Close();
                    file = new System.IO.StreamReader("..\\..\\Resources\\saved-game\\info.txt");
                    username.Text = file.ReadLine();
                    timer = Convert.ToInt32(file.ReadLine());
                    hardness = Convert.ToInt32(file.ReadLine());
                    userCounter = Convert.ToInt32(file.ReadLine());
                    compCounter = Convert.ToInt32(file.ReadLine());
                    file.Close();
                    computer.Text = "Компјутер";
                    finished = false;
                    RefreshGrid();
                    for (int n = 0; n < comfields.Count; n++)
                    {
                        int i = Convert.ToInt32(comfields.ElementAt(n)) / 10;
                        int j = Convert.ToInt32(comfields.ElementAt(n)) % 10;
                        Button button = (Button)this.Controls.Find("c" + i + "" + j, true).FirstOrDefault();
                        if (comp.get(i, j) == 0)
                        {
                            button.Enabled = false;
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\x.jpg");
                        }
                        else
                        {
                            button.Enabled = false;
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\smoke.png");
                        }
                    }
                    turnBox.Text = username.Text + " е на ред.";
                    timer1.Start();
                    //this.BackgroundImage = System.Drawing.Image.FromFile(@"..\..\Resources\main-background.jpg");
                }
            }
            else
            {
                this.Shown += new EventHandler(MyForm_CloseOnStart);
            }
        }
        void RefreshGrid()
        {
            bool found = false;
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (user.get(i, j) == 5)
                    {
                        if (user.get(i, j + 1) == 5)
                        {
                            Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\ac1.png");
                            button = (Button)this.Controls.Find("u" + i + "" + (j + 1), true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\ac2.png");
                            button = (Button)this.Controls.Find("u" + i + "" + (j + 2), true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\ac3.png");
                            button = (Button)this.Controls.Find("u" + i + "" + (j + 3), true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\ac4.png");
                            button = (Button)this.Controls.Find("u" + i + "" + (j + 4), true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\ac5.png");
                            found = true;
                            break;
                        }
                        else
                        {
                            Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\ac1v.png");
                            button = (Button)this.Controls.Find("u" + (i + 1) + "" + j, true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\ac2v.png");
                            button = (Button)this.Controls.Find("u" + (i + 2) + "" + j, true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\ac3v.png");
                            button = (Button)this.Controls.Find("u" + (i + 3) + "" + j, true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\ac4v.png");
                            button = (Button)this.Controls.Find("u" + (i + 4) + "" + j, true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\ac5v.png");
                            found = true;
                            break;
                        }
                    }
                }
                if (found) break;
            }
            found = false;
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (user.get(i, j) == 4)
                    {
                        if (user.get(i, j + 1) == 4)
                        {
                            Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\bs1.png");
                            button = (Button)this.Controls.Find("u" + i + "" + (j + 1), true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\bs2.png");
                            button = (Button)this.Controls.Find("u" + i + "" + (j + 2), true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\bs3.png");
                            button = (Button)this.Controls.Find("u" + i + "" + (j + 3), true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\bs4.png");
                            found = true;
                            break;
                        }
                        else
                        {
                            Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\bs1v.png");
                            button = (Button)this.Controls.Find("u" + (i + 1) + "" + j, true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\bs2v.png");
                            button = (Button)this.Controls.Find("u" + (i + 2) + "" + j, true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\bs3v.png");
                            button = (Button)this.Controls.Find("u" + (i + 3) + "" + j, true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\bs4v.png");
                            found = true;
                            break;
                        }
                    }
                }
                if (found) break;
            }
            found = false;
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (user.get(i, j) == 3)
                    {
                        if (user.get(i, j + 1) == 3)
                        {
                            Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\sub1.png");
                            button = (Button)this.Controls.Find("u" + i + "" + (j + 1), true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\sub2.png");
                            button = (Button)this.Controls.Find("u" + i + "" + (j + 2), true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\sub3.png");
                            found = true;
                            break;
                        }
                        else
                        {
                            Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\sub1v.png");
                            button = (Button)this.Controls.Find("u" + (i + 1) + "" + j, true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\sub2v.png");
                            button = (Button)this.Controls.Find("u" + (i + 2) + "" + j, true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\sub3v.png");
                            found = true;
                            break;
                        }
                    }
                }
                if (found) break;
            }
            found = false;
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (user.get(i, j) == 2)
                    {
                        if (user.get(i, j + 1) == 2)
                        {
                            Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\d1.png");
                            button = (Button)this.Controls.Find("u" + i + "" + (j + 1), true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\d2.png");
                            found = true;
                            break;
                        }
                        else
                        {
                            Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\d1v.png");
                            button = (Button)this.Controls.Find("u" + (i + 1) + "" + j, true).FirstOrDefault();
                            button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\ships\d2v.png");
                            found = true;
                            break;
                        }
                    }
                }
                if (found) break;
            }
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (user.get(i, j) == 0)
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Image = null;
                    }
                }
            }

        }
        private void MyForm_CloseOnStart(object sender, EventArgs e)
        {
            this.Close();
        }
        private void WaitMSeconds(int mseconds)
        {
            DateTime newTime = DateTime.Now.AddMilliseconds(mseconds);
            while (DateTime.Now < newTime)
            {
                Application.DoEvents();
            }
        }
        private void playTurnSound()
        {
            SoundPlayer userturn = new SoundPlayer(@"..\..\Resources\sounds\userturn.wav");
            userturn.Play();
        }
        private void playExpSound()
        {
            SoundPlayer explosion = new SoundPlayer(@"..\..\Resources\sounds\explosion.wav");
            explosion.Play();
        }
        private void playSplSound()
        {
            SoundPlayer splash = new SoundPlayer(@"..\..\Resources\sounds\splash.wav");
            splash.Play();
        }
        private void playWinSound()
        {
            SoundPlayer win = new SoundPlayer(@"..\..\Resources\sounds\win.wav");
            win.Play();
        }
        private void playLoseSound()
        {
            SoundPlayer lose = new SoundPlayer(@"..\..\Resources\sounds\lose.wav");
            lose.Play();
        }
        private void comGridField_Hit(object sender, EventArgs e)
        {
            if (!finished && turn)
            {
                int i, j;
                var button = (Button)sender;
                string name = button.Name.Substring(1);
                i = Convert.ToInt16(name) / 10;
                j = Convert.ToInt16(name) % 10;
                comfields.Add(i + "" + j);
                if (comp.get(i, j) == 0)
                {
                    timer2.Stop();
                    button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\splash.gif");
                    playSplSound();
                    WaitMSeconds(350);
                    timer2.Start();
                    button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\x.jpg");
                    button.Enabled = false;
                    turnBox.ResetText();
                    turnBox.AppendText("Компјутер е на ред.");
                    System.Threading.Thread.Sleep(700);
                    resetButton.Enabled = false;
                    saveButton.Enabled = false;
                    if (hardCounter == 4) comHit(getFirstFullField());
                    else comHit();
                }
                else
                {
                    timer2.Stop();
                    button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\exp.gif");
                    playExpSound();
                    WaitMSeconds(400);
                    timer2.Start();
                    button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\smoke.png");
                    button.Enabled = false;
                    userCounter++;
                    if (userCounter == 14)
                    {
                        timer1.Stop();
                        playWinSound();
                        MessageBox.Show("Победи, " + username.Text + "! Честитки! Играта траеше " + timerBox.Text);
                        finished = true;
                        turnBox.ResetText();
                        turnBox.AppendText(username.Text + " won!");
                        saveButton.Enabled = false;
                        AppearHighscores(true);
                    }
                }
            }

        }
        private void userGridField_Hit(object sender, EventArgs e)
        {
            if (hardness == 0)
            {
                if (!finished)
                {
                    turn = false;
                    int i, j;
                    var button = (Button)sender;
                    string name = button.Name.Substring(1);
                    i = Convert.ToInt16(name) / 10;
                    j = Convert.ToInt16(name) % 10;
                    if (user.get(i, j) == 0)
                    {
                        timer2.Stop();
                        button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\splash.gif");
                        playSplSound();
                        WaitMSeconds(400);
                        timer2.Start();
                        button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\x.jpg");
                        button.Enabled = false;
                        turnBox.Text = username.Text + " е на ред.";
                        Thread.Sleep(400);
                        playTurnSound();
                        turn = true;
                        resetButton.Enabled = true;
                        saveButton.Enabled = true;
                    }
                    else
                    {
                        timer2.Stop();
                        destroyed.Add(i + "" + j);
                        button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\exp.gif");
                        playExpSound();
                        WaitMSeconds(350);
                        timer2.Start();
                        button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\smoke.png");
                        button.Enabled = false;
                        compCounter++;
                        if (compCounter == 14)
                        {
                            timer1.Stop();
                            playLoseSound();
                            MessageBox.Show("Компјутерот победи... Жал ни е. Играта траеше " + timerBox.Text);
                            finished = true;
                            turnBox.ResetText();
                            turnBox.AppendText("Компјутерот победи.");
                            resetButton.Enabled = true;
                            saveButton.Enabled = false;
                            AppearHighscores(false);
                        }
                        removeImpossible();
                        if (validHit(i - 1, j) && fields.Contains((i - 1) + "" + j) && !hitfields.Contains((i - 1) + "" + j)) hitfields.Add((i - 1) + "" + j);
                        if (validHit(i, j - 1) && fields.Contains(i + "" + (j - 1)) && !hitfields.Contains(i + "" + (j - 1))) hitfields.Add(i + "" + (j - 1));
                        if (validHit(i + 1, j) && fields.Contains((i + 1) + "" + j) && !hitfields.Contains((i + 1) + "" + j)) hitfields.Add((i + 1) + "" + j);
                        if (validHit(i, j + 1) && fields.Contains(i + "" + (j + 1)) && !hitfields.Contains(i + "" + (j + 1))) hitfields.Add(i + "" + (j + 1));
                        System.Threading.Thread.Sleep(700);
                        comHit();
                    }
                }
            }
            else if (hardness == 1)
            {
                if (!finished)
                {
                    turn = false;
                    int i, j;
                    var button = (Button)sender;
                    string name = button.Name.Substring(1);
                    i = Convert.ToInt16(name) / 10;
                    j = Convert.ToInt16(name) % 10;
                    if (user.get(i, j) == 0)
                    {
                        timer2.Stop();
                        hit.Add(i + "" + j);
                        button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\splash.gif");
                        playSplSound();
                        WaitMSeconds(400);
                        timer2.Start();
                        button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\x.jpg");
                        button.Enabled = false;
                        turnBox.Text = username.Text + " е на ред.";
                        Thread.Sleep(400);
                        playTurnSound();
                        turn = true;
                        resetButton.Enabled = true;
                        saveButton.Enabled = true;
                    }
                    else
                    {
                        timer2.Stop();
                        hit.Add(i + "" + j);
                        destroyed.Add(i + "" + j);
                        button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\exp.gif");
                        playExpSound();
                        WaitMSeconds(350);
                        timer2.Start();
                        button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\smoke.png");
                        button.Enabled = false;
                        compCounter++;
                        if (compCounter == 14)
                        {
                            timer1.Stop();
                            playLoseSound();
                            MessageBox.Show("Компјутерот победи... Жал ни е. Играта траеше " + timerBox.Text);
                            finished = true;
                            turnBox.ResetText();
                            turnBox.AppendText("Компјутерот победи.");
                            resetButton.Enabled = true;
                            saveButton.Enabled = false;
                            AppearHighscores(false);
                        }
                        removeImpossible();
                        bool destroyedNeighbour = false;
                        if (destroyed.Contains((i - 1) + "" + j) && validHit(i + 1, j))
                        {
                            //hitfields.Clear();
                            if (!hit.Contains((i + 1) + "" + j))
                            {
                                medhitfields.Add((i + 1) + "" + j);
                                destroyedNeighbour = true;
                            }
                            if (validHit(i - 2, j) && !hit.Contains((i - 2) + "" + j)) medhitfields.Add((i - 2) + "" + j);
                        }
                        if (destroyed.Contains(i + "" + (j - 1)) && validHit(i, j + 1))
                        {
                            //hitfields.Clear();
                            if (!hit.Contains(i + "" + (j + 1)))
                            {
                                medhitfields.Add(i + "" + (j + 1));
                                destroyedNeighbour = true;
                            }
                            if (validHit(i, j - 2) && !hit.Contains(i + "" + (j - 2))) medhitfields.Add(i + "" + (j - 2));
                        }
                        if (destroyed.Contains((i + 1) + "" + j) && validHit(i - 1, j))
                        {
                            //hitfields.Clear();
                            if (!hit.Contains((i - 1) + "" + j))
                            {
                                medhitfields.Add((i - 1) + "" + j);
                                destroyedNeighbour = true;
                            }
                            if (validHit(i + 2, j) && !hit.Contains((i + 2) + "" + j)) medhitfields.Add((i + 2) + "" + j);
                        }
                        if (destroyed.Contains(i + "" + (j + 1)) && validHit(i, j - 1))
                        {
                            //hitfields.Clear();
                            if (!hit.Contains(i + "" + (j - 1)))
                            {
                                medhitfields.Add(i + "" + (j - 1));
                                destroyedNeighbour = true;
                            }
                            if (validHit(i, j + 2) && !hit.Contains(i + "" + (j + 2))) medhitfields.Add(i + "" + (j + 2));
                        }
                        if (!destroyedNeighbour)
                        {
                            if (validHit(i - 1, j) && fields.Contains((i - 1) + "" + j) && !hitfields.Contains((i - 1) + "" + j)) hitfields.Add((i - 1) + "" + j);
                            if (validHit(i, j - 1) && fields.Contains(i + "" + (j - 1)) && !hitfields.Contains(i + "" + (j - 1))) hitfields.Add(i + "" + (j - 1));
                            if (validHit(i + 1, j) && fields.Contains((i + 1) + "" + j) && !hitfields.Contains((i + 1) + "" + j)) hitfields.Add((i + 1) + "" + j);
                            if (validHit(i, j + 1) && fields.Contains(i + "" + (j + 1)) && !hitfields.Contains(i + "" + (j + 1))) hitfields.Add(i + "" + (j + 1));
                        }
                        else
                        {
                            hitfields.Clear();
                        }
                        System.Threading.Thread.Sleep(700);
                        comHit();
                    }
                }
            }
            else
            {
                if (!finished)
                {
                    turn = false;
                    int i, j;
                    var button = (Button)sender;
                    string name = button.Name.Substring(1);
                    i = Convert.ToInt16(name) / 10;
                    j = Convert.ToInt16(name) % 10;
                    if (user.get(i, j) == 0)
                    {
                        timer2.Stop();
                        hardCounter++;
                        hit.Add(i + "" + j);
                        button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\splash.gif");
                        playSplSound();
                        WaitMSeconds(400);
                        timer2.Start();
                        button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\x.jpg");
                        button.Enabled = false;
                        turnBox.Text = username.Text + " е на ред.";
                        Thread.Sleep(400);
                        playTurnSound();
                        turn = true;
                        resetButton.Enabled = true;
                        saveButton.Enabled = true;
                    }
                    else
                    {
                        timer2.Stop();
                        hardCounter = 0;
                        hit.Add(i + "" + j);
                        destroyed.Add(i + "" + j);
                        button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\exp.gif");
                        playExpSound();
                        WaitMSeconds(350);
                        timer2.Start();
                        button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\smoke.png");
                        button.Enabled = false;
                        compCounter++;
                        if (compCounter == 14)
                        {
                            timer1.Stop();
                            playLoseSound();
                            MessageBox.Show("Компјутерот победи... Жал ни е. Играта траеше " + timerBox.Text);
                            finished = true;
                            turnBox.ResetText();
                            turnBox.AppendText("Компјутерот победи.");
                            resetButton.Enabled = true;
                            saveButton.Enabled = false;
                            AppearHighscores(false);
                        }
                        removeImpossible();
                        bool destroyedNeighbour = false;
                        if (destroyed.Contains((i - 1) + "" + j) && validHit(i + 1, j))
                        {
                            //hitfields.Clear();
                            if (!hit.Contains((i + 1) + "" + j))
                            {
                                medhitfields.Add((i + 1) + "" + j);
                                destroyedNeighbour = true;
                            }
                            if (validHit(i - 2, j) && !hit.Contains((i - 2) + "" + j)) medhitfields.Add((i - 2) + "" + j);
                        }
                        if (destroyed.Contains(i + "" + (j - 1)) && validHit(i, j + 1))
                        {
                            //hitfields.Clear();
                            if (!hit.Contains(i + "" + (j + 1)))
                            {
                                medhitfields.Add(i + "" + (j + 1));
                                destroyedNeighbour = true;
                            }
                            if (validHit(i, j - 2) && !hit.Contains(i + "" + (j - 2))) medhitfields.Add(i + "" + (j - 2));
                        }
                        if (destroyed.Contains((i + 1) + "" + j) && validHit(i - 1, j))
                        {
                            //hitfields.Clear();
                            if (!hit.Contains((i - 1) + "" + j))
                            {
                                medhitfields.Add((i - 1) + "" + j);
                                destroyedNeighbour = true;
                            }
                            if (validHit(i + 2, j) && !hit.Contains((i + 2) + "" + j)) medhitfields.Add((i + 2) + "" + j);
                        }
                        if (destroyed.Contains(i + "" + (j + 1)) && validHit(i, j - 1))
                        {
                            //hitfields.Clear();
                            if (!hit.Contains(i + "" + (j - 1)))
                            {
                                medhitfields.Add(i + "" + (j - 1));
                                destroyedNeighbour = true;
                            }
                            if (validHit(i, j + 2) && !hit.Contains(i + "" + (j + 2))) medhitfields.Add(i + "" + (j + 2));
                        }
                        if (!destroyedNeighbour)
                        {
                            if (validHit(i - 1, j) && fields.Contains((i - 1) + "" + j) && !hitfields.Contains((i - 1) + "" + j)) hitfields.Add((i - 1) + "" + j);
                            if (validHit(i, j - 1) && fields.Contains(i + "" + (j - 1)) && !hitfields.Contains(i + "" + (j - 1))) hitfields.Add(i + "" + (j - 1));
                            if (validHit(i + 1, j) && fields.Contains((i + 1) + "" + j) && !hitfields.Contains((i + 1) + "" + j)) hitfields.Add((i + 1) + "" + j);
                            if (validHit(i, j + 1) && fields.Contains(i + "" + (j + 1)) && !hitfields.Contains(i + "" + (j + 1))) hitfields.Add(i + "" + (j + 1));
                        }
                        else
                        {
                            hitfields.Clear();
                        }
                        System.Threading.Thread.Sleep(700);
                        comHit();
                    }
                }
            }
        }
        private string getFirstFullField()
        {
            string s = "";
            bool flag = false;
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (!hit.Contains(i + "" + j))
                    {
                        if (user.get(i, j) != 0)
                        {
                            s = i + "" + j;
                            flag = true;
                            break;
                        }
                    }
                }
                if (flag) break;
            }
            return s;
        }
        private void AppearHighscores(bool won)
        {
            if (hardness == 0)
            {
                if (won)
                {
                    List<String> highscores = new List<String>();
                    string line;
                    var file = new System.IO.StreamReader("..\\..\\Resources\\highscores\\highscores.txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        highscores.Add(line);
                    }
                    file.Close();
                    highscores.Add(timerBox.Text + " - " + username.Text);
                    highscores = highscores.OrderBy(q => q).ToList();
                    if (highscores.Count > 5)
                    {
                        for (int i = 5; i < highscores.Count; i++)
                        {
                            highscores.RemoveAt(i);
                        }
                    }
                    if (highscores.Contains(timerBox.Text + " - " + username.Text) && highscores.Count != 0)
                    {
                        if (highscores.Count == 1) MessageBox.Show("Честитo! Имате едно од 5 најдобри времиња!\n1. " + highscores.ElementAt(0), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 2) MessageBox.Show("Честитo! Имате едно од 5 најдобри времиња!\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 3) MessageBox.Show("Честитo! Имате едно од 5 најдобри времиња!\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                            + "\n3. " + highscores.ElementAt(2), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 4) MessageBox.Show("Честитo! Имате едно од 5 најдобри времиња!\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                            + "\n3. " + highscores.ElementAt(2) + "\n4. " + highscores.ElementAt(3), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 5) MessageBox.Show("Честитo! Имате едно од 5 најдобри времиња!\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                            + "\n3. " + highscores.ElementAt(2) + "\n4. " + highscores.ElementAt(3) + "\n5. " + highscores.ElementAt(4), "Најдобри времиња", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (highscores.Count == 1) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 2) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 3) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                            + "\n3. " + highscores.ElementAt(2), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 4) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                            + "\n3. " + highscores.ElementAt(2) + "\n4. " + highscores.ElementAt(3), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 5) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                            + "\n3. " + highscores.ElementAt(2) + "\n4. " + highscores.ElementAt(3) + "\n5. " + highscores.ElementAt(4), "Најдобри времиња", MessageBoxButtons.OK);
                    }
                    System.IO.File.WriteAllText("..\\..\\Resources\\highscores\\highscores.txt", string.Empty);
                    if (highscores.Count >= 1) File.AppendAllText("..\\..\\Resources\\highscores\\highscores.txt", highscores.ElementAt(0) + Environment.NewLine);
                    if (highscores.Count >= 2) File.AppendAllText("..\\..\\Resources\\highscores\\highscores.txt", highscores.ElementAt(1) + Environment.NewLine);
                    if (highscores.Count >= 3) File.AppendAllText("..\\..\\Resources\\highscores\\highscores.txt", highscores.ElementAt(2) + Environment.NewLine);
                    if (highscores.Count >= 4) File.AppendAllText("..\\..\\Resources\\highscores\\highscores.txt", highscores.ElementAt(3) + Environment.NewLine);
                    if (highscores.Count == 5) File.AppendAllText("..\\..\\Resources\\highscores\\highscores.txt", highscores.ElementAt(4) + Environment.NewLine);
                }
                else
                {
                    List<String> highscores = new List<String>();
                    string line;
                    var file = new System.IO.StreamReader("..\\..\\Resources\\highscores\\highscores.txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        highscores.Add(line);
                    }
                    highscores = highscores.OrderBy(q => q).ToList();
                    if (highscores.Count > 5)
                    {
                        for (int i = 5; i < highscores.Count; i++)
                        {
                            highscores.RemoveAt(i);
                        }
                    }
                    if (highscores.Count == 1) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0), "Најдобри времиња", MessageBoxButtons.OK);
                    else if (highscores.Count == 2) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1), "Најдобри времиња", MessageBoxButtons.OK);
                    else if (highscores.Count == 3) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                        + "\n3. " + highscores.ElementAt(2), "Најдобри времиња", MessageBoxButtons.OK);
                    else if (highscores.Count == 4) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                        + "\n3. " + highscores.ElementAt(2) + "\n4. " + highscores.ElementAt(3), "Најдобри времиња", MessageBoxButtons.OK);
                    else if (highscores.Count == 5) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                        + "\n3. " + highscores.ElementAt(2) + "\n4. " + highscores.ElementAt(3) + "\n5. " + highscores.ElementAt(4), "Најдобри времиња", MessageBoxButtons.OK);
                }
            }
            else if (hardness == 1)
            {
                if (won)
                {
                    List<String> highscores = new List<String>();
                    string line;
                    var file = new System.IO.StreamReader("..\\..\\Resources\\highscores\\highscores-medium.txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        highscores.Add(line);
                    }
                    file.Close();
                    highscores.Add(timerBox.Text + " - " + username.Text);
                    highscores = highscores.OrderBy(q => q).ToList();
                    if (highscores.Count > 5)
                    {
                        for (int i = 5; i < highscores.Count; i++)
                        {
                            highscores.RemoveAt(i);
                        }
                    }
                    if (highscores.Contains(timerBox.Text + " - " + username.Text) && highscores.Count != 0)
                    {
                        if (highscores.Count == 1) MessageBox.Show("Честитo! Имате едно од 5 најдобри времиња!\n1. " + highscores.ElementAt(0), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 2) MessageBox.Show("Честитo! Имате едно од 5 најдобри времиња!\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 3) MessageBox.Show("Честитo! Имате едно од 5 најдобри времиња!\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                            + "\n3. " + highscores.ElementAt(2), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 4) MessageBox.Show("Честитo! Имате едно од 5 најдобри времиња!\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                            + "\n3. " + highscores.ElementAt(2) + "\n4. " + highscores.ElementAt(3), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 5) MessageBox.Show("Честитo! Имате едно од 5 најдобри времиња!\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                            + "\n3. " + highscores.ElementAt(2) + "\n4. " + highscores.ElementAt(3) + "\n5. " + highscores.ElementAt(4), "Најдобри времиња", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (highscores.Count == 1) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 2) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 3) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                            + "\n3. " + highscores.ElementAt(2), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 4) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                            + "\n3. " + highscores.ElementAt(2) + "\n4. " + highscores.ElementAt(3), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 5) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                            + "\n3. " + highscores.ElementAt(2) + "\n4. " + highscores.ElementAt(3) + "\n5. " + highscores.ElementAt(4), "Најдобри времиња", MessageBoxButtons.OK);
                    }
                    System.IO.File.WriteAllText("..\\..\\Resources\\highscores\\highscores-medium.txt", string.Empty);
                    if (highscores.Count >= 1) File.AppendAllText("..\\..\\Resources\\highscores\\highscores-medium.txt", highscores.ElementAt(0) + Environment.NewLine);
                    if (highscores.Count >= 2) File.AppendAllText("..\\..\\Resources\\highscores\\highscores-medium.txt", highscores.ElementAt(1) + Environment.NewLine);
                    if (highscores.Count >= 3) File.AppendAllText("..\\..\\Resources\\highscores\\highscores-medium.txt", highscores.ElementAt(2) + Environment.NewLine);
                    if (highscores.Count >= 4) File.AppendAllText("..\\..\\Resources\\highscores\\highscores-medium.txt", highscores.ElementAt(3) + Environment.NewLine);
                    if (highscores.Count == 5) File.AppendAllText("..\\..\\Resources\\highscores\\highscores-medium.txt", highscores.ElementAt(4) + Environment.NewLine);
                }
                else
                {
                    List<String> highscores = new List<String>();
                    string line;
                    var file = new System.IO.StreamReader("..\\..\\Resources\\highscores\\highscores-medium.txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        highscores.Add(line);
                    }
                    highscores = highscores.OrderBy(q => q).ToList();
                    if (highscores.Count > 5)
                    {
                        for (int i = 5; i < highscores.Count; i++)
                        {
                            highscores.RemoveAt(i);
                        }
                    }
                    if (highscores.Count == 1) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0), "Најдобри времиња", MessageBoxButtons.OK);
                    else if (highscores.Count == 2) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1), "Најдобри времиња", MessageBoxButtons.OK);
                    else if (highscores.Count == 3) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                        + "\n3. " + highscores.ElementAt(2), "Најдобри времиња", MessageBoxButtons.OK);
                    else if (highscores.Count == 4) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                        + "\n3. " + highscores.ElementAt(2) + "\n4. " + highscores.ElementAt(3), "Најдобри времиња", MessageBoxButtons.OK);
                    else if (highscores.Count == 5) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                        + "\n3. " + highscores.ElementAt(2) + "\n4. " + highscores.ElementAt(3) + "\n5. " + highscores.ElementAt(4), "Најдобри времиња", MessageBoxButtons.OK);
                }
            }
            else if (hardness == 2)
            {
                if (won)
                {
                    List<String> highscores = new List<String>();
                    string line;
                    var file = new System.IO.StreamReader("..\\..\\Resources\\highscores\\highscores-hard.txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        highscores.Add(line);
                    }
                    file.Close();
                    highscores.Add(timerBox.Text + " - " + username.Text);
                    highscores = highscores.OrderBy(q => q).ToList();
                    if (highscores.Count > 5)
                    {
                        for (int i = 5; i < highscores.Count; i++)
                        {
                            highscores.RemoveAt(i);
                        }
                    }
                    if (highscores.Contains(timerBox.Text + " - " + username.Text) && highscores.Count != 0)
                    {
                        if (highscores.Count == 1) MessageBox.Show("Честитo! Имате едно од 5 најдобри времиња!\n1. " + highscores.ElementAt(0), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 2) MessageBox.Show("Честитo! Имате едно од 5 најдобри времиња!\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 3) MessageBox.Show("Честитo! Имате едно од 5 најдобри времиња!\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                            + "\n3. " + highscores.ElementAt(2), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 4) MessageBox.Show("Честитo! Имате едно од 5 најдобри времиња!\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                            + "\n3. " + highscores.ElementAt(2) + "\n4. " + highscores.ElementAt(3), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 5) MessageBox.Show("Честитo! Имате едно од 5 најдобри времиња!\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                            + "\n3. " + highscores.ElementAt(2) + "\n4. " + highscores.ElementAt(3) + "\n5. " + highscores.ElementAt(4), "Најдобри времиња", MessageBoxButtons.OK);
                    }

                    else
                    {
                        if (highscores.Count == 1) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 2) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 3) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                            + "\n3. " + highscores.ElementAt(2), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 4) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                            + "\n3. " + highscores.ElementAt(2) + "\n4. " + highscores.ElementAt(3), "Најдобри времиња", MessageBoxButtons.OK);
                        else if (highscores.Count == 5) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                            + "\n3. " + highscores.ElementAt(2) + "\n4. " + highscores.ElementAt(3) + "\n5. " + highscores.ElementAt(4), "Најдобри времиња", MessageBoxButtons.OK);
                    }
                    System.IO.File.WriteAllText("..\\..\\Resources\\highscores\\highscores-hard.txt", string.Empty);
                    if (highscores.Count >= 1) File.AppendAllText("..\\..\\Resources\\highscores\\highscores-hard.txt", highscores.ElementAt(0) + Environment.NewLine);
                    if (highscores.Count >= 2) File.AppendAllText("..\\..\\Resources\\highscores\\highscores-hard.txt", highscores.ElementAt(1) + Environment.NewLine);
                    if (highscores.Count >= 3) File.AppendAllText("..\\..\\Resources\\highscores\\highscores-hard.txt", highscores.ElementAt(2) + Environment.NewLine);
                    if (highscores.Count >= 4) File.AppendAllText("..\\..\\Resources\\highscores\\highscores-hard.txt", highscores.ElementAt(3) + Environment.NewLine);
                    if (highscores.Count == 5) File.AppendAllText("..\\..\\Resources\\highscores\\highscores-hard.txt", highscores.ElementAt(4) + Environment.NewLine);
                }
                else
                {
                    List<String> highscores = new List<String>();
                    string line;
                    var file = new System.IO.StreamReader("..\\..\\Resources\\highscores\\highscores-hard.txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        highscores.Add(line);
                    }
                    highscores = highscores.OrderBy(q => q).ToList();
                    if (highscores.Count > 5)
                    {
                        for (int i = 5; i < highscores.Count; i++)
                        {
                            highscores.RemoveAt(i);
                        }
                    }
                    if (highscores.Count == 1) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0), "Најдобри времиња", MessageBoxButtons.OK);
                    else if (highscores.Count == 2) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1), "Најдобри времиња", MessageBoxButtons.OK);
                    else if (highscores.Count == 3) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                        + "\n3. " + highscores.ElementAt(2), "Најдобри времиња", MessageBoxButtons.OK);
                    else if (highscores.Count == 4) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                        + "\n3. " + highscores.ElementAt(2) + "\n4. " + highscores.ElementAt(3), "Најдобри времиња", MessageBoxButtons.OK);
                    else if (highscores.Count == 5) MessageBox.Show("Листа на најдобрите времиња:\n1. " + highscores.ElementAt(0) + "\n2. " + highscores.ElementAt(1)
                        + "\n3. " + highscores.ElementAt(2) + "\n4. " + highscores.ElementAt(3) + "\n5. " + highscores.ElementAt(4), "Најдобри времиња", MessageBoxButtons.OK);
                }
            }
        }
        private void comHit()
        {
            if (hardness == 0)
            {
                if (!finished)
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
            else if (hardness == 1 || hardness == 2)
            {
                if (!finished)
                {
                    Random rand = new Random();
                    if (medhitfields.Count == 0)
                    {
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
                    else
                    {
                        int i = rand.Next(0, medhitfields.Count);
                        Button button = (Button)this.Controls.Find("u" + medhitfields.ElementAt(i), true).FirstOrDefault();
                        fields.Remove(medhitfields.ElementAt(i));
                        medhitfields.RemoveAt(i);
                        button.Enabled = true;
                        button.PerformClick();
                    }
                }
            }
        }
        private void comHit(string next)

        {
            Button button = (Button)this.Controls.Find("u" + next, true).FirstOrDefault();
            fields.Remove(next);
            button.Enabled = true;
            button.PerformClick();
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
            for (int k = 0; k < fields.Count; k++)
            {
                s = fields.ElementAt(k);
                i = Convert.ToInt16(s) / 10;
                j = Convert.ToInt16(s) % 10;
                if (!fields.Contains((i + 1) + "" + j) && !fields.Contains(i + "" + (j + 1)) && !fields.Contains((i - 1) + "" + j) && !fields.Contains(i + "" + (j - 1))
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
        private int caseSwitch = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            caseSwitch++;
            string s = "";
            switch (caseSwitch)
            {
                case 1:
                    s = "";
                    break;
                case 2:
                    s = "1";
                    break;
            }
            if (caseSwitch == 2) caseSwitch = 0;
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (user.get(i, j) == 0 && !fields.Contains(i + "" + j))
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\x" + s + ".jpg");
                    }
                    if (comp.get(i, j) == 0)
                    {
                        Button button = (Button)this.Controls.Find("c" + i + "" + j, true).FirstOrDefault();
                        if (!button.Enabled) button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\x" + s + ".jpg");
                    }
                    if (user.get(i, j) != 0 && !fields.Contains(i + "" + j))
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\smoke" + s + ".png");
                    }
                    if (comp.get(i, j) != 0)
                    {
                        Button button = (Button)this.Controls.Find("c" + i + "" + j, true).FirstOrDefault();
                        if (!button.Enabled) button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\smoke" + s + ".png");
                    }
                }
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
        private void ResetForm()
        {
            DialogResult result = MessageBox.Show("Дали сте сигурни дека сакате да започнете одново?", "Започни одново?", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                comp = new Grid(user.getM());
                fields.Clear();
                hitfields.Clear();
                medhitfields.Clear();
                hit.Clear();
                destroyed.Clear();
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        fields.Add(i + "" + j);
                    }
                }
                SelectShips shipForm = new SelectShips();
                if (shipForm.ShowDialog() == DialogResult.OK)
                {
                    user = shipForm.getUser();
                    hardness = shipForm.getHardness();
                }
                hardCounter = 0;
                computer.Text = "Компјутер";
                finished = false;
                RefreshGrid();
                RefreshCompGrid();
                turnBox.Text = username.Text + " е на ред.";
                timer1.Start();
                userCounter = 0;
                compCounter = 0;
                timer = 0;
                saveButton.Enabled = true;
                turn = true;

            }
        }
        private void RefreshCompGrid()
        {
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    Button button = (Button)this.Controls.Find("c" + i + "" + j, true).FirstOrDefault();
                    button.Image = null;
                    button.Enabled = true;
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Зачувај ја играта и излези? Зачуваната игра ќе ја замени веќе постоечката.", "Зачувај?", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                System.IO.File.WriteAllText("..\\..\\Resources\\saved-game\\usergrid.txt", string.Empty);
                System.IO.File.WriteAllText("..\\..\\Resources\\saved-game\\compgrid.txt", string.Empty);
                System.IO.File.WriteAllText("..\\..\\Resources\\saved-game\\medhitfields.txt", string.Empty);
                System.IO.File.WriteAllText("..\\..\\Resources\\saved-game\\hitfields.txt", string.Empty);
                System.IO.File.WriteAllText("..\\..\\Resources\\saved-game\\hit.txt", string.Empty);
                System.IO.File.WriteAllText("..\\..\\Resources\\saved-game\\destroyed.txt", string.Empty);
                System.IO.File.WriteAllText("..\\..\\Resources\\saved-game\\fields.txt", string.Empty);
                System.IO.File.WriteAllText("..\\..\\Resources\\saved-game\\info.txt", string.Empty);
                System.IO.File.WriteAllText("..\\..\\Resources\\saved-game\\comfields.txt", string.Empty);
                File.AppendAllText("..\\..\\Resources\\saved-game\\usergrid.txt", user.ToString());
                File.AppendAllText("..\\..\\Resources\\saved-game\\compgrid.txt", comp.ToString());
                for (int i = 0; i < fields.Count; i++)
                {
                    if (i != fields.Count - 1) File.AppendAllText("..\\..\\Resources\\saved-game\\fields.txt", fields.ElementAt(i) + Environment.NewLine);
                    else File.AppendAllText("..\\..\\Resources\\saved-game\\fields.txt", fields.ElementAt(i));
                }
                for (int i = 0; i < hitfields.Count; i++)
                {
                    if (i != hitfields.Count - 1) File.AppendAllText("..\\..\\Resources\\saved-game\\hitfields.txt", hitfields.ElementAt(i) + Environment.NewLine);
                    else File.AppendAllText("..\\..\\Resources\\saved-game\\hitfields.txt", hitfields.ElementAt(i));
                }
                for (int i = 0; i < medhitfields.Count; i++)
                {
                    if (i != medhitfields.Count - 1) File.AppendAllText("..\\..\\Resources\\saved-game\\medhitfields.txt", medhitfields.ElementAt(i) + Environment.NewLine);
                    else File.AppendAllText("..\\..\\Resources\\saved-game\\medhitfields.txt", medhitfields.ElementAt(i));
                }
                for (int i = 0; i < hit.Count; i++)
                {
                    if (i != hit.Count - 1) File.AppendAllText("..\\..\\Resources\\saved-game\\hit.txt", hit.ElementAt(i) + Environment.NewLine);
                    else File.AppendAllText("..\\..\\Resources\\saved-game\\hit.txt", hit.ElementAt(i));
                }
                for (int i = 0; i < destroyed.Count; i++)
                {
                    if (i != destroyed.Count - 1) File.AppendAllText("..\\..\\Resources\\saved-game\\destroyed.txt", destroyed.ElementAt(i) + Environment.NewLine);
                    else File.AppendAllText("..\\..\\Resources\\saved-game\\destroyed.txt", destroyed.ElementAt(i));
                }
                for (int i = 0; i < comfields.Count; i++)
                {
                    if (i != comfields.Count - 1) File.AppendAllText("..\\..\\Resources\\saved-game\\comfields.txt", comfields.ElementAt(i) + Environment.NewLine);
                    else File.AppendAllText("..\\..\\Resources\\saved-game\\comfields.txt", comfields.ElementAt(i));
                }
                File.AppendAllText("..\\..\\Resources\\saved-game\\info.txt", username.Text + Environment.NewLine);
                File.AppendAllText("..\\..\\Resources\\saved-game\\info.txt", timer + Environment.NewLine);
                File.AppendAllText("..\\..\\Resources\\saved-game\\info.txt", hardness + Environment.NewLine);
                File.AppendAllText("..\\..\\Resources\\saved-game\\info.txt", userCounter + Environment.NewLine);
                File.AppendAllText("..\\..\\Resources\\saved-game\\info.txt", compCounter + Environment.NewLine);
                Close();
            }

        }
    }
}
