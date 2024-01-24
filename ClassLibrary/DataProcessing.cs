namespace ClassLibrary;

public static class DataProcessing // Класс для работы с данными файла.
{ 
    // Метод для фильтрации массива по полю и значению.
    public static List<Apartments> Filter(List<Apartments> apartmentsList, string field, string value)
    {
        switch (field) // Конструкция switch-case для выбора поля.
        {
            case "propertyId": // Пользователь выбрал поле propertyId.
                return apartmentsList.Where(a => a.PropertyId == int.Parse(value)).ToList(); // Возвращаем лист объектов выбранного поля, значения которого соответствуют подаваемым.
            case "address": // Пользователь выбрал поле address.
                return apartmentsList.Where(a => a.Address == value).ToList(); // Возвращаем лист объектов выбранного поля, значения которого соответствуют подаваемым.
            case "bedrooms": // Пользователь выбрал поле bedrooms.
                return apartmentsList.Where(a => a.Bedrooms == int.Parse(value)).ToList(); // Возвращаем лист объектов выбранного поля, значения которого соответствуют подаваемым.
            case "bathrooms": // Пользователь выбрал поле bathrooms.
                return apartmentsList.Where(a => a.Bathrooms == value).ToList(); // Возвращаем лист объектов выбранного поля, значения которого соответствуют подаваемым.
            case "squareFeet": // Пользователь выбрал поле squareFeet.
                return apartmentsList.Where(a => a.SquareFeet == int.Parse(value)).ToList(); // Возвращаем лист объектов выбранного поля, значения которого соответствуют подаваемым.
            case "isFurnished": // Пользователь выбрал поле isFurnished.
                return apartmentsList.Where(a => a.IsFurnished == bool.Parse(value)).ToList(); // Возвращаем лист объектов выбранного поля, значения которого соответствуют подаваемым.
            case "amenities": // Пользователь выбрал поле amenities.
                return apartmentsList.Where(a => a.Amenities.Contains(value)).ToList(); // Возвращаем лист объектов выбранного поля, значения которого соответствуют подаваемым.
            default: // Вариант по-умолчанию.
                throw new ArgumentException("Некорректное значение поля. Повторите попытку."); // Сообщаем пользователю об ошибке.
        }
    }

    // Метод для сортировки объектов файла.
    public static List<Apartments> Sort(List<Apartments> apartmentsList, string field, string order)
    {
        switch (field) // Конструкция switch-case для выбора поля.
        {
            case "propertyId": // Пользователь выбрал поле propertyId.
                return order.ToLower() == "straight" // Если сортировка прямая.
                    ? apartmentsList.OrderBy(a => a.PropertyId).ToList() // Возвращаем массив, отсортированный по полю в прямом порядке.
                    : apartmentsList.OrderByDescending(a => a.PropertyId).ToList(); // Если сортировка обратная, то возвращаем массив, отсорированный по полю в обратном порядке.
            case "address": // Пользователь выбрал поле address.
                return order.ToLower() == "straight" // Если сортировка прямая.
                    ? apartmentsList.OrderBy(a => a.Address).ToList() // Возвращаем массив, отсортированный по полю в прямом порядке.
                    : apartmentsList.OrderByDescending(a => a.Address).ToList(); // Если сортировка обратная, то возвращаем массив, отсорированный по полю в обратном порядке.
            case "bedrooms": // Пользователь выбрал поле bedrooms.
                return order.ToLower() == "straight" // Если сортировка прямая.
                    ? apartmentsList.OrderBy(a => a.Bedrooms).ToList() // Возвращаем массив, отсортированный по полю в прямом порядке.
                    : apartmentsList.OrderByDescending(a => a.Bedrooms).ToList(); // Если сортировка обратная, то возвращаем массив, отсорированный по полю в обратном порядке.
            case "bathrooms": // Пользователь выбрал поле bathrooms.
                return order.ToLower() == "straight" // Если сортировка прямая.
                    ? apartmentsList.OrderBy(a => a.Bathrooms).ToList() // Возвращаем массив, отсортированный по полю в прямом порядке.
                    : apartmentsList.OrderByDescending(a => a.Bathrooms).ToList(); // Если сортировка обратная, то возвращаем массив, отсорированный по полю в обратном порядке.
            case "squareFeet": // Пользователь выбрал поле squareFeet.
                return order.ToLower() == "straight" // Если сортировка прямая.
                    ? apartmentsList.OrderBy(a => a.SquareFeet).ToList() // Возвращаем массив, отсортированный по полю в прямом порядке.
                    : apartmentsList.OrderByDescending(a => a.SquareFeet).ToList(); // Если сортировка обратная, то возвращаем массив, отсорированный по полю в обратном порядке.
            case "isFurnished": // Пользователь выбрал поле isFurnished.
                return order.ToLower() == "straight" // Если сортировка прямая.
                    ? apartmentsList.OrderBy(a => a.IsFurnished).ToList() // Возвращаем массив, отсортированный по полю в прямом порядке.
                    : apartmentsList.OrderByDescending(a => a.IsFurnished).ToList(); // Если сортировка обратная, то возвращаем массив, отсорированный по полю в обратном порядке.
            case "amenities": // Пользователь выбрал поле amenities.
                throw new ArgumentException("Нельзя отсортировать по массиву."); // Сообщаем пользователю, что по этому полю файл невозможно отсортировать.
            default: // Вариант по-умолчанию.
                throw new ArgumentException("Некорректное значение поля. Повторите попытку."); // Сообщаем пользователю об ошибке.
        }
    }

    public static void View(List<Apartments> list) // Метод для вывода значений листа объектов.
    {
        for (int i = 0; i < list.Count; i++) // Цикл для вывода всех элементов.
        {
            Console.WriteLine($"property_id: {list[i].PropertyId}"); // Выводим значение поля propertyId.
            Console.WriteLine($"address: {list[i].Address}"); // Выводим значение поля address.
            Console.WriteLine($"bedrooms: {list[i].Bedrooms}"); // Выводим значение поля bedrooms.
            Console.WriteLine($"bathrooms: {list[i].Bathrooms}"); // Выводим значение поля bathrooms.
            Console.WriteLine($"square_feet: {list[i].SquareFeet}"); // Выводим значение поля squareFeet.
            Console.WriteLine($"is_furnished: {list[i].IsFurnished}"); // Выводим значение поля isFurnished.
            Console.WriteLine($"amenities: {list[i].Amenities}"); // Выводим значение поля amenities.
        }
    }

    // private static void ArrayView(List<Apartments> list)
    // {
    //     
    // }
}