using Products.Domain.Entities;

namespace Products.Application.Commands;

public interface ICreateNewProductCommand
{
    Task<Product> ExecuteAsync(Product product, CancellationToken cancellationToken);
}