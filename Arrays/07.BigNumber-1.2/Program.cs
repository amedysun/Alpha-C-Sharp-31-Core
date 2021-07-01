using System;
using System.Linq;

namespace _07.BigNumber_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayLength = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            int[] firstSequence = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int[] secondSequence = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            int[] result = new int[Math.Max(arrayLength[0], arrayLength[1])];
            int reminder = 0;

            int loops = 0;
            if (firstSequence.Length > secondSequence.Length)
            {
                loops = firstSequence.Length;
            }
            else
            {
                loops = secondSequence.Length;
            }

            for (int i = 0; i < loops; i++)
            {
                int currentNumberFromFirstArray = 0;
                if (i <= firstSequence.Length - 1)
                {
                    currentNumberFromFirstArray = firstSequence[i];
                }

                int currentNumberFromSecondArray = 0;
                if (i <= secondSequence.Length - 1)
                {
                    currentNumberFromSecondArray = secondSequence[i];
                }

                int sum = currentNumberFromFirstArray + currentNumberFromSecondArray + reminder;

                if (sum >= 10)
                {
                    reminder = 1;
                    sum %= 10;
                }
                else
                {
                    reminder = 0;
                }

                result[i] = sum % 10;
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
