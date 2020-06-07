using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Matrix
{
    public class MatrixInSnakePattern
    {
        public static void MatrixInSnakePatternDemo()
        {
            int[,] matrix = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            Console.WriteLine(" PrintThisMatrixSnakePatter(matrix);");
            PrintThisMatrixSnakePatter(matrix);


            Console.WriteLine(" PrintThisMatrixBoundtry(matrix);");
            PrintThisMatrixBoundtry(matrix);
        }

        private static void PrintThisMatrixBoundtry(int[,] matrix)
        {
            int left = 0;
            int right = matrix.GetLength(0) - 1;
            int top = 0;
            int bottom = matrix.GetLength(1) - 1;
            int count = 0;


            //while (left <= right && top <= bottom)
            while (count < matrix.Length)
            {
                for (int col = left; col <= right; col++)
                {
                    Console.Write(matrix[top, col] + " "); count++;
                }
                top++;

                Console.WriteLine();
                for (int row = top; row <= bottom; row++)
                {
                    Console.Write(matrix[row, right] + "  "); count++;
                }
                right--;
                Console.WriteLine();


                for (int col = right; col >= left; col--)
                {
                    Console.Write(matrix[bottom, col] + " "); count++;
                }
                bottom--;

                Console.WriteLine();

                for (int row = bottom; row >= top; row--)
                {
                    Console.Write(matrix[row, left] + "  "); count++;
                }
                left++;
            }

            Console.WriteLine();
        }

        private static void PrintThisMatrixSnakePatter(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Console.Write(matrix[i, j] + "   ");
                }
                Console.WriteLine();
            }
        }
    }
}
