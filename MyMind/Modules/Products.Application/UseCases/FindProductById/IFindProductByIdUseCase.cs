using Products.Domain.Entities;

namespace Products.Application.UseCases.FindProductById;

public interface IFindProductByIdUseCase
{
    Task<Product> ExecuteAsync(FindProductByIdUseCaseInput input, CancellationToken cancellationToken);
}