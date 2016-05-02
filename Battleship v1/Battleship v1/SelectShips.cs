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
    public partial class SelectShips : Form
    {
        Grid user = new Grid(true);
        public SelectShips()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            radioButton1.Checked = true;
            radioButton2.Enabled = false;
            checkBox2.Enabled = false;
            radioButton3.Enabled = false;
            checkBox3.Enabled = false;
            radioButton4.Enabled = false;
            checkBox4.Enabled = false;
            for (int i=1; i<9; i++)
            {
                for (int j=5; j<9; j++)
                {
                    Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                    button.Enabled = false;
                }
            }
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = true;
                radioButton2.Checked = true;
                checkBox1.Enabled = false;
                checkBox2.Enabled = true;
                Disable4();
            }
            else if (radioButton2.Checked)
            {
                radioButton2.Enabled = false;
                radioButton3.Enabled = true;
                radioButton3.Checked = true;
                checkBox2.Enabled = false;
                checkBox3.Enabled = true;
                Disable3();
            }
            else if (radioButton3.Checked)
            {
                radioButton3.Enabled = false;
                radioButton4.Enabled = true;
                radioButton4.Checked = true;
                checkBox3.Enabled = false;
                checkBox4.Enabled = true;
                button1.Text = "Готово";
                Disable2();
            }
            else if (radioButton4.Checked)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
            button1.Enabled = false;

        }
        private void Disable4()
        {
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    if (user.get(i, j) != 5 && user.get(i,j+1)!=5 && user.get(i, j + 2) != 5 && user.get(i, j + 3) != 5)
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = true;
                    }
                    else
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = false;
                    }
                }
            }
            for (int i = 1; i < 9; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                    button.Enabled = false;
                }
            }
        }
        private void Disable4Vertical()
        {
            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (user.get(i, j) != 5 && user.get(i+1, j) != 5 && user.get(i+2, j) != 5 && user.get(i+3, j) != 5)
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = true;
                    }
                    else
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = false;
                    }
                }
            }
            for (int i = 6; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                    button.Enabled = false;
                }
            }
        }
        private void Disable3()
        {
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    if (user.get(i, j) != 5 && user.get(i, j + 1) != 5 && user.get(i, j + 2) != 5
                        && user.get(i, j) != 4 && user.get(i, j + 1) != 4 && user.get(i, j + 2) != 4)
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = true;
                    }
                    else
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = false;
                    }
                }
            }
            for (int i = 1; i < 9; i++)
            {
                for (int j = 7; j < 9; j++)
                {
                    Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                    button.Enabled = false;
                }
            }
        }
        private void Disable3Vertical()
        {
            for (int i = 1; i < 7; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (user.get(i, j) != 5 && user.get(i + 1, j) != 5 && user.get(i + 2, j) != 5
                        && user.get(i, j) != 4 && user.get(i + 1, j) != 4 && user.get(i + 2, j) != 4)
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = true;
                    }
                    else
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = false;
                    }
                }
            }
            for (int i = 7; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                    button.Enabled = false;
                }
            }
        }
        private void Disable2()
        {
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    if (user.get(i, j) != 5 && user.get(i, j + 1) != 5 && user.get(i, j) != 4 
                        && user.get(i, j + 1) != 4 && user.get(i, j) != 3 && user.get(i, j + 1) != 3)
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = true;
                    }
                    else
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = false;
                    }
                }
            }
            for (int i = 1; i < 9; i++)
            {
                for (int j = 8; j < 9; j++)
                {
                    Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                    button.Enabled = false;
                }
            }
        }
        private void Disable2Vertical()
        {
            for (int i = 1; i < 8; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (user.get(i, j) != 5 && user.get(i + 1, j) != 5 && user.get(i, j) != 4 
                        && user.get(i + 1, j) != 4 && user.get(i, j) != 3 && user.get(i + 1, j) != 3)
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = true;
                    }
                    else
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = false;
                    }
                }
            }
            for (int i = 8; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                    button.Enabled = false;
                }
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                for (int i = 5; i < 9; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = false;
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 5; j < 9; j++)
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = true;
                    }
                }
            }
            else
            {
                for (int i = 5; i < 9; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = true;
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 5; j < 9; j++)
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = false;
                    }
                }
            }
        }
        private void grid_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            string name = button.Name.Substring(1);
            int i = Convert.ToInt16(name) / 10;
            int j = Convert.ToInt16(name) % 10;
            button1.Enabled = true;
            if (radioButton1.Checked)
            {
                if(!checkBox1.Checked)
                {
                    for (int m = 1; m < 9; m ++)
                    {
                        for (int n = 1; n < 9; n ++)
                        {
                            if (user.get(m,n)==5)
                            {
                                user.set(m, n, 0);
                            }
                        }
                    }
                    for (int k = j; k < j+5; k++)
                    {
                        user.set(i, k, 5);
                    }
                    RefreshGrid();
                }
                else
                {
                    for (int m = 1; m < 9; m++)
                    {
                        for (int n = 1; n < 9; n++)
                        {
                            if (user.get(m, n) == 5)
                            {
                                user.set(m, n, 0);
                            }
                        }
                    }
                    for (int k = i; k < i + 5; k++)
                    {
                        user.set(k, j, 5);
                    }
                    RefreshGrid();
                }
            }
            if (radioButton2.Checked)
            {
                if (!checkBox2.Checked)
                {
                    for (int m = 1; m < 9; m++)
                    {
                        for (int n = 1; n < 9; n++)
                        {
                            if (user.get(m, n) == 4)
                            {
                                user.set(m, n, 0);
                            }
                        }
                    }
                    for (int k = j; k < j + 4; k++)
                    {
                        user.set(i, k, 4);
                    }
                    RefreshGrid();
                }
                else
                {
                    for (int m = 1; m < 9; m++)
                    {
                        for (int n = 1; n < 9; n++)
                        {
                            if (user.get(m, n) == 4)
                            {
                                user.set(m, n, 0);
                            }
                        }
                    }
                    for (int k = i; k < i + 4; k++)
                    {
                        user.set(k, j, 4);
                    }
                    RefreshGrid();
                }
            }
            if (radioButton3.Checked)
            {
                if (!checkBox3.Checked)
                {
                    for (int m = 1; m < 9; m++)
                    {
                        for (int n = 1; n < 9; n++)
                        {
                            if (user.get(m, n) == 3)
                            {
                                user.set(m, n, 0);
                            }
                        }
                    }
                    for (int k = j; k < j + 3; k++)
                    {
                        user.set(i, k, 3);
                    }
                    RefreshGrid();
                }
                else
                {
                    for (int m = 1; m < 9; m++)
                    {
                        for (int n = 1; n < 9; n++)
                        {
                            if (user.get(m, n) == 3)
                            {
                                user.set(m, n, 0);
                            }
                        }
                    }
                    for (int k = i; k < i + 3; k++)
                    {
                        user.set(k, j, 3);
                    }
                    RefreshGrid();
                }
            }
            if (radioButton4.Checked)
            {
                if (!checkBox4.Checked)
                {
                    for (int m = 1; m < 9; m++)
                    {
                        for (int n = 1; n < 9; n++)
                        {
                            if (user.get(m, n) == 2)
                            {
                                user.set(m, n, 0);
                            }
                        }
                    }
                    for (int k = j; k < j + 2; k++)
                    {
                        user.set(i, k, 2);
                    }
                    RefreshGrid();
                }
                else
                {
                    for (int m = 1; m < 9; m++)
                    {
                        for (int n = 1; n < 9; n++)
                        {
                            if (user.get(m, n) == 2)
                            {
                                user.set(m, n, 0);
                            }
                        }
                    }
                    for (int k = i; k < i + 2; k++)
                    {
                        user.set(k, j, 2);
                    }
                    RefreshGrid();
                }
            }
        }
        void RefreshGrid()
        {
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (user.get(i, j) != 0)
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\o.jpg");
                    }
                    else
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Image = null;
                    }
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
            {
                Disable4Vertical();
            }
            else
            {
                Disable4();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                Disable3Vertical();
            }
            else
            {
                Disable3();
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                Disable2Vertical();
            }
            else
            {
                Disable2();
            }
        }
        public Grid getUser()
        {
            return user;
        }
    }
}
