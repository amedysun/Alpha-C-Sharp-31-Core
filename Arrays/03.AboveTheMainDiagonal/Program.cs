using System;
using System.Numerics;

namespace _03.AboveTheMainDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger[,] matrix = CreateMatrix(n);
            BigInteger sum = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (col > row)
                    {
                        sum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine(sum);
        }

        static BigInteger[,] CreateMatrix(int size)
        {
            BigInteger[,] matrix = new BigInteger[size, size];

            BigInteger currentRow = 1;
            BigInteger counter = 1;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = counter;
                    counter *= 2;

                    if (col == size - 1)
                    {
                        currentRow *= 2;
                        counter = currentRow;
                    }
                }
            }
            return matrix;
        }
    }
}
