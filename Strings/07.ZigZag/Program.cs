using System;
using System.Linq;
using System.Numerics;

namespace _07.ZigZag
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sides = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int n = sides[0];
            int m = sides[1];

            if (n == 1 ||m  == 1)
            {
                Console.WriteLine(1);
                return;
            }

            ulong summary = 0;

            for (int currentRow = 0; currentRow < n; currentRow++)
            {
                for (int currentCol = 0; currentCol < m; currentCol++)
                {
                    if (FirstAdd(currentRow, currentCol)) // Add first time
                    {
                        Sum(currentRow, currentCol, ref summary);
                    }

                    if (SecondAdd(currentRow, currentCol, n, m)) // Add second time
                    {
                        Sum(currentRow, currentCol, ref summary);
                    }
                }
            }

            Console.WriteLine(summary);
        }
        static bool FirstAdd(int currentRow, int currentCol)
        {
            return (currentRow % 2 == 0 && currentCol % 2 == 0) || (currentRow % 2 != 0 && currentCol % 2 != 0);
        }
        static bool SecondAdd(int currentRow, int currentCol, int row, int col)
        {
            return currentRow != 0 && currentRow != row - 1 && currentCol != 0 && currentCol != col - 1 && FirstAdd(currentRow, currentCol);
        }
        static ulong Sum(int row, int col, ref ulong sum)
        {
            return sum += (ulong)(1 + 3 * row + 3 * col);
        }
    }
}
