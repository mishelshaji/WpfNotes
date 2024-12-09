using Bogus;
using ProductManagementApp.Models;

namespace ProductManagementApp.Repositories;

public class ProductRepository
{
    private readonly List<Product> _products;

    public ProductRepository()
    {
        var productFaker = new Faker<Product>()
            .RuleFor(p => p.Id, f => f.IndexFaker + 1)
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price(1.00m, 1000.00m)))
            .RuleFor(p => p.ImageUrl, f => f.Image.PicsumUrl())
            .RuleFor(p => p.Categories, f => new List<Category>())
            .RuleFor(p => p.Tags, f => new List<Tag>());

        // Generate a list of 10 fake products
        _products = productFaker.Generate(500);
    }

    public List<Product> GetAll() => _products;
}
