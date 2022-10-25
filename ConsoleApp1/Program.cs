using System.Text.Json;
using System.Text.Json.Serialization;

public class PublishingHouse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
}

public class File
{
    [JsonIgnore] 
    public int PublishingHouseId { get; set; }
    [JsonPropertyName("Name")] 
    public string Title { get; set; }
    [JsonInclude] 
    public PublishingHouse PublishingHouse { get; set; }
    [JsonConstructor]
    public File(int PublishingHouseId, string Title, PublishingHouse PublishingHouse)
    {
        this.PublishingHouseId = PublishingHouseId;
        this.Title = Title;
        this.PublishingHouse = PublishingHouse;
    }
    
}

public class Program
{
    static void Main()
    {
         async void run()
        {
            string path = @"/Users/iqura/RiderProjects/ConsoleApp1/ConsoleApp1/JSON.json";
            var option = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true
            };
            using(FileStream fs = new FileStream(path, FileMode.Open,FileAccess.Read))
            {
                var files =  await JsonSerializer.DeserializeAsync<List<File>>(fs); // зчитати з файлу
                Console.WriteLine(JsonSerializer.Serialize(files,option)); // вивести на екран
            }
        }
        run();
    }
}