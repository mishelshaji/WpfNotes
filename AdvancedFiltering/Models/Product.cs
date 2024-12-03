namespace AdvancedFiltering.Models;

public class Product
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    
    public Product(long id, string name, string shortDescription, decimal price, bool isAvailable)
    {
        Id = id;
        Name = name;
        ShortDescription = shortDescription;
        Price = price;
        IsAvailable = isAvailable;
    }
}
