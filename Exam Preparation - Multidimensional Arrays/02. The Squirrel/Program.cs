using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._The_Squirrel
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizes = int.Parse(Console.ReadLine());

            Queue<string> movingCommands = new Queue<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));
            string[,] matrix = new string[sizes, sizes];

            ReadMatrix(matrix);
            int startingRow = -1;
            int startingCol = -1;
            int totalHazelnuts = 0;

            bool isTrappedOrLeft = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "s")
                    {
                        startingRow = row;
                        startingCol = col;
                        matrix[startingRow, startingCol] = "*";
                    }
                }
            }

            while (totalHazelnuts < 3 && movingCommands.Any())
            {
                string direction = movingCommands.Dequeue();
                if (OutOfBounds(direction, startingRow, startingCol, matrix) || PositionIsATrap(direction, startingRow, startingCol, matrix))
                {
                    break;
                }
                if (direction == "up")
                {
                    startingRow--;
                }
                if (direction == "down")
                {
                    startingRow++;
                }
                if (direction == "left")
                {
                    startingCol--;
                }
                if (direction == "right")
                {
                    startingCol++;
                }

                if (matrix[startingRow, startingCol] == "h")
                {
                    totalHazelnuts++;
                    matrix[startingRow, startingCol] = "*";
                    if (totalHazelnuts == 3)
                    {
                        break;
                    }
                }
                if (matrix[startingRow, startingCol] == "t")
                {
                    totalHazelnuts = 0;
                    Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                    Console.WriteLine($"Hazelnuts collected: {totalHazelnuts}");
                    return;
                }
            }

            if (!isTrappedOrLeft)
            {
                if (totalHazelnuts == 3)
                {
                    Console.WriteLine($"Good job! You have collected all hazelnuts!");
                }
                else
                {
                    Console.WriteLine($"There are more hazelnuts to collect.");
                }
            }

            Console.WriteLine($"Hazelnuts collected: {totalHazelnuts}");

            bool PositionIsATrap(string direction, int row, int col, string[,] field)
            {
                switch (direction)
                {
                    case "left":
                        col--;
                        break;
                    case "right":
                        col++;
                        break;
                    case "up":
                        row--;
                        break;
                    case "down":
                        row++;
                        break;
                }

                if (field[row, col] == "t")
                {
                    Console.WriteLine($"Unfortunately, the squirrel stepped on a trap...");
                    isTrappedOrLeft = true;
                    return true;
                }
                return false;
            }

            bool OutOfBounds(string direction, int startRow, int startCol, string[,] matrix)
            {
                if ((direction == "left" && startCol == 0) ||
             (direction == "right" && startCol == matrix.GetLength(1) - 1) ||
             (direction == "up" && startRow == 0) ||
             (direction == "down" && startRow == matrix.GetLength(0) - 1))
                {
                    Console.WriteLine($"The squirrel is out of the field.");
                    isTrappedOrLeft = true;
                    return true;
                }

                return false;
            }
        }      



        private static void ReadMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col].ToString();
                }
            }
        }
    }
}

