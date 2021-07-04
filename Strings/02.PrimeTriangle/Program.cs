using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.PrimeTriangle
{
    class Program
    {
        static bool IsPrime(int n)
        {
            if (n > 1)
            {
                return Enumerable.Range(1, n).Where(x => n % x == 0)
                    .SequenceEqual(new[] { 1, n });
            }

            return false;
        }
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            List<int> primes = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            StringBuilder triangle = new StringBuilder();
            triangle.AppendLine("1");

            for (int i = 0; i < primes.Count; i++)
            {
                for (int j = 1; j <= primes[i]; j++)
                {
                    if (IsPrime(j))
                    {
                        triangle.Append("1");
                    }
                    else if (j == 1)
                    {
                        triangle.Append("1");
                    }
                    else
                    {
                        triangle.Append("0");
                    }
                }
                triangle.AppendLine();
            }

            Console.WriteLine(triangle.ToString());
        }
    }
}
