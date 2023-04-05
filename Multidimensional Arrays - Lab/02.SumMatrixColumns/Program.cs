using System;
using System.Linq;

namespace _02.SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            


            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];


            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int sum = 0;
                    for (int row = 0; row < matrix.GetLength(1); row++)
                    {
                    sum += matrix[row, col];
                    }
                Console.WriteLine(sum);
                }
            
        }
    }
}
