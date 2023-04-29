using System;
using System.Drawing;

namespace _01.Rally_racing
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizes = int.Parse(Console.ReadLine());
            string carNumber = Console.ReadLine();

            int rows = sizes;
            int cols = sizes;

            string[,] matrix = new string[rows, cols];
            ReadMatrix(matrix);

            string command = string.Empty;

            int currentRow = 0;
            int currentCol = 0;
            int kms = 0;

            int firstTunnelRow = 0;
            int firstTunnelCol = 0;
            int secondTunnelRow = 0;
            int secondTunnelCol = 0;

            bool isFirstTunnelFound = false;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == "T" && !isFirstTunnelFound) // if isFirstTunnelFound is still false
                    {
                        firstTunnelRow = row;
                        firstTunnelCol = col;
                        isFirstTunnelFound = true;
                    }
                    else if (matrix[row, col] == "T")
                    {
                        secondTunnelRow = row;
                        secondTunnelCol = col;
                    }
                }             

            }
            bool isFinished = false;

            while ((command = Console.ReadLine()) != "End")
            {
                matrix[currentRow, currentCol] = ".";

                if (command == "down")
                {
                    currentRow++;
                }
                if (command == "up")
                {
                    currentRow--;
                }
                if (command == "left")
                {
                    currentCol--;
                }
                if (command == "right")
                {
                    currentCol++;
                }

                if (matrix[currentRow, currentCol] == ".")
                {
                    kms += 10;
                }
                if (matrix[currentRow, currentCol] == "T")
                {
                    matrix[currentRow, currentCol] = ".";
                    if (currentRow == firstTunnelRow && currentCol == firstTunnelCol)
                    {
                        currentRow = secondTunnelRow;
                        currentCol = secondTunnelCol;
                    }
                    else
                    {
                        currentRow = firstTunnelRow;
                        currentCol = firstTunnelCol;
                    }
                    matrix[currentRow, currentCol] = ".";
                    kms += 30;
                }
                if (matrix[currentRow, currentCol] == "F")
                {
                    kms += 10;
                    isFinished = true;
                    break;
                }                
            }

            matrix[currentRow, currentCol] = "C"; // the last position in the matrix is always "C"

            if (isFinished)
            {
                Console.WriteLine($"Racing car {carNumber} finished the stage!");
            }
            else
            {
                Console.WriteLine($"Racing car {carNumber} DNF.");
            }
            Console.WriteLine($"Distance covered {kms} km.");
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }

        }
        private static void ReadMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine().Split();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
                Console.WriteLine();
            }
        }   

    }
}
