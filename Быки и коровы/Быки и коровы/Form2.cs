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
    public partial class Form2 : Form
    {
        public Form1 _form1;
        public Form2(Form1 form1)
        {
            _form1 = form1;
            InitializeComponent();
        }

        Random r = new Random();
        double v, v1, v2, v3, v4;
        double a, a1, a2, a3, a4;

        #region генерация числа
        private void timer1_Tick(object sender, EventArgs e)
        {
            a1 = r.Next(1, 10);
            a2 = r.Next(0, 10);
            while (a2 == a1) { a2 = r.Next(0, 10); }
            a3 = r.Next(0, 10);
            while (a3 == a1 || a3 == a2) { a3 = r.Next(0, 10); }
            a4 = r.Next(0, 10);
            while (a4 == a1 || a4 == a2 || a4 == a3) { a4 = r.Next(0, 10); }
            timer1.Stop();
        }
        #endregion

        private void Form2_Load(object sender, EventArgs e)
        {
            button2.Text = ("Выход");
        }

        int k = 0;
        int p = 0;

        int but1 = 1;

        private void button1_Click(object sender, EventArgs e)
        {
            switch (but1)
            {
                case 1:
                    timer1.Start();
                    MessageBox.Show("Число было сгенерировано автоматически", "Оповещение", MessageBoxButtons.OK);
                    a = a1 * 1000 + a2 * 100 + a3 * 10 + a4;

                    but1++;
                    button1.Text = ("Проверить число");
                    break;
                case 2:
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Введите число от 1000 до 9999", "Число не введено!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        v = Double.Parse(textBox1.Text);
                        if (v < 1000 || v >= 10000)
                        {
                            MessageBox.Show("Введите число от 1000 до 9999", "Введено не подходящее число!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (v >= 1000 || v <= 9999)
                        {
                            listBox1.Items.Clear();
                            textBox1.Clear();
                            v1 = (int)v / 1000;
                            v2 = ((int)v / 100) % 10;
                            v3 = ((int)v / 10) % 10;
                            v4 = v % 10;
                            k = 0;
                            listBox1.Items.Add(v.ToString() + "\n\n");
                            //listBox1.Items.Add(a.ToString() + "\n\n");
                            #region Сравнения
                            if (a1 == v1)
                            {
                                listBox1.Items.Add("бык");
                                k++;
                            }
                            if (a1 == v2 || a1 == v3 || a1 == v4)
                            {
                                listBox1.Items.Add("корова");
                            }
                            if (a2 == v2)
                            {
                                listBox1.Items.Add("бык");
                                k++;
                            }
                            if (a2 == v1 || a2 == v3 || a2 == v4)
                            {
                                listBox1.Items.Add("корова");
                            }
                            if (a3 == v3)
                            {
                                listBox1.Items.Add("бык");
                                k++;
                            }
                            if (a3 == v1 || a3 == v2 || a3 == v4)
                            {
                                listBox1.Items.Add("корова");
                            }
                            if (a4 == v4)
                            {
                                listBox1.Items.Add("бык");
                                k++;
                            }
                            if (a4 == v1 || a4 == v2 || a4 == v3)
                            {
                                listBox1.Items.Add("корова");
                            }
                            #endregion
                        }
                    }
                    if (k == 4)
                    {
                        MessageBox.Show("Вы отгадали! \n\nЧисло:  " + a.ToString(), "Результат", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button1.Enabled = false;
                    }
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
