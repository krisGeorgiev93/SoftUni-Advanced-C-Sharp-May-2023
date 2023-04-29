using System;
using System.Drawing;
using System.Linq;

namespace _03._Blind_Man_s_Buff
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] rowsData = Console.ReadLine().Split();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowsData[col];
                }
            }

            int startingRow = 0;
            int startingCol = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == "B")
                    {
                        startingRow = row;
                        startingCol = col;
                    }
                }
            }

            string command = string.Empty;
            

            int totalMoves = 0;
            int touchedOpponents = 0;

            while ((command = Console.ReadLine()) != "Finish" && touchedOpponents < 3)
            {
                if (OutOfBounds(command, startingRow, startingCol, matrix) || BlockedPosition(command, startingRow, startingCol, matrix))
                {
                    continue;
                }

                if (command == "up")
                {
                    startingRow--;
                }
                if (command == "down")
                {
                    startingRow++;
                }
                if (command == "left")
                {
                    startingCol--;
                }
                if (command == "right")
                {
                    startingCol++;
                }
                if (matrix[startingRow, startingCol] == "P")
                {
                    matrix[startingRow, startingCol] = "-";
                    touchedOpponents++;
                }
                totalMoves++;
            }

            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {totalMoves}");

            bool OutOfBounds(string direction, int row, int col, string[,] matrix)
            {
                if ((direction == "left" && col == 0) ||
                 (direction == "right" && col == matrix.GetLength(1) - 1) ||
                 (direction == "up" && row == 0) ||
                 (direction == "down" && row == matrix.GetLength(0) - 1))
                {                 
                    return true;
                }
                    return false;

            }
            bool BlockedPosition(string direction, int row, int col, string[,] matrix)
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
                if (matrix[row, col] == "O")
                {
                    return true;
                }
                return false;
            }
        }
    }
}
