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

namespace Крестики_Нолики
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// Тут обитают слоны, будьте бдительны!
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int[,] cells = { {0, 0, 0}, {0, 0, 0}, {0, 0, 0} };
        bool step = true;
        string msg = "Ничья";

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            #region столбец 1
            if (e.GetPosition(null).X >= 0 && e.GetPosition(null).X < 100 &&
                e.GetPosition(null).Y >= 0 && e.GetPosition(null).Y < 100 && cells[0, 0] == 0)
            {
                if (step) 
                { 
                    DrawCross(10, 10, 90, 90); 
                    cells[0, 0] = 1; 
                }
                else 
                { 
                    DrawNull(-200, -200, 40); 
                    cells[0, 0] = 2; 
                }
            }
            else if (e.GetPosition(null).X >= 0 && e.GetPosition(null).X < 100 &&
                e.GetPosition(null).Y >= 100 && e.GetPosition(null).Y < 200 && cells[0, 1] == 0)
            {
                if (step)
                {
                    DrawCross(10, 110, 90, 190);
                    cells[0, 1] = 1;
                }
                else
                {
                    DrawNull(-200, 0, 40);
                    cells[0, 1] = 2;
                }
            }
            else if (e.GetPosition(null).X >= 0 && e.GetPosition(null).X < 100 &&
                e.GetPosition(null).Y >= 200 && e.GetPosition(null).Y < 300 && cells[0, 2] == 0)
            {
                if (step)
                {
                    DrawCross(10, 210, 90, 290);
                    cells[0, 2] = 1;
                }
                else
                {
                    DrawNull(-200, 200, 40);
                    cells[0, 2] = 2;
                }
            }
            #endregion
            #region столбец 2
            else if (e.GetPosition(null).X >= 100 && e.GetPosition(null).X < 200 &&
                e.GetPosition(null).Y >= 0 && e.GetPosition(null).Y < 100 && cells[1, 0] == 0)
            {
                if (step)
                {
                    DrawCross(110, 10, 190, 90);
                    cells[1, 0] = 1;
                }
                else
                {
                    DrawNull(0, -200, 40);
                    cells[1, 0] = 2;
                }
            }
            else if (e.GetPosition(null).X >= 100 && e.GetPosition(null).X < 200 &&
                e.GetPosition(null).Y >= 100 && e.GetPosition(null).Y < 200 && cells[1, 1] == 0)
            {
                if (step)
                {
                    DrawCross(110, 110, 190, 190);
                    cells[1, 1] = 1;
                }
                else
                {
                    DrawNull(0, 0, 40);
                    cells[1, 1] = 2;
                }
            }
            else if (e.GetPosition(null).X >= 100 && e.GetPosition(null).X < 200 &&
                e.GetPosition(null).Y >= 200 && e.GetPosition(null).Y < 300 && cells[1, 2] == 0)
            {
                if (step)
                {
                    DrawCross(110, 210, 190, 290);
                    cells[1, 2] = 1;
                }
                else
                {
                    DrawNull(0, 200, 40);
                    cells[1, 2] = 2;
                }
            }
            #endregion
            #region столбец 3
            else if (e.GetPosition(null).X >= 200 && e.GetPosition(null).X < 300 &&
                e.GetPosition(null).Y >= 0 && e.GetPosition(null).Y < 100 && cells[2, 0] == 0)
            {
                if (step)
                {
                    DrawCross(210, 10, 290, 90);
                    cells[2, 0] = 1;
                }
                else
                {
                    DrawNull(200, -200, 40);
                    cells[2, 0] = 2;
                }
            }
            else if (e.GetPosition(null).X >= 200 && e.GetPosition(null).X < 2300 &&
                e.GetPosition(null).Y >= 100 && e.GetPosition(null).Y < 200 && cells[2, 1] == 0)
            {
                if (step)
                {
                    DrawCross(210, 110, 290, 190);
                    cells[2, 1] = 1;
                }
                else
                {
                    DrawNull(200, 0, 40);
                    cells[2, 1] = 2;
                }
            }
            else if (e.GetPosition(null).X >= 200 && e.GetPosition(null).X < 300 &&
                e.GetPosition(null).Y >= 200 && e.GetPosition(null).Y < 300 && cells[2, 2] == 0)
            {
                if (step)
                {
                    DrawCross(210, 210, 290, 290);
                    cells[2, 2] = 1;
                }
                else
                {
                    DrawNull(200, 200, 40);
                    cells[2, 2] = 2;
                }
            }
            #endregion
            step = !step;
            if (WinCross())EndGame("Победа крестиков");
            else if (WinNulls()) EndGame("Победа нулей");
            else if (P())EndGame(msg);
        }

        bool WinCross()
        {
            for (int j = 0; j < 3; j++)
            {
                if ((cells[j, 0] == 1 && cells[j, 1] == 1 && cells[j, 2] == 1) ||
                    (cells[0, j] == 1 && cells[1, j] == 1 && cells[2, j] == 1)) return true;
            }
            if ((cells[0, 0] == 1 && cells[1, 1] == 1 && cells[2, 2] == 1) ||
                (cells[2, 0] == 1 && cells[1, 1] == 1 && cells[0, 2] == 1)) return true;
            else return false;
        }

        bool WinNulls()
        {
            for (int j = 0; j < 3; j++)
            {
                if ((cells[j, 0] == 2 && cells[j, 1] == 2 && cells[j, 2] == 2) ||
                    (cells[0, j] == 2 && cells[1, j] == 2 && cells[2, j] == 2)) return true;
            }
            if ((cells[0, 0] == 2 && cells[1, 1] == 2 && cells[2, 2] == 2) ||
                (cells[2, 0] == 2 && cells[1, 1] == 2 && cells[0, 2] == 2)) return true;
            else return false;
        }

        bool P() 
        {
            bool b = true;
            for (int i = 0; i < 3; i++)  
            {
                for (int j = 0; j < 3; j++)
                {
                    if (cells[i, j] == 0)return false;
                    else b = true;
                }
            }
            return b;
        }

        void EndGame(string msg) 
        {
            MessageBox.Show(msg + "\nИгра будет перезапущена автоматически", "Конец игры", MessageBoxButton.OK);
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        void DrawCross(double x1, double y1, double x2, double y2)
        {
            Line left = new Line();
            left.X1 = x1;
            left.Y1 = y1;
            left.X2 = x2;
            left.Y2 = y2;
            left.Stroke = Brushes.Black;
            Line right = new Line();
            right.X1 = x2;
            right.Y1 = y1;
            right.X2 = x1;
            right.Y2 = y2;
            right.Stroke = Brushes.Black;

            MyGrid.Children.Add(left);
            MyGrid.Children.Add(right);
        }

        void DrawNull(double x, double y, double r)
        {
            Ellipse ell = new Ellipse();
            ell.Stroke = Brushes.Black;
            ell.Width = r;
            ell.Height = r * 2;
            ell.Margin = new Thickness(x, y, 0, 0);
            MyGrid.Children.Add(ell);
        }
    }
}
