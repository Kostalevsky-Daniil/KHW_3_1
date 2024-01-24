using ClassLibrary;

static class Program
{
    public static void Main()
    {
        // try
        // {
            do
            {
                List<Apartments> temp = new List<Apartments>();
                temp = JsonParser.ReadJson("/Users/daniilkostalevsky/Code/C#/KHW_3_1/KHW_3_1/data_13V (1).json", 1);
                // DataProcessing.View(temp);
                // Menu.MainMenu();
                var temp1 = JsonParser.WriteJson(temp);
                Console.WriteLine(temp1);
                Console.WriteLine("Нажмите ESC, чтобы выйти из программы.");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        // }
        // catch
        // {
        //     Console.WriteLine("Ошибка!");
        // }
    }
}