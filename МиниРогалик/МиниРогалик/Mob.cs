using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace МиниРогалик
{
    public class Mob
    {
        public int x { get; set; }
        public int y { get; set; }
        public string direction;
        public int CountSteps;
        public int SizeStep;

        public int d = 0; //временная

        public Mob(int x, int y, string dir)
        {
            this.x = x;
            this.y = y;
            this.direction = dir;
            CountSteps = 0;
            SizeStep = 2;
            d = 0;
        }

        public void ChangeDir()
        {
            //Random r = new Random();
            switch (d)
            {
                case 0: direction = "r"; break;
                case 1: direction = "u"; break;
                case 2: direction = "l"; break;
                case 3: direction = "d"; break;
            }
            CountSteps = 0;
            if (d == 3) d = 0;
            else d++;
        }

        public void Move()
        {
            switch (direction)
            {
                case "r": if (x < 490) x+= SizeStep; break;
                case "l": if (x > 10) x -= SizeStep; break;
                case "d": if (y < 190) y += SizeStep; break;
                case "u": if (y > 10) y -= SizeStep; break;
            }
            CountSteps++;
            if (CountSteps == 10)ChangeDir();
        }
    }
}
