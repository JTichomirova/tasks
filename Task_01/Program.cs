using System;
using System.Linq;

namespace TaskOne
{

    /// задача №1
    /// необходимо просуммировать все найденные числа
    /// исправить потенциальную ошибку
    ///
    /// задачу необходимо реализовать, дописав код, чтобы data.GetDigits() стал работоспособным

    public static class MyExtensions
    {
        public static int[] GetDigits(this String str)
        {
            return str.Where(a => int.TryParse(a.ToString(), out int res)).Select(c => int.Parse(c.ToString())).ToArray();
        }
    }

    class Program
    {  

        public static string RandomString(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        static void Main(string[] args)
        {
            int strLength = 5;

            if (strLength < Int32.MaxValue / 9)
            {
                string data = RandomString(strLength);
                int summary = 0; // byte summary = 0; 
                                 // Type Byte is not CLS-Compliant, so can't be used in LINQ and makes this code not available for distribution like a library for use with other CLS-compliant languages
                                 // Byte.MaxValue = 255, so for this task strLength can't be more than 28, but probably someone would like to set it more than 28. 
                                 // For int strLength can be 238609293, looks enough, probably even check (if clause) is redundant

                summary = data.GetDigits().Sum();

                Console.WriteLine($"{data} => {summary}");
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

        }
    }
}
