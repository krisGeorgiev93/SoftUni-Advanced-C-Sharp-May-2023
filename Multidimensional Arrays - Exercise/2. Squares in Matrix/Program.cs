﻿using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            //3,4
            //A B B D
            //E B B B
            //I J B B
            int count = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row,col] == matrix[row,col+1] &&
                        matrix[row,col] == matrix[row+1,col] &&
                        matrix[row,col] == matrix[row+1,col+1])
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
