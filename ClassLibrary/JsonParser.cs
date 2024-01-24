namespace ClassLibrary;
using System.Text.RegularExpressions;

public static class JsonParser // Класс, созданный для работы с JSON-файлами.
{
    public static string WriteJson(List<Apartments> list, int option_stream, int option)
    {
        string jsonFile = "[";
        for (int i = 0; i < list.Count; i++)
        {
            jsonFile += "  \n{" + "\t\n\"property_id\": " + list[i].PropertyId + "\t\n\"address\": " + list[i].Address +
                        "\t\n\"bedrooms\": " + list[i].Bedrooms +
                        "\t\n\"bathrooms\": " + list[i].Bathrooms.ToString().Replace(',', '.') + "\t\n\"square_feet\":" +
                        list[i].SquareFeet
                        + "\t\n\"is_furnished\": " + list[i].IsFurnished + "\t\n\"amenities\": " + "[" +
                        list[i].Amenities[i] + "]" + "\n},";
        }
        jsonFile += "\n]";
        return jsonFile;
    }

    public static List<Apartments> ReadJson(string filePath, int option) // Метод чтения информации из JSON-файла.
    {
        try // Конструкция try-catch для обработки ошибок.
        {
            // Создаем нужные массивы.
            List<Apartments> apartmentsList = new List<Apartments>(); // Массив, в котором будут хранится объекты класса.
            List<string> amenities = new List<string>(); // Массив, в котором будут хранится объекты массива типа Apartments.
            string lines = "";
            if (option == 1) // Пользователь выбрал режим работы через файловый ввод-вывод.
            { 
                lines = File.ReadAllText(filePath); // Считываем строку с данными из файла.
            }
            else if (option == 2) // Пользователь выбрал режим работы через стандартный поток ввод-ввывод.
            {
                string temp = ""; // Создаем временную строку, куда будем считывать строки из файла.
                var standartInput = new StreamReader(Console.OpenStandardInput()); // Создаем стандартный поток.
                StreamReader streamReader = new StreamReader(filePath); // Создаем streamReader.
                using (streamReader) 
                {
                    Console.SetIn(streamReader);
                    do
                    {
                        temp = streamReader.ReadLine();
                        lines += temp + "\n";
                    } while (temp != null);

                    Console.SetIn(standartInput); // Возвращаем стандартный поток.
                }
            }
            // Создаем паттерн для нахождения нужных элементов в строке.
            string pattern = "\\\"property_id\\\"\\:\\s(\\d+),\\n.*\\\"address\\\":\\s(\\\".*?\\\"),\\n.*\\\"bedrooms\\\":\\s(\\d),\\n.*\\\"bathrooms\\\":\\s(\\d+\\.\\d+),\\n.*\\\"square_feet\\\":\\s(\\d+),\\n.*\\\"is_furnished\\\":\\s(true|false),\\n.*\\\"amenities\\\":\\s*\\[\\s*((?:\\\"[^\\\"]+\\\",\\s*)*\\\"[^\\\"]+\\\")?\\s*\\]";
            MatchCollection matches = Regex.Matches(lines, pattern); // Ищем соответствия.
            foreach (Match match in matches) // Даем переменным значения, полученные из файла, чтобы потом подать их в конструктов в качестве параметров.
            {
                int property_id = int.Parse(match.Groups[1].Value);
                string address = match.Groups[2].Value;
                int bedrooms = int.Parse(match.Groups[3].Value);
                double bathrooms = double.Parse(match.Groups[4].Value.Replace('.', ','));
                int square_feet = int.Parse(match.Groups[5].Value);
                bool is_furnished = bool.Parse(match.Groups[6].Value);
                amenities.Add(match.Groups[7].Value); 
                Apartments apartment = new Apartments(property_id, address, bedrooms, bathrooms, square_feet, is_furnished, amenities); // Создаем объект.
                apartmentsList.Add(apartment); // Добавляем объект в массив объектов.
            }
            return apartmentsList; // Возвращаем массив объектов.
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