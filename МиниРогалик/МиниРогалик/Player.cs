using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace МиниРогалик
{
    class Player
    {
        public Point Location = new Point();
        public Point BodySize = new Point();

        public string status;
        public int step;

        public Player(int x, int y, int width, int heigth)
        {
            Location.X = x;
            Location.Y = y;
            BodySize.X = width;
            BodySize.Y = heigth;
            status = "walk";
            step = 10;
        }

        public void Move(string key)
        {
            if (status == "walk")
            {
                switch (key)
                {
                    case "a": Location.X -= step; break;
                    case "d": Location.X += step; break;
                    case "w": Location.Y -= step; break;
                    case "s": Location.Y += step; break;
                }
            }
        }

        public void Shot()
        {
            status = "shoting";

            //тут будет создание стрел, а может и их движение, а может вынести стрелы в отдельный класс...

            status = "walk";
        }

    }
}
