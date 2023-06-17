namespace matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(",").Select(int.Parse).ToArray();

            int rows = sizes[0];
            int cols = sizes[1];
            char[,] matrix = new char[rows, cols];
            ReadMatrix(matrix);
            int mouseRow = 0;
            int mouseCol = 0;
            int foundCheese = 0;
            int totalCheese = 0;
            bool cheeseFinished = false;
            bool mouseIsTrapped = false;

            string direction = string.Empty;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'M')
                    {
                        mouseRow = row;
                        mouseCol = col;
                    }
                    if (matrix[row, col] == 'C')
                    {
                        totalCheese++;
                    }
                }
            }

            while ((direction = Console.ReadLine()) != "danger")
            {
                int oldRow = mouseRow;
                int oldCol = mouseCol;
                switch (direction)
                {
                    case "up":
                        mouseRow--;
                        break;
                    case "down":
                        mouseRow++;
                        break;
                    case "left":
                        mouseCol--;
                        break;
                    case "right":
                        mouseCol++;
                        break;
                }

                if (IsValid(matrix, mouseRow, mouseCol))
                {
                    if (matrix[mouseRow, mouseCol] == '*')
                    {
                        matrix[oldRow, oldCol] = '*';
                        matrix[mouseRow, mouseCol] = 'M';
                    }
                    else if (matrix[mouseRow, mouseCol] == 'C')
                    {
                        matrix[oldRow, oldCol] = '*';
                        matrix[mouseRow, mouseCol] = 'M';
                        foundCheese++;
                        if (foundCheese == totalCheese)
                        {
                            cheeseFinished = true;
                            break;
                        }
                    }
                    else if (matrix[mouseRow, mouseCol] == 'T')
                    {
                        matrix[oldRow, oldCol] = '*';
                        matrix[mouseRow, mouseCol] = 'M';
                        mouseIsTrapped = true;
                        break;
                    }
                    else if (matrix[mouseRow, mouseCol] == '@')
                    {
                        mouseRow = oldRow;
                        mouseCol = oldCol;
                    }
                }
                else
                {
                    mouseRow = oldRow;
                    mouseCol = oldCol;
                    Console.WriteLine("No more cheese for tonight!");
                    break;
                }
            }
            if (cheeseFinished)
            {
                Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
            }
            if (mouseIsTrapped)
            {
                Console.WriteLine("Mouse is trapped!");
            }
            if (direction == "danger")
            {
                Console.WriteLine("Mouse will come back later!");
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

        static bool IsValid(char[,] matrix, int mouseRow, int mouseCol)
        {
            return mouseRow >= 0 && mouseRow < matrix.GetLength(0) &&
                   mouseCol >= 0 && mouseCol < matrix.GetLength(1);
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