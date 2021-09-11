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
    public partial class Form4 : Form
    {
        public Form1 _form1;
        public Form4(Form1 form1)
        {
            _form1 = form1;
            InitializeComponent();
        }
            
        Random r = new Random();
        double a1, a2, a3, a4, a, b1, b2, b3, b4, b = 0;
        double c1, c2, c3, c4, c, d1, d2, d3, d4, d = 0;

        int kol_b, kol_k = 0;
        int h, k = 0;

        int round = 0;
        int but1 = 1;

        DialogResult result_pl;
        DialogResult result_pc;

        private void Form4_Load(object sender, EventArgs e)
        {
            Text = ("                                                    Игрок против пк");
            label1.Text = ("Введите число");
            label2.Text = ("Прогресс отгадывания \nкомпом");
            label3.Text = ("Уровень сложности:");
            label4.Text = ("Раунд " + round);
            label4.Visible = false;
            button1.Text = ("Загадать число компу");

            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            label3.Visible = false;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            switch (but1)
            {
                case 1:
                    #region Загадывание чисел
                    label1.Text = ("Введите число");
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Введите число от 1000 до 9999", "Число не введено!", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        a = Double.Parse(textBox1.Text);
                        if (a < 1000 || a >= 10000)
                        {
                            MessageBox.Show("Введите число от 1000 до 9999", "Введено не подходящее число!", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            a = Double.Parse(textBox1.Text);
                            a1 = (int)b / 1000;
                            a2 = (int)(b / 100) % 10;
                            a3 = (int)(b / 10) % 10;
                            a4 = (int)b % 10;
                            if (a1 == a2 || a1 == a3 || a1 == a4 || a2 == a3 || a2 == a4 || a3 == a4 || a1 == 0)
                            {
                                MessageBox.Show("Необходимо число без повторяющихся цифр!", "Введено число с одинаковыми числами!", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                a = Double.Parse(textBox1.Text);
                                a1 = (int)b / 1000;
                                a2 = (int)(b / 100) % 10;
                                a3 = (int)(b / 10) % 10;
                                a4 = (int)b % 10;

                                c1 = r.Next(1, 10);
                                c2 = r.Next(0, 10);
                                while (c2 == c1) { c2 = r.Next(0, 10); }
                                c3 = r.Next(0, 10);
                                while (c3 == c1 || c3 == c2) { c3 = r.Next(0, 10); }
                                c4 = r.Next(0, 10);
                                while (c4 == c1 || c4 == c2 || c4 == c3) { c4 = r.Next(0, 10); }
                                c = c1 * 1000 + c2 * 100 + c3 * 10 + c4;

                                MessageBox.Show("Числа загаданы. \nИгра началась", "Оповещение", MessageBoxButtons.OK);
                                button1.Text = ("Завершить раунд");
                                label4.Visible = true;
                                but1++;
                            }
                        }
                    }
                    #endregion
                    break;
                case 2:
                    #region Проверка чисел
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    if (radioButton1.Checked == false && radioButton2.Checked == false &&
                        radioButton3.Checked == false && radioButton4.Checked == false && radioButton5.Checked == false)
                    {
                        MessageBox.Show("Выбери уровень сложности. \nИбо честная игра всегда интересней.", "Сложность не выбрана!", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (textBox1.Text == "")
                        {
                            MessageBox.Show("Введите число от 1000 до 9999", "Число не введено!", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            b = Double.Parse(textBox1.Text);
                            if (b < 1000 || b >= 10000)
                            {
                                MessageBox.Show("Введите число от 1000 до 9999", "Введено не подходящее число!", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                b = Double.Parse(textBox1.Text);
                                b1 = (int)d / 1000;
                                b2 = (int)(d / 100) % 10;
                                b3 = (int)(d / 10) % 10;
                                b4 = d % 10;
                                if (b1 == b2 || b1 == b3 || b1 == b4 || b2 == b3 || b2 == b4 || b3 == b4 || b1 == 0)
                                {
                                    MessageBox.Show("Игра будет интересней, \nесли число будет из разных цифр(без повторов)", "Введено не подходящее число!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    round++;
                                    label4.Text = ("Раунд " + round);

                                    //Отгадывает игрок
                                    b = Double.Parse(textBox1.Text);
                                    b1 = (int)d / 1000;
                                    b2 = (int)(d / 100) % 10;
                                    b3 = (int)(d / 10) % 10;
                                    b4 = d % 10;
                                    k = 0; h = 0;
                                    listBox1.Items.Add(b.ToString());

                                    #region Сравнения
                                    if (b1 == c1) { listBox1.Items.Add("бык"); h++; }
                                    if (b2 == c2) { listBox1.Items.Add("бык"); h++; }
                                    if (b3 == c3) { listBox1.Items.Add("бык"); h++; }
                                    if (b4 == c4) { listBox1.Items.Add("бык"); h++; }

                                    if (b1 == c2) { listBox1.Items.Add("корова"); k++; }
                                    if (b1 == c3) { listBox1.Items.Add("корова"); k++; }
                                    if (b1 == c4) { listBox1.Items.Add("корова"); k++; }

                                    if (b2 == c1) { listBox1.Items.Add("корова"); k++; }
                                    if (b2 == c3) { listBox1.Items.Add("корова"); k++; }
                                    if (b2 == c4) { listBox1.Items.Add("корова"); k++; }

                                    if (b3 == c1) { listBox1.Items.Add("корова"); k++; }
                                    if (b3 == c2) { listBox1.Items.Add("корова"); k++; }
                                    if (b3 == c4) { listBox1.Items.Add("корова"); k++; }

                                    if (b4 == c1) { listBox1.Items.Add("корова"); k++; }
                                    if (b4 == c2) { listBox1.Items.Add("корова"); k++; }
                                    if (b4 == c3) { listBox1.Items.Add("корова"); k++; }
                                    #endregion

                                    //ИИ
                                    kol_b = 0; kol_k = 0;
                                    #region very easy
                                    if (radioButton1.Checked == true)
                                    {
                                        radioButton2.Visible = false;
                                        radioButton3.Visible = false;
                                        radioButton4.Visible = false;
                                        radioButton5.Visible = false;
                                        if (round == 35)
                                        {
                                            d1 = a1;
                                            d2 = a2;
                                            d3 = a3;
                                            d4 = a4;
                                        }
                                        d = d1 * 1000 + d2 * 100 + d3 * 10 + d4;
                                        listBox2.Items.Add(c.ToString());
                                        #region Сравнения
                                        if (d1 == a1) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (d2 == a2) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (d3 == a3) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (d4 == a4) { listBox2.Items.Add("бык"); kol_b++; }

                                        if (d1 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d1 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d1 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (d2 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d2 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d2 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (d3 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d3 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d3 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (d4 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d4 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d4 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        #endregion
                                        d1 = 0; d2 = 0; d3 = 0; d4 = 0;
                                    }
                                    #endregion

                                    #region easy
                                    if (radioButton5.Checked == true)
                                    {
                                        radioButton1.Visible = false;
                                        radioButton2.Visible = false;
                                        radioButton3.Visible = false;
                                        radioButton4.Visible = false;
                                        if (round == 14)
                                        {
                                            d1 = a1;
                                            d2 = a2;
                                            d3 = a3;
                                            d4 = a4;
                                        }
                                        d = d1 * 1000 + d2 * 100 + d3 * 10 + d4;
                                        listBox2.Items.Add(c.ToString());
                                        #region Сравнения
                                        if (d1 == a1) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (d2 == a2) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (d3 == a3) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (d4 == a4) { listBox2.Items.Add("бык"); kol_b++; }

                                        if (d1 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d1 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d1 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (d2 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d2 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d2 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (d3 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d3 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d3 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (d4 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d4 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d4 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        #endregion
                                        d1 = 0; d2 = 0; d3 = 0; d4 = 0;
                                    }
                                    #endregion

                                    #region normal
                                    if (radioButton2.Checked == true)
                                    {
                                        radioButton1.Visible = false;
                                        radioButton3.Visible = false;
                                        radioButton4.Visible = false;
                                        radioButton5.Visible = false;
                                        if (round == 10)
                                        {
                                            d1 = a1;
                                            d2 = a2;
                                            d3 = a3;
                                            d4 = a4;
                                        }
                                        d = d1 * 1000 + d2 * 100 + d3 * 10 + d4;
                                        listBox2.Items.Add(c.ToString());
                                        #region Сравнения
                                        if (d1 == a1) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (d2 == a2) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (d3 == a3) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (d4 == a4) { listBox2.Items.Add("бык"); kol_b++; }

                                        if (d1 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d1 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d1 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (d2 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d2 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d2 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (d3 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d3 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d3 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (d4 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d4 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d4 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        #endregion
                                        d1 = 0; d2 = 0; d3 = 0; d4 = 0;
                                    }
                                    #endregion

                                    #region hard
                                    if (radioButton3.Checked == true)
                                    {
                                        radioButton2.Visible = false;
                                        radioButton1.Visible = false;
                                        radioButton4.Visible = false;
                                        radioButton5.Visible = false;
                                        if (round == 7)
                                        {
                                            d1 = a1;
                                            d2 = a2;
                                            d3 = a3;
                                            d4 = a4;
                                        }
                                        d = d1 * 1000 + d2 * 100 + d3 * 10 + d4;
                                        listBox2.Items.Add(c.ToString());
                                        #region Сравнения
                                        if (d1 == a1) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (d2 == a2) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (d3 == a3) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (d4 == a4) { listBox2.Items.Add("бык"); kol_b++; }

                                        if (d1 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d1 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d1 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (d2 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d2 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d2 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (d3 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d3 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d3 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (d4 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d4 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d4 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        #endregion
                                        d1 = 0; d2 = 0; d3 = 0; d4 = 0;
                                    }
                                    #endregion

                                    #region Impossible
                                    if (radioButton4.Checked == true)
                                    {
                                        radioButton2.Visible = false;
                                        radioButton3.Visible = false;
                                        radioButton1.Visible = false;
                                        radioButton5.Visible = false;

                                        d1 = a1;
                                        d2 = a2;
                                        d3 = a3;
                                        d4 = a4;
                                        d = d1 * 1000 + d2 * 100 + d3 * 10 + d4;
                                        listBox2.Items.Add(c.ToString());
                                        #region Сравнения
                                        if (d1 == a1) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (d2 == a2) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (d3 == a3) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (d4 == a4) { listBox2.Items.Add("бык"); kol_b++; }

                                        if (d1 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d1 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d1 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (d2 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d2 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d2 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (d3 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d3 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d3 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (d4 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d4 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (d4 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        #endregion
                                        d1 = 0; d2 = 0; d3 = 0; d4 = 0;
                                    }
                                    #endregion

                                    if (kol_b == 4 && h == 4)
                                    {
                                        MessageBox.Show("Число:  " + a.ToString(), "Ничья",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        if (h == 4)
                                        {
                                            result_pl = MessageBox.Show("Число:  " + a.ToString() + "\nЖелаете выйти?", "Вы выиграли!",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                            if (result_pl == DialogResult.Yes)
                                            {
                                                Application.Restart();
                                            }
                                        }

                                        if (kol_b == 4)
                                        {
                                            result_pc = MessageBox.Show("Число:  " + a.ToString() + "\nЖелаете выйти?", "Комп выиграл!",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                            if (result_pc == DialogResult.Yes)
                                            {
                                                Application.Restart();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
