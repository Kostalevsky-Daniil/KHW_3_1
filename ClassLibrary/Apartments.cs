namespace ClassLibrary;

public class Apartments // Класс представляющий объекты из индивидуального варианта.
{
    // Объявляем поля класса.
    private int _propertyId;
    private string _address;
    private int _bedrooms;
    private string _bathrooms;
    private int _squareFeet;
    private bool _isFurnished;
    private List<string> _amenities;

    // Конструктор по-умолчанию.
    public Apartments()
    {
        // Присваиваем полям значения по-умолчанию.
        _propertyId = 0;
        _address = "Balaklavsky 16";
        _bedrooms = 3;
        _bathrooms = "2";
        _squareFeet = 120;
        _isFurnished = true;
        _amenities = new List<string>() {"dog", "cat"};
    }

    // Перегруженный конструктор.
    public Apartments(int propertyId, string address, int bedrooms, string bathrooms, int squareFeet, bool isFurnished, List<string> amenities)
    {
        // Присваиваем полям считанные значения.
        _propertyId = propertyId;
        _address = address;
        _bedrooms = bedrooms;
        _bathrooms = bathrooms;
        _squareFeet = squareFeet;
        _isFurnished = isFurnished;
        _amenities = amenities;
    }

    // Создаем свойства.
    public int PropertyId // Свойство для поля _propertyId.
    {
        get => _propertyId; // Возвращаем значение поля.
    }

    public string Address // Свойство для поля _address.
    {
        get => _address; // Возвращаем значение поля.
    }
    
    public int Bedrooms // Свойство для поля _bedrooms.
    {
        get => _bedrooms; // Возвращаем значение поля.
    }

    public string Bathrooms // Свойство для поля _bathrooms.
    {
        get => _bathrooms; // Возвращаем значение поля.
    }

    public int SquareFeet // Свойство для поля _squareFeet.
    {
        get => _squareFeet; // Возвращаем значение поля.
    }

    public bool IsFurnished // Свойство для поля _isFurnished.
    {
        get => _isFurnished; // Возвращаем значение поля.
    }

    public List<string> Amenities // Свойство для поля _amenities.
    {
        get => _amenities; // Возвращаем значение поля.
    }
}