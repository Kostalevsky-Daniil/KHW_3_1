using ClassLibrary;

class Program
{
    public static void Main()
    {
        // try
        // {
            do
            {
                var x = JsonParser.ReadJson("/Users/daniilkostalevsky/Code/C#/KHW_3_1/KHW_3_1/data_13V (1).json");
                // for (int i = 0; i < x.Count; i++)
                // {
                //     Console.WriteLine(x[i].PropertyId);
                //     Console.WriteLine(x[i].Address);
                //     Console.WriteLine(x[i].Bedrooms);
                //     Console.WriteLine(x[i].Bathrooms);
                //     Console.WriteLine(x[i].SquareFeet);
                //     Console.WriteLine(x[i].IsFurnished);
                //     foreach (var VARIABLE in x[i].Amenities)
                //     {
                //         Console.WriteLine(VARIABLE);
                //     }
                // }
                // Menu.MainMenu();
                Console.WriteLine("Нажмите ESC, чтобы выйти из программы.");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
        // catch
        // {
        //     Console.WriteLine("Ошибка!");
        // }
    }
// }