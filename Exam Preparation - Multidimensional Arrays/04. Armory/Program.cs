using System;
using System.Linq;
namespace _04._Armory
{
    class Program
    {
        static void Main(string[] args)
        {

            int sizes = int.Parse(Console.ReadLine());


            string[,] matrix = new string[sizes, sizes];

            int goldCoins = 0;
            string command = string.Empty;
            int currentRow = 0;
            int currentCol = 0;
            int firstMirrorRow = 0;
            int firstMirrorCol = 0;
            int secondMirrorRow = 0;
            int secondMirrorCol = 0;
            bool isOutOfTheArmory = false;

            ReadMatrix(matrix);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "A")
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            bool isFirstMirror = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "M" && !isFirstMirror)
                    {
                        firstMirrorRow = row;
                        firstMirrorCol = col;
                        isFirstMirror = true;
                    }
                    else if (matrix[row, col] == "M")
                    {
                        secondMirrorRow = row;
                        secondMirrorCol = col;
                    }
                }
            }

            while (goldCoins < 65)
            {
                matrix[currentRow, currentCol] = "-";
                command = Console.ReadLine();
                if (command == "up" && currentRow == 0 || command == "down" && currentRow == matrix.GetLength(0) - 1
                    || command == "left" && currentCol == 0 || command == "right" && currentCol == matrix.GetLength(1) - 1)
                {
                    isOutOfTheArmory = true;
                    matrix[currentRow, currentCol] = "-";
                    break;
                }
                if (command == "up")
                {
                    currentRow--;
                }
                if (command == "down")
                {
                    currentRow++;
                }
                if (command == "left")
                {
                    currentCol--;
                }
                if (command == "right")
                {
                    currentCol++;
                }

                if (char.IsDigit(matrix[currentRow,currentCol][0]))
                {
                    goldCoins += int.Parse(matrix[currentRow, currentCol]);
                    if (goldCoins < 65)
                    {
                        matrix[currentRow, currentCol] = "-";
                    }
                    else
                    {
                        matrix[currentRow, currentCol] = "A";
                    }
                }
                if (matrix[currentRow, currentCol] == "M")
                {
                    matrix[currentRow, currentCol] = "-";
                    if (currentRow == firstMirrorRow && currentCol == firstMirrorCol)
                    {
                        currentRow = secondMirrorRow;
                        currentCol = secondMirrorCol;
                    }
                    else
                    {
                        currentRow = firstMirrorRow;
                        currentCol = firstMirrorCol;
                    }
                    matrix[currentRow, currentCol] = "A";
                }
            }

            if (isOutOfTheArmory)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }
            Console.WriteLine($"The king paid {goldCoins} gold coins.");
            PrintMatrix(matrix);


        }



        private static void PrintMatrix(string[,] matrix)
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
