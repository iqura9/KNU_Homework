namespace ConsoleApp1;

public abstract class Geographical_object
{
    public string x { get; }
    public string y { get; }
    
    private string _name;

    public string Name
    {
        get { return _name; }
    }
    private string _description;
    public string Description
    {
        get { return _description; }
    }

    public Geographical_object(string x, string y, string name, string desc)
    {
        this.x = x;
        this.y = y;
        _name = name;
        _description = desc;
    }
    public abstract void GetInfo();

    public void GetSimpleInfo() // method to avoid duplication
    {
        Console.WriteLine("Географічний об'єкт: Річка");
        Console.WriteLine($"Координата Х: {x}");
        Console.WriteLine($"Координата У: {y} ");
        Console.WriteLine($"Назва: {Name}");
        Console.WriteLine($"Опис: {Description}");
    }
}

public class River : Geographical_object
{
    private decimal _flow_rate;
    private decimal _total_length;

    public River(string x, string y, string name, string desc, decimal flowRate, decimal totalLength) : base(x, y, name, desc)
    {
        _flow_rate = flowRate;
        _total_length = totalLength;
    }
    public override void GetInfo()
    {
        GetSimpleInfo();
        
        Console.WriteLine($"Швидкість течії (см/с): {_flow_rate} ");
        Console.WriteLine($"Загальна довжина: {_total_length} км");
        Console.WriteLine("");
    }
    
}

public class Mountain : Geographical_object
{
    public decimal _peak;
    public Mountain(string x, string y, string name, string desc, decimal peak) : base(x, y, name, desc)
    {
        _peak = peak;
    }
    public override void GetInfo()
    {
        GetSimpleInfo(); 
        
        Console.WriteLine($"Найвища точка: {_peak} метрів");
        Console.WriteLine("");
    }
}