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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Быки_и_коровы_new
{
    public partial class MainWindow : Window
    {
        SingleWindow single = new SingleWindow();
        MultiWindow multi = new MultiWindow();
        ComNumWindow PCgame = new ComNumWindow();

        Settings settings = new Settings();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            multi.check_settings(settings);
            ComboBoxItem item = (ComboBoxItem)listgame.SelectedItem;
            switch (item.Name)
            {
                case "S": single.Show(); break;
                case "M": multi.Show(); break;
                //case "PCc": PCgame.Show(); break;
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            settings.Show();
        }

    }
}
