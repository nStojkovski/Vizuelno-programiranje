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
        int hardness = 0;
        private const int CP_NOCLOSE_BUTTON = 0x200;
        public SelectShips()
        {
            InitializeComponent();
            radioButton6.Checked = true;
            StartPosition = FormStartPosition.CenterScreen;
            //this.BackgroundImage = System.Drawing.Image.FromFile(@"..\..\Resources\background-radar.jpg");
            panel1.BackgroundImage = System.Drawing.Image.FromFile(@"..\..\Resources\ships\aircraft-carrier.png");
            panel2.BackgroundImage = System.Drawing.Image.FromFile(@"..\..\Resources\ships\battleship.png");
            panel3.BackgroundImage = System.Drawing.Image.FromFile(@"..\..\Resources\ships\submarine.png");
            panel4.BackgroundImage = System.Drawing.Image.FromFile(@"..\..\Resources\ships\destroyer.png");
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
                    button.BackColor = Color.Transparent;
                }
            }
            button1.Enabled = false;
            textBox1.ResetText();
            textBox1.Text = "Кликнете на почетната координата на бродот кој сакате да го поставите. За вертикална поставеност, обележете го полето со назив \"Вертикално\" и кликнете одново.";
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        public int getHardness()
        {
            return hardness;
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
                if (radioButton5.Checked) hardness = 0;
                else if (radioButton6.Checked) hardness = 1;
                else if (radioButton7.Checked) hardness = 2;
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
                        button.BackColor = Color.LightBlue;
                    }
                    else
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = false;
                        button.BackColor = Color.Transparent;
                    }
                }
            }
            for (int i = 1; i < 9; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                    button.Enabled = false;
                    button.BackColor = Color.Transparent;
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
                        button.BackColor = Color.LightBlue;
                    }
                    else
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = false;
                        button.BackColor = Color.Transparent;
                    }
                }
            }
            for (int i = 6; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                    button.Enabled = false;
                    button.BackColor = Color.Transparent;
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
                        button.BackColor = Color.LightBlue;
                    }
                    else
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = false;
                        button.BackColor = Color.Transparent;
                    }
                }
            }
            for (int i = 1; i < 9; i++)
            {
                for (int j = 7; j < 9; j++)
                {
                    Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                    button.Enabled = false;
                    button.BackColor = Color.Transparent;
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
                        button.BackColor = Color.LightBlue;
                    }
                    else
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = false;
                        button.BackColor = Color.Transparent;
                    }
                }
            }
            for (int i = 7; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                    button.Enabled = false;
                    button.BackColor = Color.Transparent;
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
                        button.BackColor = Color.LightBlue;
                    }
                    else
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = false;
                        button.BackColor = Color.Transparent;
                    }
                }
            }
            for (int i = 1; i < 9; i++)
            {
                for (int j = 8; j < 9; j++)
                {
                    Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                    button.Enabled = false;
                    button.BackColor = Color.Transparent;
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
                        button.BackColor = Color.LightBlue;
                    }
                    else
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = false;
                        button.BackColor = Color.Transparent;
                    }
                }
            }
            for (int i = 8; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                    button.Enabled = false;
                    button.BackColor = Color.Transparent;
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
                        button.BackColor = Color.Transparent;
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 5; j < 9; j++)
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = true;
                        button.BackColor = Color.LightBlue;
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
                        button.BackColor = Color.LightBlue;
                    }
                }
                for (int i = 1; i < 5; i++)
                {
                    for (int j = 5; j < 9; j++)
                    {
                        Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                        button.Enabled = false;
                        button.BackColor = Color.Transparent;
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
                    RefreshGrid(5);
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
                    RefreshGrid(5);
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
                    RefreshGrid(4);
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
                    RefreshGrid(4);
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
                    RefreshGrid(3);
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
                    RefreshGrid(3);
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
                    RefreshGrid(2);
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
                    RefreshGrid(2);
                }
                textBox1.ResetText();
                textBox1.Text = "Доколку сте задоволни од мапата, притиснете на \"Готово\". Во спротивно ресетирајте ја мапата.";
            }
        }
        void RefreshGrid(int k)
        {
            bool found = false;
            if (k == 5)
            {
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (user.get(i, j) == 5)
                        {
                            //Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                            //button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\o.jpg");
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
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if(user.get(i, j) == 0)
                        {
                            Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                            button.Image = null;
                        }
                    }
                }
            }
            if (k == 4)
            {
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (user.get(i, j) == 4)
                        {
                            //Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                            //button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\o.jpg");
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
            if (k == 3)
            {
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (user.get(i, j) == 3)
                        {
                            //Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                            //button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\o.jpg");
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
            if (k == 2)
            {
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (user.get(i, j) == 2)
                        {
                            //Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                            //button.Image = System.Drawing.Image.FromFile(@"..\..\Resources\o.jpg");
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
        public void resetGrid()
        {
            radioButton1.Checked = true;
            radioButton1.Enabled = true;
            checkBox1.Enabled = true;
            checkBox1.Checked = false;
            radioButton2.Enabled = false;
            checkBox2.Enabled = false;
            checkBox2.Checked = false;
            radioButton3.Enabled = false;
            checkBox3.Enabled = false;
            checkBox3.Checked = false;
            radioButton4.Enabled = false;
            checkBox4.Enabled = false;
            checkBox4.Checked = false;
            for (int i = 1; i < 9; i++)
            {
                for (int j = 5; j < 9; j++)
                {
                    Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                    button.Enabled = false;
                    button.BackColor = Color.Transparent;
                }
            }
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                    button.Enabled = true;
                    button.BackColor = Color.LightBlue;
                }
            }
            user.resetGrid();
            RefreshGrid(5);
            RefreshGrid(4);
            RefreshGrid(3);
            RefreshGrid(2);
            button1.Text = "Следен брод";
            button1.Enabled = false;
            textBox1.ResetText();
            textBox1.Text = "Кликнете на почетната координата на бродот кој сакате да го поставите. За вертикална поставеност, обележете го полето со назив \"Вертикално\" и кликнете одново";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Дали сте сигурни дека сакате да ја ресетирате мапата?", "Потврда", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                resetGrid();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resetGrid();
            checkBox1.Enabled = false;
            radioButton1.Enabled = false;
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    Button button = (Button)this.Controls.Find("u" + i + "" + j, true).FirstOrDefault();
                    button.Enabled = false;
                    button.BackColor = Color.Transparent;
                }
            }
            user = new Grid();
            RefreshGrid(5);
            RefreshGrid(4);
            RefreshGrid(3);
            RefreshGrid(2);
            button1.Enabled = true;
            button1.Text = "Готово";
            radioButton4.Checked = true;
            textBox1.ResetText();
            textBox1.Text = "Доколку сте задоволни од мапата, притиснете на \"Готово\". Во спротивно ресетирајте ја мапата.";
        }
    }
}
