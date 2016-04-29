using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship_v1
{
    public partial class Username : Form
    {
        private string username { get; set; }
        private bool save { get; set; }
        bool test { get; set; }
        ErrorProvider err = new ErrorProvider();
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        public Username()
        {
            StartPosition = FormStartPosition.CenterScreen;
            test = false;
            InitializeComponent();
        }
        public string getUsername()
        {
            return username;
        }
        public bool getSave()
        {
            return save;
        }
        private void OK_Click(object sender, EventArgs e)
        {
            if (test)
            {
                username = usernameTB.Text;
                save = saveUsername.Checked;
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }
        private void usernameTB_Validating(object sender, CancelEventArgs s)
        {
            if (usernameTB.Text.Trim().Length == 0)
            {
                err.SetError(usernameTB, "Please enter your username!");
            }
            else
            {
                test = true;
                err.SetError(usernameTB, null);
            }
        }

        private void usernameTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OK.PerformClick();
            }
        }
    }
}
