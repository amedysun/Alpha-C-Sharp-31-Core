using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.KnightMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] board = new int[n, n];

            //List<bool> allMoves = new List<bool>(8);
            board[0, 0] = 1;

            int row = 0;
            int col = 0;

            for (int value = 2; value <= n * n; value++)
            {

                //2 up 1 left
                if (ValidateCurrentValue(board, row - 2, col - 1))
                {
                    row -= 2;
                    col -= 1;
                    board[row, col] = value;
                }
                //2 up 1 right
                else if (ValidateCurrentValue(board, row - 2, col + 1))
                {
                    row -= 2;
                    col += 1;
                    board[row, col] = value;
                }
                //2 left 1 up
                else if (ValidateCurrentValue(board, row - 1, col - 2))
                {
                    row -= 1;
                    col -= 2;
                    board[row, col] = value;
                }
                //2 right 1 up
                else if (ValidateCurrentValue(board, row - 1, col + 2))
                {
                    row -= 1;
                    col += 2;
                    board[row, col] = value;
                }
                //2 left 1 down
                else if (ValidateCurrentValue(board, row + 1, col - 2))
                {
                    row += 1;
                    col -= 2;
                    board[row, col] = value;
                }
                //2 right 1 down
                else if (ValidateCurrentValue(board, row + 1, col + 2))
                {
                    col += 2;
                    row += 1;
                    board[row, col] = value;
                }
                //2 down 1 left
                else if (ValidateCurrentValue(board, row + 2, col - 1))
                {
                    row += 2;
                    col -= 1;
                    board[row, col] = value;
                }
                //2 down 1 right
                else if (ValidateCurrentValue(board, row + 2, col + 1))
                {
                    row += 2;
                    col += 1;
                    board[row, col] = value;
                }
                else
                {
                    row = 0;
                    col = 0;
                    while (board[row, col] != 0)
                    {
                        col++;
                        if (col > board.GetLength(1) - 1)
                        {
                            col = 0;
                            row++;
                        }
                    }
                    board[row, col] = value;
                }
            }

            PrintBoard(board);
        }

        private static void PrintBoard(int[,] board)
        {
            StringBuilder boardPrint = new StringBuilder();
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    boardPrint.Append(board[row, col] + " ");
                }
                boardPrint.AppendLine();
            }

            Console.WriteLine(boardPrint.ToString().TrimEnd());
        }

        static bool ValidatePosition(int row, int col, int[,] board)
        {
            return row < board.GetLength(0) && col < board.GetLength(1) && row >= 0 && col >= 0;
        }

        private static bool ValidateCurrentValue(int[,] board,int row,int col)
        {
            if (ValidatePosition(row,col,board))
            {
                if (board[row, col] == 0)
                {
                    return true;
                }                
            }
            return false;
        }
    }
}
