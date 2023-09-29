using Products.Domain.Entities;

namespace Products.Application.Commands;

public interface IDeleteProductCommand
{
    Task ExecuteAsync(Product product, CancellationToken cancellationToken);
}