using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using AdvancedFiltering.Commands;
using AdvancedFiltering.Models;
using AdvancedFiltering.Repostories;

namespace AdvancedFiltering.ViewModels;

public class MainWindowViewModel: ViewModelBase
{
    /// <summary>
    /// This is a fake repository to fetch all products.
    /// </summary>
    private IRepository<Product> _repository;
    
    /// <summary>
    /// The list of products returned from the repository. This is a fake list
    /// and contains all products.
    /// </summary>
    private readonly IEnumerable<Product> _products;
    
    /// <summary>
    /// This is the list of products that will be displayed in the UI.
    /// </summary>
    public ObservableCollection<Product> ProductsToDisplay { get; set; }
    
    public RelayCommand ApplyFilterCommand { get; set; }
    public RelayCommand ClearFilterCommand { get; set; }

    #region Properties for Filtering

    private string _nameFilter;
    public string NameFilter
    {
        get => _nameFilter;
        set
        {
            _nameFilter = value;
            OnPropertyChanged();
        }
    }

    private int _minPriceRangeFilter;
    public int MinPriceRangeFilter
    {
        get => _minPriceRangeFilter;
        set
        {
            _minPriceRangeFilter = value;
            OnPropertyChanged();
        }
    }
    
    private int _maxPriceRangeFilter;
    public int MaxPriceRangeFilter
    {
        get => _maxPriceRangeFilter;
        set
        {
            _maxPriceRangeFilter = value;
            OnPropertyChanged();
        }
    }

    private bool _hideOutOfStockItems;

    public bool HideOutOfStockItems
    {
        get => _hideOutOfStockItems;
        set
        {
            _hideOutOfStockItems = value;
            OnPropertyChanged();
        }
    }

    #endregion

    private bool _isLoading;

    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            _isLoading = value;
            OnPropertyChanged();
        }
    }

    public MainWindowViewModel()
    {
        _repository = new InMemoryProductRepository();
        _products = _repository.GetAll();
        ProductsToDisplay = new ObservableCollection<Product>(_products);
        ApplyFilterCommand = new RelayCommand(ApplyFilterCommandHandler);
        ClearFilterCommand = new RelayCommand(ClearFilterCommandHandler);
    }

    private void ApplyFilterCommandHandler()
    {
        IsLoading = true;
        Thread.Sleep(2000);
        var productsQuery = _products.AsQueryable();
        if (!string.IsNullOrEmpty(NameFilter))
        {
            productsQuery = productsQuery.Where(p => p.Name.Contains(NameFilter, StringComparison.OrdinalIgnoreCase));
        }
        
        if (MinPriceRangeFilter > 0)
        {
            productsQuery = productsQuery.Where(p => p.Price >= MinPriceRangeFilter);
        }
        
        if (MaxPriceRangeFilter > 0)
        {
            productsQuery = productsQuery.Where(p => p.Price <= MaxPriceRangeFilter);
        }
        
        if (HideOutOfStockItems)
        {
            productsQuery = productsQuery.Where(p => p.IsAvailable);
        }

        ProductsToDisplay.Clear();
        foreach (var product in productsQuery)
        {
            ProductsToDisplay.Add(product);
        }

        IsLoading = false;
    }
    
    private void ClearFilterCommandHandler()
    {
        var res = MessageBox.Show("Are you sure you want to clear the filter?", 
            "Clear Filter", 
            MessageBoxButton.YesNo);
        
        if (res != MessageBoxResult.Yes)
        {
            return;
        }
        
        NameFilter = string.Empty;
        MinPriceRangeFilter = 0;
        MaxPriceRangeFilter = 0;
        HideOutOfStockItems = false;
        ProductsToDisplay.Clear();
        foreach (var product in _products)
        {
            ProductsToDisplay.Add(product);
        }
    }
}
