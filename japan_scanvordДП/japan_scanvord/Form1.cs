using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace japan_scanvord
{
    public partial class MainForm : Form
    {
        FilesIO SaverMaps = new FilesIO();
        DialogResult Result;
        GenerationMap GeneratorMaps = new GenerationMap();
        Game engine;

        public MainForm()
        {
            InitializeComponent();

            Width = 800;
            Height = 800;
            GameField.BackColor = back;
            //
            SaverMaps.file = "free";
            if (SaverMaps.CheckFiles() != 0)
                FreeList.Enabled = false;
            SaverMaps.file = "campany";
            if (SaverMaps.CheckFiles() != 0)
                CampanyList.Enabled = false;
            //
            if(!CampanyList.Enabled || !FreeList.Enabled)
            {
                Result = MessageBox.Show("Файлы с картами не обнаружены программой, \n" +
                                    "список карт будет пуст\n\n\n" +
                                    "Желаете продолжить?",
                                    SaverMaps.Message,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Error);
            }
            //
            LoadSeeds();
            GeneratorMaps.StringInMap(ListSeeds[NumLevel]);
            Start();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Result == DialogResult.No) Application.Exit();
        }

        #region Переменные

        int health;

        int ColCount = 0;
        int RowCount = 0;
        int HintCountW;
        int HintCountH;
        string[] NumsRows;
        string[] NumsCols;

        int SizeCell = 40;
        int SizeFont = 14;

        int[,] CurrentMap;
        int[,] PlayerMap;

        int NumLevel = 0;

        int[,] NullMap = {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
            { 0, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0, 1, 0, 1, 0, },
            { 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, },
            { 0, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 1, 1, 1, 0, },
            { 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, },
            { 0, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0, },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        };

        bool complete = false;
        string[] ListSeeds;


        Color back = Color.White;
        Brush nums = Brushes.DarkRed;
        Color grid = Color.Gray;
        Color cross = Color.Gray;
        Brush cell = Brushes.Black;
        string NumFont = "Consolas";
        #endregion

        private void LoadSeeds()
        {
            NumLevel = 0;
            if (SaverMaps.CheckFiles() == 0)
            {
                SaverMaps.SavesOutFile(out ListSeeds);
            }
            else
            {
                GeneratorMaps.Map = NullMap;
                ListSeeds = new string[1];
                ListSeeds[0] = GeneratorMaps.MapInString();
            }
        }

        private void Start()
        {
            health = 6;
            HealthLabel.Text = "" + health;

            if (engine != null && !engine.Create)
                GeneratorMaps.StringInMap(ListSeeds[NumLevel]);

            CurrentMap = new int[GeneratorMaps.Map.GetLength(0), GeneratorMaps.Map.GetLength(1)];
            ColCount = CurrentMap.GetLength(0);
            RowCount = CurrentMap.GetLength(1);
            PlayerMap = new int[ColCount, RowCount];

            SizeCell = (int)(450 / (ColCount > RowCount ? ColCount : RowCount));
                
            SizeFont = SizeCell / 2;

            for (int i = 0; i < ColCount; i++)
            {
                for (int j = 0; j < RowCount; j++)
                {
                    PlayerMap[i, j] = engine != null && engine.Create ? GeneratorMaps.Map[i, j] : 0;
                    CurrentMap[i, j] = i >= GeneratorMaps.Map.GetLength(0) || j >= GeneratorMaps.Map.GetLength(1) ? 0 : GeneratorMaps.Map[i, j];
                    //CurrentMap[i, j] = (i + j) % 2 == 0 ? 1 : 0;

                }
            }
            engine = new Game(ColCount, RowCount, CurrentMap);
        }

        #region Отрисовка поля
        private void GameField_Paint(object sender, PaintEventArgs e)
        {
            NumsRows = engine.GetHintLine();
            NumsCols = engine.GetHintColumn();
            if (ColCount < 6 || RowCount < 6)
            {
                HintCountH = engine.ColumnCount;
                HintCountW = engine.LineCount;
            }
            else
            {
                HintCountH = engine.ColumnCount + (ColCount % 2 == 0 ? 0 : 1);
                HintCountW = engine.LineCount + (RowCount % 2 == 0 ? 0 : 1);
            }
            //MessageBox.Show(engine.ColumnCount + " " + engine.LineCount);
            int LenRowsMax = (HintCountW + RowCount) * SizeCell;
            int LenColsMax = (HintCountH + ColCount) * SizeCell;

            Graphics g = e.Graphics;
            Point p1, p2;

            #region Отрисовка
            Pen p = new Pen(grid, 1);

            #region Подсказки
            //Сверху
            //Горизонтальные
            if (!engine.Create)
            {
                for (int i = 0; i <= HintCountH; i++)
                {
                    p1 = new Point(SizeCell * HintCountW, i * SizeCell);
                    p2 = new Point(LenRowsMax, i * SizeCell);
                    g.DrawLine(p, p1, p2);
                }
                //Вертикальные
                for (int i = HintCountW; i <= RowCount + HintCountW; i++)
                {
                    p1 = new Point(i * SizeCell, 0);
                    p2 = new Point(i * SizeCell, HintCountH * SizeCell);
                    g.DrawLine(p, p1, p2);
                }
                //Слева
                //Горизонтальные
                for (int i = HintCountH; i <= ColCount + HintCountH; i++)
                {
                    p1 = new Point(0, i * SizeCell);
                    p2 = new Point(HintCountW * SizeCell, i * SizeCell);
                    g.DrawLine(p, p1, p2);
                }
                //Вертикальные
                for (int i = 0; i <= HintCountW; i++)
                {
                    p1 = new Point(i * SizeCell, SizeCell * HintCountH);
                    p2 = new Point(i * SizeCell, LenColsMax);
                    g.DrawLine(p, p1, p2);
                }
                //цифры
                for (int i = 0; i < NumsCols.Length; i++)
                {
                    String[] number = NumsCols[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 0; j < number.Length; j++)
                        g.DrawString(number[number.Length - j - 1] + "\n",
                                             new Font(NumFont, SizeFont),
                                             nums,
                                             (i + HintCountW) * SizeCell + SizeCell / 4 - (Int32.Parse(number[number.Length - j - 1]) > 9 ? 7 : 0),
                                             (HintCountH - j - 1) * SizeCell + SizeCell / 4 - (Int32.Parse(number[number.Length - j - 1]) > 9 ? 5 : 0));

                }
                for (int i = 0; i < NumsRows.Length; i++)
                {
                    String[] number = NumsRows[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 0; j < number.Length; j++)
                        g.DrawString(number[number.Length - j - 1] + "\n",
                                            new Font(NumFont, SizeFont),
                                            nums,
                                           (HintCountW - j - 1) * SizeCell + SizeCell / 4 - (Int32.Parse(number[number.Length - j - 1]) > 9 ? 7 : 0),
                                           (i + HintCountH) * SizeCell + SizeCell / 4 - (Int32.Parse(number[number.Length - j - 1]) > 9 ? 5 : 0));
                }
            }
            #endregion
            //редактор
            else
            {
                int countcell = (ColCount > RowCount ? ColCount : RowCount) / 5;
                HintCountH = HintCountW = countcell == 0 ? 1 : countcell + 1;
                LenRowsMax = (HintCountW + RowCount) * SizeCell;
                LenColsMax = (HintCountH + ColCount) * SizeCell;
            }
            #endregion

            #region Поле 5*5
            //Горизонтальные
            for (int i = HintCountH; i * SizeCell <= LenColsMax; i += 5) 
            {
                Point a = new Point(HintCountW * SizeCell, i * SizeCell),
                      b = new Point(LenRowsMax, i * SizeCell);
                g.DrawLine(new Pen(grid, 2), a, b);
            }
            //Вертикальные
            for (int i = HintCountW; i * SizeCell <= LenRowsMax; i += 5) 
            {
                Point a = new Point(i * SizeCell, HintCountH * SizeCell),
                      b = new Point(i * SizeCell, LenColsMax);
                g.DrawLine(new Pen(grid, 2), a, b);
            }
            #endregion

            #region игровое поле
            //Горизонтальные
            for (int i = HintCountH; i <= ColCount + HintCountH; i++)
            {
                p1 = new Point(HintCountW * SizeCell, i * SizeCell);
                p2 = new Point(LenRowsMax, i * SizeCell);
                g.DrawLine(p, p1, p2);
            }
            //Вертикальные
            for (int i = HintCountW; i <= RowCount + HintCountW; i++)
            {
                p1 = new Point(i * SizeCell, HintCountH * SizeCell);
                p2 = new Point(i * SizeCell, LenColsMax);
                g.DrawLine(p, p1, p2);
            }
            #endregion

            #region Изменения карты игроком
            for (int j = 0; j < RowCount; j++)
            {
                for (int i = 0; i < ColCount; i++)
                {
                    if (PlayerMap[i, j] == 1)
                    {
                        g.FillRectangle(cell,
                            (j + HintCountW) * SizeCell,
                            (i + HintCountH) * SizeCell,
                            SizeCell,
                            SizeCell);
                    }
                    if (PlayerMap[i, j] == 2)
                    {
                        g.DrawLine(new Pen(cross, 2),
                            (j + HintCountW) * SizeCell,
                            (i + HintCountH) * SizeCell,
                            (j + HintCountW) * SizeCell + SizeCell,
                            (i + HintCountH) * SizeCell + SizeCell);
                        g.DrawLine(new Pen(cross, 2),
                            (j + HintCountW) * SizeCell,
                            (i + HintCountH) * SizeCell + SizeCell,
                            (j + HintCountW) * SizeCell + SizeCell,
                            (i + HintCountH) * SizeCell);
                    }
                    if (PlayerMap[i, j] == 9)
                    {
                        g.DrawLine(new Pen(Color.DarkRed, 2),
                            (j + HintCountW) * SizeCell,
                            (i + HintCountH) * SizeCell,
                            (j + HintCountW) * SizeCell + SizeCell,
                            (i + HintCountH) * SizeCell + SizeCell);
                        g.DrawLine(new Pen(Color.DarkRed, 2),
                            (j + HintCountW) * SizeCell,
                            (i + HintCountH) * SizeCell + SizeCell,
                            (j + HintCountW) * SizeCell + SizeCell,
                            (i + HintCountH) * SizeCell);
                    }
                }
            }
            #endregion
        }
        #endregion

        #region Клики на поле
        private void Click(MouseEventArgs e)
        {
            #region Координаты мыши в индексы матрицы карты
            //координаты курсора в момент нажатия
            int x = MousePosition.X - this.Location.X - 8;
            int y = MousePosition.Y - this.Location.Y - 31;
            //проверка положения курсора в пределах игрового поля
            //если вне поля, то останавливаем обработку
            if (x < HintCountW * SizeCell || x > (HintCountW + RowCount) * SizeCell - 2 ||
                y < HintCountH * SizeCell || y > (HintCountH + ColCount) * SizeCell - 2) return;
            //координаты клетки на которую сра ботало нажатие
            int i = y / SizeCell - HintCountH;
            int j = x / SizeCell - HintCountW;
            #endregion

            if (!engine.Create)
            {
                #region Заполнение клеток карты
                //проверка режимаа игры
                if (complete)
                {
                    CompletePanel.Location = new Point(300, 300);
                    CompletePanel.Visible = true;
                }
                else
                {
                    if (GameType.Checked)
                    {
                        //проверка пкм и лкм
                        if (e.Button == MouseButtons.Left)
                        {
                            if (PlayerMap[i, j] != 9)
                            {
                                PlayerMap[i, j] = PlayerMap[i, j] == 1 ? 0 : CurrentMap[i, j] == 1 ? 1 : 9;
                                HealthLabel.Text = "" + (health = CurrentMap[i, j] != 1 ? health - 1 : health);

                            }
                        }
                        else if (e.Button == MouseButtons.Right)
                        {
                            if (PlayerMap[i, j] == 2) PlayerMap[i, j] = 0;
                            else PlayerMap[i, j] = PlayerMap[i, j] == 0 ? 2 : PlayerMap[i, j];
                        }
                    }
                    else
                    {
                        if (e.Button == MouseButtons.Left)
                            PlayerMap[i, j] = PlayerMap[i, j] == 1 ? 0 : 1;
                        else if (e.Button == MouseButtons.Right)
                            PlayerMap[i, j] = PlayerMap[i, j] == 2 ? 0 : 2;
                    }


                    //автозаполнение столбцов
                    if (engine.CheckCols(PlayerMap, NumsCols[j].Split(' '), j))
                        for (int k = 0; k < PlayerMap.GetLength(0); k++)
                            PlayerMap[k, j] = PlayerMap[k, j] == 0 ? 2 : PlayerMap[k, j];

                    //автозаполнение строк
                    if (engine.CheckRows(PlayerMap, NumsRows[i].Split(' '), i))
                        for (int k = 0; k < PlayerMap.GetLength(1); k++)
                            PlayerMap[i, k] = PlayerMap[i, k] == 0 ? 2 : PlayerMap[i, k];

                    GameField.Invalidate();
                }
                #endregion

                #region Проверка решения карты
                if (engine.Checking(PlayerMap))
                {
                    //отметка о прохождении карты
                    GeneratorMaps.passed = true;
                    ListSeeds[NumLevel] = GeneratorMaps.MapInString();
                    GeneratorMaps.passed = false;

                    //режим панели смена уровня
                    complete = true;
                    Next.Text = "Следующий уровень";
                    Exit.Text = "Посмотреть текущий уровень";
                    LabelPanel.Text = "Уровень " + (NumLevel + 1) + " пройден";
                    IconBox.Invalidate();
                    PanelShow();

                    return;
                }
                if (health == 0)
                {
                    MessageBox.Show("you lose");
                    Start();
                    GameField.Invalidate();
                }
                #endregion
            }
            else
            {
                /*
                if (e.Button == MouseButtons.Left)
                    PlayerMap[i, j] = PlayerMap[i, j] == 1 ? 0 : 1;
                else if (e.Button == MouseButtons.Right)
                    PlayerMap[i, j] = PlayerMap[i, j] == 2 ? 0 : 2;
                */
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        PlayerMap[i, j] = 1;
                        break;
                    case MouseButtons.Right:
                        PlayerMap[i, j] = 0;
                        break;
                }
                GameField.Invalidate();
            }
        }
        private void GameField_MouseClick(object sender, MouseEventArgs e)
        {
            Click(e);
        }
        #endregion

        #region Кнопки Меню

        #region Игра
        private void Invert_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ColCount; i++)
                for (int j = 0; j < RowCount; j++)
                    PlayerMap[i, j] = PlayerMap[i, j] == 1 ? 0 : 1;
            GameField.Invalidate();
        }
        private void Reset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ColCount; i++)
                for (int j = 0; j < RowCount; j++)
                    PlayerMap[i, j] = 0;
            GameField.Invalidate();
        }
        private void LoadString_Click(object sender, EventArgs e)
        {
            string seeed = Clipboard.GetText().Substring(0, Clipboard.GetText().Length - 1);
            try
            {
                GeneratorMaps.StringInMap(seeed);
                complete = false;
                engine.Create = false;
                SaverMaps.file = "free";
                LoadSeeds();
                Array.Resize(ref ListSeeds, ListSeeds.Length + 1);
                ListSeeds[ListSeeds.Length - 1] = seeed;
                NumLevel = ListSeeds.Length - 1;
                Start();
                GameField.Invalidate();
            }
            catch
            {
                MessageBox.Show("Скопированный текст не является картой", "Ошибка");
                return;
            }
        }
        private void CopyString_Click(object sender, EventArgs e)
        {
            GeneratorMaps.passed = false;
            GeneratorMaps.Map = PlayerMap;
            Clipboard.SetText(GeneratorMaps.MapInString() + ";");
            MessageBox.Show("Карта успешно скопирована"/* + Clipboard.GetText()*/);
        }
        #endregion

        #region Уровни

        #region Панель смены уровня
        private void IconBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            SolidBrush White = new SolidBrush(Color.White);
            SolidBrush Black = new SolidBrush(Color.Black);

            GeneratorMaps.StringInMap(ListSeeds[NumLevel]);
            int[,] Map = GeneratorMaps.Map;
            
            int RectH = IconBox.Width / Map.GetLength(0);
            int RectW = IconBox.Height / Map.GetLength(1);

            if (complete)
            {
                for (int m = 0; m < ColCount; m++)
                {
                    for (int n = 0; n < RowCount; n++)
                    {
                        g.FillRectangle(Map[m, n] == 1 ? Black : White,
                            n * RectW,
                            m * RectH,
                            RectW,
                            RectH);
                    }
                }
            }
            else
            {
                //MessageBox.Show(CampanySeeds[NumLevel] + "\n" + GeneratorMaps.passed);
                if (GeneratorMaps.passed)
                {
                    Map = GeneratorMaps.Map;
                    for (int m = 0; m < Map.GetLength(0); m++)
                    {
                        for (int n = 0; n < Map.GetLength(1); n++)
                        {
                            g.FillRectangle(Map[m, n] == 1 ? Black : White,
                                n * RectW,
                                m * RectH,
                                RectW,
                                RectH);
                        }
                    }
                }
                else
                {
                    RectW = IconBox.Width / NullMap.GetLength(1);
                    RectH = IconBox.Height / NullMap.GetLength(0);
                    Map = NullMap;
                    for (int m = 0; m < NullMap.GetLength(0); m++)
                    {
                        for (int n = 0; n < NullMap.GetLength(1); n++)
                        {
                            g.FillRectangle(Map[m, n] == 1 ? Black : White,
                                n * RectW,
                                m * RectH,
                                RectW,
                                RectH);
                        }
                    }
                }
            }
        }
        private void Next_Click(object sender, EventArgs e)
        {
            NumLevel = NumLevel >= ListSeeds.Length-1 ? 0 : NumLevel + 1;
            if (complete)
            {
                PanelHide();
                complete = false;
                Start(); 
                GameField.Invalidate();
            }
            else
            {
                IconBox.Invalidate();
                LabelPanel.Text = "Уровень " + (NumLevel + 1);
            }
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            if (complete)
            {
                PanelHide();
            }
            else
            {
                PanelHide();
                complete = false;
                Start(); 
                GameField.Invalidate();
            }
        }
        public void PanelShow()
        {
            CompletePanel.Location = new Point(300, 300);
            CompletePanel.Visible = true;
        }
        public void PanelHide()
        {
            CompletePanel.Location = new Point(30000, 30000);
            CompletePanel.Visible = false;
        }
        #endregion

        private void CreateLevel_Click(object sender, EventArgs e)
        {
            Invert.Visible = true;
            Focus();
            Start();
            engine.Create = true;
            GameField.Invalidate();
        }
        private void FreeList_Click(object sender, EventArgs e)
        {
            Invert.Visible = false;
            engine.Create = false;
            SaverMaps.SavesInFile(ListSeeds);
            SaverMaps.file = "free";
            LoadSeeds();

            complete = false;
            Next.Text = "Следующий уровень";
            Exit.Text = "Выбрать текущий уровень";
            LabelPanel.Text = "Уровень " + (NumLevel + 1);

            IconBox.Invalidate();
            PanelShow();
        }
        private void CampanyList_Click(object sender, EventArgs e)
        {
            Invert.Visible = false;
            engine.Create = false;
            SaverMaps.SavesInFile(ListSeeds);
            SaverMaps.file = "campany";
            LoadSeeds();

            complete = false;
            Next.Text = "Следующий уровень";
            Exit.Text = "Выбрать текущий уровень";
            LabelPanel.Text = "Уровень " + (NumLevel + 1);

            IconBox.Invalidate();
            PanelShow();
        }
        #endregion

        #region Помощь
        private void Help_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"Saves\help.html"))
                Process.Start(@"Saves\help.html");
        }

        #endregion

        #region Настройки
        private void Theme_Click(object sender, EventArgs e)
        {
            switch (Theme.Text)
            {
                case "Светлая":
                    Theme.Text = "Тёмная";

                    back = Color.Black;
                    nums = Brushes.Lime;
                    grid = Color.Gray;
                    cross = Color.Gray;
                    cell = Brushes.White;
                    break;
                case "Тёмная":
                    Theme.Text = "Светлая";

                    back = Color.White;
                    nums = Brushes.DarkRed;
                    grid = Color.Gray;
                    cross = Color.Gray;
                    cell = Brushes.Black;
                    break;
            }
            GameField.BackColor = back;
            HealthLabel.BackColor = back;
            GameField.Invalidate();
        }
        private void Colors_Click(object sender, EventArgs e)
        {
            //SelectColors.FullOpen = true;
            SelectColors.ShowDialog();
            switch (((ToolStripMenuItem)sender).Name)
            {
                case "ColorBack": back = SelectColors.Color; break;
                case "ColorGrid": grid = SelectColors.Color; break;
                case "ColorCross": cross = SelectColors.Color; break;
                case "ColorNums": nums = new SolidBrush(SelectColors.Color); break;
                case "ColorCell": cell = new SolidBrush(SelectColors.Color); break;
            }
            GameField.BackColor = back;
            HealthLabel.BackColor = back;
            GameField.Invalidate();
        }
        private void GameType_Click(object sender, EventArgs e)
        {
            Start(); 
            GameField.Invalidate();
            GameType.Text = GameType.Checked ? "Сложный" : "Простой";
            GameType.Checked = !GameType.Checked;
        }
        #endregion

        #region Выход
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall) return;
            DialogResult result = MessageBox.Show("Сохранить?", "Ask", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                SaverMaps.SavesInFile(ListSeeds);
            }
            else if (result == DialogResult.Cancel) e.Cancel = true;
        }
        private void ExitGame_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #endregion

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (engine.Create)
            {
                if (e.Shift)
                {
                    if (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add)
                        ResizeMap("AddRow");
                    if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
                        ResizeMap("RemoveRow");
                }
                if (e.Control)
                {
                    if (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add)
                        ResizeMap("AddCol");
                    if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
                        ResizeMap("RemoveCol");
                }
            }
        }
        public void ResizeMap(string action)
        {
            GeneratorMaps.Map = engine.ResizeField(PlayerMap, action);
            Start();
            engine.Create = true;
            GameField.Invalidate();
        }
    }
}

/*Trash
        Stopwatch st = new Stopwatch();
        MouseButtons mb = MouseButtons.None;
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == mb)
            {
                if (st.ElapsedMilliseconds > 1000 && e.Button == mb)
                {
                    st.Stop();
                    MessageBox.Show("Вы держали нажатой " + e.Button.ToString() + " кнопку мыши более 10x секунд, а именно: " + st.Elapsed.ToString() + "\n(Вы нашли пасхалку, вы видимо гений)");
                }
                mb = MouseButtons.None;
                st.Reset();
            }
        }
 */
