using System;
using System.Text;

namespace _01.PrimesТоN
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            StringBuilder output = new StringBuilder();

            if (number == 1)
            {
                output.AppendLine(number.ToString());
                Console.WriteLine(output.ToString());
                return;
            }

            output.Append($"{1} ");
             
            for (int i = 1; i <= number; i++)
            {
                if (CheckIsPrime(i))
                {
                    output.Append($"{i} ");
                }
            }

            Console.WriteLine(output.ToString().TrimEnd());
        }
        private static bool CheckIsPrime(int number)
        {
            int i;
            for (i = 2; i <= number - 1; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            if (i == number)
            {
                return true;
            }
            return false;
        }
    }
}
