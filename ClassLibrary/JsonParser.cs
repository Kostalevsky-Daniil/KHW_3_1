using System.IO;
namespace ClassLibrary;
using System.Text.RegularExpressions;

public static class JsonParser
{
    public static void WriteJson()
    {
        
    }

    public static List<Apartments> ReadJson(string filePath)
    {
        try
        {
            Apartments apartment;
            List<Apartments> apartmentsList = new List<Apartments>();
            List<Apartments> apart = new List<Apartments>();
            int property_id;
            string address;
            int bedrooms;
            string bathrooms;
            int square_feet;
            bool is_furnished;
            List<string> amenities = new List<string>();
            
            string lines = File.ReadAllText(filePath);
            string pattern = "\\\"property_id\\\"\\:\\s(\\d+),\\n.*\\\"address\\\":\\s(\\\".*?\\\"),\\n.*\\\"bedrooms\\\":\\s(\\d),\\n.*\\\"bathrooms\\\":\\s(\\d\\.\\d+),\\n.*\\\"square_feet\\\":\\s(\\d+),\\n.*\\\"is_furnished\\\":\\s(true|false),\\n.*\\\"amenities\\\":\\s*\\[\\s*((?:\\\"[^\\\"]+\\\",\\s*)*\\\"[^\\\"]+\\\")?\\s*\\]";
            MatchCollection matches = Regex.Matches(lines, pattern);
            foreach (Match match in matches)
            {
                property_id = int.Parse(match.Groups[1].Value);
                address = match.Groups[2].Value;
                bedrooms = int.Parse(match.Groups[3].Value);
                bathrooms = match.Groups[4].Value;
                square_feet = int.Parse(match.Groups[5].Value);
                is_furnished = bool.Parse(match.Groups[6].Value);
                amenities.Add(match.Groups[7].Value);
                apartment = new Apartments(property_id, address, bedrooms, bathrooms, square_feet, is_furnished, amenities);
                apartmentsList.Add(apartment);
            }
            return apartmentsList;
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