using AdvancedFiltering.Models;

namespace AdvancedFiltering.Repostories;

public class InMemoryProductRepository: IRepository<Product>
{
    private readonly List<Product> _products =
    [
        new(1, "Product 1", "Description 1", 100, true),
        new(2, "Product 2", "Description 2", 200, true),
        new(3, "Product 3", "Description 3", 300, false),
        new(4, "Product 4", "Description 4", 400, true),
        new(5, "Product 5", "Description 5", 500, false)
    ];

    public IEnumerable<Product> GetAll()
    {
        return _products; 
    }
}
