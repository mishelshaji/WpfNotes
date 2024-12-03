namespace AdvancedFiltering.Repostories;

public interface IRepository<TModel>
{
    public IEnumerable<TModel> GetAll();
}
