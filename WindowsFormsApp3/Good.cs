using System;
using System.Text.Json.Serialization;

namespace WindowsFormsApp3
{
    public class Good
    {
        [JsonPropertyName("id")] 
        public string Id { get; private set; }
        [JsonPropertyName("name")] 
        public string Name { get; set; }
        [JsonPropertyName("category")] 
        public string Category { get; set; }
        [JsonPropertyName("price")] 
        public decimal Price { get; set; }
        [JsonConstructor]
        public Good(string id, string name, string category, decimal price )
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
        }
        public Good(string name, string category, decimal price)
        {
            Id = Guid.NewGuid().ToString("N");
            Name = name;
            Category = category;
            Price = price;
        }
        public dynamic GetName(string name)
        {
            switch (name)
            {
                case "Id": return Id;
                case "Name": return Name;
                case "Category": return Category;
                case "Price": return Price;
                default: return Name;
            }
        }
    }
}