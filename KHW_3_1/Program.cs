using ClassLibrary;

class Program
{
    public static void Main()
    {
        try
        {
            do
            {
                Console.WriteLine(JsonParser.ReadJson("/Users/daniilkostalevsky/Code/C#/KHW_3_1/KHW_3_1/data_13V (1).json"));
                // Menu.MainMenu();
                Console.WriteLine("Нажмите ESC, чтобы выйти из программы.");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
        catch
        {
            Console.WriteLine("Ошибка!");
        }
    }
}