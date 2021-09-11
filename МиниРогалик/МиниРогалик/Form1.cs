using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/** задачи
 * убрать мерцание отрисовки
 * переработать врагов в классы и создавать по несколько на карту
 * 
 * предметы
**/

namespace МиниРогалик
{
    //тут всё так и задумано
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            xarr = px+8; yarr = py+8;
            x = r.Next(10, Width - 100); y = r.Next(10, Height - 100);
        }

        Random r = new Random();

        //игрок
        int px = 200, py = 200;
        int heatpoints = 20;
        
        //клавиши
        bool w, a, s, d, up, down, right, left, enter = false;
        
        //двери
        bool door = false;

        //снаряд
        int xarr, yarr, timearr;
        string dirarr;

        //временные
        int x, y;
        Mob[] mobs = new Mob[10];
        Player player = new Player(200, 200, 20, 20);

        public void StartGame()
        {
            timer1.Start();
            heatpoints = 20;
            px = py = 200;
            door = false; 
            int a = r.Next(1, 4);
            
            for(int i = 0; i < mobs.Length; i++)
            {
                x = r.Next(10, Width - 100);
                y = r.Next(10, Height - 100);
                mobs[i] = new Mob(x, y, "r");
            }
        }

        public void LoseGame()
        {
            timer1.Stop();
            MessageBox.Show("You lose!");
        }

        public void StopGame()
        {
            timer1.Stop();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawRectangle(door ? new Pen(Color.Lime, 5) : new Pen(Color.Red, 10), 0, 0, Width-16, Height-38);
            g.FillRectangle(new SolidBrush(Color.Blue), player.Location.X, player.Location.Y, player.BodySize.X, player.BodySize.Y);
            g.FillEllipse(new SolidBrush(Color.Blue), xarr, yarr, 5, 5);

            if (mobs[0] != null)
            {
                
                for (int i = 0; i < mobs.Length; i++)
                {
                    g.FillEllipse(new SolidBrush(Color.Red), mobs[i].x, mobs[i].y, 25, 25);
                }
                
                /*
                g.FillEllipse(new SolidBrush(Color.Red), mob.x, mob.y, 25, 25);
                g.FillEllipse(new SolidBrush(Color.Red), mob1.x, mob1.y, 25, 25);
                */
                //g.FillEllipse(new SolidBrush(Color.Red), mobs[0].x, mobs[0].y, 25, 25);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //вывод
            HPBar.Text = "HP: " + heatpoints + " / 20: "+mobs[0].d;


            //движения


            if (w) player.Move("w");
            if (s) player.Move("s");
            if (d) player.Move("d");
            if (a) player.Move("a");


            if (w && timearr == 0) py -= py >= 0 ? 2 : 0;
            if (s && timearr == 0) py += py + 20 < Height - 39 ? 2 : 0;
            if (a && timearr == 0) px -= px >= 0 ? 2 : 0;
            if (d && timearr == 0) px += px + 20 < Width - 15 ? 2 : 0;

            //стрельба
            if (right && timearr == 0) { timearr = 100; dirarr = "r"; }
            if (left && timearr == 0) { timearr = 100; dirarr = "l"; }
            if (up && timearr == 0) { timearr = 100; dirarr = "u"; }
            if (down && timearr == 0) { timearr = 100; dirarr = "d"; }

            if (timearr > 0)
            {
                if (dirarr == "r") xarr += 1;
                if (dirarr == "l") xarr -= 1;
                if (dirarr == "u") yarr -= 1;
                if (dirarr == "d") yarr += 1;
                timearr--;
            }
            else 
            {
                xarr = px+8; yarr = py+8;
            }

            //движение препятствия

            for (int i = 0; i < mobs.Length; i++)
            {
                mobs[i].Move();
            }

            //попадание
            if (xarr > x && xarr < x + 25 && yarr > y && yarr < y + 25) 
            {
                x = -100; y = -100;
                timearr = 0;
                door = true;
            }

            //столкновение с препятствием
            if (px + 20 > x && px < x + 25 && py + 20 > y && py < y + 25)
            {
                heatpoints -= 5;
                x = -100; y = -100;
                door = true;
            }

            //переход в новую комнату
            if (py < 5 && door)
            {
                py = Height - 59;
                door = false;
                x = r.Next(10, Width - 100); y = r.Next(10, Height - 100);
            }
            if (py+20 > Height-44 && door)
            {
                py = 6;
                door = false;
                x = r.Next(10, Width - 100); y = r.Next(10, Height - 100);
            }
            if (px < 5 && door)
            {
                px = Width-40;
                door = false;
                x = r.Next(10, Width - 100); y = r.Next(10, Height - 100);
            }
            if (px + 20 > Width-40 && door)
            {
                px = 6;
                door = false;
                x = r.Next(10, Width - 100); y = r.Next(10, Height - 100);
            }

            //смерть
            if (heatpoints <= 0) LoseGame();

            //перерисовка
            Invalidate();
        }

        //клавиши
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            if (e.KeyCode == Keys.W || 
                e.KeyCode == Keys.A || 
                e.KeyCode == Keys.S || 
                e.KeyCode == Keys.D)
            {
                player.Move(e.KeyCode.ToString().ToLower());
            }
            */
            switch (e.KeyCode) 
            {
                case Keys.W: w = true; break;
                case Keys.A: a = true; break;
                case Keys.S: s = true; break;
                case Keys.D: d = true; break;
                case Keys.Up: up = true; break;
                case Keys.Down: down = true; break;
                case Keys.Right: right = true; break;
                case Keys.Left: left = true; break;
                case Keys.Enter: StartGame(); break;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.W: w = false; break;
                case Keys.A: a = false; break;
                case Keys.S: s = false; break;
                case Keys.D: d = false; break;
                case Keys.Up: up = false; break;
                case Keys.Down: down = false; break;
                case Keys.Right: right = false; break;
                case Keys.Left: left = false; break;
                case Keys.Enter: enter = false; break;
            }
        }
    }
}
