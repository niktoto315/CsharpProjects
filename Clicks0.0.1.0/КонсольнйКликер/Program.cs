using System;
using System.Threading;
using System.Text.RegularExpressions;

//Задачи

/**
*придумать команду с параметром
*переделать на классы
*дорабатывать
*
**/

/***
 * поправки тестирования
 * 
 * 
 * 
 * 
 ***/

namespace КонсольнйКликер
{
    class Program
    {
        static Timer timer;

        static int count = 0;
        static int price = 10;
        static int mpc = 1;

        static int aim = 20000;
        static int bonus = 0;


        static void Main(string[] args)
        {
            Regex regul = new Regex(@"\w*\s(\w*)");
            Console.Title = "Clicks";
            Console.WriteLine("/help или /tips - Список команд");
            while (true)
            {
                //not worked
                if (regul.Matches(Console.ReadLine()).Count > 0) 
                {
                    switch (Console.ReadLine())
                    {
                        case "/test test": Console.WriteLine("meoow"); break;
                    }
                }
                else
                {
                    switch (Console.ReadLine())
                    {
                        case "/click": count++; break;
                        case "/watch": Console.Clear(); ShowInfo(); break;
                        case "/clear": Console.Clear(); Console.WriteLine("/help или /tips - Список команд"); break;
                        //case "/break": enter = !enter; break;
                        case "/autoclick": BuyAutoClick(); break;
                        case "/help": Console.Clear(); ShowTips(); break;
                        case "/tips": Console.Clear(); ShowTips(); break;
                        case "/zero": Console.Clear(); Zero(); break;
                        //case "/hiding": count += aim; break;
                    }
                }
            }
        }

        static void ShowInfo()
        {
            Console.WriteLine("" +
                                "Количество = " + count + "\n" +
                                "Цена = " + price + "\n" +
                                "Количество клонов за клик = " + mpc + "\n" +
                                "План клонирования = " + aim + "\n" +
                                //"что-то неизвестное" +  + "\n" +
                                "Уровень клонов = " + bonus);
        }

        static void ShowTips()
        {
            Console.WriteLine("/clear - очистить консоль\n" +
                "/click - создать клона\n" +
                "/watch - вывести количество\n" +
                "/zero - Повысить уровень клонов\n" +
                "/autoclick - начать/увеличить автоматическое клонирование");
        }

        static void Zero()
        {
            Console.Clear();
            if (count < aim) Console.WriteLine("Нужно больше золота:\n" + count + " / " + aim + " clones");
            else
            {
                timer.Dispose();
                count = 0;
                mpc = 1;
                price = 10;
                aim += aim / 100 * 20;
                bonus++;
                ShowInfo();
            }
        }

        static void BuyAutoClick() 
        {
            Console.Clear();
            if (count < price) Console.WriteLine("Нужно больше золота:\n" + count + " / " + price + " clones");
            else  
            {
                if (price == 10) StartTimer();
                count -= price;
                price *= 5;
                mpc *= 2 + bonus;
                ShowInfo();
            }
        }

        static void StartTimer()
        {
            timer = new Timer(Tm, null, 0, 1000);
        }

        static void Tm(object obj)
        {
            count += mpc;
            //Console.Clear();
            //Console.WriteLine("/help или /tips - Список команд");
            //Console.WriteLine("count=" + count + "\nprice=" + price + "\nmpc=" + mpc);
        }
    }
}
