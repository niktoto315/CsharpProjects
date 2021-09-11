using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//MessageBox.Show(11 + "\n" + 0xb + "\n" + (600 + "0b110" + 0x3c));

namespace japan_scanvord
{
    class GenerationMap
    {
        public int[,] Map { get; set; }
        public string[] Seed16 { get; set; }
        public bool passed = false;

        public void StringInMap(string seed)
        {
            uint Seed10;
            string Seed2;

            string []size = seed.Split(' ');
            passed = Int32.Parse(size[0]) == 1 ? false : true;
            Seed16 = size[2].Split(';');
            int CountLine = Seed16.Length;
            int CountColumn = Int32.Parse(size[1]);
            Map = new int[CountLine, CountColumn];
         
            for (int j = 0; j < CountLine; j++)
            {
                Seed10 = Convert.ToUInt32(Seed16[j], 16);
                Seed2 = Convert.ToString(Seed10, 2);
                while (Seed2.Length < CountColumn)
                {
                    Seed2 = "0" + Seed2;
                }
                for (int i = 0; i < CountColumn; i++)
                {
                    Map[j, i] = Int32.Parse(Seed2[i].ToString());
                }
            }
        }

        public string MapInString()
        {
            string Seed = (passed ? 0 : 1) + " " + Map.GetLength(1) + " ";
            uint Seed10 = 0;
            string Seed2 = "";
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    Seed2 += Map[i, j];
                }
            
                Seed10 = Convert.ToUInt32(Seed2, 2);
                Seed += Convert.ToString(Seed10, 16) + ";";
                Seed2 = "";
            }
            Seed = Seed.Substring(0, Seed.Length - 1);
            return Seed;
            /*
            string Seed1 = "FFFFFFFF";//8
            uint Seed4 = Convert.ToUInt32(Seed1, 16);
            string Seed3 = Convert.ToString(Seed10, 2);

            Seed3 = "11111111111111111111111111111111";//32
            Seed4 = Convert.ToUInt32(Seed3, 2);
            Seed1 = Convert.ToString(Seed4, 16);
            */
        }
    }
}
/*string Seed16 = "FFFFFFFF";//8
            uint Seed10 = Convert.ToUInt32(Seed16, 16);
            string Seed2 = Convert.ToString(Seed10, 2);

            Seed2 = "11111111111111111111111111111111";//32
            Seed10 = Convert.ToUInt32(Seed2, 2);
            Seed16 = Convert.ToString(Seed10, 16);
 */
