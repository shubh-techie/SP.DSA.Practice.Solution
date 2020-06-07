using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Matrix
{
    public class MatrixDemo
    {
        public static void MatrixDemoStart()
        {
            //TwoDimArray();
            //TwoDimArrayOther();
            TwoDimArrayModel();
        }

        private static void TwoDimArrayModel()
        {
            int[][] arr = new int[3][];
            arr[0] = new int[] { 0, 0, 0 };
            arr[1] = new int[] { 1, 1, 1 };
            arr[2] = new int[] { 2, 2, 2 };
            int rows = arr.Length;
            int cols = arr[0].Length;
            Console.WriteLine("rows :{0}, cols :{1}", rows, cols);

            Console.WriteLine(" PrintTwoDMatrixArrayDimension(arr)  ");
            PrintTwoDMatrixArrayDimension(arr);
        }

        public static void PrintTwoDMatrixArrayDimension(int[][] arr)
        {
            int rows = arr.Length;
            int cols = arr[0].Length;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void TwoDimArrayOther()
        {
            int[,] arr = { { 2, 3, 4 }, { 2, 3, 4 }, { 2, 3, 4 } };

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void TwoDimArray()
        {
            int[,] arr = new int[3, 3];
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);

            Console.WriteLine("rows :{0}, cols :{1}", rows, cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    arr[i, j] = i;
                }
                Console.WriteLine();
            }
            Console.WriteLine("PrintTwoDMatrix(int[,] arr)");
            PrintTwoDMatrix(arr);
        }

        public static void PrintTwoDMatrix(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
