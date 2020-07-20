using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Matrix
{
    public class PracticeSetOneMatrix
    {
        public static void PracticeSetOneMatrixStart()
        {
            //SumMatrixDemo();
            //SumOfUpperAndLower();
            //PrintSnakePattern();
            TransposeDemo();
        }

        private static void TransposeDemo()
        {
            int[,] matrix = { { 1, 1, 1, 1 }, { 2, 2, 2, 2 }, { 3, 3, 3, 3 }, { 4, 4, 4, 4 } };
            Console.WriteLine("Before................");
            PrintMatrix(matrix);

            int rows = matrix.GetLength(0);
            for (int i = 0; i < rows; i++)
            {
                for (int j = i + 1; j < rows; j++)
                {
                        //Dosing swapping
                        int temp = matrix[i, j];
                        matrix[i, j] = matrix[j, i];
                        matrix[j, i] = temp;
                }
            }

            Console.WriteLine("After................");
            PrintMatrix(matrix);
        }

        private static void PrintSnakePattern()
        {
            int[,] matrix = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };


            int rows = matrix.GetLength(0);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (i % 2 == 0)
                        Console.Write(matrix[i, j] + "   ");
                    else
                        Console.Write(matrix[i, rows - j - 1] + "   ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static void SumOfUpperAndLower()
        {
            int[,] matrix1 = new int[,] { { 6, 5, 4 }, { 1, 2, 5 }, { 7, 9, 7 } };
            PrintSum(matrix1);

        }

        private static void PrintSum(int[,] matrix1)
        {
            int upperSUM = 0, lowerSUM = 0;
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    if (j >= i)
                    {
                        upperSUM += matrix1[i, j];
                    }

                    if (i >= j)
                    {
                        lowerSUM += matrix1[i, j];
                    }
                }
            }
            Console.WriteLine("upper Sum :{0}, lower Sum :{1}", upperSUM, lowerSUM);
        }


        private static void SumMatrixDemo()
        {
            int[,] matrix1 = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            int[,] matrix2 = new int[,] { { 1, 3 }, { 3, 2 }, { 3, 3 } };
            PrintMatrix(matrix1);
            ProvideAddition(matrix1, matrix2);
            PrintMatrix(matrix1);
        }

        private static void PrintMatrix(int[,] matrix1)
        {
            Console.WriteLine();

            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    Console.Write(matrix1[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static void ProvideAddition(int[,] matrix1, int[,] matrix2)
        {
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    matrix1[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
        }
    }
}
