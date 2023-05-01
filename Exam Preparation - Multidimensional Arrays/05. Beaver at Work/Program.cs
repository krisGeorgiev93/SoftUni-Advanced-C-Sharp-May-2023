using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] pond = new char[size, size];

            int branchesLeft = 0;
            int currRow = 0;
            int currCol = 0;

            for (int row = 0; row < size; row++)
            {
                char[] cols = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    pond[row, col] = cols[col];

                    if (cols[col] == 'B')
                    {
                        currRow = row;
                        currCol = col;
                    }

                    if (char.IsLower(cols[col]))
                    {
                        branchesLeft++;
                    }
                }
            }

            Stack<char> branches = new Stack<char>();
            string move;

            while ((move = Console.ReadLine()) != "end")
            {
                int oldRow = currRow;
                int oldCol = currCol;
                switch (move)
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

                if (currRow < 0 || currRow >= size || currCol < 0 || currCol >= size)
                {
                    if (branches.Count != 0)
                    {
                        branches.Pop();
                    }

                    currRow = oldRow;
                    currCol = oldCol;

                    continue;
                }

                if (pond[currRow, currCol] == 'F')
                {
                    pond[currRow, currCol] = '-';

                    switch (move)
                    {
                        case "right":
                            currCol = currCol == size - 1 ? 0 : size - 1;
                            break;
                        case "left":
                            currCol = currCol == 0 ? size - 1 : 0;
                            break;
                        case "down":
                            currRow = currRow == size - 1 ? 0 : size - 1;
                            break;
                        case "up":
                            currRow = currRow == 0 ? size - 1 : 0;
                            break;
                    }
                }

                if (char.IsLower(pond[currRow, currCol]))
                {
                    branches.Push(pond[currRow, currCol]);
                    branchesLeft--;
                }

                pond[oldRow, oldCol] = '-';
                pond[currRow, currCol] = 'B';

                if (branchesLeft == 0)
                {
                    break;
                }
            }

            if (branchesLeft == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches.Reverse())}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branchesLeft} branches left.");
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{pond[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}