using System;
using System.Linq;

namespace _12._Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizes = int.Parse(Console.ReadLine());

            string[][] beach = new string[sizes][];
            int collectedTokens = 0;
            int opponentTokens = 0;

            ReadMatrix(beach);
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Gong")
            {
                string[] commandArgs = command.Split(' ');
                string commandType = commandArgs[0];
                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);
                if (commandType == "Find" && IndexChecker(row,col,beach))
                {
                    if (beach[row][col] == "T")
                    {
                        beach[row][col] = "-";
                        collectedTokens++;
                    }
                }
                if (commandType == "Opponent" && IndexChecker(row,col,beach))
                {
                    string direction = commandArgs[3];
                    if (beach[row][col] == "T")
                    {
                        beach[row][col] = "-";
                        opponentTokens++;
                    }
                    if (direction == "up")
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            row--;
                            if (row < 0)
                            {
                                break;
                            }
                            if (beach[row][col] == "T")
                            {
                                opponentTokens++;
                                beach[row][col] = "-";
                            }
                        }
                    }
                    if (direction == "down")
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            row++;
                            if (row > beach.GetLength(0))
                            {
                                break;
                            }
                            if (beach[row][col] == "T")
                            {
                                opponentTokens++;
                                beach[row][col] = "-";
                            }
                        }
                    }
                    if (direction == "left")
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            col--;
                            if (col < 0)
                            {
                                break;
                            }
                            if (beach[row][col] == "T")
                            {
                                opponentTokens++;
                                beach[row][col] = "-";
                            }
                        }
                    }
                    if (direction == "right")
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            col++;
                            if (col >= beach[row].Length)
                            {
                                break;
                            }
                            if (beach[row][col] == "T")
                            {
                                opponentTokens++;
                                beach[row][col] = "-";
                            }
                        }
                    }
                }
            }
            PrintMatrix(beach);
            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");


        }

        private static void PrintMatrix(string[][] beach)
        {
            for (int row = 0; row < beach.GetLength(0); row++)
            {
                for (int col = 0; col < beach[row].Length; col++)
                {
                    Console.Write(beach[row][col] + " ");
                }
                Console.WriteLine();
            }
        }

        static bool IndexChecker(int row,int col, string[][] beach)
        {
            return row >= 0 && row < beach.GetLength(0) &&
                    col >= 0 && col < beach[row].Length;
        }

        private static void ReadMatrix(string[][] beach)
        {
            for (int row = 0; row < beach.GetLength(0); row++)
            {
                string [] cols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                beach[row] = cols;
            }
        }
    }
}
