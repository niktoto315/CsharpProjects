using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Быки_и_коровы_new
{
    public partial class MultiWindow : Window
    {
        Settings settings;

        public void check_settings(Settings s) 
        {
            settings = s;
        }

        public MultiWindow()
        {
            InitializeComponent();
        }

        int step = 0;
        int []plyr0 = { 0, 0, 0, 0, 0, 0 };
        int []plyr1 = { 0, 0, 0, 0, 0, 0 };

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            lbx1.Items.Clear();
            int n, n1, n2, n3, n4 = 0;


            if ((bool)settings.rBtnM1.IsChecked)
            {
                MessageBox.Show("Ещё в разработке", "Оповещение");
            }
            else if ((bool)settings.rBtnM2.IsChecked)
            {
                switch (step) 
                {
                    case 0:
                        #region plyr1
                        if (plyr0[0] == 0)
                        {
                            if (Int32.TryParse(tbx1.Text, out n))
                            {
                                if (n < 1023 || n > 9876)
                                {
                                    MessageBox.Show("Press number between 1023 and 9876 without repeat");
                                    return;
                                }
                                n1 = n / 1000;
                                n2 = n / 100 % 10;
                                n3 = n / 10 % 10;
                                n4 = n % 10;
                                if (n1 == n2 || n1 == n3 || n1 == n4 || n2 == n3 || n2 == n4 || n3 == n4)
                                {
                                    MessageBox.Show("Press number between 1023 and 9876 without repeat");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Press number");
                                return;
                            }

                            tbx1.Text = "";
                            plyr0[0] = n;

                            plyr0[2] = n / 1000;
                            plyr0[3] = n / 100 % 10;
                            plyr0[4] = n / 10 % 10;
                            plyr0[5] = n % 10;

                            MessageBox.Show("Игрок 1 загадал число");
                        }
                        else
                        {
                            if (Int32.TryParse(tbx1.Text, out n))
                            {
                                if (n < 1023 || n > 9876)
                                {
                                    MessageBox.Show("Press number between 1023 and 9876 without repeat");
                                    return;
                                }
                                n1 = n / 1000;
                                n2 = n / 100 % 10;
                                n3 = n / 10 % 10;
                                n4 = n % 10;
                                if (n1 == n2 || n1 == n3 || n1 == n4 || n2 == n3 || n2 == n4 || n3 == n4)
                                {
                                    MessageBox.Show("Press number between 1023 and 9876 without repeat");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Press number");
                                return;
                            }

                            tbk1.Text = tbx1.Text;
                            tbx1.Text = "";
                            plyr0[1] = n;

                            n1 = n / 1000;
                            n2 = n / 100 % 10;
                            n3 = n / 10 % 10;
                            n4 = n % 10;

                            int b = 0, k = 0;
                            k += n1 == plyr1[3] || n1 == plyr1[4] || n1 == plyr1[5] ? 1 : 0; b += n1 == plyr1[2] ? 1 : 0;
                            k += n2 == plyr1[2] || n2 == plyr1[4] || n2 == plyr1[5] ? 1 : 0; b += n2 == plyr1[3] ? 1 : 0;
                            k += n3 == plyr1[2] || n3 == plyr1[3] || n3 == plyr1[5] ? 1 : 0; b += n3 == plyr1[4] ? 1 : 0;
                            k += n4 == plyr1[2] || n4 == plyr1[3] || n4 == plyr1[4] ? 1 : 0; b += n4 == plyr1[5] ? 1 : 0;
                            while (k > 0) { lbx1.Items.Add("корова"); k--; }
                            while (b > 0) { lbx1.Items.Add("бык"); b--; }

                            if (n1 == plyr1[2] && n2 == plyr1[3] && n3 == plyr1[4] && n4 == plyr1[5])
                            {
                                if (MessageBox.Show(
                                    "Игрок 1 отгадал число первым\nПерезапустить?",
                                    "Конец",
                                    MessageBoxButton.OKCancel,
                                    MessageBoxImage.Information,
                                    MessageBoxResult.OK) == MessageBoxResult.OK)
                                {
                                    //reset
                                    tbk1.Text = "Press number";
                                    lbx1.Items.Clear();
                                    tbx1.Text = "";
                                    plyr0[0] = 0;
                                    plyr1[0] = 0;
                                }
                            }
                        }
                        step = 1;
                        #endregion
                        break;
                    case 1:
                        #region plyr2
                        if (plyr1[0] == 0)
                        {
                            if (Int32.TryParse(tbx1.Text, out n))
                            {
                                if (n < 1023 || n > 9876)
                                {
                                    MessageBox.Show("Press number between 1023 and 9876 without repeat");
                                    return;
                                }
                                n1 = n / 1000;
                                n2 = n / 100 % 10;
                                n3 = n / 10 % 10;
                                n4 = n % 10;
                                if (n1 == n2 || n1 == n3 || n1 == n4 || n2 == n3 || n2 == n4 || n3 == n4)
                                {
                                    MessageBox.Show("Press number between 1023 and 9876 without repeat");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Press number");
                                return;
                            }

                            tbx1.Text = "";
                            plyr1[0] = n;

                            plyr1[2] = n / 1000;
                            plyr1[3] = n / 100 % 10;
                            plyr1[4] = n / 10 % 10;
                            plyr1[5] = n % 10;

                            MessageBox.Show("Игрок 2 загадал число");
                        }
                        else
                        {
                            if (Int32.TryParse(tbx1.Text, out n))
                            {
                                if (n < 1023 || n > 9876)
                                {
                                    MessageBox.Show("Press number between 1023 and 9876 without repeat");
                                    return;
                                }
                                n1 = n / 1000;
                                n2 = n / 100 % 10;
                                n3 = n / 10 % 10;
                                n4 = n % 10;
                                if (n1 == n2 || n1 == n3 || n1 == n4 || n2 == n3 || n2 == n4 || n3 == n4)
                                {
                                    MessageBox.Show("Press number between 1023 and 9876 without repeat");
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Press number");
                                return;
                            }

                            tbk1.Text = tbx1.Text;
                            tbx1.Text = "";
                            plyr1[1] = n;

                            n1 = n / 1000;
                            n2 = n / 100 % 10;
                            n3 = n / 10 % 10;
                            n4 = n % 10;

                            int b = 0, k = 0;
                            k += n1 == plyr0[3] || n1 == plyr0[4] || n1 == plyr0[5] ? 1 : 0; b += n1 == plyr0[2] ? 1 : 0;
                            k += n2 == plyr0[2] || n2 == plyr0[4] || n2 == plyr0[5] ? 1 : 0; b += n2 == plyr0[3] ? 1 : 0;
                            k += n3 == plyr0[2] || n3 == plyr0[3] || n3 == plyr0[5] ? 1 : 0; b += n3 == plyr0[4] ? 1 : 0;
                            k += n4 == plyr0[2] || n4 == plyr0[3] || n4 == plyr0[4] ? 1 : 0; b += n4 == plyr0[5] ? 1 : 0;
                            while (k > 0) { lbx1.Items.Add("корова"); k--; }
                            while (b > 0) { lbx1.Items.Add("бык"); b--; }

                            if (n1 == plyr0[2] && n2 == plyr0[3] && n3 == plyr0[4] && n4 == plyr0[5])
                            {
                                if (MessageBox.Show(
                                    "Игрок 2 отгадал число первым\nПерезапустить?",
                                    "Конец",
                                    MessageBoxButton.OKCancel,
                                    MessageBoxImage.Information,
                                    MessageBoxResult.OK) == MessageBoxResult.OK)
                                {
                                    //reset
                                    tbk1.Text = "Press number";
                                    lbx1.Items.Clear();
                                    tbx1.Text = "";
                                    plyr0[0] = 0;
                                    plyr1[0] = 0;
                                }
                            }
                        }
                        step = 0;
                        #endregion
                        break;
                }
            }
            else
            {
                MessageBox.Show("Ti kak suda popal chudak?!", "?F??a?ta?l ??Er?r?or???");
            }
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            //reset
            tbk1.Text = "Press number";
            lbx1.Items.Clear();
            tbx1.Text = "";
            plyr0[0] = 0;
            plyr1[0] = 0;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
