using System;
using System.Drawing;
using System.Linq;

namespace _06._Help_A_Mole
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizes = int.Parse(Console.ReadLine());

            int rows = sizes;
            int cols = sizes;
            char[,] matrix = new char[rows, cols];

            ReadMatrix(matrix, rows, cols);

            int currRow = 0;
            int currCol = 0;
            int firstSpecialRow = 0;
            int firstSpecialCol = 0;
            int secondSpecialRow = 0;
            int secondSpecialCol = 0;
            int totalPoints = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'M')
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }


            bool isFirstSpecialLocation = false;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'S' && !isFirstSpecialLocation)
                    {
                        firstSpecialRow = row;
                        firstSpecialCol = col;
                        isFirstSpecialLocation = true;
                    }
                    else if (matrix[row, col] == 'S')
                    {
                        secondSpecialRow = row;
                        secondSpecialCol = col;
                    }
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End" && totalPoints < 25)
            {
                int oldRow = currRow;
                int oldCol = currCol;
                matrix[oldRow, oldCol] = '-';
                switch (command)
                {
                    case "up":
                        currRow--;
                        break;
                    case "down":
                        currRow++;
                        break;
                    case "left":
                        currCol--;
                        break;
                    case "right":
                        currCol++;
                        break;
                }
                if (currRow < 0 || currRow >= sizes || currCol < 0 || currCol >= sizes)
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    currRow = oldRow; // return the old values !
                    currCol = oldCol;
                }
                if (matrix[currRow,currCol] == '-')
                {
                    matrix[currRow, currCol] = 'M';
                }
                if (matrix[currRow, currCol] == 'S')
                {
                    if (currRow == firstSpecialRow && currCol == firstSpecialCol)
                    {
                        matrix[currRow, currCol] = '-';
                        currRow = secondSpecialRow;
                        currCol = secondSpecialCol;
                        matrix[currRow, currCol] = 'M';
                    }
                    else
                    {
                        matrix[currRow, currCol] = '-';
                        currRow = firstSpecialRow;
                        currCol = firstSpecialCol;
                        matrix[currRow, currCol] = 'M';
                    }
                    totalPoints -= 3;
                }
                if (char.IsDigit(matrix[currRow, currCol]))
                {
                    totalPoints += int.Parse(matrix[currRow, currCol].ToString());
                    matrix[currRow, currCol] = 'M';
                }               

            }

            if (totalPoints >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
            }
            if (totalPoints >= 25)
            {
                Console.WriteLine($"The Mole managed to survive with a total of {totalPoints} points.");
            }
            else
            {
                Console.WriteLine($"The Mole lost the game with a total of {totalPoints} points.");
            }
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }

        private static void ReadMatrix(char[,] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
        }
    }
}
