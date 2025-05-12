namespace _04_Fun_with_2D_Arrays
{
    internal class Program
    {
        const string FILL_METHOD_NUMBERS = "numbers";
        const string FILL_METHOD_CHECKERS = "checkers";
        const string FILL_METHOD_RANDOM = "random";
        const int FILL_METHOD_RANGE_LOW = 1;
        const int FILL_METHOD_RANGE_HIGH = 100;
        const string FILL_METHOD_ICONS = "icons";
        const string DISPLAY_MODE_INDICES = "indices";
        const string DISPLAY_MODE_BORDER = "border";
        const string DISPLAY_MODE_BOXED = "boxed";
        const string COLOR_METHOD_NONE = "none";
        const string COLOR_METHOD_HEATMAP = "heatmap";
        const string COLOR_METHOD_RANDOM = "random";

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            Random random = new();
            List<string> utf8Icons = new()
            {
                "😀", "😁", "😂", "🤣", "😃", "😄", "😅", "😆", "😉", "😊", // 1-10
                "😋", "😎", "😍", "😘", "😗", "😙", "😚", "🙂", "🤗", "🤩", // 11-20
                "🤔", "🤨", "😐", "😑", "😶", "🙄", "😏", "😣", "😥", "😮", // 21-30
                "🤐", "😯", "😪", "😫", "😴", "😌", "😛", "😜", "😝", "🤤", // 31-40
                "😒", "😓", "😔", "😕", "🙃", "🤑", "😲", "☹️", "🙁", "😖", // 41-50
                "😞", "😟", "😤", "😢", "😭", "😦", "😧", "😨", "😩", "🤯", // 51-60
                "😬", "😰", "😱", "🥵", "🥶", "😳", "🤪", "😵", "😡", "😠", // 61-70
                "🤬", "😷", "🤒", "🤕", "🤢", "🤮", "🤧", "😇", "🥳", "🥸", // 71-80
                "😈", "👿", "👻", "💀", "☠️", "👽", "👾", "🤖", "🎃", "😺", // 81-90
                "😸", "😹", "😻", "😼", "😽", "🙀", "😿", "😾", "🦄", "🐱"  // 91-100
            };

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
                    Console.WriteLine($"Please choose the fill method: {FILL_METHOD_NUMBERS}, {FILL_METHOD_CHECKERS}, {FILL_METHOD_ICONS}, {FILL_METHOD_RANDOM}");
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
                        case FILL_METHOD_CHECKERS:
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
                                    grid[i, j] = random.Next(FILL_METHOD_RANGE_LOW, FILL_METHOD_RANGE_HIGH);
                                }
                            }
                            break;
                        case FILL_METHOD_ICONS:
                            for (int i = 0; i < grid.GetLength(0); i++)
                            {
                                for (int j = 0; j < grid.GetLength(1); j++)
                                {
                                    grid[i, j] = utf8Icons[random.Next(0, utf8Icons.Count)];
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

                // Choose color method
                string colorMethod = COLOR_METHOD_NONE;
                while (true)
                {
                    Console.WriteLine($"Choose the color method: {COLOR_METHOD_NONE}, {COLOR_METHOD_RANDOM}, {COLOR_METHOD_HEATMAP}");
                    Console.WriteLine($"Note: Color methods only available for fill methods: {FILL_METHOD_NUMBERS}, {FILL_METHOD_RANDOM}");
                    Console.WriteLine($"      and display methods: {DISPLAY_MODE_BORDER}, {DISPLAY_MODE_BOXED}");
                    colorMethod = Console.ReadLine()?.ToLower();
                    switch (colorMethod)
                    {
                        case COLOR_METHOD_NONE:
                            Console.WriteLine("No color method selected.");
                            break;
                        case COLOR_METHOD_RANDOM:
                            Console.WriteLine("Random color method selected.");
                            break;
                        case COLOR_METHOD_HEATMAP:
                            Console.WriteLine("Heatmap color method selected.");
                            break;
                        default:
                            Console.WriteLine("Invalid color method. Please try again.");
                            continue;
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
                                    Console.WriteLine(new string('-', (grid.GetLength(1) * (maxIndexWidth + 2)) + (grid.GetLength(1) - 3))); // Adjust for spacing
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
                                    string value = grid[i, j].ToString().PadLeft(cellWidth - 1);
                                    ApplyColorMethod(value, grid[i, j], colorMethod, grid);
                                    Console.Write($" {value} ");
                                    Console.ResetColor();
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
                                Console.Write(new string('-', cellWidth + 1) + "+");
                            }
                            Console.WriteLine();

                            // Print the grid rows with boxed cells
                            for (int i = 0; i < grid.GetLength(0); i++)
                            {
                                Console.Write("|"); // Left border
                                for (int j = 0; j < grid.GetLength(1); j++)
                                {
                                    string value = grid[i, j].ToString().PadLeft(cellWidth - 1);
                                    ApplyColorMethod(value, grid[i, j], colorMethod, grid);
                                    Console.Write($" {value} |");
                                    Console.ResetColor();
                                }
                                Console.WriteLine();

                                // Print the row separator
                                Console.Write("+");
                                for (int j = 0; j < grid.GetLength(1); j++)
                                {
                                    Console.Write(new string('-', cellWidth + 1) + "+");
                                }
                                Console.WriteLine();
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid display method. Please try again.");
                            continue;
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                }
            }
        }

        static void ApplyColorMethod(string value, int cellValue, string? colorMethod, dynamic[,] grid)
        {

            if (colorMethod == COLOR_METHOD_HEATMAP)
            {
                int min = int.MaxValue, max = int.MinValue;
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    for (int j = 0; j < grid.GetLength(1); j++)
                    {
                        min = Math.Min(min, grid[i, j]);
                        max = Math.Max(max, grid[i, j]);
                    }
                }

                int range = max - min;
                if (range == 0) range = 1; // no division by zero

                // Map the value to a heatmap color
                double normalized = (double)(cellValue - min) / range; // guarantee 0.0 to 1.0
                if (normalized < 0.2) Console.ForegroundColor = ConsoleColor.Blue;
                else if (normalized < 0.4) Console.ForegroundColor = ConsoleColor.Green;
                else if (normalized < 0.6) Console.ForegroundColor = ConsoleColor.Yellow;
                else if (normalized < 0.8) Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Magenta;
            }
            if (colorMethod == COLOR_METHOD_RANDOM)
            {
                // Apply a random color to each cell
                Random random = new();
                Console.ForegroundColor = (ConsoleColor)random.Next(1, 16); // Random color from ConsoleColor
            }
        }
    }
}