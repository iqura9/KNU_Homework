using System.ComponentModel;

namespace Homework_2;
public abstract class Worker
{
    public string Name { get; }
    public string Position { get; set; }
    public List<string> WorkDay = new List<string>();
    protected Worker(string name)
    {
        Name = name;
    }

    protected void Call()
    {
        WorkDay.Add("Call");
        
    }

    protected void WriteCode()
    {
        WorkDay.Add("WriteCode");
    }

    protected void Relax()
    {
        WorkDay.Add("Relax");
    }
    public abstract void FillWorkDay();
}

public class Developer : Worker
{
    private Random rand = new Random();
    public Developer(string name) : base(name)
    {
        Position = "Розробник";
        FillWorkDay();
    }

    public override void FillWorkDay()
    {
        int RandWrite = rand.Next(1, 3);
        int RandCall = rand.Next(2, 5);
        int RandRelax = rand.Next(2, 5);
        int RandWriteAgain = rand.Next(2, 5);
        
        for(int i=1;i<=RandWrite;i++) WriteCode();
        
        for (int i = 1; i <= RandCall; i++) Call();
        
        for (int i = 1; i <= RandRelax; i++) Relax();
        
        for (int i = 1; i <= RandWriteAgain; i++) WriteCode();
    }
}

public class Manager : Worker
{
    private Random rand = new Random();

    public Manager(string name) : base(name)
    {
        Position = "Менеджер";
        FillWorkDay();
    }

    public override void FillWorkDay()
    {
        for (int i = 1; i <= 3; i++)
        {
            Call();
            Relax();
            Call();
        }
    }
}

public class Team
{
    private List<Worker> _coworkers = new List<Worker>();
    private string _name;
    public Team(string name)
    {
        _name = name;
    }

    public void AddNewCoworker(Worker worker)
    {
        _coworkers.Add(worker);
    }

    public void ShowInfo()
    {
        
        Console.WriteLine($"Group name: {_name}");
        if (_coworkers.Count > 0)
        {
            Console.WriteLine("Workers:");
            foreach (var worker in _coworkers) Console.WriteLine(worker.Name);
        }
        else
        {
            Console.WriteLine("Workers are absent");
        }
        Console.WriteLine("");
    }

    public void ShowDetailedInfo()
    {
        Console.WriteLine($"Group name: {_name}");
        if (_coworkers.Count > 0)
        {
            Console.WriteLine("Workers:");
            foreach (var worker in _coworkers) Console.WriteLine($"{worker.Name} - {worker.Position} - {String.Join(", ",worker.WorkDay)}" );
        }
        else
        {
            Console.WriteLine("Workers are absent");
        }
        
        Console.WriteLine("");
    }
    
}
