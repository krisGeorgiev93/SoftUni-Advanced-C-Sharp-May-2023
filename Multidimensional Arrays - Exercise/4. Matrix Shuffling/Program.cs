using System;
using System.Data;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                string[] tokens = command.Split();

                if (tokens[0] == "END")
                {
                    break;
                }
                if (tokens.Length == 5)
                {
                    string commandType = tokens[0];
                    int row1 = int.Parse(tokens[1]);
                    int col1 = int.Parse(tokens[2]);
                    int row2 = int.Parse(tokens[3]);
                    int col2 = int.Parse(tokens[4]);

                    if (IsValid(rows,cols,tokens))
                    {
                        string firstElement = matrix[row1, col1];
                        string secondElement = matrix[row2, col2];
                        matrix[row1, col1] = secondElement;
                        matrix[row2, col2] = firstElement;

                        PrintMatrix();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }


            void PrintMatrix()
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write($"{matrix[row, col]} ");
                    }
                    Console.WriteLine();
                }
            }


            bool IsValid(int rows, int cols, string[] tokens)
            {
                return
                  tokens[0] == "swap" && tokens.Length == 5 &&
                  int.Parse(tokens[1]) >= 0 && int.Parse(tokens[1]) < rows &&
                  int.Parse(tokens[2]) >= 0 && int.Parse(tokens[2]) < cols &&
                  int.Parse(tokens[3]) >= 0 && int.Parse(tokens[3]) < rows &&
                  int.Parse(tokens[4]) >= 0 && int.Parse(tokens[4]) < cols;
            }
        }
    }
}
