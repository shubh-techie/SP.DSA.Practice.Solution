using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Matrix
{
    public class TransposeMatrix
    {
        public static void TransposeMatrixDemo()
        {
            int[,] matrix = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            PrintThisMatrix(matrix);

            RotateMatrixBy90Degree(matrix);

            //DoTransposeMatrixBigON(matrix);
            //DoTransposeMatrix(matrix);
            //Console.WriteLine("After transpose.");
            //PrintThisMatrix(matrix);

        }

        private static void RotateMatrixBy90Degree(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            //Do Tranpose the matrix 
            for (int i = 0; i < rows; i++)
            {
                for (int j = i; j < cols; j++)
                {
                    int temp = matrix[j, i];
                    matrix[j, i] = matrix[i, j];
                    matrix[i, j] = temp;
                }
            }

            Console.WriteLine("After Transpose.");
            PrintThisMatrix(matrix);

            // reverse the matrix
            for (int i = 0; i < rows / 2; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[rows - i - 1, j];
                    matrix[rows - i - 1, j] = temp;
                }
            }
            Console.WriteLine("After Reverse.");
            PrintThisMatrix(matrix);

        }

        private static void DoTransposeMatrixBigON(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = i + 1; j < cols; j++)
                {
                    int temp = matrix[j, i];
                    matrix[j, i] = matrix[i, j];
                    matrix[i, j] = temp;
                }
            }
        }

        private static void DoTransposeMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] Temp = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Temp[i, j] = matrix[j, i];
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = Temp[i, j];
                }
            }

            Console.WriteLine("temp array");
            PrintThisMatrix(Temp);

        }

        private static void PrintThisMatrix(int[,] matrix)
        {
            Console.WriteLine("+++++++++ Here is Your Matrix ++++++++++");
            Console.WriteLine();
            int rows = matrix.GetLength(0);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("++++++++ Here is Your Matrix ++++++++++");
        }
    }
}
