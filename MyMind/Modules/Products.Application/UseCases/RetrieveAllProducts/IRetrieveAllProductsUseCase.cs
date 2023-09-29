using Products.Domain.Entities;

namespace Products.Application.UseCases.RetrieveAllProducts;

public interface IRetrieveAllProductsUseCase
{
    Task<IList<Product>> ExecuteAsync(RetrieveAllProductsUseCaseInput input, CancellationToken cancellationToken);
}