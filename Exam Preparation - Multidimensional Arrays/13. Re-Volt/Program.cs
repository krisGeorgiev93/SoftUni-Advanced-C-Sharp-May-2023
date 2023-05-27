using System;

namespace _13._Re_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int sizes = int.Parse(Console.ReadLine());
            int numberOfCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizes, sizes];
            ReadMatrix(matrix);
            int playerRow = 0;
            int playerCol = 0;
            bool PlayerIsWinner = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                        break;
                    }
                }
            }
            // If the player goes out of the matrix, he comes in from the other side.
            //If the player steps on a bonus, he should move another step forward in the direction he is going.
            //If the player steps on a trap, he should move a step backwards.

            //When the player reaches the finish mark or the count of commands is reached the game ends.

            for (int i = 0; i < numberOfCommands; i++)
            {
                string direction = Console.ReadLine();
                matrix[playerRow, playerCol] = '-';
                switch (direction)
                {
                    case "up":
                        if (IsValid(--playerRow, playerCol, matrix))
                        {
                            if (matrix[playerRow, playerCol] == 'B')
                            {
                                playerRow--;
                                if (!IsValid(playerRow, playerCol, matrix))
                                {
                                    playerRow = matrix.GetLength(0) - 1;
                                }
                            }
                            else if (matrix[playerRow, playerCol] == 'T')
                            {
                                playerRow++;
                            }
                        }
                        else
                        {
                            playerRow = matrix.GetLength(0) - 1;
                        }
                        break;
                    case "down":
                        if (IsValid(++playerRow, playerCol, matrix))
                        {
                            if (matrix[playerRow, playerCol] == 'B')
                            {
                                playerRow++;
                                if (!IsValid(playerRow, playerCol, matrix))
                                {
                                    playerRow = 0;
                                }
                            }
                            else if (matrix[playerRow, playerCol] == 'T')
                            {
                                playerRow--;
                            }
                        }
                        else
                        {
                            playerRow = 0;
                        }
                        break;
                    case "right":
                        if (IsValid(playerRow, ++playerCol, matrix))
                        {
                            if (matrix[playerRow, playerCol] == 'B')
                            {
                                playerCol++;
                                if (!IsValid(playerRow, playerCol, matrix))
                                {
                                    playerCol = 0;
                                }
                            }
                            else if (matrix[playerRow, playerCol] == 'T')
                            {
                                playerCol--;
                            }
                        }
                        else
                        {
                            playerCol = 0;
                        }
                        break;
                    case "left":
                        if (IsValid(playerRow, --playerCol, matrix))
                        {
                            if (matrix[playerRow, playerCol] == 'B')
                            {
                                playerCol--;
                                if (!IsValid(playerRow, playerCol, matrix))
                                {
                                    playerCol = matrix.GetLength(1) - 1;
                                }
                            }
                            else if (matrix[playerRow, playerCol] == 'T')
                            {
                                playerCol++;
                            }
                        }
                        else
                        {
                            playerCol = matrix.GetLength(1) - 1;
                        }
                        break;
                }
                if (matrix[playerRow, playerCol] == 'F')
                {
                    matrix[playerRow, playerCol] = 'f';
                    PlayerIsWinner = true;
                    break;
                }
            }
            if (PlayerIsWinner)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                matrix[playerRow, playerCol] = 'f';
                Console.WriteLine("Player lost!");
            }
            PrintMatrix(matrix);
            static bool IsValid(int row, int col, char[,] matrix)
            {
                return row >= 0 && row < matrix.GetLength(0) &&
                       col >= 0 && col < matrix.GetLength(1);
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
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
