using System;
using System.ComponentModel;
using System.Drawing;

namespace _10._Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Black truffle -'B'
            //Summer truffle -'S'
            //White truffle -'W'

            int sizes = int.Parse(Console.ReadLine());
            int rows = sizes;
            int cols = sizes;
            int blackTruffles = 0;
            int summerTruffles = 0;
            int whiteTruffles = 0;
            int eatenTruffles = 0;

            string[,] forest = new string[rows, cols];
            ReadMatrix(forest);

            string command;
            while ((command = Console.ReadLine()) != "Stop the hunt")
            {
                string[] tokens = command.Split(' ');
                if (tokens[0] == "Collect")
                {
                    int currentRow = int.Parse(tokens[1]);
                    int currentCol = int.Parse(tokens[2]);
                    if (forest[currentRow, currentCol] == "W")
                    {
                        whiteTruffles++;
                        forest[currentRow, currentCol] = "-";
                    }
                    else if (forest[currentRow, currentCol] == "B")
                    {
                        blackTruffles++;
                        forest[currentRow, currentCol] = "-";
                    }
                    else if (forest[currentRow, currentCol] == "S")
                    {
                        summerTruffles++;
                        forest[currentRow, currentCol] = "-";
                    }
                }
                if (tokens[0] == "Wild_Boar")
                {
                    int currentRow = int.Parse(tokens[1]);
                    int currentCol = int.Parse(tokens[2]);
                    string direction = tokens[3];                  

                    if (forest[currentRow, currentCol] == "W")
                    {
                        eatenTruffles++;
                        forest[currentRow, currentCol] = "-";
                    }
                    else if (forest[currentRow, currentCol] == "B")
                    {
                        eatenTruffles++;
                        forest[currentRow, currentCol] = "-";
                    }
                    else if (forest[currentRow, currentCol] == "S")
                    {
                        eatenTruffles++;
                        forest[currentRow, currentCol] = "-";
                    }                                  

                    if (direction == "up")
                    {
                        
                        for (int i = currentRow; i >= 0; i -= 2)
                        {
                            if (forest[i, currentCol] == "W" || forest[i, currentCol] == "S" || forest[i, currentCol] == "B")
                            {
                                eatenTruffles++;
                                forest[i, currentCol] = "-";
                            }
                        }
                    }
                    if (direction == "down")
                    {                       
                        for (int i = currentRow; i < forest.GetLength(0); i += 2)
                        {
                            if (forest[i, currentCol] == "W" || forest[i, currentCol] == "S" || forest[i, currentCol] == "B")
                            {
                                eatenTruffles++;
                                forest[i, currentCol] = "-";
                            }
                        }
                    }
                    if (direction == "left")
                    {
                        for (int i = currentCol; i >= 0; i -= 2)
                        {
                            if (forest[currentRow, i] == "W" || forest[currentRow, i] == "S" || forest[currentRow, i] == "B")
                            {
                                eatenTruffles++;
                                forest[currentRow, i] = "-";
                            }
                        }
                    }
                    if (direction == "right")
                    {                       
                        for (int i = currentCol; i < forest.GetLength(1); i += 2)
                        {
                            if (forest[currentRow, i] == "W" || forest[currentRow, i] == "S" || forest[currentRow, i] == "B")
                            {
                                eatenTruffles++;
                                forest[currentRow, i] = "-";
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"Peter manages to harvest {blackTruffles} black, {summerTruffles} summer, and {whiteTruffles} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eatenTruffles} truffles.");
            PrintForest(forest);
        }

        private static void PrintForest(string[,] forest)
        {
            for (int row = 0; row < forest.GetLength(0); row++)
            {
                for (int col = 0; col < forest.GetLength(1); col++)
                {
                    Console.Write(forest[row,col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void ReadMatrix(string[,] forest)
        {
            for (int row = 0; row < forest.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < forest.GetLength(1); col++)
                {
                    forest[row, col] = rowData[col];
                }
            }
        }
    }
}
