using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace japan_scanvord
{
    class Game
    {
        private int LenW;
        private int LenH;
        private int[,] MCurr;

        public int ColumnCount;
        public int LineCount;

        public bool Create = false;

        public Game(int w, int h, int[,] map)
        {
            LenW = w;
            LenH = h;
            MCurr = map;
        }

        public bool Checking(int[,] MPlayer)
        {
            for (int i = 0; i < LenW; i++)
                for (int j = 0; j < LenH; j++) {
                    if (MPlayer[i, j] == 1 || MCurr[i, j] == 1)
                        if (MCurr[i, j] != MPlayer[i, j]) return false;
                }
            return true;
        }

        public int[,] ResizeField(int[,] Map, string type)
        {
            int[,] newMap = Map;
            switch (type)
            {
                case "AddRow":
                    if (Map.GetLength(0) < 20)
                        newMap = new int[Map.GetLength(0) + 1, Map.GetLength(1)];
                    break;
                case "RemoveRow":
                    if (Map.GetLength(0) > 3)
                        newMap = new int[Map.GetLength(0) - 1, Map.GetLength(1)];
                    break;
                case "AddCol":
                    if (Map.GetLength(1) < 20)
                        newMap = new int[Map.GetLength(0), Map.GetLength(1) + 1];
                    break;
                case "RemoveCol":
                    if (Map.GetLength(1) > 3)
                        newMap = new int[Map.GetLength(0), Map.GetLength(1) - 1];
                    break;
            }

            for (int i = 0; i < newMap.GetLength(0); i++)
                for (int j = 0; j < newMap.GetLength(1); j++)
                    newMap[i, j] = i >= Map.GetLength(0) || j >= Map.GetLength(1) ? 0 : Map[i, j];

            return newMap;
        }

        #region Проверка заполнение строк/столбцов
        public bool CheckCols(int[,] MPlayer, string[] str, int j)
        {
            string StrMap = "", StrNums = "";
            int sum = 0;
            for (int k = 0; k < str.Length; k++)
            {
                StrNums += str[k];
            }
            for (int k = 0; k < MPlayer.GetLength(0); k++)
            {
                if (MPlayer[k, j] == 1)
                    sum++;
                else if (MPlayer[k, j] != 1)
                {
                    if (sum == 0)
                        continue;
                    StrMap += sum;
                    sum = 0;
                }
            }
            if (sum != 0) StrMap += sum;
            return StrMap == StrNums;
        }
        public bool CheckRows(int[,] MPlayer, string[] str, int i)
        {
            string StrMap = "", StrNums = "";
            int sum = 0;
           

            for (int k = 0; k < str.Length; k++)
            {
                StrNums += str[k];
            }
            for (int k = 0; k < MPlayer.GetLength(1); k++)
            {
              

                if (MPlayer[i, k] == 1)
                    sum++;
                else if (MPlayer[i, k] != 1)
                {
                    if (sum == 0)
                        continue;
                    StrMap += sum;
                    sum = 0;
                }
            }
            if (sum != 0) StrMap += sum;
            return StrMap == StrNums;
        }
        #endregion

        #region Расчет подсказок (циферки сбоку/сверху)
        public string[] GetHintColumn()
        {
            string[] mas = new string[LenH];
            int[] SumCols = new int[LenH];
            for (int i = 0; i < LenH; i++)
            {
                int Sum = 0;
                int Count = 0;
                string StrHint = "";
                for (int j = 0; j < LenW; j++)
                {
                    if (MCurr[j, i] != 0)
                    {
                        Sum++;
                        if (j == LenW - 1) Count++;
                    }
                    else if (Sum != 0)
                    {
                        StrHint += Sum + " ";
                        Sum = 0;
                        Count++;
                    }
                }
                if (Sum != 0) StrHint += Sum + " ";
                if (Count > ColumnCount) ColumnCount = Count;
                mas[i] = StrHint;
            }
            return mas;
        }
        public string[] GetHintLine()
        {
            string[] mas = new string[LenW];
            int[] SumRows = new int[LenW];
            for (int i = 0; i < LenW; i++)
            {
                int Sum = 0;
                int Count = 0;
                string StrHint = "";
                for (int j = 0; j < LenH; j++)
                {
                    if (MCurr[i, j] != 0)
                    {
                        Sum++;
                        if (j == LenH - 1) Count++;
                    }
                    else if (Sum != 0)
                    {
                        StrHint += Sum + " ";
                        Sum = 0;
                        Count++;
                    }
                }
                if (Sum != 0) StrHint += Sum + " ";
                if (Count > LineCount) LineCount = Count;
                mas[i] = StrHint;
            }
            return mas;
        }
        #endregion
    }
}
