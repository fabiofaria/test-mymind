using Products.Domain.Entities;

namespace Products.Application.Queries;

public interface IFindProductByIdQuery
{
    Task<Product> ExecuteAsync(int id, CancellationToken cancellationToken);
}