using Products.Domain.Entities;

namespace Products.Application.UseCases.CreateNewProduct;

public interface ICreateNewProductUseCase
{
    Task<Product> ExecuteAsync(CreateNewProductUseCaseInput input, CancellationToken cancellationToken);
}