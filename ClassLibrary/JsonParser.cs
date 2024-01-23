using System.IO;
namespace ClassLibrary;

public static class JsonParser
{
    public static void WriteJson()
    {
        
    }

    public static List<string> ReadJson(string filePath)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            List<string> fileLines = new List<string>();
            return fileLines = lines.ToList();
        }
        catch (FileNotFoundException ex) // Обрабатываем ошибку, когда файла не существует.
        {
            throw new FileNotFoundException("Файл не найден, повторите попытку", ex); // Выводим пользователю сообщение об ошибке.
        }
        catch (ArgumentNullException ex) // Обрабатываем ошибку, когда был введен пустой путь.
        {
            throw new ArgumentNullException("Ошибка, пустой путь."); // Выводим пользователю сообщение об ошибке.
        }
        catch // Обрабатываем все остальные ошибки.
        {
            throw new Exception("Ошибка, повторите попытку"); // Выводим пользователю сообщение об ошибке.
        }
    }
}