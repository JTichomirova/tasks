using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace Task_04
{

    /// Задача - дорабатываем будильник
    /// необходимо написать метод, который позволит считать, сколько времени осталось до того, как зазвонит будильник


    class Program
    {
        public static DateTime[] AlarmClockTimer(DateTime wakeUp, DateTime now)
        {
            return Enumerable.Range(0, wakeUp.Subtract(now).Seconds + 1).Select(offset => now.AddSeconds(offset)).ToArray();
        }

        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            var wakeUp = now.AddSeconds(10);
            foreach (DateTime value in AlarmClockTimer(wakeUp,now))
            {

                Console.WriteLine((wakeUp - value).ToString(@"dd\.hh\:mm\:ss"));
                Thread.Sleep(1000); 
            }
        }
    }
}
