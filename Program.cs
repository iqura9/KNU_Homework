// .NET 6.0

string input = Console.ReadLine();
if (!long.TryParse(input, out long number))
{
    Console.WriteLine("Ви ввели некоректне число");
    return;
}
Console.WriteLine("Ви ввели число N {0}", number);