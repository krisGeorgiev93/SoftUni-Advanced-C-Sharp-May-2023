using System;
using System.Linq;

namespace _17._Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];

            int[,] matrix = new int[rows, cols];
           

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] coordinates = command.Split(" ").Select(int.Parse).ToArray();
                int row = coordinates[0];
                int col = coordinates[1];
                int oldRow = row;
                int oldCol = col;
                if (isValidPosition(matrix, row, col))
                {
                    matrix[row, col]++;
                    while (row > 0)
                    {
                        row--;
                        matrix[row, col]++;
                    }
                    row = oldRow; // return to old coordinates
                    while (row < matrix.GetLength(0) -1)
                    {
                        row++;
                        matrix[row, col]++;
                    }
                    row = oldRow;
                    while (col > 0)
                    {
                        col--;
                        matrix[row, col]++;
                    }
                    col = oldCol;
                    while (col < matrix.GetLength(1) -1)
                    {
                        col++;
                        matrix[row, col]++;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }

            PrintMatrix(matrix);


            static bool isValidPosition(int[,] matrix, int row, int col)
            {
                return row >= 0 && row < matrix.GetLength(0)
                    && col >= 0 && col < matrix.GetLength(1);
            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
