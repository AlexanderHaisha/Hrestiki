using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hrestiki
{
    public partial class Form1 : Form
    {
        private 
            int[] M = new int[9] {0, 0, 0, 0, 0, 0, 0, 0, 0 }; //1 - якщо у комірку походим гравець, -1 - якщо компютер
        private
            int totalgames;
        private
            int wongames;
        private
            int drawgames;

        public Form1()
        {
            InitializeComponent();
            totalgames = 0;
            wongames = 0;
            drawgames = 0;
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private int checkWinner() //повертає 1 при перемозі користувача, 2 - компютера, 3 - нічия, 0 - гра триває
        {
            //if (M[0]==1 && M[1]==1 && M[2]==1) return 1;
            if (M[0] + M[1] + M[2] == 3) return 1;
            if (M[3] + M[4] + M[5] == 3) return 1;
            if (M[6] + M[7] + M[8] == 3) return 1;
            if (M[0] + M[3] + M[6] == 3) return 1;
            if (M[1] + M[4] + M[7] == 3) return 1;
            if (M[2] + M[5] + M[8] == 3) return 1;
            if (M[0] + M[4] + M[8] == 3) return 1;
            if (M[2] + M[4] + M[6] == 3) return 1;
            
            if (M[0] + M[1] + M[2] == -3) return 2;
            if (M[3] + M[4] + M[5] == -3) return 2;
            if (M[6] + M[7] + M[8] == -3) return 2;
            if (M[0] + M[3] + M[6] == -3) return 2;
            if (M[1] + M[4] + M[7] == -3) return 2;
            if (M[2] + M[5] + M[8] == -3) return 2;
            if (M[0] + M[4] + M[8] == -3) return 2;
            if (M[2] + M[4] + M[6] == -3) return 2;

            for (int i = 0; i < 9; i++)
                if (M[i] == 0)
                    return 0;
            return 3;
        }

        private void showResults()
        {
            label6.Text = totalgames.ToString();
            label5.Text = wongames.ToString();
            label4.Text = drawgames.ToString();

        }

        private void computerStep()
        {
            Random rand = new Random();
            int newstep;
            do {
                newstep = rand.Next(0, 8);
            } while (M[newstep]!=0);
            M[newstep] = -1;
            if (newstep == 0) { checkBox1.Text = "O"; checkBox1.Checked = true; }
            if (newstep == 1) { checkBox2.Text = "O"; checkBox2.Checked = true; }
            if (newstep == 2) { checkBox3.Text = "O"; checkBox3.Checked = true; }
            if (newstep == 3) { checkBox4.Text = "O"; checkBox4.Checked = true; }
            if (newstep == 4) { checkBox5.Text = "O"; checkBox5.Checked = true; }
            if (newstep == 5) { checkBox6.Text = "O"; checkBox6.Checked = true; }
            if (newstep == 6) { checkBox7.Text = "O"; checkBox7.Checked = true; }
            if (newstep == 7) { checkBox8.Text = "O"; checkBox8.Checked = true; }
            if (newstep == 8) { checkBox9.Text = "O"; checkBox9.Checked = true; }
            int res=checkWinner();
            /*if (res == 1)
            {
                MessageBox.Show("Вітаємо, Ви виграли!");
                return;
            }*/
            if (res == 2)
            {
                MessageBox.Show("Нажаль, Ви програли...");
                totalgames++;
                showResults();
                return;
            }
            if (res == 3)
            {
                MessageBox.Show("Нічия.");
                totalgames++;
                drawgames++;
                showResults();
                return;
            }
        }

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Програма написана в рамках триденного марафону з програмування","Про програму:");
            Form2 form = new Form2();
            form.ShowDialog();
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            int res;
            int num;
            if(((CheckBox)sender).Checked == false)
            {
                ((CheckBox)sender).Checked = true;
                return;
            }
            Thread.Sleep(1000);
            ((CheckBox)sender).Text = "X";
            num = Int32.Parse((sender as CheckBox).Tag.ToString()); // (int)(((CheckBox)sender).Tag);
            M[num] = 1;
            res = checkWinner();
            if (res==1)
            {
                MessageBox.Show("Вітаємо, Ви виграли!");
                totalgames++;
                wongames++;
                showResults();
                return;
            }
            /*if (res==2)
            {
                MessageBox.Show("Нажаль, Ви програли...");
                return;
            }*/
            if (res == 3)
            {
                MessageBox.Show("Нічия.");
                totalgames++;
                drawgames++;
                showResults();
                return;
            }
            computerStep();
        }

       /* private void checkBox2_Click(object sender, EventArgs e)
        {
            int res;
            if (checkBox2.Checked == false)
            {
                checkBox2.Checked = true;
                return;
            }
            checkBox2.Text = "X";
            M[1] = 1;
            res = checkWinner();
            if (res == 1)
            {
                MessageBox.Show("Вітаємо, Ви виграли!");
                return;
            }
            if (res == 2)
            {
                MessageBox.Show("Нажаль, Ви програли...");
                return;
            }
            if (res == 3)
            {
                MessageBox.Show("Нічия.");
                return;
            }
            computerStep();

        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            int res;
            if (checkBox3.Checked == false)
            {
                checkBox3.Checked = true;
                return;
            }
            checkBox3.Text = "X";
            M[2] = 1;
            res = checkWinner();
            if (res == 1)
            {
                MessageBox.Show("Вітаємо, Ви виграли!");
                return;
            }
            if (res == 2)
            {
                MessageBox.Show("Нажаль, Ви програли...");
                return;
            }
            if (res == 3)
            {
                MessageBox.Show("Нічия.");
                return;
            }
            computerStep();

        }

        private void checkBox4_Click(object sender, EventArgs e)
        {
            int res;
            if (checkBox4.Checked == false)
            {
                checkBox4.Checked = true;
                return;
            }
            checkBox4.Text = "X";
            M[3] = 1;
            res = checkWinner();
            if (res == 1)
            {
                MessageBox.Show("Вітаємо, Ви виграли!");
                return;
            }
            if (res == 2)
            {
                MessageBox.Show("Нажаль, Ви програли...");
                return;
            }
            if (res == 3)
            {
                MessageBox.Show("Нічия.");
                return;
            }
            computerStep();

        }

        private void checkBox5_Click(object sender, EventArgs e)
        {
            int res;
            if (checkBox5.Checked == false)
            {
                checkBox5.Checked = true;
                return;
            }
            checkBox5.Text = "X";
            M[4] = 1;
            res = checkWinner();
            if (res == 1)
            {
                MessageBox.Show("Вітаємо, Ви виграли!");
                return;
            }
            if (res == 2)
            {
                MessageBox.Show("Нажаль, Ви програли...");
                return;
            }
            if (res == 3)
            {
                MessageBox.Show("Нічия.");
                return;
            }
            computerStep();

        }

        private void checkBox6_Click(object sender, EventArgs e)
        {
            int res;
            if (checkBox6.Checked == false)
            {
                checkBox6.Checked = true;
                return;
            }
            checkBox6.Text = "X";
            M[5] = 1;
            res = checkWinner();
            if (res == 1)
            {
                MessageBox.Show("Вітаємо, Ви виграли!");
                return;
            }
            if (res == 2)
            {
                MessageBox.Show("Нажаль, Ви програли...");
                return;
            }
            if (res == 3)
            {
                MessageBox.Show("Нічия.");
                return;
            }
            computerStep();

        }

        private void checkBox7_Click(object sender, EventArgs e)
        {
            int res;
            if (checkBox7.Checked == false)
            {
                checkBox7.Checked = true;
                return;
            }
            checkBox7.Text = "X";
            M[6] = 1;
            res = checkWinner();
            if (res == 1)
            {
                MessageBox.Show("Вітаємо, Ви виграли!");
                return;
            }
            if (res == 2)
            {
                MessageBox.Show("Нажаль, Ви програли...");
                return;
            }
            if (res == 3)
            {
                MessageBox.Show("Нічия.");
                return;
            }
            computerStep();

        }

        private void checkBox8_Click(object sender, EventArgs e)
        {
            int res;
            if (checkBox8.Checked == false)
            {
                checkBox8.Checked = true;
                return;
            }
            checkBox8.Text = "X";
            M[7] = 1;
            res = checkWinner();
            if (res == 1)
            {
                MessageBox.Show("Вітаємо, Ви виграли!");
                return;
            }
            if (res == 2)
            {
                MessageBox.Show("Нажаль, Ви програли...");
                return;
            }
            if (res == 3)
            {
                MessageBox.Show("Нічия.");
                return;
            }
            computerStep();

        }

        private void checkBox9_Click(object sender, EventArgs e)
        {
            int res;
            if (checkBox9.Checked == false)
            {
                checkBox9.Checked = true;
                return;
            }
            checkBox9.Text = "X";
            M[8] = 1;
            res = checkWinner();
            if (res == 1)
            {
                MessageBox.Show("Вітаємо, Ви виграли!");
                return;
            }
            if (res == 2)
            {
                MessageBox.Show("Нажаль, Ви програли...");
                return;
            }
            if (res == 3)
            {
                MessageBox.Show("Нічия.");
                return;
            }
            computerStep();

        }
       */
        private void button1_Click(object sender, EventArgs e) //обробник кнопки Нова гра
        {
            checkBox1.Text = "";
            checkBox2.Text = "";
            checkBox3.Text = "";
            checkBox4.Text = "";
            checkBox5.Text = "";
            checkBox6.Text = "";
            checkBox7.Text = "";
            checkBox8.Text = "";
            checkBox9.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false; 
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            for(int i=0; i<9; i++)
            {
                M[i] = 0;
            }
        }


    }
}
