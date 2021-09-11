using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace japan_scanvord
{
    class FilesIO
    {
        public string PathMain = @"C:\Nonogram";
        public string PathSaves = @"Saves";

        public string Message = "Ok";
        public string file;

        public void CheckDirs(string dirname)
        {
            if (!Directory.Exists(dirname)) Directory.CreateDirectory(dirname);
        }

        public int CheckFiles()
        {
            string filePath = PathSaves + @"\" + file + ".snm";
            if (!File.Exists(filePath))
            {
                Message = "Файлы повреждены или утеряны";
                return 1;
            }
            Message = "";
            return 0;
        }

        public void SavesInFile(string[] Seeds)
        {
            CheckDirs(PathSaves);
            FileStream Writer = new FileStream(PathSaves + @"\" + file + ".snm", FileMode.OpenOrCreate);
            string str = "";
            for (int k = 0; k < Seeds.Length; k++)
                str += k == 0 ? Seeds[k] + ";" : "\n" + Seeds[k] + ";";
            byte[] bytes = Encoding.Default.GetBytes(str);
            Writer.Write(bytes, 0, bytes.Length);
            Writer.Close();
        }

        public void SavesOutFile(out string[] SeedMap)
        {
            string filePath = PathSaves + @"\" + file + ".snm";
            SeedMap = new string[0];
            StreamReader Reader = new StreamReader(filePath);
            string line = Reader.ReadLine();
            while (line != null)
            {
                Array.Resize(ref SeedMap, SeedMap.Length + 1);
                for (int i = 0; i < line.Length - 1; i++)
                {
                    SeedMap[SeedMap.Length-1] += line[i];
                }
                SeedMap[SeedMap.Length - 1] += ";";
                line = Reader.ReadLine();
                SeedMap[SeedMap.Length - 1] = SeedMap[SeedMap.Length - 1].Substring(0, SeedMap[SeedMap.Length - 1].Length - 1);
            }
            Reader.Close();
        }
    }
}
