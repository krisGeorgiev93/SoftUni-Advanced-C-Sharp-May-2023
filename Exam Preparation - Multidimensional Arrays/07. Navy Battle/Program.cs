

int sizes = int.Parse(Console.ReadLine());

char[,] matrix = new char[sizes, sizes];

ReadMatrix(matrix);
int submarinRow = 0;
int submarinCol = 0;
int hitMines = 0;
int destroyedCruisers = 0;

for (int row = 0; row < sizes; row++)
{
    for (int col = 0; col < sizes; col++)
    {
        if (matrix[row, col] == 'S')
        {
            submarinRow = row;
            submarinCol = col;
        }
    }
}

while (hitMines < 3 && destroyedCruisers < 3)
{
    string direction = Console.ReadLine();
    matrix[submarinRow, submarinCol] = '-';
    if (direction == "up")
    {
        submarinRow--;
    }
    if (direction == "down")
    {
        submarinRow++;
    }
    if (direction == "left")
    {
        submarinCol--;
    }
    if (direction == "right")
    {
        submarinCol++;
    }

    if (matrix[submarinRow, submarinCol] == '-')
    {
        matrix[submarinRow, submarinCol] = 'S';
    }
    if (matrix[submarinRow, submarinCol] == '*')
    {
        matrix[submarinRow, submarinCol] = 'S';
        hitMines++;
        if (hitMines == 3)
        {
            Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{submarinRow}, {submarinCol}]!");
            break;
        }
    }

    if (matrix[submarinRow, submarinCol] == 'C')
    {
        destroyedCruisers++;
        matrix[submarinRow, submarinCol] = 'S';
        if (destroyedCruisers == 3)
        {
            Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
            break;
        }
    }
}

PrintMatrix(matrix);
void PrintMatrix(char[,] matrix)
{
    for (int row = 0; row < sizes; row++)
    {
        for (int col = 0; col < sizes; col++)
        {
            Console.Write(matrix[row,col]);
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

