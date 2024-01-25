namespace ClassLibrary;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

public static class JsonParser // Класс, созданный для работы с JSON-файлами.
{
    public static void WriteJson(List<Apartments> list, int option, string path) // Метод для записи данных в файл.
    {
        string jsonFile = "["; // Создаем строку, в которую будут подаваться данные.
        for (int i = 0; i < list.Count; i++) 
        {
            jsonFile += "\n  {" + "\n\t\"property_id\": " + list[i].PropertyId + "," + "\n\t\"address\": " + list[i].Address + "," + // Создаем паттерн, по которому данные будут записываться в файл.
                        "\n\t\"bedrooms\": " + list[i].Bedrooms + "," +
                        "\n\t\"bathrooms\": " + list[i].Bathrooms.ToString().Replace(',', '.') + "," + "\n\t\"square_feet\": " +
                        list[i].SquareFeet 
                        + "," + "\n\t\"is_furnished\": " + list[i].IsFurnished.ToString().ToLower() + "," + "\n\t\"amenities\": " + "[" +
                        list[i].Amenities[i] + "]" + "\n  }";
            if (i != list.Count - 1)
            {
                jsonFile += ",";
            }
        }
        jsonFile += "\n]"; // Добавляем необходимые элементы в конец файла.
        
        if (option == 1) // Пользователь выбрал записать информацию в существующий файл.
        {
            Console.WriteLine("\n1) Запись с помощью перенаправленного потока.\n");
            Console.WriteLine("2) Запись с помощью файлового потока");
            Console.WriteLine("Введите опцию: ");
            int streamOption = 0; // Переменная опции выбора.
            while (!int.TryParse(Console.ReadLine(), out streamOption) && streamOption < 0 && streamOption > 2) // Проверка на корректность введенной опции.
            {
                Console.WriteLine("Ошибка, введены неправильные значения."); // Сообщаем пользователю об ошибке.
            }

            switch (streamOption) // Switch-case конструкция для обработки опции.
            {
                case 1: // Пользователь выбрал запись с помощью перенаправленного потока
                    streamWrite(path, jsonFile); // Используем запись в существующий файл с помощью перенаправленного потока.
                    break;
                case 2: // Пользователь выбрал запись с помощью файлового потока.
                    fileWrite(path, jsonFile); // Используем запись в существующий файл с помощью файлового потока.
                    break;
            }
        }
        else if (option == 2) // Пользователь выбрал записать информацию в новый файл.
        {
            Console.WriteLine("1) Запись с помощью перенаправленного потока.");
            Console.WriteLine("2) Запись с помощью файлового потока");
            Console.WriteLine("Введите опцию: ");
            int streamOption = 0; // Переменная опции выбора.
            while (!int.TryParse(Console.ReadLine(), out streamOption) && streamOption < 0 && streamOption > 2) // Проверка на корректность введенной опции.
            {
                Console.WriteLine("Ошибка, введены неправильные значения."); // Сообщаем пользователю об ошибке.
            }

            switch (streamOption) // Switch-case конструкция для обработки опции.
            {
                case 1: // Используем запись в новый файл с помощью перенаправленного потока.
                    streamWriteNew(path, jsonFile); // Используем запись в новый файл с помощью перенаправленного потока.
                    break;
                case 2: // Пользователь выбрал запись с помощью файлового потока.
                    fileWriteNew(path, jsonFile); // Используем запись в новый файл с помощью файлового потока.
                    break;
            }
        }
    }

    private static void streamWrite(string path, string line) // Метод для записи в существующий файл с помощью перенаправленного потока.
    {
        using (StreamWriter fileStreamWriter = new StreamWriter(path, false))
        {
            fileStreamWriter.Write(line);
        }
        Console.WriteLine("\nФайл успешно записан с помощью перенаправленного потока.\n");
    }
    
    private static void streamWriteNew(string path, string line) // Метод для записи в новый файл с помощью перенаправленного потока.
    {
        using (StreamWriter file = new StreamWriter(path, true))
        {
            file.Write(line);
        }
        Console.WriteLine("\nФайл успешно записан с помощью перенаправленного потока.\n");
    }

    private static void fileWriteNew(string path, string line) // Метод для записи в новый файл с помощью файлового потока.
    {
        File.Create(path);
        File.WriteAllText(path, line);
        Console.WriteLine("\nФайл успешно перезаписан с помощью файлового потока.\n");
    }
    
    private static void fileWrite(string path, string line) // Метод для записи в существующий файл с помощью файлового потока.
    {
        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            byte[] info = Encoding.UTF8.GetBytes(line);
            fileStream.Write(info, 0, line.Length);
        }
        Console.WriteLine("\nФайл успешно перезаписан с помощью файлового потока.");
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