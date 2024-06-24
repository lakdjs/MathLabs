using System;
using System.Linq;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var calc = new Sqrt();

            Console.WriteLine("Введите число, из которого нужно вычислить корень");
            int num = calc.CorrectNum();
            calc.Calculate(num);
        }
    }
}