using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int rows = size;
            int cols = size;

            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;

            int[,] matrix = new int[size, size];

            for (int row = 0; row < rows; row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            //11 2 4
            //4 5 6
            //10 8 -12

            for (int i = 0; i < size; i++)
            {
                primaryDiagonal += matrix[i, i];
                secondaryDiagonal += matrix[size - i - 1, i];
            }

            int total = Math.Abs(primaryDiagonal - secondaryDiagonal);

            Console.WriteLine(total);

        }
    }
}
