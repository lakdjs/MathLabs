using System;
using System.Linq;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //last kt
            Console.WriteLine("напишите строку");
            string a =  Console.ReadLine();
            


            int Determine(string s)
            {
                int left = 0;
                int right = 0;
                int max = 0;

                
                var chars = s.ToCharArray();
                string sub = "";

                while (right < chars.Length)
                {
                    if (sub.Contains(chars[right]))
                    {
                        sub = "";
                        left++;
                    }
                    else
                    {
                        sub += chars[right];
                        right++;
                        max = Math.Max(max, sub.Length);
                    }
                }

                return max;
            }

            int maxlen = Determine(a);
            Console.WriteLine(maxlen);
        }
    }
}