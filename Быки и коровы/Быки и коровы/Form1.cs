using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Быки_и_коровы
{
    public partial class Form1 : Form
    {
        public Form5 form5;
        public Form4 form4;
        public Form3 form3;
        public Form2 form2;
        public Form1()
        {
            InitializeComponent();
            form2 = new Form2(this) { Visible = false };
            form3 = new Form3(this) { Visible = false };
            form4 = new Form4(this) { Visible = false };
            form5 = new Form5(this) { Visible = false };

            if (i == 0)
            {
                i = 1;
                MessageBox.Show("Версия 0.5.4" +
                    "\n\n-Доработан режим с общим числом." +
                    "\n-Исправлены некоторые ошибки." +
                    "\n\n-3-й режим закрыт на переработку." +
                    "\n-В скором времени будут усовершенствованы" +
                "\n алгоритмы отгадывания чисел компьютером.", "Список изменений", MessageBoxButtons.OK);
            }
        }

        int k = 0;
        int i = 0;

        #region mode1
        private void button1_Click(object sender, EventArgs e)
        {
            if (k == 0)
            {
                this.Visible = false;
                form2.Visible = true;
                form2.Enabled = true;
                k++;
            }
            else
            {
                MessageBox.Show("Так как у тебя уже был запущен другой режим, перезапусти.", "Много форм запускать не одобряю.", MessageBoxButtons.OK);
            }
        }
        #endregion

        #region mode2
        private void button2_Click(object sender, EventArgs e)
        {
            if (k == 0)
            {
                this.Visible = false;
                form3.Visible = true;
                form3.Enabled = true;
                k++;
            }
            else
            {
                MessageBox.Show("Так как у тебя уже был запущен другой режим, перезапусти.", "Много форм запускать не одобряю.", MessageBoxButtons.OK);
            }
        }
        #endregion

        #region mode3
        private void button3_Click(object sender, EventArgs e)
        {
            if (k == 0)
            {
                this.Visible = false;
                form4.Visible = true;
                form4.Enabled = true;
                k++;
            }
            else
            {
                MessageBox.Show("Так как у тебя уже был запущен другой режим, перезапусти.", "Много форм запускать не одобряю.", MessageBoxButtons.OK);
            }
        }
        #endregion

        #region mode4
        private void button4_Click(object sender, EventArgs e)
        {
            if (k == 0)
            {
                this.Visible = false;
                form5.Visible = true;
                form5.Enabled = true;
                k++;
            }
            else
            {
                MessageBox.Show("Так как у тебя уже был запущен другой режим, перезапусти.", "Много форм запускать не одобряю.", MessageBoxButtons.OK);
            }
        }
        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Location = new Point(12, 210);
            Text = ("                                       Быки и коровы");
            label2.Text = ("версия 0.5.4.");
     
            label1.Text = ("Тут необходимо выбрать режим игры.");
            button1.Text = ("Без соперника");
            button2.Text = ("С другим человеком");
            button3.Text = ("С компом, разные числа");
            button4.Text = ("С компом, одно число");
            button5.Text = ("Перезапуск");
            button6.Text = ("Выход");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //e.Cancel = true;
    }
}
