using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace РеализацияСимплекс_метода
{
    /// <summary>
    /// Класс главного окна
    /// </summary>
    public partial class MainWindow : Window
    {
        //создаем окно для вывода результатов
        Output push = new Output();
        //создаём экземпляр класса для вычислений симплекс-таблиц
        SimplexTable iterations = new SimplexTable();
        //массив значений целевой функции
        double[] NumFun;
        //массив значений свободных членов
        double[] FreeMember;
        //массив значений системы ограничений
        double[,] NumLimits;
        //массив значений базиных переменных
        double[,] NumBasis;
        /// <summary>
        /// Иницилаизация окна
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Изменение цели функции
        /// </summary>
        private void CB1_Click(object sender, RoutedEventArgs e)
        {
            CB1.Content = CB1.IsChecked == true ? "Максимизировать" : "Минимизировать";
            setup();
        }
        /// <summary>
        /// Изменениеколичества переменных или ограничений
        /// </summary>
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            setup();
        }
        /// <summary>
        /// Кнопка вычисления
        /// </summary>
        private void Result_Click(object sender, RoutedEventArgs e)
        {
            //проверка пустых значений
            if (CMBm.SelectedItem == null || CMBn.SelectedItem == null) {
                MessageBox.Show("Выберите количество переменных и/или ограничений.", "Ошибка ввода!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return; 
            }
            //считываем количество переменных и/или ограничений
            ComboBoxItem item1 = (ComboBoxItem)CMBn.SelectedItem;
            ComboBoxItem item2 = (ComboBoxItem)CMBm.SelectedItem;
            int n = Convert.ToInt32(item1.Content);
            int m = Convert.ToInt32(item2.Content);
            int newn = 0;
            #region Ввод значений с формы
            //проверяем количество неравенств
            for (int c = 0; c <= SystemLimits.Children.Count - 1; c++)
                if (SystemLimits.Children[c].GetType() == new ComboBox().GetType())
                    newn += SystemLimits.Children[c].GetValue(ComboBox.TextProperty).ToString() != "=" ? 1 : 0;
            //задаём размерность массивов
            NumFun = new double[n + newn];
            FreeMember = new double[m];
            NumLimits = new double[m, n];
            NumBasis = new double[m, newn];
            //запись коэффициентов целевой функции
            int k = 0;
            for (int i = 0; i < AimFun.Children.Count - 1; i++)
            {
                if (AimFun.Children[i].IsEnabled && SystemLimits.Children[i] != new ComboBox())
                {
                    double a;
                    Double.TryParse(AimFun.Children[i].GetValue(TextBox.TextProperty).ToString(), out a);
                    NumFun[k++] = a;
                }
            }
            for (int i = k; i < n+newn; i++)
                NumFun[i] = 0;
            //запись коэффициентов системы ограничений
            int k1 = 0;
            int k2 = 0;
            for (int c = 0; c <= SystemLimits.Children.Count - 1; c++)
            {
                //запись коэффициентов системы ограничений
                if (SystemLimits.Children[c].GetValue(TextBox.TextAlignmentProperty).ToString() == TextAlignment.Right.ToString() &&
                    SystemLimits.Children[c].GetType() != new ComboBox().GetType())
                {
                    if (k2 == n)
                    {
                        k1++;
                        k2 = 0;
                    }
                    Double.TryParse(SystemLimits.Children[c].GetValue(TextBox.TextProperty).ToString(), out NumLimits[k1, k2++]);
                }
                //запись свободных членов
                if (SystemLimits.Children[c].GetValue(TextBox.TextAlignmentProperty).ToString() == TextAlignment.Left.ToString() &&
                    SystemLimits.Children[c].IsEnabled &&
                    SystemLimits.Children[c].GetType() != new ComboBox().GetType())
                {
                    double a;
                    Double.TryParse(SystemLimits.Children[c].GetValue(TextBox.TextProperty).ToString(), out a);
                    FreeMember[k1] = a;
                }
            }
            #endregion
            //Создаем и задаём массив для базисного плана и промежуточных итераций
            int CountRow = m + 1;
            int CountColumn = n + newn + 1;
            double[,] StartValues = new double[CountRow, CountColumn+1];
            double[,] Next = new double[CountRow, CountColumn+1];
            //проверяем знаки системы ограничений и соответственно задаём значения базисных переменных
            #region перевод в каноническую форму системы ограничений
            k1 = 0;
            k2 = 0;
            for (int c = 0; c <= SystemLimits.Children.Count - 1; c++)
            {
                //запись базисных переменных
                if (SystemLimits.Children[c].GetType() == new ComboBox().GetType())
                {
                    for (k2 = 0; k2 < newn; k2++)
                    {
                        if (k1 == m) break;
                        switch (SystemLimits.Children[c].GetValue(ComboBox.TextProperty))
                        {
                            case "≤": NumBasis[k1, k2] = k1 == k2 ? 1 : 0; break;
                            case "≥": NumBasis[k1, k2] = k1 == k2 ? -1 : 0; break;
                                //case "=": NumBasis[k1, k2] = k1 == k2 ? 2 : 0; break;
                        }
                    }
                    k1++;
                }
            }
            #endregion
            //заполняем базисный план
            #region базисный план
            if ((bool)CB1.IsChecked)
            {
                //максимизация
                //коэффициенты небазисных, а после и базисных переменных
                for (int i = 0; i < m; i++)
                    for (int j = 0; j < n; j++)
                        StartValues[i, j] = NumLimits[i, j];
                for (int i = 0; i < m; i++)
                    for (int j = 0; j < newn; j++)
                        StartValues[i, n + j] = NumBasis[i, j];
                //свободные члены - предпоследний столбец
                for (int i = 0; i < m; i++)
                    StartValues[i, newn + n] = FreeMember[i] < 0 ? FreeMember[i] * -1 : FreeMember[i];
                //целевой функция - последняя строка
                for (int j = 0; j < n + newn; j++)
                    StartValues[m, j] = NumFun[j] * (-1);
            }
            else
            {
                //минимизация
                //коэффициенты небазисных, а после и базисных переменных
                for (int i = 0; i < m; i++)
                    for (int j = 0; j < n; j++)
                        StartValues[i, j] = NumLimits[i, j];
                for (int i = 0; i < m; i++)
                    for (int j = 0; j < newn; j++)
                        StartValues[i, n + j] = NumBasis[i, j];
                //свободные члены - предпоследний столбец
                for (int i = 0; i < m; i++)
                    StartValues[i, newn + n] = FreeMember[i] < 0 ? FreeMember[i] * -1 : FreeMember[i];
                //целевой функция - последняя строка
                for (int j = 0; j < n + newn; j++)
                    StartValues[m, j] = NumFun[j];
            }
            #endregion
            //вычисление симплекс-таблиц и вывод результатов
            #region итерации
            //список имён переменных в базисе
            string[] s = { };
            //счётчик итераций, для вывода
            int NumberIteration = 0;
            //очищаем от предыдущего вывода
            push.IterationView.Items.Clear();
            //вкладка для итерации
            TabItem iter;
            //элемент управления для вывода таблиц
            DataGrid dg;
            //таблица для вывода
            DataTable dt;
            //строка для добавления в таблицу
            DataRow row;
            //вычисление симплекс-отношений базисного плана
            Next = iterations.StartComputation(StartValues, CB1.IsChecked.Value);
            #region вывод базисного плана
            //Создаём новую вкладку для итерации
            iter = new TabItem { Header = "Итерация " + NumberIteration++ };
            //создаём новый объект класса DataGrid
            dg = new DataGrid();
            //задаём столбцы в DataGrid
            dg.Columns.Add(new DataGridTextColumn()
            {
                Header = "Базис",
                Binding = new Binding(string.Format("[{0}]", 0))
            });
            for (int i = 1; i < Next.GetLength(1)-1; i++)
                dg.Columns.Add(new DataGridTextColumn()
                {
                    Header = "x" + i,
                    Binding = new Binding(string.Format("[{0}]", i))
                });
            dg.Columns.Add(new DataGridTextColumn()
            {
                Header = "Свободные члены",
                Binding = new Binding(string.Format("[{0}]", Next.GetLength(1)-1))
            });
            dg.Columns.Add(new DataGridTextColumn()
            {
                Header = "Симплекс-отношения",
                Binding = new Binding(string.Format("[{0}]", Next.GetLength(1)))
            });
            //создаём таблицу для записи значений
            dt = new DataTable();
            //задаём ей столбцы
            dt.Columns.Add(new DataColumn() { ColumnName = "Basis" });
            for (int i = 1; i < Next.GetLength(1); i++)
                dt.Columns.Add(new DataColumn() { ColumnName = "x" + i });
            dt.Columns.Add(new DataColumn() { ColumnName = "Free" });
            dt.Columns.Add(new DataColumn() { ColumnName = "S" });
            //заполняем строки таблицы значениями
            for (int i = 0; i < Next.GetLength(0); i++)
            {
                //обнуляем строку
                row = dt.NewRow();
                //первое значение строки номер базисной переменной
                if(i < Next.GetLength(0) - 1)
                {
                    Array.Resize(ref s, i + 1);
                    s[i] = "x" + (n + i + 1);
                }
                row["Basis"] = i == Next.GetLength(0) - 1 ? "" : s[i];
                //остальные значения строки из массива итерации
                for (int j = 0; j < Next.GetLength(1); j++)
                    row[j+1] = i == Next.GetLength(0) - 1 && (j == Next.GetLength(1) - 1 || j == Next.GetLength(1) - 2) ? "" : Next[i, j] + "";
                //прикрепляем строку к таблице
                dg.Items.Add(row);
            }
            //прикрепляем таблицу ко вкладке
            iter.Content = dg;
            //прикрепляем вкладку к окну
            push.IterationView.Items.Add(iter);
            #endregion
            //вычисление первой итерации
            Next = iterations.StartComputation(Next, CB1.IsChecked.Value);
            //начинаем цикл, пока оптимум не будет достигнут
            while (!iterations.IsOptimum(Next) && NumberIteration < 100)
            {
                #region выводим текущую итерацию
                //Создаём новую вкладку для итерации
                iter = new TabItem { Header = "Итерация " + NumberIteration++ };
                //создаём новый объект класса DataGrid
                dg = new DataGrid();
                //задаём столбцы в DataGrid
                dg.Columns.Add(new DataGridTextColumn()
                {
                    Header = "Базис",
                    Binding = new Binding(string.Format("[{0}]", 0))
                });
                for (int i = 1; i < Next.GetLength(1)-1; i++)
                    dg.Columns.Add(new DataGridTextColumn()
                    {
                        Header = "x" + i,
                        Binding = new Binding(string.Format("[{0}]", i))
                    });
                dg.Columns.Add(new DataGridTextColumn()
                {
                    Header = "Свободные члены",
                    Binding = new Binding(string.Format("[{0}]", Next.GetLength(1)-1))
                });
                dg.Columns.Add(new DataGridTextColumn()
                {
                    Header = "Симплекс-отношения",
                    Binding = new Binding(string.Format("[{0}]", Next.GetLength(1)))
                });
                //создаём таблицу для записи значений
                dt = new DataTable();
                //задаём ей столбцы
                dt.Columns.Add(new DataColumn() { ColumnName = "Basis" });
                for (int i = 1; i < Next.GetLength(1); i++)
                    dt.Columns.Add(new DataColumn() { ColumnName = "x" + i });
                dt.Columns.Add(new DataColumn() { ColumnName = "Free" });
                dt.Columns.Add(new DataColumn() { ColumnName = "S" });
                //заполняем строки таблицы значениями
                for (int i = 0; i < Next.GetLength(0); i++)
                {
                    //обнуляем строку
                    row = dt.NewRow();
                    //первое значение строки номер базисной переменной
                    if (i < Next.GetLength(0) - 1)
                        s[i] = i == iterations.Search_ved_Row(iterations.Currentiteration) ? "x" + (iterations.Search_ved_Column(iterations.Currentiteration) + 1) : s[i];
                    row["Basis"] = i == Next.GetLength(0) - 1 ? "" : s[i];
                    //остальные значения строки из массива итерации
                    for (int j = 0; j < Next.GetLength(1); j++)
                        row[j + 1] = i == Next.GetLength(0) - 1 && (j == Next.GetLength(1) - 1 || j == Next.GetLength(1) - 2) ? "" : Next[i, j] + "";
                    //прикрепляем строку к таблице
                    dg.Items.Add(row);
                }
                //прикрепляем таблицу ко вкладке
                iter.Content = dg;
                //прикрепляем вкладку к окну
                push.IterationView.Items.Add(iter);
                #endregion
                //вычисляем следующую итерацию
                Next = iterations.StartComputation(Next, CB1.IsChecked.Value);
                //прверяем возмоность достигнуть оптимум
                if (iterations.Search_ved_Row(Next) == 1111) 
                    break;
                //после роверяется достигнут ли оптимум
                //если нет, то повторяем
                //если да то выводим оптимальный план и считаем значение целевой функции
            }
            #region вывод оптимального плана
            //Создаём новую вкладку для итерации
            iter = new TabItem { Header = "Итерация " + NumberIteration++ };
            //создаём новый объект класса DataGrid
            dg = new DataGrid();
            //задаём столбцы в DataGrid
            dg.Columns.Add(new DataGridTextColumn()
            {
                Header = "Базис",
                Binding = new Binding(string.Format("[{0}]", 0))
            });
            for (int i = 1; i < Next.GetLength(1) - 1; i++)
                dg.Columns.Add(new DataGridTextColumn()
                {
                    Header = "x" + i,
                    Binding = new Binding(string.Format("[{0}]", i))
                });
            dg.Columns.Add(new DataGridTextColumn()
            {
                Header = "Свободные члены",
                Binding = new Binding(string.Format("[{0}]", Next.GetLength(1) - 1))
            });
            //создаём таблицу для записи значений
            dt = new DataTable();
            //задаём ей столбцы
            dt.Columns.Add(new DataColumn() { ColumnName = "Basis" });
            for (int i = 1; i < Next.GetLength(1); i++)
                dt.Columns.Add(new DataColumn() { ColumnName = "x" + i });
            dt.Columns.Add(new DataColumn() { ColumnName = "Free" });
            dt.Columns.Add(new DataColumn() { ColumnName = "S" });
            //заполняем строки таблицы значениями
            for (int i = 0; i < Next.GetLength(0); i++)
            {
                //обнуляем строку
                row = dt.NewRow();
                //первое значение строки номер базисной переменной
                if (i < Next.GetLength(0) - 1)
                    s[i] = i == iterations.Search_ved_Row(iterations.Currentiteration) ? "x" + (iterations.Search_ved_Column(iterations.Currentiteration) + 1) : s[i];
                row["Basis"] = i == Next.GetLength(0) - 1 ? "" : s[i];
                for (int j = 0; j < Next.GetLength(1)-1; j++)
                    row[j + 1] = i == Next.GetLength(0) - 1 && (j == Next.GetLength(1) - 1 || j == Next.GetLength(1) - 2) ? "" : Next[i, j] + "";
                //прикрепляем строку к таблице
                dg.Items.Add(row);
            }
            //прикрепляем таблицу ко вкладке
            iter.Content = dg;
            //прикрепляем вкладку к окну
            push.IterationView.Items.Add(iter);
            #endregion
            #region Рассчёт и вывод значения целевой функции
            //Создаём новую вкладку для итерации
            iter = new TabItem { Header = "Решение" };
            //текстовое поле для вывода
            TextBlock TB = new TextBlock();
            //переменные для вывода
            string str = "";
            double sum = 0;
            //проверка результатов вычисления
            if (iterations.Search_ved_Row(Next) == 1111)
            {
                TB.Text = "Все симплекс-отношения отрицательны, оптимум не достигается";
            }
            else if(NumberIteration >= 100)
            {
                TB.Text = "Как вы уже догадались произошли технические неполадки.\nВозможно вы ввели некорректные данные";
            }
            else
            {
                iterations.AimFunValue(Next, FreeMember, NumFun, s, n, out sum, out str);
                TB.Text = "Значение целевой функции: \n" + str.Substring(0, str.Length - 2) + "= " + sum;
            }
            //прикрепляем выведенный результат к окну
            iter.Content = TB;
            push.IterationView.Items.Add(iter);
            #endregion
            //отображаем окно с результатом
            push.Show();
            #endregion
        }
        /// <summary>
        /// Отрисовка всех компонентов формы, для ввода значений
        /// </summary>
        void setup()
        {
            //проверка пустых значений
            if (CMBm.SelectedItem == null) CMBm.SelectedIndex = 0;
            if (CMBn.SelectedItem == null) CMBn.SelectedIndex = 0;
            //обнуление предыдущей формы
            AimFun.Children.Clear();
            SystemLimits.Children.Clear();
            //считываем количество переменных
            ComboBoxItem item = (ComboBoxItem)CMBn.SelectedItem;
            int n = Convert.ToInt32(item.Content);
            #region отрисовка целевой функции
            for (int i = 0; i < n; i++)
            {
                //текстовое поле для ввода
                TextBox tb = new TextBox();
                tb.Width = 50;
                tb.Height = 20;
                tb.Text = "1";
                tb.TextAlignment = TextAlignment.Right;
                AimFun.Children.Add(tb);
                //надпись с номером переменной этого поля
                TextBox lb = new TextBox();
                lb.IsEnabled = false;
                lb.Text = i == n - 1 ? "x" + (i+1) + " → " + CB1.Content : "x" + (i+1) + " + ";
                lb.Width = i == n - 1 ? 150 : 50;
                lb.Height = 20;
                AimFun.Children.Add(lb);
            }
            #endregion
            //считываем количество ограничений
            item = (ComboBoxItem)CMBm.SelectedItem;
            int m = Convert.ToInt32(item.Content);
            #region отрисовка системы ограничений
            SystemLimits.Columns = n * 2 + 2;
            SystemLimits.Width = n * 100 + 100;
            SystemLimits.Height = m * 20;
            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    //текстовое поле для ввода
                    TextBox tb = new TextBox();
                    tb.Width = 50;
                    tb.Height = 20;
                    tb.Text = "1";
                    tb.TextAlignment = TextAlignment.Right;
                    SystemLimits.Children.Add(tb);
                    //надпись с номером переменной этого поля
                    TextBox lb = new TextBox();
                    lb.IsEnabled = false;
                    lb.Text = i == n - 1 ? "x" + (i + 1) + " + " : "x" + (i + 1) + " + ";
                    lb.Width = 50;
                    lb.Height = 20;
                    SystemLimits.Children.Add(lb);
                }
                //выбор знака для текущего равенства/неравенства
                ComboBox cb = new ComboBox();
                cb.Width = 50;
                cb.Height = 20;
                cb.Text = "1";
                cb.SelectedIndex = 0;
                ComboBoxItem it = new ComboBoxItem();
                it.Content = "≤";
                cb.Items.Add(it);
                it = new ComboBoxItem();
                it.Content = "≥";
                cb.Items.Add(it);
                it = new ComboBoxItem();
                it.Content = "=";
                cb.Items.Add(it);
                SystemLimits.Children.Add(cb);
                TextBox tbl = new TextBox();
                //текстовое поле для ввода значения свободного члена
                tbl.Width = 50;
                tbl.Height = 20; 
                tbl.Text = "10";
                SystemLimits.Children.Add(tbl);
            }
            #endregion
        }
        /// <summary>
        /// Закрытие окна
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //если открыто второе окна - отмена
            //иначе завершить работу программы
            if (push.Visibility == Visibility.Visible) e.Cancel = true;
            else App.Current.Shutdown();
        }
    }
}
