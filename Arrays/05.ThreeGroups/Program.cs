using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ThreeGroups
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ')
                .Select(int.Parse).ToList();

            List<int> remainderOne = new List<int>();
            List<int> remainderTwo = new List<int>();
            List<int> remainderThree = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];

                if (currentNumber % 3 == 0)
                {
                    remainderOne.Add(currentNumber);
                }
                else if (currentNumber % 3 == 1)
                {
                    remainderTwo.Add(currentNumber);
                }
                else
                {
                    remainderThree.Add(currentNumber);
                }
            }

            Console.WriteLine(string.Join(" ", remainderOne));
            Console.WriteLine(string.Join(" ", remainderTwo));
            Console.WriteLine(string.Join(" ", remainderThree));
        }
    }
}
