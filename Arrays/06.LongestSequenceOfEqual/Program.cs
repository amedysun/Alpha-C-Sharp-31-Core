using System;

namespace _06.LongestSequenceOfEqual
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int lastNummber = int.Parse(Console.ReadLine());
            int currNumber;
            int max = 1;
            int count = 1;

            for (int i = 1; i < n; i++)
            {
                currNumber = int.Parse(Console.ReadLine());

                if (currNumber == lastNummber)
                {
                    count++;

                    if (count > max)
                    {
                        max = count;
                    }
                }
                else
                {
                    count = 1;
                }

                lastNummber = currNumber;
            }

            Console.WriteLine(max);
        }
    }
}
