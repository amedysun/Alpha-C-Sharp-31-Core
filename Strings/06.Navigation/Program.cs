using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _06.Navigation
{
    class Program
    {
        static void Main(string[] args)
        {
            byte R = byte.Parse(Console.ReadLine());
            byte C = byte.Parse(Console.ReadLine());

            BigInteger[,] board = new BigInteger[R, C];

            BigInteger summmary = 0;

            FillMatrix(R, C, board);

            byte moves = byte.Parse(Console.ReadLine());

            Queue<int> code = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToList());

            int coefficient = Math.Max(R, C);

            int startingRow = R - 1;
            int startingCol = 0;

            bool[,] stepedPlacesInBoard = new bool[R, C];

            for (int i = 0; i < moves; i++)
            {
                int currentCode = code.Dequeue();
                int endingRow = currentCode / coefficient;
                int endingCol = currentCode % coefficient;

                if (startingCol < endingCol)
                {
                    for (int col = startingCol; col <= endingCol; col++)
                    {
                        if (!stepedPlacesInBoard[startingRow, col])
                        {
                            summmary += board[startingRow, col];
                        }
                        stepedPlacesInBoard[startingRow, col] = true;
                    }
                }
                else
                {
                    for (int col = startingCol; col >= endingCol; col--)
                    {
                        if (!stepedPlacesInBoard[startingRow, col])
                        {
                            summmary += board[startingRow, col];
                        }
                        stepedPlacesInBoard[startingRow, col] = true;
                    }
                }
                startingCol = endingCol;
                
                if (startingRow > endingRow)
                {
                    for (int row = startingRow; row >= endingRow; row--)
                    {
                        if (!stepedPlacesInBoard[row, startingCol])
                        {
                            summmary += board[row, startingCol];
                        }
                        stepedPlacesInBoard[row, startingCol] = true;
                    }
                }
                else
                {
                    for (int row = startingRow; row <= endingRow; row++)
                    {
                        if (!stepedPlacesInBoard[row, startingCol])
                        {
                            summmary += board[row, startingCol];
                        }
                        stepedPlacesInBoard[row, startingCol] = true;
                    }
                }
                startingRow = endingRow;
            }

            Console.WriteLine(summmary);
        }

        private static void FillMatrix(byte R, byte C, BigInteger[,] board)
        {
            BigInteger startingValue = 1;
            BigInteger manipulatedValue = startingValue;
            for (int row = R - 1; row >= 0; row--)
            {
                board[row, 0] = startingValue;
                for (int col = 1; col < C; col++)
                {
                    board[row, col] = manipulatedValue * 2;
                    manipulatedValue = board[row, col];
                }
                startingValue *= 2;
                manipulatedValue = startingValue;
            }
        }
    }
}
