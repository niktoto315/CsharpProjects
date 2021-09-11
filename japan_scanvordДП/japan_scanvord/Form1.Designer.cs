namespace japan_scanvord
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.GameField = new System.Windows.Forms.PictureBox();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.играToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetMap = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyString = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadString = new System.Windows.Forms.ToolStripMenuItem();
            this.уровниToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.FreeList = new System.Windows.Forms.ToolStripMenuItem();
            this.CampanyList = new System.Windows.Forms.ToolStripMenuItem();
            this.Info = new System.Windows.Forms.ToolStripMenuItem();
            this.Help = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.Colors = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorBack = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorNums = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorCell = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorCross = new System.Windows.Forms.ToolStripMenuItem();
            this.GameType = new System.Windows.Forms.ToolStripMenuItem();
            this.Theme = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectColors = new System.Windows.Forms.ColorDialog();
            this.CompletePanel = new System.Windows.Forms.Panel();
            this.LabelPanel = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Button();
            this.IconBox = new System.Windows.Forms.PictureBox();
            this.Next = new System.Windows.Forms.Button();
            this.HealthLabel = new System.Windows.Forms.Label();
            this.Invert = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).BeginInit();
            this.MainMenu.SuspendLayout();
            this.CompletePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GameField
            // 
            this.GameField.BackColor = System.Drawing.SystemColors.Control;
            this.GameField.Dock = System.Windows.Forms.DockStyle.Left;
            this.GameField.Location = new System.Drawing.Point(0, 0);
            this.GameField.Name = "GameField";
            this.GameField.Size = new System.Drawing.Size(1000, 837);
            this.GameField.TabIndex = 0;
            this.GameField.TabStop = false;
            this.GameField.Paint += new System.Windows.Forms.PaintEventHandler(this.GameField_Paint);
            this.GameField.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameField_MouseClick);
            // 
            // MainMenu
            // 
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.играToolStripMenuItem,
            this.уровниToolStripMenuItem,
            this.Info,
            this.Settings,
            this.выходToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 837);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(784, 24);
            this.MainMenu.TabIndex = 6;
            // 
            // играToolStripMenuItem
            // 
            this.играToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ResetMap,
            this.CopyString,
            this.LoadString,
            this.Invert});
            this.играToolStripMenuItem.Name = "играToolStripMenuItem";
            this.играToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.играToolStripMenuItem.Text = "Игра";
            // 
            // ResetMap
            // 
            this.ResetMap.Name = "ResetMap";
            this.ResetMap.Size = new System.Drawing.Size(180, 22);
            this.ResetMap.Text = "Очистить карту";
            this.ResetMap.Click += new System.EventHandler(this.Reset_Click);
            // 
            // CopyString
            // 
            this.CopyString.Name = "CopyString";
            this.CopyString.Size = new System.Drawing.Size(180, 22);
            this.CopyString.Text = "Выгрузить";
            this.CopyString.Click += new System.EventHandler(this.CopyString_Click);
            // 
            // LoadString
            // 
            this.LoadString.Name = "LoadString";
            this.LoadString.Size = new System.Drawing.Size(180, 22);
            this.LoadString.Text = "Загрузить";
            this.LoadString.Click += new System.EventHandler(this.LoadString_Click);
            // 
            // уровниToolStripMenuItem
            // 
            this.уровниToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateLevel,
            this.FreeList,
            this.CampanyList});
            this.уровниToolStripMenuItem.Name = "уровниToolStripMenuItem";
            this.уровниToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.уровниToolStripMenuItem.Text = "Уровни";
            // 
            // CreateLevel
            // 
            this.CreateLevel.Name = "CreateLevel";
            this.CreateLevel.Size = new System.Drawing.Size(164, 22);
            this.CreateLevel.Text = "Создать";
            this.CreateLevel.Click += new System.EventHandler(this.CreateLevel_Click);
            // 
            // FreeList
            // 
            this.FreeList.Name = "FreeList";
            this.FreeList.Size = new System.Drawing.Size(164, 22);
            this.FreeList.Text = "Свободная Игра";
            this.FreeList.Click += new System.EventHandler(this.FreeList_Click);
            // 
            // CampanyList
            // 
            this.CampanyList.Name = "CampanyList";
            this.CampanyList.Size = new System.Drawing.Size(164, 22);
            this.CampanyList.Text = "Кампания";
            this.CampanyList.Click += new System.EventHandler(this.CampanyList_Click);
            // 
            // Info
            // 
            this.Info.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Help});
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(63, 20);
            this.Info.Text = "Об игре";
            // 
            // Help
            // 
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(123, 22);
            this.Help.Text = "Помощь";
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // Settings
            // 
            this.Settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Colors,
            this.GameType,
            this.Theme});
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(79, 20);
            this.Settings.Text = "Настройки";
            // 
            // Colors
            // 
            this.Colors.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ColorBack,
            this.ColorNums,
            this.ColorGrid,
            this.ColorCell,
            this.ColorCross});
            this.Colors.Name = "Colors";
            this.Colors.Size = new System.Drawing.Size(128, 22);
            this.Colors.Text = "Цвета";
            // 
            // ColorBack
            // 
            this.ColorBack.Name = "ColorBack";
            this.ColorBack.Size = new System.Drawing.Size(115, 22);
            this.ColorBack.Text = "Фон";
            this.ColorBack.Click += new System.EventHandler(this.Colors_Click);
            // 
            // ColorNums
            // 
            this.ColorNums.Name = "ColorNums";
            this.ColorNums.Size = new System.Drawing.Size(115, 22);
            this.ColorNums.Text = "Цифры";
            this.ColorNums.Click += new System.EventHandler(this.Colors_Click);
            // 
            // ColorGrid
            // 
            this.ColorGrid.Name = "ColorGrid";
            this.ColorGrid.Size = new System.Drawing.Size(115, 22);
            this.ColorGrid.Text = "Сетка";
            this.ColorGrid.Click += new System.EventHandler(this.Colors_Click);
            // 
            // ColorCell
            // 
            this.ColorCell.Name = "ColorCell";
            this.ColorCell.Size = new System.Drawing.Size(115, 22);
            this.ColorCell.Text = "Клетки";
            this.ColorCell.Click += new System.EventHandler(this.Colors_Click);
            // 
            // ColorCross
            // 
            this.ColorCross.Name = "ColorCross";
            this.ColorCross.Size = new System.Drawing.Size(115, 22);
            this.ColorCross.Text = "Кресты";
            this.ColorCross.Click += new System.EventHandler(this.Colors_Click);
            // 
            // GameType
            // 
            this.GameType.Name = "GameType";
            this.GameType.Size = new System.Drawing.Size(128, 22);
            this.GameType.Text = "Сложный";
            this.GameType.Click += new System.EventHandler(this.GameType_Click);
            // 
            // Theme
            // 
            this.Theme.Name = "Theme";
            this.Theme.Size = new System.Drawing.Size(128, 22);
            this.Theme.Text = "Светлая";
            this.Theme.Click += new System.EventHandler(this.Theme_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.ExitGame_Click);
            // 
            // CompletePanel
            // 
            this.CompletePanel.Controls.Add(this.LabelPanel);
            this.CompletePanel.Controls.Add(this.Exit);
            this.CompletePanel.Controls.Add(this.IconBox);
            this.CompletePanel.Controls.Add(this.Next);
            this.CompletePanel.Location = new System.Drawing.Point(1052, 476);
            this.CompletePanel.Name = "CompletePanel";
            this.CompletePanel.Size = new System.Drawing.Size(300, 323);
            this.CompletePanel.TabIndex = 7;
            this.CompletePanel.Visible = false;
            // 
            // LabelPanel
            // 
            this.LabelPanel.AutoSize = true;
            this.LabelPanel.Location = new System.Drawing.Point(107, 231);
            this.LabelPanel.Name = "LabelPanel";
            this.LabelPanel.Size = new System.Drawing.Size(96, 13);
            this.LabelPanel.TabIndex = 3;
            this.LabelPanel.Text = "Уровень пройден";
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(13, 259);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(100, 50);
            this.Exit.TabIndex = 2;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // IconBox
            // 
            this.IconBox.Location = new System.Drawing.Point(53, 15);
            this.IconBox.Name = "IconBox";
            this.IconBox.Size = new System.Drawing.Size(200, 200);
            this.IconBox.TabIndex = 1;
            this.IconBox.TabStop = false;
            this.IconBox.Paint += new System.Windows.Forms.PaintEventHandler(this.IconBox_Paint);
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(197, 259);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(100, 50);
            this.Next.TabIndex = 0;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // HealthLabel
            // 
            this.HealthLabel.AutoSize = true;
            this.HealthLabel.BackColor = System.Drawing.Color.White;
            this.HealthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HealthLabel.Location = new System.Drawing.Point(12, 12);
            this.HealthLabel.Name = "HealthLabel";
            this.HealthLabel.Size = new System.Drawing.Size(51, 55);
            this.HealthLabel.TabIndex = 8;
            this.HealthLabel.Text = "6";
            // 
            // Invert
            // 
            this.Invert.Name = "Invert";
            this.Invert.Size = new System.Drawing.Size(180, 22);
            this.Invert.Text = "Инвертировать";
            this.Invert.Visible = false;
            this.Invert.Click += new System.EventHandler(this.Invert_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(784, 861);
            this.Controls.Add(this.HealthLabel);
            this.Controls.Add(this.CompletePanel);
            this.Controls.Add(this.GameField);
            this.Controls.Add(this.MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.MaximumSize = new System.Drawing.Size(800, 900);
            this.MinimumSize = new System.Drawing.Size(800, 858);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Nonogram";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.CompletePanel.ResumeLayout(false);
            this.CompletePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GameField;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem играToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ResetMap;
        private System.Windows.Forms.ToolStripMenuItem уровниToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateLevel;
        private System.Windows.Forms.ToolStripMenuItem FreeList;
        private System.Windows.Forms.ToolStripMenuItem Info;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Help;
        private System.Windows.Forms.ToolStripMenuItem Settings;
        private System.Windows.Forms.ToolStripMenuItem Colors;
        private System.Windows.Forms.ColorDialog SelectColors;
        private System.Windows.Forms.ToolStripMenuItem ColorBack;
        private System.Windows.Forms.ToolStripMenuItem ColorNums;
        private System.Windows.Forms.ToolStripMenuItem ColorGrid;
        private System.Windows.Forms.ToolStripMenuItem ColorCell;
        private System.Windows.Forms.ToolStripMenuItem ColorCross;
        private System.Windows.Forms.ToolStripMenuItem CampanyList;
        private System.Windows.Forms.ToolStripMenuItem GameType;
        private System.Windows.Forms.Panel CompletePanel;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.PictureBox IconBox;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Label LabelPanel;
        private System.Windows.Forms.ToolStripMenuItem Theme;
        private System.Windows.Forms.Label HealthLabel;
        private System.Windows.Forms.ToolStripMenuItem CopyString;
        private System.Windows.Forms.ToolStripMenuItem LoadString;
        private System.Windows.Forms.ToolStripMenuItem Invert;
    }
}

