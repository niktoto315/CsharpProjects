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
    public partial class Form3 : Form
    {
        public Form1 _form1;
        public Form3(Form1 form1)
        {
            _form1 = form1;
            InitializeComponent();
        }

        double b, b1;
        double c, c1;
        int k, n = 0;

        int but1 = 1;
        int but2 = 1;

        private void Form3_Load(object sender, EventArgs e)
        {
            Text = ("                                                                  PvP");
            label1.Text = ("Загадайте число сопернику");
            button1.Text = ("Загадать число, игрок 1");
            button2.Text = ("Загадать число, игрок 2");
        }

        #region but1
        private void button1_Click(object sender, EventArgs e)
        {
            switch (but1)
            {
                case 1:
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Введите число!", "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        c1 = Double.Parse(textBox1.Text);
                        if (c1 < 1000 || c1 >= 10000)
                        {
                            MessageBox.Show("Необходимо ввести число от 1000 до 9999", "Введено не подходящее число!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            button1.Text = ("Завершить ход, игрок 1");
                            c1 = Double.Parse(textBox1.Text);
                            textBox1.Clear();
                            textBox1.Enabled = false;
                            
                            button2.Enabled = true;
                            textBox2.Enabled = true;

                            but1++;
                            button1.Enabled = false;
                        }
                    }
                    break;
                case 2:
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Введите число!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        b = Double.Parse(textBox1.Text);
                        if (b < 1000 || b >= 10000)
                        {
                            MessageBox.Show("Необходимо ввести число от 1000 до 9999", "Введено не подходящее число!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            b = double.Parse(textBox1.Text);
                            listBox1.Items.Clear();
                            textBox1.Clear();

                            textBox1.Enabled = false;
                            button1.Enabled = false;

                            textBox2.Enabled = true;
                            button2.Enabled = true;

                            double a1 = (int)b1 / 1000;
                            double a2 = ((int)b1 / 100) % 10;
                            double a3 = ((int)b1 / 10) % 10;
                            double a4 = (int)b1 % 10;

                            double v1 = (int)b / 1000;
                            double v2 = ((int)b / 100) % 10;
                            double v3 = ((int)b / 10) % 10;
                            double v4 = (int)b % 10;

                            listBox1.Items.Add(b.ToString());
                            k = 0;
                            #region Сравнения
                            if (a1 == v1)
                            {
                                listBox1.Items.Add("бык");
                                k++;
                            }
                            if (a1 == v2)
                            {
                                listBox1.Items.Add("корова");
                            }
                            if (a1 == v3)
                            {
                                listBox1.Items.Add("корова");
                            }
                            if (a1 == v4)
                            {
                                listBox1.Items.Add("корова");
                            }
                            if (a2 == v2)
                            {
                                listBox1.Items.Add("бык");
                                k++;
                            }
                            if (a2 == v1)
                            {
                                listBox1.Items.Add("корова");
                            }
                            if (a2 == v3)
                            {
                                listBox1.Items.Add("корова");
                            }
                            if (a2 == v4)
                            {
                                listBox1.Items.Add("корова");
                            }
                            if (a3 == v3)
                            {
                                listBox1.Items.Add("бык");
                                k++;
                            }
                            if (a3 == v1)
                            {
                                listBox1.Items.Add("корова");
                            }
                            if (a3 == v2)
                            {
                                listBox1.Items.Add("корова");
                            }
                            if (a3 == v4)
                            {
                                listBox1.Items.Add("корова");
                            }
                            if (a4 == v4)
                            {
                                listBox1.Items.Add("бык");
                                k++;
                            }
                            if (a4 == v1)
                            {
                                listBox1.Items.Add("корова");
                            }
                            if (a4 == v2)
                            {
                                listBox1.Items.Add("корова");
                            }
                            if (a4 == v3)
                            {
                                listBox1.Items.Add("корова");
                            }
                            #endregion
                        }
                    }
                    if (k == 4)
                    {
                        MessageBox.Show("Число:  " + b1.ToString() + "\n Победил игрок 1", "Победа!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button2.Enabled = false;
                    }
                    break;
            }
        }
        #endregion

        #region but2
        private void button2_Click(object sender, EventArgs e)
        {
            switch (but2)
            {
                case 1:
                    if (textBox2.Text == "")
                    {
                        MessageBox.Show("Введите число!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        b1 = Double.Parse(textBox2.Text);
                        if (b1 < 1000 || b1 >= 10000)
                        {
                            MessageBox.Show("Необходимо ввести число от 1000 до 9999", "Введено не подходящее число!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            label1.Text = ("Отгадывайте число");
                            button2.Text = ("Завершить ход, игрок 2");
                            b1 = double.Parse(textBox2.Text);
                            textBox2.Clear();
                            textBox2.Enabled = false;
                            
                            button1.Enabled = true;
                            textBox1.Enabled = true;
                        }
                    }
                    but2++;
                    button2.Enabled = false;
                    break;
                case 2:
                    if (textBox2.Text == "")
                    {
                        MessageBox.Show("Введите число!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        c = Double.Parse(textBox2.Text);
                        if (c < 1000 || c >= 10000)
                        {
                            MessageBox.Show("Необходимо ввести число от 1000 до 9999", "Введено не подходящее число!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            c = double.Parse(textBox2.Text);
                            listBox2.Items.Clear();
                            textBox2.Clear();

                            textBox2.Enabled = false;
                            button2.Enabled = false;

                            textBox1.Enabled = true;
                            button1.Enabled = true;

                            double a1 = (int)c1 / 1000;
                            double a2 = ((int)c1 / 100) % 10;
                            double a3 = ((int)c1 / 10) % 10;
                            double a4 = (int)c1 % 10;

                            double v1 = (int)c / 1000;
                            double v2 = ((int)c / 100) % 10;
                            double v3 = ((int)c / 10) % 10;
                            double v4 = (int)c % 10;

                            listBox2.Items.Add(c.ToString());
                            n = 0;
                            #region Сравнения
                            if (a1 == v1)
                            {
                                listBox2.Items.Add("бык");
                                n++;
                            }
                            if (a1 == v2)
                            {
                                listBox2.Items.Add("корова");
                            }
                            if (a1 == v3)
                            {
                                listBox2.Items.Add("корова");
                            }
                            if (a1 == v4)
                            {
                                listBox2.Items.Add("корова");
                            }
                            if (a2 == v2)
                            {
                                listBox2.Items.Add("бык");
                                n++;
                            }
                            if (a2 == v1)
                            {
                                listBox2.Items.Add("корова");
                            }
                            if (a2 == v3)
                            {
                                listBox2.Items.Add("корова");
                            }
                            if (a2 == v4)
                            {
                                listBox2.Items.Add("корова");
                            }
                            if (a3 == v3)
                            {
                                listBox2.Items.Add("бык");
                                n++;
                            }
                            if (a3 == v1)
                            {
                                listBox2.Items.Add("корова");
                            }
                            if (a3 == v2)
                            {
                                listBox2.Items.Add("корова");
                            }
                            if (a3 == v4)
                            {
                                listBox2.Items.Add("корова");
                            }
                            if (a4 == v4)
                            {
                                listBox2.Items.Add("бык");
                                n++;
                            }
                            if (a4 == v1)
                            {
                                listBox2.Items.Add("корова");
                            }
                            if (a4 == v2)
                            {
                                listBox2.Items.Add("корова");
                            }
                            if (a4 == v3)
                            {
                                listBox2.Items.Add("корова");
                            }
                            #endregion
                        }
                    }
                    if (n == 4)
                    {
                        MessageBox.Show("Число:  " + c1.ToString() + "\n Победил игрок 2", "Победа!", 
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        button1.Enabled = false;
                    }
                    break;
            }
        }
        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
