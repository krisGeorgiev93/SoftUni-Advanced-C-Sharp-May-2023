using System;

namespace _16._Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            bool outOfMatrix = false;
            int firstPillarRow = 0;
            int firstPillarCol = 0;
            int secondPillarRow = 0;
            int secondPillarCol = 0;
            bool firstPillarFound = false;
            int currentRow = 0;
            int currentCol = 0;

            int totalMoney = 0;
            ReadMatrix(matrix);
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                    if (matrix[row, col] == 'O' && !firstPillarFound)
                    {
                        firstPillarRow = row;
                        firstPillarCol = col;
                        firstPillarFound = true;
                    }
                    else if (matrix[row, col] == 'O')
                    {
                        secondPillarRow = row;
                        secondPillarCol = col;
                    }
                }
            }

            while (true)
            {
                if (totalMoney >= 50)
                {
                    matrix[currentRow, currentCol] = 'S';
                    break;
                }
                int oldRow = currentRow;
                int oldCol = currentCol;
                matrix[oldRow, oldCol] = '-';
                string direction = Console.ReadLine();
                switch (direction)
                {
                    case "up":
                        currentRow--;
                        break;
                    case "down":
                        currentRow++;
                        break;
                    case "left":
                        currentCol--;
                        break;
                    case "right":
                        currentCol++;
                        break;
                }
                if (isValidPosition(matrix, currentRow, currentCol))
                {
                    if (char.IsDigit(matrix[currentRow, currentCol]))
                    {
                        char targetChar = matrix[currentRow, currentCol];
                        totalMoney += int.Parse(targetChar.ToString());
                        matrix[currentRow, currentCol] = '-';
                        continue;
                    }
                    if (matrix[currentRow, currentCol] == 'O')
                    {
                        if (currentRow == firstPillarRow && currentCol == firstPillarCol)
                        {
                            matrix[secondPillarRow, secondPillarCol] = 'S';
                            matrix[firstPillarRow, firstPillarCol] = '-';
                            currentRow = secondPillarRow;
                            currentCol = secondPillarCol;
                        }
                        else
                        {
                            matrix[firstPillarRow, firstPillarCol] = 'S';
                            matrix[secondPillarRow, secondPillarCol] = '-';
                            currentRow = firstPillarRow;
                            currentCol = firstPillarCol;
                        }
                    }
                    if (matrix[currentRow, currentCol] == '-')
                    {
                        matrix[currentRow, currentCol] = 'S';
                    }
                }
                else
                {
                    outOfMatrix = true;
                    matrix[oldRow, oldCol] = '-';
                    break;
                }
            }
            if (outOfMatrix)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {totalMoney}");
            PrintMatrix(matrix);
            static bool isValidPosition(char[,] matrix, int row, int col)
            {
                return row >= 0 && row < matrix.GetLength(0)
                    && col >= 0 && col < matrix.GetLength(1);
            }



        }

        static void ReadMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
        }
        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}