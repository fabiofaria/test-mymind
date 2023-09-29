using Products.Domain.Entities;

namespace Products.Application.Queries;

public interface IRetrieveProductsQuery
{
    Task<IList<Product>> ExecuteAsync(CancellationToken cancellationToken);
}