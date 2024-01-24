using ClassLibrary;

class Program
{
    public static void Main()
    {
        // try
        // {
            do
            {
                Menu.MainMenu();
                Console.WriteLine("Нажмите ESC, чтобы выйти из программы.");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        // }
        // catch
        // {
        //     Console.WriteLine("Ошибка!");
        // }
    }
}