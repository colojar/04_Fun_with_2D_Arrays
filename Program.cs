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
            const string DISPLAY_MODE_INDICES = "indices";
            const string DISPLAY_MODE_BORDER = "border";
            const string DISPLAY_MODE_BOXED = "boxed";

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

                // get grid size
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

                // get fill method
                while (true)
                {
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
                                    grid[i, j] = random.Next(1, 100);
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
                    break;
                }

                // Choose display mode
                while (true)
                {
                    Console.WriteLine($"Choose the display mode: {DISPLAY_MODE_INDICES}, {DISPLAY_MODE_BORDER}, {DISPLAY_MODE_BOXED}");
                    string? displayMode = Console.ReadLine()?.ToLower();
                    int cellWidth = 0;

                    switch (displayMode)
                    {
                        case DISPLAY_MODE_INDICES:
                            Console.WriteLine("Grid with Indices and Borders:");

                            // Determine the maximum width of any index string
                            int maxIndexWidth = 0;
                            for (int i = 0; i < grid.GetLength(0); i++)
                            {
                                for (int j = 0; j < grid.GetLength(1); j++)
                                {
                                    string indexString = $"[{i},{j}]";
                                    maxIndexWidth = Math.Max(maxIndexWidth, indexString.Length);
                                }
                            }

                            // Print the grid with indices and borders
                            for (int i = 0; i < grid.GetLength(0); i++)
                            {
                                for (int j = 0; j < grid.GetLength(1); j++)
                                {
                                    Console.Write($"[{i},{j}]".PadRight(maxIndexWidth));
                                    if (j < grid.GetLength(1) - 1) Console.Write(" | ");
                                }
                                Console.WriteLine();
                                if (i < grid.GetLength(0) - 1)
                                {
                                    Console.WriteLine(new string('-', (grid.GetLength(1) * (maxIndexWidth + 2)) + (grid.GetLength(1) -3))); // Adjust for spacing
                                }
                            }
                            break;

                        case DISPLAY_MODE_BORDER:
                            Console.WriteLine("Grid Border Highlight:");

                            // Determine the maximum width of any cell in the grid
                            for (int i = 0; i < grid.GetLength(0); i++)
                            {
                                for (int j = 0; j < grid.GetLength(1); j++)
                                {
                                    cellWidth = Math.Max(cellWidth, grid[i, j].ToString().Length);
                                }
                            }
                            cellWidth += 1;

                            Console.WriteLine(new string('#', (grid.GetLength(1) * (cellWidth + 1)) + 2));

                            for (int i = 0; i < grid.GetLength(0); i++)
                            {
                                Console.Write("#"); // Left border
                                for (int j = 0; j < grid.GetLength(1); j++)
                                {
                                    Console.Write($" {grid[i, j].ToString().PadLeft(cellWidth - 1)} "); // Grid value with padding
                                }
                                Console.WriteLine("#"); // Right border
                            }

                            // Print the bottom border
                            Console.WriteLine(new string('#', (grid.GetLength(1) * (cellWidth + 1)) + 2));
                            break;

                        case DISPLAY_MODE_BOXED:
                            Console.WriteLine("Grid with Boxed Cells:");

                            // Determine the maximum width of any cell in the grid
                            for (int i = 0; i < grid.GetLength(0); i++)
                            {
                                for (int j = 0; j < grid.GetLength(1); j++)
                                {
                                    cellWidth = Math.Max(cellWidth, grid[i, j].ToString().Length);
                                }
                            }
                            cellWidth += 1; // Add padding for spacing

                            // Print the top border
                            Console.Write("+");
                            for (int j = 0; j < grid.GetLength(1); j++)
                            {
                                Console.Write(new string('-', cellWidth +1 ) + "+");
                            }
                            Console.WriteLine();

                            // Print the grid rows with boxed cells
                            for (int i = 0; i < grid.GetLength(0); i++)
                            {
                                Console.Write("|"); // Left border
                                for (int j = 0; j < grid.GetLength(1); j++)
                                {
                                    Console.Write($" {grid[i, j].ToString().PadLeft(cellWidth - 1)} |");
                                }
                                Console.WriteLine();

                                // Print the row separator
                                Console.Write("+");
                                for (int j = 0; j < grid.GetLength(1); j++)
                                {
                                    Console.Write(new string('-', cellWidth +1) + "+");
                                }
                                Console.WriteLine();
                            }
                            break;
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
