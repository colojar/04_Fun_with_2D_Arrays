namespace _04_Fun_with_2D_Arrays
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            const string FILL_METHOD_NUMBERS = "numbers";
            const string FILL_METHOD_CHESSBOARD = "chessboard";
            const string FILL_METHOD_RANDOM = "random";

            Random random = new();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("04 - Fun with 2D arrays!");
                Console.WriteLine("==========================================================================");
                Console.WriteLine("= This is a playground for 2D arrays.                                    =");
                Console.WriteLine("= You can create a grid of any size and fill it with values.             =");
                Console.WriteLine("= You can also modify specific ranges and print the content of the grid. =");
                Console.WriteLine("==========================================================================");

                int rows;
                int columns;

                while (true)
                {
                    Console.Write("Enter grid size (e.g. 3 x 5): ");
                    string? input = Console.ReadLine()?.ToLower()?.Replace(" ", "");

                    if (string.IsNullOrEmpty(input) || !input.Contains('x'))
                    {
                        Console.WriteLine("Invalid format. Use 'int x int'.");
                        continue;
                    }
                    string[] dimensions = input.Split('x');

                    if (dimensions.Length != 2 ||
                        !int.TryParse(dimensions[0], out rows) ||
                        !int.TryParse(dimensions[1], out columns))
                    {
                        Console.WriteLine("Both dimensions must be integers.");
                        continue;
                    }

                    if (rows <= 1 || columns <= 1)
                    {
                        Console.WriteLine("Both numbers must be greater than one.");
                        continue;
                    }

                    break;
                }
                dynamic[,] grid = new dynamic[rows, columns];

                Console.WriteLine($"Please choose the fill method: {FILL_METHOD_NUMBERS}, {FILL_METHOD_CHESSBOARD}, {FILL_METHOD_RANDOM}");
                string? fillMethod = Console.ReadLine()?.ToLower();
                switch (fillMethod)
                {
                    case FILL_METHOD_NUMBERS:
                        int value = 1;
                        for (int i = 0; i < grid.GetLength(0); i++)
                        {
                            for (int j = 0; j < grid.GetLength(1); j++)
                            {
                                grid[i, j] = value++;
                            }
                        }
                        break;
                    case FILL_METHOD_CHESSBOARD:
                        for (int i = 0; i < grid.GetLength(0); i++)
                        {
                            for (int j = 0; j < grid.GetLength(1); j++)
                            {
                                if ((i + j) % 2 == 0)
                                {
                                    grid[i, j] = 'X';
                                }
                                else
                                {
                                    grid[i, j] = 'O';
                                }
                            }
                        }
                        break;
                    case FILL_METHOD_RANDOM:
                        for (int i = 0; i < grid.GetLength(0); i++)
                        {
                            for (int j = 0; j < grid.GetLength(1); j++)
                            {
                                grid[i, j] = random.Next(1, 101);
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid fill method. Please try again.");
                        continue;
                }
                Console.WriteLine("====================================");
                Console.WriteLine("Grid filled successfully!");
                Console.WriteLine("====================================");
                Console.WriteLine("Grid content:");
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    for (int j = 0; j < grid.GetLength(1); j++)
                    {
                        Console.Write($"{grid[i, j],3} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
