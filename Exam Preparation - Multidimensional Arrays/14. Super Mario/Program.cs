using System;
using System.Diagnostics;
using System.Linq;

namespace _14._Super_Mario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int marioLives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            bool marioIsDead = false;
            bool marioIsWinner = false;

            char[][] matrix = new char[rows][];
            int currentMarioRow = 0;
            int currentMarioCol = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string line = Console.ReadLine();

                matrix[i] = new char[line.Length];

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (line[j] == 'M')
                    {
                        currentMarioRow = i;
                        currentMarioCol = j;
                        matrix[i][j] = '-';
                        continue;
                    }
                    matrix[i][j] = line[j];
                }
            }

            string command = string.Empty;
            while (true)
            {
                command = Console.ReadLine();
                string[] tokens = command.Split(" ").ToArray();
                string direction = tokens[0];
                int bowserRow = int.Parse(tokens[1]);
                int bowserCol = int.Parse(tokens[2]);

                int marioRow = currentMarioRow;
                int marioCol = currentMarioCol;
                matrix[marioRow][marioCol] = '-';
                matrix[bowserRow][bowserCol] = 'B';
                switch (direction)
                {
                    case "W":
                        if (IndexChecker(--marioRow, marioCol, matrix)) currentMarioRow--;
                        break;
                    case "S":
                        if (IndexChecker(++marioRow, marioCol, matrix)) currentMarioRow++;
                        break;
                    case "A":
                        if (IndexChecker(marioRow, --marioCol, matrix)) currentMarioCol--;
                        break;
                    case "D":
                        if (IndexChecker(marioRow, ++marioCol, matrix)) currentMarioCol++;
                        break;
                }
                marioLives--;
                marioRow = currentMarioRow;
                marioCol = currentMarioCol;

                if (matrix[marioRow][marioCol] == 'P')
                {
                    marioIsWinner = true;
                    matrix[marioRow][marioCol] = '-';
                    break;
                }

                if (matrix[marioRow][marioCol] == 'B')
                {
                    marioLives -= 2;
                    matrix[marioRow][marioCol] = '-';
                }

                if (marioLives <= 0)
                {
                    matrix[marioRow][marioCol] = 'X';
                    marioIsDead = true;
                    break;
                }
            }



            if (marioIsDead)
            {
                Console.WriteLine($"Mario died at {currentMarioRow};{currentMarioCol}.");
            }
            if (marioIsWinner)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLives}");
            }
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j]);
                }
                Console.WriteLine();
            }
        }

        static bool IndexChecker(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix[row].Length;
        }
    }
}
