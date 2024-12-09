using System.Collections.ObjectModel;
using ProductMaagementApp.Windows;
using ProductManagementApp.Commands;
using ProductManagementApp.Models;
using ProductManagementApp.Repositories;

namespace ProductManagementApp.ViewModels;

public class ProductListVewModel: ViewModelBase
{
    private readonly ProductRepository _productRepository = new();
    public ObservableCollection<Product> Products { get; set; } = new();

    private string _searchFilter;

    public string SearchFilter
    {
        get => _searchFilter;
        set
        {
            _searchFilter = value;
            SearchCommand.OnCanExecuteChanged();
            OnPropertyChanged();
        }
    }

    public RelayCommand SearchCommand { get; set; }
    public RelayCommand NewProductCommand { get; set; }

    public ProductListVewModel()
    {
        Products = new ObservableCollection<Product>(_productRepository.GetAll());
        SearchCommand = new RelayCommand(SearchCommandHandler, SearchCommandCanExecuteHandler);
        NewProductCommand = new RelayCommand(NewProductComandHandler);
    }

    private void NewProductComandHandler()
    {
        new CreateProductWindow().ShowDialog();
    }

    private void SearchCommandHandler()
    {
        var filteredProducts = _productRepository.GetAll()
            .Where(p => p.Name.Contains(SearchFilter, StringComparison.OrdinalIgnoreCase))
            .ToList();
        
        Products.Clear();
        foreach (var product in filteredProducts)
        {
            Products.Add(product);
        }
    }

    private bool SearchCommandCanExecuteHandler()
    {
        return !string.IsNullOrEmpty(SearchFilter);
    }
}
