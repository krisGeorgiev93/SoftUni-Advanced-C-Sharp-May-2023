using System;

namespace _08.__Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizes = int.Parse(Console.ReadLine());


            char[,] matrix = new char[sizes, sizes];
            int vankoRow = 0;
            int vankoCol = 0;
            int holesCounter = 1;
            int rodsCounter = 0;
            ReadMatrix(matrix);
            bool IsElectrocurted = false;

            //Find Vanko's position
            for (int row = 0; row < sizes; row++)
            {
                for (int col = 0; col < sizes; col++)
                {
                    if (matrix[row, col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;
                        break;
                    }
                }
            }

            string direction = string.Empty;
            while ((direction = Console.ReadLine()) != "End")
            {
                //old row col positions before directions command
                int oldRow = vankoRow;
                int oldCol = vankoCol;

                if (direction == "down")
                {
                    vankoRow++;
                }
                if (direction == "up")
                {
                    vankoRow--;
                }
                if (direction == "left")
                {
                    vankoCol--;
                }
                if (direction == "right")
                {
                    vankoCol++;
                }

                //checks if is in the sizes
                if (vankoRow < 0 || vankoRow >= sizes || vankoCol < 0 || vankoCol >= sizes)
                {
                    vankoRow = oldRow;
                    vankoCol = oldCol;
                    continue;
                }

                if (matrix[vankoRow, vankoCol] == '-')
                {
                    matrix[vankoRow, vankoCol] = 'V';
                    matrix[oldRow, oldCol] = '*';
                    holesCounter++;
                    continue;
                }
                if (matrix[vankoRow, vankoCol] == 'R')
                {
                    vankoRow = oldRow;
                    vankoCol = oldCol;
                    Console.WriteLine("Vanko hit a rod!");
                    rodsCounter++;
                    continue;
                }
                if (matrix[vankoRow, vankoCol] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                    matrix[oldRow, oldCol] = '*';
                    matrix[vankoRow, vankoCol] = 'V'; // always the new position is "V" !!
                    continue;
                }
                if (matrix[vankoRow, vankoCol] == 'C')
                {
                    matrix[vankoRow, vankoCol] = 'E';
                    matrix[oldRow, oldCol] = '*';
                    holesCounter++;
                    IsElectrocurted = true;
                    break;
                }
            }

            if (IsElectrocurted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCounter} hole(s).");
            }
            else
            {               
                Console.WriteLine($"Vanko managed to make {holesCounter} hole(s) and he hit only {rodsCounter} rod(s).");
            }

            PrintMatrix(matrix);



            void PrintMatrix(char[,] matrix)
            {
                for (int row = 0; row < sizes; row++)
                {
                    for (int col = 0; col < sizes; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }
            }
            void ReadMatrix(char[,] matrix)
            {
                for (int row = 0; row < sizes; row++)
                {
                    string rowData = Console.ReadLine();
                    for (int col = 0; col < sizes; col++)
                    {
                        matrix[row, col] = rowData[col];
                    }
                }
            }
        }


    }
}
