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
    public partial class SingleWindow : Window
    {
        Random rand = new Random();
        int r, r1, r2, r3, r4 = 0;

        public SingleWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            do
            {
                r1 = rand.Next(1, 10);
                r2 = rand.Next(0, 10);
                r3 = rand.Next(0, 10);
                r4 = rand.Next(0, 10);
            }
            while (r1 == r2 || r1 == r3 || r1 == r4 || r2 == r3 || r2 == r4 || r3 == r4);
            r = r1 * 1000 + r2 * 100 + r3 * 10 + r4;
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            lbx1.Items.Clear();
            int n, n1, n2, n3, n4 = 0;
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
            tbk1.Text = n+"";

            n1 = n / 1000;
            n2 = n / 100 % 10;
            n3 = n / 10 % 10;
            n4 = n % 10;

            int b = 0, k = 0;

            k += n1 == r2 || n1 == r3 || n1 == r4 ? 1 : 0; b += n1 == r1 ? 1 : 0;
            k += n2 == r1 || n2 == r3 || n2 == r4 ? 1 : 0; b += n2 == r2 ? 1 : 0;
            k += n3 == r1 || n3 == r2 || n3 == r4 ? 1 : 0; b += n3 == r3 ? 1 : 0;
            k += n4 == r1 || n4 == r2 || n4 == r3 ? 1 : 0; b += n4 == r4 ? 1 : 0;

            while (k > 0) { lbx1.Items.Add("корова"); k--; }
            while (b > 0) { lbx1.Items.Add("бык"); b--; }

            if (n1 == r1 && n2 == r2 && n3 == r3 && n4 == r4) 
            {
                if (MessageBox.Show(
                    "Число отгадано\nПерезапустить?", 
                    "Конец", 
                    MessageBoxButton.OKCancel, 
                    MessageBoxImage.Information,
                    MessageBoxResult.OK) == MessageBoxResult.OK) 
                {
                    tbk1.Text = "Press number";
                    lbx1.Items.Clear();
                    tbx1.Text = "";
                    do
                    {
                        r1 = rand.Next(1, 10);
                        r2 = rand.Next(0, 10);
                        r3 = rand.Next(0, 10);
                        r4 = rand.Next(0, 10);
                    }
                    while (r1 == r2 || r1 == r3 || r1 == r4 || r2 == r3 || r2 == r4 || r3 == r4);
                    r = r1 * 1000 + r2 * 100 + r3 * 10 + r4;
                }
            }
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            tbk1.Text = "Press number";
            lbx1.Items.Clear();
            tbx1.Text = "";
            do
            {
                r1 = rand.Next(1, 10);
                r2 = rand.Next(0, 10);
                r3 = rand.Next(0, 10);
                r4 = rand.Next(0, 10);
            }
            while (r1 == r2 || r1 == r3 || r1 == r4 || r2 == r3 || r2 == r4 || r3 == r4);
            r = r1 * 1000 + r2 * 100 + r3 * 10 + r4;
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
