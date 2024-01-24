namespace ClassLibrary;

public static class Menu // Класс, который мы будем использовать для взаимодействия с пользователем.
{
    public static void MainMenu() // Основной метод, который мы вызываем в методе Main().
    {
        bool mainFlag = true; // Флаг для остановки работы.
        
        
        // Сюда можно сделать привествие пользователя по времени суток и добавить кнопку enter чтобы продолжить.
        
        
        while (mainFlag == true)
        {
            ReadMenu();
        }
    }

    private static void ReadMenu() // Метод, который позволит пользователю выбрать режим работы с файлом.
    {
        bool readWriteFlag = true; // Флаг состояния бесконечного ввода.
        while (readWriteFlag == true) // Пока флаг == true, меню будет вызываться бесконечно.
        {
            // Диалог с пользователем.
            Console.WriteLine("Выберите режим работы:");
            Console.WriteLine("1) Стандартный поток ввода-вывода.");
            Console.WriteLine("2) Файловый потоковой ввод-вывод.");
            Console.WriteLine("3) Выйти из меню.");
            Console.Write("Введите опцию: ");
            int readWriteOption; // Переменная, в которую будет считываться номер выбранной опции.
            while (!int.TryParse(Console.ReadLine(), out readWriteOption) && readWriteOption < 0 && readWriteOption > 3) // Проверка на корректность введенной опции.
            {
                Console.WriteLine("Ошибка, введены неправильные значения."); // Сообщаем пользователю об ошибке.
            }

            switch (readWriteOption) // Конструкция switch-case для обработки выбранной опции.
            {
                case 1: // Пользователь выбрал стандартный поток ввода-вывода.
                    stdIOMenu();
                    break;
                case 2: // Пользователь выбрал файловый поток ввода-вывода.
                    fileIOMenu(); // Вызываем метод работы с файловым вводом-выводом.
                    break;
                case 3: // Пользователь решил выйти из меню.
                    readWriteFlag = false; // Флаг состояния переводится в false и бесконечное меню останавливается.
                    break;
                defaults:
                    Console.WriteLine("Введено неправильное значение.");
                    break;
            }
        }
    }

    private static void stdIOMenu() // Метод для работы с файлом, если пользователь выбрал стандартный ввод-вывод.
    {
        bool stdIOMenuFlag = true; // Флаг состояния бесконечного ввода.
        while (stdIOMenuFlag == true) // Пока флаг == true, меню будет вызываться бесконечно.
        {
            // Сообщаем пользователю, чтобы он ввел путь или вернулся обратно.
            Console.WriteLine("\nВы выбрали файловый поток ввода-вывода.");
            Console.Write("Введите абсолютный путь или введите назад, чтобы вернуться обратно: ");
            var path = Console.ReadLine(); // Считываем путь.
            if (path.ToLower() == "назад") // Если пользователь ввел "назад", то меню останавливается.
            {
                stdIOMenuFlag = false; // Флаг состояния переводится в false и бесконечное меню останавливается.
                break;
            }
            else if (File.Exists(path)) // Проверяем существования файла по введенному пути.
            {
                var objectsArray = JsonParser.ReadJson(path, 2); // Считываем в переменную массив объектов пользовательского типа, с которым мы будем работать в дальнейшем.
                DataProcessing(objectsArray); // Вызываем метод обработки данных.
            }
            else // Случай, когда файла не существует или было введено некорректное значение.
            {
                Console.WriteLine("Ошибка, повторите попытку.");
            }
        }
    }
    
    private static void fileIOMenu() // Метод для работы с файлом, если пользователь выбрал файловый ввод-вывод.
    {
        bool fileIOMenuFlag = true; // Флаг состояния бесконечного ввода.
        while (fileIOMenuFlag == true) // Пока флаг == true, меню будет вызываться бесконечно.
        {
            // Сообщаем пользователю, чтобы он ввел путь или вернулся обратно.
            Console.WriteLine("\nВы выбрали файловый поток ввода-вывода.");
            Console.Write("Введите абсолютный путь или введите назад, чтобы вернуться обратно: ");
            var path = Console.ReadLine(); // Считываем путь.
            if (path.ToLower() == "назад") // Если пользователь ввел "назад", то меню останавливается.
            {
                fileIOMenuFlag = false; // Флаг состояния переводится в false и бесконечное меню останавливается.
                break;
            }
            else if (File.Exists(path)) // Проверяем существования файла по введенному пути.
            {
                var objectsArray = JsonParser.ReadJson(path, 1); // Считываем в переменную массив объектов пользовательского типа, с которым мы будем работать в дальнейшем.
                DataProcessing(objectsArray); // Вызываем метод обработки данных.
            }
            else // Случай, когда файла не существует или было введено некорректное значение.
            {
                Console.WriteLine("Ошибка, повторите попытку.");
            }
        }
    }
    
    private static void DataProcessing(List<Apartments> objects) // Меню для работы с данными файла.
    {
        bool dataProcessingFlag = true; // Флаг состояния бесконечного ввода.
        while (dataProcessingFlag == true) // Пока флаг == true, меню будет вызываться бесконечно.
        {
            // Даем пользователю выбор для обработки данных файла.
            Console.WriteLine("\nВыберите действие с данными:");
            Console.WriteLine("1) Отфильтровать по значению.");
            Console.WriteLine("2) Отсортировать по значению.");
            Console.WriteLine("3) Вернуться обратно.");
            Console.Write("Введите опцию: ");
            int dataProcessingOption; // Переменная, в которую будет считываться номер выбранной опции.
            while (!int.TryParse(Console.ReadLine(), out dataProcessingOption) && dataProcessingOption < 0 && dataProcessingOption > 3) // Проверка на корректность введенной опции.
            {
                Console.WriteLine("Ошибка, введены неправильные значения."); // Сообщаем пользователю об ошибке.
            }

            switch (dataProcessingOption) // Конструкция switch-case для работы с выбранной опцией.
            {
                case 1: // Пользователь выбрал отфильтровать значения по полю.
                    FilterMenu(objects); // Вызываем меню для фильтрации.
                    break;
                case 2:
                    SortMenu(objects); // Вызываем меню для сортировки.
                    break;
                case 3: // Пользователь решил выйти из меню.
                    dataProcessingFlag = false; // Флаг состояния переводится в false и бесконечное меню останавливается.
                    break;
            }
        }
    }

    private static void FilterMenu(List<Apartments> objects) // Метод для работы с фильтрацией.
    {
        bool filterFlag = true; // Флаг состояния бесконечного ввода.
        while (filterFlag == true) // Пока флаг == true, меню будет вызываться бесконечно.
        {
            // Сообщаем пользователю о возможных действиях.
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1) Отфильтровать по полю.");
            Console.WriteLine("2) Вернуться обратно.");
            Console.Write("Введите опцию: ");
            int filterOption; // Переменная, в которую будет считываться номер выбранной опции.
            while (!int.TryParse(Console.ReadLine(), out filterOption) && filterOption < 0 && filterOption > 2) // Проверка на корректность введенной опции.
            {
                Console.WriteLine("Ошибка, введены неправильные значения."); // Сообщаем пользователю об ошибке.
            }

            switch (filterOption) // Конструкция switch-case для работы с выбранной опцией.
            {
                case 1: // Пользователь выбрал отсортировать по полю.
                    Console.WriteLine("\nПоля, по которым можно отфильтровать файл: propertyId, address, bedrooms, bathrooms, squareFeet, isFurnished, amenities.");
                    Console.Write("\nВведите поле: "); // Предлагаем ввести поле, по которому нужно отфильтровать файл.
                    var field = Console.ReadLine(); // Считываем поле.
                    Console.Write("Введите значение: "); // Предлагаем ввести значение, по которому нужно отфильтровать файл.
                    var value = Console.ReadLine(); // Считываем значение.
                    List<Apartments> filteredList = new List<Apartments>(ClassLibrary.DataProcessing.Filter(objects, field, value)); // Создаем лист отфильтрованных объектов.
                    ClassLibrary.DataProcessing.View(filteredList);
                    break;
                case 2:
                    filterFlag = false; // Пользователь решил выйти из меню.
                    break;
            }
        }
    }
    
    private static void SortMenu(List<Apartments> objects) // Метод для работы с сортировкой.
    {
        bool filterFlag = true; // Флаг состояния бесконечного ввода.
        while (filterFlag == true) // Пока флаг == true, меню будет вызываться бесконечно.
        {
            // Сообщаем пользователю о возможных действиях.
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1) Отсортировать по полю.");
            Console.WriteLine("2) Вернуться обратно.");
            Console.Write("Введите опцию: ");
            int sortOption; // Переменная, в которую будет считываться номер выбранной опции.
            while (!int.TryParse(Console.ReadLine(), out sortOption) && sortOption < 0 && sortOption > 2) // Проверка на корректность введенной опции.
            {
                Console.WriteLine("Ошибка, введены неправильные значения."); // Сообщаем пользователю об ошибке.
            }

            switch (sortOption) // Конструкция switch-case для работы с выбранной опцией.
            {
                case 1: // Пользователь выбрал отсортировать поле.
                    Console.WriteLine("\nПоля, по которым можно отфильтровать файл: propertyId, address, bedrooms, bathrooms, squareFeet, isFurnished.");
                    Console.Write("\nВведите поле: "); // Спрашиваем по какому полю нужно отсортировать файл.
                    var field = Console.ReadLine(); // Считываем поле.
                    Console.Write("Введите порядок сортировки (прямой, обратный): "); // Спрашиваем порядок сортировки.
                    var order = Console.ReadLine(); // Считываем порядок.
                    switch (order.ToLower()) // Конструкция switch-case для работы с сортировкой.
                    {
                        case "прямой": // Пользователь выбрал прямой порядок сортировки.
                            List<Apartments> sortedListStraight = new List<Apartments>(ClassLibrary.DataProcessing.Sort(objects, field, "straight")); // Создаем лист отсортированных объектов.
                            ClassLibrary.DataProcessing.View(sortedListStraight);
                            break;
                        case "обратный": // Пользователь выбрал обратный порядок сортировки.
                            List<Apartments> sortedListBack = new List<Apartments>(ClassLibrary.DataProcessing.Sort(objects, field, "back")); // Создаем лист отсортированных объектов.
                            ClassLibrary.DataProcessing.View(sortedListBack);
                            break;
                    } 
                    break;
                case 2: // Пользователь решил выйти из меню.
                    filterFlag = false; // Флаг состояния переводится в false и бесконечное меню останавливается.
                    break;
            }
        }
    }

    private static void WriteMenu(List<Apartments> list)
    {
        bool writeFlag = true;
        while (writeFlag == true)
        {
            Console.WriteLine("Выберите опцию: ");
            Console.WriteLine("1) Перезаписать существующий файл.");
            Console.WriteLine("2) Записать в новый файл.");
            Console.WriteLine("3) Вернуться назад.");
            int writeMenuOption;
            while (!int.TryParse(Console.ReadLine(), out writeMenuOption) && writeMenuOption < 0 && writeMenuOption > 3) // Проверка на корректность введенной опции.
            {
                Console.WriteLine("Ошибка, введены неправильные значения."); // Сообщаем пользователю об ошибке.
            }

            switch (writeMenuOption)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    writeFlag = false;
                    break;
                default:
                    Console.WriteLine("Введена некорректная опция.");
                    break;
            }
        }
    }
}