using ClassLibrary;

static class Program
{
    public static void Main()
    {
        try
        {
            do
            {
                Menu.MainMenu(); // Вызываем метод меню, через который будем работать с файлом.
                Console.WriteLine("Нажмите ESC, чтобы выйти из программы.");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
        catch
        {
            Console.WriteLine("Ошибка!");
        }
    }
}