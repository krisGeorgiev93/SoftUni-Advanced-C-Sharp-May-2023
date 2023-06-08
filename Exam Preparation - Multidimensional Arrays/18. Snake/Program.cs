using System;

namespace _18._Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizes = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizes, sizes];
            ReadMatrix(matrix);
            int snakeRow = 0;
            int snakeCol = 0;
            int firstBurrowRow = 0;
            int firstBurrowCol = 0;
            int secondBurrowRow = 0;
            int secondBurrowCol = 0;
            bool firstBurrowFound = false;
            int eatenFood = 0;
            bool goesOut = false;

            for (int row = 0; row < sizes; row++)
            {
                for (int col = 0; col < sizes; col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                    if (matrix[row, col] == 'B' && !firstBurrowFound)
                    {
                        firstBurrowRow = row;
                        firstBurrowCol = col;
                        firstBurrowFound = true;
                    }
                    else if (matrix[row,col] == 'B')
                    {
                        secondBurrowRow = row;
                        secondBurrowCol = col;
                    }
                }
            }

            while (true)
            {
                string direction = Console.ReadLine();
                matrix[snakeRow, snakeCol] = '.';
                switch (direction)
                {
                    case "up":
                        snakeRow--;
                        break;
                    case "down":
                        snakeRow++;
                        break;
                    case "left":
                        snakeCol--;
                        break;
                    case "right":
                        snakeCol++;
                        break;
                }
                if(IsValidPosition(matrix, snakeRow, snakeCol))
                {
                    if (matrix[snakeRow, snakeCol] == '*')
                    {
                        eatenFood++;
                        matrix[snakeRow, snakeCol] = 'S';
                    }
                    else if (matrix[snakeRow,snakeCol] == 'B')
                    {
                        if (snakeRow == firstBurrowRow && snakeCol == firstBurrowCol)
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            snakeRow = secondBurrowRow;
                            snakeCol = secondBurrowCol;
                            matrix[snakeRow, snakeCol] = 'S';
                        }
                        else
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            snakeRow = firstBurrowRow;
                            snakeCol = firstBurrowCol;
                            matrix[snakeRow, snakeCol] = 'S';
                        }
                    }
                    else if (matrix[snakeRow,snakeCol] == '-')
                    {
                        matrix[snakeRow, snakeCol] = 'S';
                    }
                    if (eatenFood >= 10)
                    {
                        break;
                    }

                }
                else
                {
                    goesOut = true;
                    break;
                }
            }

            if (goesOut)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {eatenFood}");
            PrintMatrix(matrix);
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

        private static bool IsValidPosition(char[,] matrix, int snakeRow, int snakeCol)
        {
            return snakeRow >= 0 && snakeRow < matrix.GetLength(0)
                && snakeCol >= 0 && snakeCol < matrix.GetLength(1);
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
    }
}
