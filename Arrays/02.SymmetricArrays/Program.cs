using System;
using System.Linq;

namespace _02.SymmetricArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());

            bool IsSymmetric = true;

            for (int i = 0; i < loops; i++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(' ').Select(int.Parse).ToArray();

                for (int k = 0, j = numbers.Length - 1; k < j; k++, j--)
                {
                    int left = numbers[k];
                    int right = numbers[j];

                    if (left != right)
                    {
                        IsSymmetric = false;
                        break;
                    }
                }

                if (IsSymmetric)
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }

                IsSymmetric = true;
            }
        }
    }
}
