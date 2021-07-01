using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.MatrixMaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumMax = int.MinValue;

            // rows
            int n = int.Parse(Console.ReadLine());

            // find columns length
            int[] arrayFirst = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[,] matrix = new int[n, arrayFirst.Length];

            FillMatrix(n, arrayFirst, matrix);
            Queue<int> receipt = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());

            while (receipt.Count != 0)
            {
                //taking rows and cols from recepit
                int currentRow = receipt.Dequeue();
                int currentCol = receipt.Dequeue();
                int sumCurr = 0;

                // if the current row is bigger than 0
                if (currentRow > 0)
                {
                    //looping from one to current col but before that we math abs current col becaus its negative number 
                    for (int col = 0; col <= Math.Abs(currentCol) - 1; col++)
                    {
                        sumCurr += matrix[currentRow - 1, col]; // adding the current value from matrix to our current summary
                    }
                    if (currentCol > 0) // if the current col is a positive number we go up in rows
                    {
                        // starting from where we left and go up until its the end
                        for (int row = currentRow - 2; row >= 0; row--)
                        {
                            sumCurr += matrix[row, currentCol - 1];
                        }
                    }
                    else
                    {
                        for (int row = currentRow; row <= matrix.GetLength(0) - 1; row++)
                        {
                            sumCurr += matrix[row, Math.Abs(currentCol) - 1];
                        }
                    }

                }

                else
                {
                    // we start from the end of  matrix col and loop until we areach our column from receipt
                    for (int col = matrix.GetLength(1) - 1; col >= Math.Abs(currentCol) - 1; col--)
                    {
                        sumCurr += matrix[Math.Abs(currentRow) - 1, col];
                    }
                    if (currentCol > 0)
                    {
                        for (int row = Math.Abs(currentRow) - 2; row >= 0; row--)
                        {
                            sumCurr += matrix[row, Math.Abs(currentCol) - 1];
                        }
                    }
                    else
                    {
                        for (int row = Math.Abs(currentRow); row <= matrix.GetLength(0) - 1; row++)
                        {
                            sumCurr += matrix[row, Math.Abs(currentCol) - 1];
                        }
                    }


                }

                //getting bigger sum
                if (sumCurr > sumMax)
                {
                    sumMax = sumCurr;
                }
            }
            Console.WriteLine(sumMax);
        }

        private static void FillMatrix(int n, int[] arrayFirst, int[,] matrix)
        {
            //fill first col in matrix
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[0, i] = arrayFirst[i];
            }

            // fill matrix
            for (int i = 1; i < n; i++)
            {
                int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();


                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    matrix[i, k] = array[k];
                }

            }
        }
    }
}
