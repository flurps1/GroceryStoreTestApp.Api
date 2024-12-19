namespace DataAccess;

public interface IProductService
{
    Task createAsync(string name, CancellationToken cancellationToken);
}