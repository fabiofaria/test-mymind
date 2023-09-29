using Products.Domain.Entities;

namespace Products.Application.Commands;

public interface IUpdateProductCommand
{
    Task ExecuteAsync(Product product, CancellationToken cancellationToken);
}