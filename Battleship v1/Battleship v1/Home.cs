using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship_v1
{
    public partial class Home : Form
    {
        bool newgame;
        public Home()
        {
            InitializeComponent();
            this.BackgroundImage = System.Drawing.Image.FromFile(@"..\..\Resources\background.jpg");
            newgame = true;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void HelpButton1_Click(object sender, EventArgs e)
        {
            Process.Start(@"..\..\Resources\help\help.html");
        }

        private void loadGame_Click(object sender, EventArgs e)
        {
            newgame = false;
            this.DialogResult = DialogResult.OK;
            Close();
        }
        public bool getNewGame()
        {
            return newgame;
        }
    }
}
