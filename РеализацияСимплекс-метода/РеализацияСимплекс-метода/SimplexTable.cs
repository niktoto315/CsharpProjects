using System;

namespace РеализацияСимплекс_метода
{
    /// <summary>
    /// Класс, объект которого принимает текущую итерацию, а возращает следующую
    /// </summary>
    class SimplexTable
    {
        //ведущая строк
        public int ved_Row;
        //ведущий столбец
        public int ved_Column;
        //массив для текущей итерации
        public double[,] Currentiteration;
        //массив для следующей итерации
        public double[,] Nextiteration;
        //Значение чекбокса, отмечающее функцию цели (максимум или минимум)
        private bool Max = false;

        #region Вычисление симплекс-таблиц
        public double[,] StartComputation(double[,] BasisPlan, bool CBFun)
        {
            //считываем состояние чекбокса
            Max = CBFun;
            //задаем размерность массивов соответственно принимаемому плану
            Currentiteration = new double[BasisPlan.GetLength(0), BasisPlan.GetLength(1)];
            Nextiteration = new double[BasisPlan.GetLength(0), BasisPlan.GetLength(1)];
            //копируем план в текущую итерацию
            Array.Copy(BasisPlan, Currentiteration, BasisPlan.Length);
            //вычисляем сумму столбца симплекс-отношени
            double sum = 0;
            for (int i = 0; i < Currentiteration.GetLength(0) - 1; i++)
                sum += Math.Abs(Currentiteration[i, Currentiteration.GetLength(1) - 1]);
            //если сумма симплекс-отношений = 0, то вычисляем только их (необходимо для нулевой итерации)
            if (sum == 0)
            {
                //вычислем ведущий столбец
                ved_Column = Search_ved_Column(Currentiteration);
                //знаю ведущий столбец, вычисялем симлекс-отношений и выводим план
                ResultNextSimple(Currentiteration);
                return Currentiteration;
            }
            else
            {
                //проверяем условие оптимальности
                if (!IsOptimum(Currentiteration))
                {
                    //вычислем ведущий столбец
                    ved_Column = Search_ved_Column(Currentiteration);
                    //вычислем ведущую строку
                    ved_Row = Search_ved_Row(Currentiteration);
                    //проверяем наличие положительного симплекс-отношения, и заершаем если таких нет
                    if (ved_Row == 1111) return Currentiteration;
                    //преобразуем текущую итерацию в следующую, запиывая их в массив следующей итерации
                    //Разные массиы имеют значение, как минимум для вывода промежуточных таблиц
                    TransformationPlan();
                    //знаю ведущий столбец, вычисялем симлекс-отношений и выводим план
                    ResultNextSimple(Nextiteration);
                }
                return Nextiteration;
            }
        }
        #endregion

        #region Вывод симплекс-отношений
        private void ResultNextSimple(double[,] Plan)
        {
            //вычисляем ведущий столбец
            ved_Column = Search_ved_Column(Plan);
            //симплекс-отношения - последний столбец (количество столбцов - 1)
            //свободные члены - предпоследний столбец (количество столбцов - 2)
            //значения ведуего столбца - ведущий столбец (ved_Сolumn)
            for (int i = 0; i < Plan.GetLength(0) - 1; i++)
                Plan[i, Plan.GetLength(1) - 1] = Math.Round(Plan[i, Plan.GetLength(1) - 2] / Plan[i, ved_Column], 2);
        }
        #endregion

        #region Преобразование симплекс таблицы по правилу прямоугольника
        private void TransformationPlan()
        {
            //преобразуем ведущую строку
            //элемент ведущей строки делим на ведущий элемент
            for (int i = 0; i < Currentiteration.GetLength(1)-1; i++)
                Nextiteration[ved_Row, i] = Math.Round(Currentiteration[ved_Row, i] / Currentiteration[ved_Row, ved_Column], 2);
            //обнуляем ведущий столбец, кроме ведущего столбца
            for (int i = 0; i < Currentiteration.GetLength(0); i++)
                Nextiteration[i, ved_Column] = i == ved_Row ? 1 : 0;
            //вычисляем все остальные необходимые элементы по правилу прямоугольника
            for (int i = 0; i < Currentiteration.GetLength(0); i++)
                for (int j = 0; j < Currentiteration.GetLength(1)-1; j++)
                    if (i != ved_Row && j != ved_Column)
                        Nextiteration[i, j] = Math.Round(Currentiteration[i, j] - 
                            (Currentiteration[ved_Row, j] * 
                            Currentiteration[i, ved_Column] / 
                            Currentiteration[ved_Row, ved_Column]), 2);
        }
        #endregion

        #region Проверка на оптимальность
        public bool IsOptimum(double[,] Plan)
        {
            //проверяем цель функции
            if (Max)
            {
                //проверяем последнюю строку таблицы на наличие отрицательных значений
                //если есть хотя бы один выводим false
                for (int i = 0; i < Plan.GetLength(1) - 1; i++)
                {
                    if (Plan[Plan.GetLength(0) - 1, i] < 0) return false;

                }
                return true;
            }
            else
            {
                //проверяем последнюю строку таблицы на наличие положительных значений
                //если есть хотя бы один выводим false
                for (int i = 0; i < Plan.GetLength(1) - 1; i++)
                {
                    if (Plan[Plan.GetLength(0) - 1, i] > 0) return false;

                }
                return true;
            }
        }
        #endregion

        #region Поиск ведущей строки и провверка симплекс-отношений на неотрицательность(1111)
        public int Search_ved_Row(double[,] Plan)
        {
            //задаём флаг неотрицательности симлекс-отношений
            bool NotOptimum = false;
            //проверяем наличие хотя бы одного положительнго симплекс-отношения
            for (int i = 0; i < Plan.GetLength(0) - 1; i++)
                if (Plan[i, Plan.GetLength(1) - 1] < 0) NotOptimum = true;
                else
                {
                    NotOptimum = false;
                    break;
                }
            //отмечаем минимальным первое симлекс-отношение
            double min = Plan[0, Plan.GetLength(1) - 1];
            ved_Row = 0;
            //начинаем с второго и находим минимальное среди положительных
            for (int i = 1; i < Plan.GetLength(0) - 1; i++)
                if (Plan[i, Plan.GetLength(1) - 1] > 0 && Plan[i, Plan.GetLength(1) - 1] < min)
                {
                    min = Plan[i, Plan.GetLength(1) - 1];
                    ved_Row = i;
                }
            //если нет положительных отношений выводим аномально большой номер ведущей строки, которого просто не может быть
            //так сделано, потому метод возращает целое число
            //а указывать дополнительный выходной параметр будет лишним на мой скромный взгляд
            return NotOptimum ? 1111 : ved_Row;
        }
        #endregion

        #region Поиск ведущего столбца
        public int Search_ved_Column(double[,] Plan)
        {
            //сохраняем в максимум первый элемент
            double max = Plan[Plan.GetLength(0) - 1, 0];
            ved_Column = 0;
            //проверяем цель функции
            if (Max)
            {
                //максимизация
                //начинаем с второго и находим минимальный среди отрицательных
                for (int i = 1; i < Plan.GetLength(1) - 2; i++)
                    if (Plan[Plan.GetLength(0) - 1, i] < 0 && Plan[Plan.GetLength(0) - 1, i] < max)
                    {
                        max = Plan[Plan.GetLength(0) - 1, i];
                        ved_Column = i;
                    }
            }
            else
            {
                //минимизация
                //начинаем с второго и находим максимальный среди положительных
                for (int i = 1; i < Plan.GetLength(1) - 2; i++)
                    if (Plan[Plan.GetLength(0) - 1, i] > 0 && Plan[Plan.GetLength(0) - 1, i] > max)
                    {
                        max = Plan[Plan.GetLength(0) - 1, i];
                        ved_Column = i;
                    }
            }
            //дополнительно возращаем индекс ведущего столбца
            return ved_Column;
        }
        #endregion

        #region Вычисление значения целевой функции
        public void AimFunValue(double[,] Plan, double[] Free, double[] NumFun, string[] BasX, int n, out double sum, out string str)
        {
            ///этот метод вызывается уже вне цикла вычислений, и потому тут так много входных параметров
            //массив - вектор решения
            double[] SumFun = new double[n];
            //строка для вывода
            str = "";
            //значение функции
            sum = 0;
            //перебираем количество переменных исходной целевой функции
            for (int t = 0; t < n; t++)
            {
                //перебираем строки с номерами базисных переменных
                for (int i = 0; i < BasX.Length; i++)
                    //заполняем базисные переменные значениями предпоследнего столбца
                    //учитывая знак исходного значения свободного члена
                    //небазисные переменные остаются нулевыми
                    if (BasX[i][1].ToString() == (t + 1).ToString())
                        SumFun[t] = Free[i] < 0 ?
                            Plan[i, Plan.GetLength(1) - 2] * -1 :
                            Plan[i, Plan.GetLength(1) - 2];
                //получив вектор решения, читаем значение целевой функции
                sum += NumFun[t] * SumFun[t];
                //и записываем в строку выражение, для более подвинутого вывода
                str += NumFun[t] + "*" + SumFun[t] + " + ";
            }
        }
        #endregion
    }
}
