using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.BackTracking
{
    public class QueenSolutionChess
    {
        public static void QueenSolutionChessDemo()
        {
            int size = 4;
            int[,] board = new int[size, size];
            Console.WriteLine("Queen can be placed :{0}", QueenSolve(board, size));
        }

        private static bool QueenSolve(int[,] board, int size)
        {
            return QueenSolveHelper(board, size, 0);
        }

        private static bool QueenSolveHelper(int[,] board, int size, int col)
        {
            if (col == size)
            {
                PrintBoard(board, size);
                return true;
            }
            // go to each row. 
            for (int row = 0; row < size; row++)
            {
                if (IsSafe(board, row, col, size))
                {
                    board[row, col] = 1;
                    if (QueenSolveHelper(board, size, col + 1))
                        return true;
                    else
                        board[row, col] = 0;
                }
            }
            return false;
        }

        private static void PrintBoard(int[,] board, int size)
        {
            Console.WriteLine();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static bool IsSafe(int[,] board, int row, int col, int size)
        {
            for (int i = 0; i < col; i++)
            {
                if (board[row, i] == 1)
                    return false;
            }

            for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1)
                    return false;
            }

            for (int i = row, j = col; i < size && j >= 0; i++, j--)
            {
                if (board[row, col] == 1)
                    return false;
            }

            return true;
        }
    }
}
