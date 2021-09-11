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
    public partial class Form5 : Form
    {
        public Form1 _form1;
        public Form5(Form1 form1)
        {
            _form1 = form1;
            InitializeComponent();
        }

        Random r = new Random();
        double a, a1, a2, a3, a4 = 0;
        double b, b1, b2, b3, b4 = 0;
        double c1, c2, c3, c4 = 0;
        double c = 999;

        int kol_b, kol_k = 0;
        int h, k = 0;

        int but1 = 1;
        int round = 0;

        DialogResult result_pl;
        DialogResult result_pc;

        private void Form5_Load(object sender, EventArgs e)
        {
            Text = ("                                    В разработке");
            label1.Text = ("Введите число: ");
            label2.Text = ("Раунд: " + round);
            label3.Text = ("Сложность: ");
            button1.Text = ("Загадать число");
            button2.Text = ("Выход");

            radioButton1.Text = ("Лёгкая");
            radioButton2.Text = ("Средняя");
            radioButton3.Text = ("Сложная");

            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            label3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (but1)
            {
                case 1:
                    #region Загадывание чисел
                    label1.Text = ("Введите число");

                    a1 = r.Next(1, 10);
                    a2 = r.Next(0, 10);
                    while (a2 == a1) { a2 = r.Next(0, 10); }
                    a3 = r.Next(0, 10);
                    while (a3 == a1 || a3 == a2) { a3 = r.Next(0, 10); }
                    a4 = r.Next(0, 10);
                    while (a4 == a1 || a4 == a2 || a4 == a3) { a4 = r.Next(0, 10); }
                    a = a1 * 1000 + a2 * 100 + a3 * 10 + a4;

                    MessageBox.Show("Число было загадано автоматически.", "Оповещение", MessageBoxButtons.OK);
                    button1.Text = ("Завершить раунд");
                    but1++;

                    radioButton1.Visible = true;
                    radioButton2.Visible = true;
                    radioButton3.Visible = true;
                    label3.Visible = true;

                    #endregion
                    break;
                case 2:
                    listBox1.Items.Clear();
                    listBox2.Items.Clear();
                    #region Проверка чисел
                    if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
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
                                b1 = (int)b / 1000;
                                b2 = (int)(b / 100) % 10;
                                b3 = (int)(b / 10) % 10;
                                b4 = b % 10;
                                if (b1 == b2 || b1 == b3 || b1 == b4 || b2 == b3 || b2 == b4 || b3 == b4 || b1 == 0)
                                {
                                    MessageBox.Show("Игра будет интересней, \nесли число будет из разных цифр(без повторов)", "Введено не подходящее число!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    round++;
                                    label2.Text = ("Раунд " + round);

                                    //Отгадывает игрок
                                    b = Double.Parse(textBox1.Text);
                                    listBox1.Items.Add(b.ToString());
                                    b1 = (int)b / 1000;
                                    b2 = (int)(b / 100) % 10;
                                    b3 = (int)(b / 10) % 10;
                                    b4 = b % 10;
                                    k = 0; h = 0;

                                    #region Сравнения
                                    if (b1 == a1) { listBox1.Items.Add("бык"); h++; }
                                    if (b2 == a2) { listBox1.Items.Add("бык"); h++; }
                                    if (b3 == a3) { listBox1.Items.Add("бык"); h++; }
                                    if (b4 == a4) { listBox1.Items.Add("бык"); h++; }

                                    if (b1 == a2) { listBox1.Items.Add("корова"); k++; }
                                    if (b1 == a3) { listBox1.Items.Add("корова"); k++; }
                                    if (b1 == a4) { listBox1.Items.Add("корова"); k++; }

                                    if (b2 == a1) { listBox1.Items.Add("корова"); k++; }
                                    if (b2 == a3) { listBox1.Items.Add("корова"); k++; }
                                    if (b2 == a4) { listBox1.Items.Add("корова"); k++; }

                                    if (b3 == a1) { listBox1.Items.Add("корова"); k++; }
                                    if (b3 == a2) { listBox1.Items.Add("корова"); k++; }
                                    if (b3 == a4) { listBox1.Items.Add("корова"); k++; }

                                    if (b4 == a1) { listBox1.Items.Add("корова"); k++; }
                                    if (b4 == a2) { listBox1.Items.Add("корова"); k++; }
                                    if (b4 == a3) { listBox1.Items.Add("корова"); k++; }
                                    #endregion

                                    //ИИ
                                    kol_b = 0; kol_k = 0;

                                    #region easy
                                    if (radioButton1.Checked == true)
                                    {
                                        radioButton2.Visible = false;
                                        radioButton3.Visible = false;
                                        c++;
                                        c1 = (int)c / 1000;
                                        c2 = (int)(c / 100) % 10;
                                        c3 = (int)(c / 10) % 10;
                                        c4 = c % 10;
                                        c = c1 * 1000 + c2 * 100 + c3 * 10 + c4;
                                        while (c1 == c2 || c1 == c3 || c1 == c4 || c2 == c3 || c2 == c4 || c3 == c4 || c1 == 0)
                                        {
                                            c++;
                                            c1 = (int)c / 1000;
                                            c2 = (int)(c / 100) % 10;
                                            c3 = (int)(c / 10) % 10;
                                            c4 = c % 10;
                                            c = c1 * 1000 + c2 * 100 + c3 * 10 + c4;
                                        }
                                        c1 = (int)c / 1000;
                                        c2 = (int)(c / 100) % 10;
                                        c3 = (int)(c / 10) % 10;
                                        c4 = c % 10;
                                        c = c1 * 1000 + c2 * 100 + c3 * 10 + c4;
                                        listBox2.Items.Add(c.ToString());
                                        #region Сравнения
                                        if (c1 == a1) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (c2 == a2) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (c3 == a3) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (c4 == a4) { listBox2.Items.Add("бык"); kol_b++; }

                                        if (c1 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c1 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c1 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (c2 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c2 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c2 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (c3 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c3 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c3 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (c4 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c4 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c4 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        #endregion
                                    }
                                    #endregion

                                    #region normal
                                    if (radioButton2.Checked == true)
                                    {
                                        c1 = r.Next(1, 10);
                                        c2 = r.Next(0, 10);
                                        while (c2 == c1) { c2 = r.Next(0, 10); }
                                        c3 = r.Next(0, 10);
                                        while (c3 == c1 || c3 == c2) { c3 = r.Next(0, 10); }
                                        c4 = r.Next(0, 10);
                                        while (c4 == c1 || c4 == c2 || c4 == c3) { c4 = r.Next(0, 10); }
                                        c = c1 * 1000 + c2 * 100 + c3 * 10 + c4;
                                        radioButton1.Visible = false;
                                        radioButton3.Visible = false;
                                        if (round == 10)
                                        {
                                            c1 = a1;
                                            c2 = a2;
                                            c3 = a3;
                                            c4 = a4;
                                        }
                                        listBox2.Items.Add(c.ToString());
                                        #region Сравнения
                                        if (c1 == a1) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (c2 == a2) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (c3 == a3) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (c4 == a4) { listBox2.Items.Add("бык"); kol_b++; }

                                        if (c1 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c1 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c1 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (c2 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c2 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c2 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (c3 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c3 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c3 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (c4 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c4 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c4 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        #endregion
                                        c1 = 0; c2 = 0; c3 = 0; c4 = 0;
                                    }
                                    #endregion

                                    #region hard
                                    if (radioButton3.Checked == true)
                                    {
                                        c1 = r.Next(1, 10);
                                        c2 = r.Next(0, 10);
                                        while (c2 == c1) { c2 = r.Next(0, 10); }
                                        c3 = r.Next(0, 10);
                                        while (c3 == c1 || c3 == c2) { c3 = r.Next(0, 10); }
                                        c4 = r.Next(0, 10);
                                        while (c4 == c1 || c4 == c2 || c4 == c3) { c4 = r.Next(0, 10); }
                                        c = c1 * 1000 + c2 * 100 + c3 * 10 + c4;
                                        radioButton1.Visible = false;
                                        radioButton2.Visible = false;
                                        if (round == 7)
                                        {
                                            c1 = a1;
                                            c2 = a2;
                                            c3 = a3;
                                            c4 = a4;
                                        }
                                        listBox2.Items.Add(c.ToString());
                                        #region Сравнения
                                        if (c1 == a1) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (c2 == a2) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (c3 == a3) { listBox2.Items.Add("бык"); kol_b++; }
                                        if (c4 == a4) { listBox2.Items.Add("бык"); kol_b++; }

                                        if (c1 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c1 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c1 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (c2 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c2 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c2 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (c3 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c3 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c3 == a4) { listBox2.Items.Add("корова"); kol_k++; }

                                        if (c4 == a1) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c4 == a2) { listBox2.Items.Add("корова"); kol_k++; }
                                        if (c4 == a3) { listBox2.Items.Add("корова"); kol_k++; }
                                        #endregion
                                        c1 = 0; c2 = 0; c3 = 0; c4 = 0;
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