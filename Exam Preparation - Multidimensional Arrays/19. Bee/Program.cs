using System;

namespace Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizes = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizes, sizes];
            ReadMatrix(matrix);
            int flowers = 0;
            int beeRow = 0;
            int beeCol = 0;
            for (int row = 0; row < sizes; row++)
            {
                for (int col = 0; col < sizes; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }
            bool goesOut = false;

            string direction = string.Empty;
            while ((direction = Console.ReadLine()) != "End")
            {
                matrix[beeRow, beeCol] = '.';
                switch (direction)
                {
                    case "up":
                        beeRow--;
                        break;
                    case "down":
                        beeRow++;
                        break;
                    case "left":
                        beeCol--;
                        break;
                    case "right":
                        beeCol++;
                        break;
                }

                if (IsValidPosition(matrix, beeRow, beeCol))
                {
                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        flowers++;
                        matrix[beeRow, beeCol] = 'B';
                    }
                    else if (matrix[beeRow, beeCol] == 'O')
                    {
                        matrix[beeRow, beeCol] = '.';
                        if (direction == "up")
                        {
                            if (matrix[beeRow - 1, beeCol] == 'f')
                            {
                                flowers++;
                            }
                            matrix[beeRow - 1, beeCol] = 'B';
                            beeRow--;
                        }
                        if (direction == "down")
                        {
                            if (matrix[beeRow + 1, beeCol] == 'f')
                            {
                                flowers++;
                            }
                            matrix[beeRow + 1, beeCol] = 'B';
                            beeRow++;

                        }
                        if (direction == "left")
                        {
                            if (matrix[beeRow, beeCol - 1] == 'f')
                            {
                                flowers++;
                            }
                            matrix[beeRow, beeCol - 1] = 'B';
                            beeCol--;

                        }
                        if (direction == "right")
                        {
                            if (matrix[beeRow, beeCol + 1] == 'f')
                            {
                                flowers++;
                            }
                            matrix[beeRow, beeCol + 1] = 'B';
                            beeCol++;
                        }
                    }
                    else if (matrix[beeRow,beeCol] == '.')
                    {
                        matrix[beeRow, beeCol] = 'B';
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
                Console.WriteLine("The bee got lost!");
            }

            if (flowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-flowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
            }

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

        private static bool IsValidPosition(char[,] matrix, int beeRow, int beeCol)
        {
            return beeRow >= 0 && beeRow < matrix.GetLength(0)
                && beeCol >= 0 && beeCol < matrix.GetLength(1);
        }
        private static void ReadMatrix(char[,] matrix)
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
