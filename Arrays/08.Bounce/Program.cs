using System;
using System.Linq;

namespace _08.Bounce
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = dimensions[0];
            int m = dimensions[1];

            ulong sum = 0;

            if (n == 1 || m == 1)
            {
                sum = 1;
                Console.WriteLine(sum);
                return;
            }

            ulong[,] matrix = FillingMatrix(n,m);

            int currentRow = 0;
            int currentCol = 0;
            bool moveRightAndDown = true;
            bool moveRightAndUp = false;
            bool moveLeftAndDown = false;
            bool moveLeftAndUp = false;

            while (true)
            {
                sum += matrix[currentRow, currentCol];

                if (moveRightAndDown == true)
                {
                    currentRow++;
                    currentCol++;
                }
                else if (moveRightAndUp == true)
                {
                    currentRow--;
                    currentCol++;
                }
                else if (moveLeftAndDown == true)
                {
                    currentRow++;
                    currentCol--;
                }
                else if (moveLeftAndUp == true)
                {
                    currentRow--;
                    currentCol--;
                }

                if ((currentRow == 0 && currentCol == m - 1) ||
                 (currentRow == n - 1 && currentCol == m - 1) ||
                 (currentRow == n - 1 && currentCol == 0))
                {
                    sum += matrix[currentRow, currentCol];
                    Console.WriteLine(sum);
                    return;
                }

                if (currentRow == n - 1 && moveRightAndDown)
                {
                    moveRightAndDown = false;
                    moveRightAndUp = true;
                }
                else if (currentCol == m - 1 && moveRightAndUp)
                {
                    moveRightAndUp = false;
                    moveLeftAndUp = true;
                }
                else if (currentRow == 0 && moveLeftAndUp)
                {
                    moveLeftAndUp = false;
                    moveLeftAndDown = true;
                }
                else if (currentCol == 0 && moveLeftAndDown)
                {
                    moveLeftAndDown = false;
                    moveRightAndDown = true;
                }
                else if (currentCol == m - 1 && moveRightAndDown)
                {
                    moveRightAndDown = false;
                    moveLeftAndDown = true;
                }
                else if (currentRow == n - 1 && moveLeftAndDown)
                {
                    moveLeftAndDown = false;
                    moveLeftAndUp = true;
                }
                else if (currentCol == 0 && moveLeftAndUp)
                {
                    moveLeftAndUp = false;
                    moveRightAndUp = true;
                }
                else if (currentRow == 0 && moveRightAndUp)
                {
                    moveRightAndUp = false;
                    moveRightAndDown = true;
                }
            }
        }

        static ulong[,] FillingMatrix(int n, int m)
        {
            ulong[,] matrix = new ulong[n, m];

            ulong counter = 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = counter;
                    counter *= 2;
                }

                counter = matrix[row, 0] * 2;
            }

            return matrix;
        }
    }
}