namespace ClassLibrary;

public class Menu
{
    public static void MainMenu()
    {
        bool mainFlag = true;
        while (mainFlag == true)
        {
            ReadWrite();
        }
    }

    private static void ReadWrite()
    {
        bool readWriteFlag = true;
        while (readWriteFlag == true)
        {
            Console.WriteLine("Выберите режим работы:");
            Console.WriteLine("1) Стандартный поток ввода и вывода.");
            Console.WriteLine("2) Файловый потоковой ввод и вывод.");
            Console.WriteLine("3) Выйти из меню.");
            Console.Write("Введите опцию: ");
            int readWriteOption;
            while (!int.TryParse(Console.ReadLine(), out readWriteOption) && readWriteOption < 0 && readWriteOption > 3)
            {
                Console.WriteLine("Ошибка, введены неправильные значения.");
            }

            switch (readWriteOption)
            {
                case 1:
                    DataProcessing();
                    break;
                case 2:
                    DataProcessing();
                    break;
                case 3:
                    readWriteFlag = false;
                    break;
            }
        }
    }

    private static void DataProcessing()
    {
        bool dataProcessingFlag = true;
        while (dataProcessingFlag == true)
        {
            Console.WriteLine("\nВыберите действие с данными:");
            Console.WriteLine("1) Отфильтровать по значению.");
            Console.WriteLine("2) Отсортировать по значению.");
            Console.WriteLine("3) Вернуться обратно.");
            Console.Write("Введите опцию: ");
            int dataProcessingOption;
            while (!int.TryParse(Console.ReadLine(), out dataProcessingOption) && dataProcessingOption < 0 && dataProcessingOption > 3)
            {
                Console.WriteLine("Ошибка, введены неправильные значения.");
            }

            switch (dataProcessingOption)
            {
                case 1:
                    FilterMenu();
                    break;
                case 2:
                    SortMenu();
                    break;
                case 3:
                    dataProcessingFlag = false;
                    break;
            }
        }
    }

    private static void FilterMenu()
    {
        bool filterFlag = true;
        while (filterFlag == true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1) Отфильтровать по полю.");
            Console.WriteLine("2) Вернуться обратно.");
            Console.Write("Введите опцию: ");
            int filterOption;
            while (!int.TryParse(Console.ReadLine(), out filterOption) && filterOption < 0 && filterOption > 2)
            {
                Console.WriteLine("Ошибка, введены неправильные значения.");
            }

            switch (filterOption)
            {
                case 1:
                    Console.Write("Введите поле: ");
                    var value = Console.ReadLine();
                    break;
                case 2:
                    filterFlag = false;
                    break;
            }
        }
    }
    
    private static void SortMenu()
    {
        bool filterFlag = true;
        while (filterFlag == true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1) Отсортировать по полю.");
            Console.WriteLine("2) Вернуться обратно.");
            Console.Write("Введите опцию: ");
            int sortOption;
            while (!int.TryParse(Console.ReadLine(), out sortOption) && sortOption < 0 && sortOption > 2)
            {
                Console.WriteLine("Ошибка, введены неправильные значения.");
            }

            switch (sortOption)
            {
                case 1:
                    Console.Write("Введите поле: ");
                    var value = Console.ReadLine();
                    break;
                case 2:
                    filterFlag = false;
                    break;
            }
        }
    }
}