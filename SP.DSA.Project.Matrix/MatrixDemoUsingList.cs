using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP.DSA.Project.Matrix
{
    public class MatrixDemoUsingList
    {
        public static void MatrixDemoUsingListDemo()
        {
            JaggedArrayDemo();
            //ShowMatrixDemo();
        }

        private static void JaggedArrayDemo()
        {
            int[][] jaggedArray ={ new int[]{ 1, 2, 3, 4, 5 },
                            new int[] { 6, 7, 8, 9 } };

            Console.WriteLine(" PrintThisJaggedArray(jaggedArray);");
            PrintThisJaggedArray(jaggedArray);
        }

        private static void PrintThisJaggedArray(int[][] jaggedArray)
        {
            int rows = jaggedArray.Length;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void ShowMatrixDemo()
        {
            List<List<int>> matrix = new List<List<int>>();
            matrix.Add(new List<int>() { 1, });
            matrix.Add(new List<int>() { 2, 2 });
            matrix.Add(new List<int>() { 3, 3, 3 });
            matrix.Add(new List<int>() { 4, 4, 4, 4 });
            matrix.Add(new List<int>() { 5, 5, 5, 5, 5 });
            matrix.Add(new List<int>() { 6, 6, 6, 6, 6, 6 });
            int rows = matrix.Count;
            int cols = matrix[0].Count;
            Console.WriteLine("rows :{0}, cols :{1}", rows, cols);
            PrintThisMatrix(matrix);

        }

        private static void PrintThisMatrix(List<List<int>> matrix)
        {
            int rows = matrix.Count;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
