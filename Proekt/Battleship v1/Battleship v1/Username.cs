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
            string content = File.ReadAllText("..\\..\\Resources\\username\\pending.txt");
            System.IO.File.WriteAllText("..\\..\\Resources\\username\\pending.txt", string.Empty);
            if(content.Length != 0) File.AppendAllText("..\\..\\Resources\\username\\username.txt", content + Environment.NewLine);
            PopulateList("..\\..\\Resources\\username\\username.txt");
            rbVnesi.Checked = true;
            listBox1.Enabled = false;
        }
        private void PopulateList(string filePath)
        {
            string line;
            var file = new System.IO.StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                listBox1.Items.Add(line);
            }
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
            if(rbVnesi.Checked)
            {
                if (test)
                {
                    username = usernameTB.Text;
                    save = saveUsername.Checked;
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                username = listBox1.SelectedItem.ToString();
                save = false;
                this.DialogResult = DialogResult.OK;
            }
        }
        private void usernameTB_Validating(object sender, CancelEventArgs s)
        {
            if (rbVnesi.Checked)
            {
                if (usernameTB.Text.Trim().Length == 0)
                {
                    err.SetError(usernameTB, "Внесете го вашето корисничко име!");
                }
                else if (listBox1.Items.Contains(usernameTB.Text.Trim()))
                {
                    err.SetError(usernameTB, "Корисничкото име постои!");
                }
                else
                {
                    test = true;
                    err.SetError(usernameTB, null);
                }
            }
            else
            {
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

        private void rbVnesi_CheckedChanged(object sender, EventArgs e)
        {
            if(listBox1.Enabled)
            {
                listBox1.Enabled = false;
                usernameTB.Enabled = true;
                saveUsername.Enabled = true;
                OK.CausesValidation = true;
            }
        }

        private void rbIzberi_CheckedChanged(object sender, EventArgs e)
        {
            if(usernameTB.Enabled)
            {
                usernameTB.Enabled = false;
                saveUsername.Enabled = false;
                listBox1.Enabled = true;
                listBox1.SelectedIndex = 0;
                OK.CausesValidation = false;
            }
        }
    }
}
