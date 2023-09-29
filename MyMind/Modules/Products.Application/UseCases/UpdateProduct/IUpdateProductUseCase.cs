namespace Products.Application.UseCases.UpdateProduct;

public interface IUpdateProductUseCase
{
    Task ExecuteAsync(UpdateProductUseCaseInput input, CancellationToken cancellationToken);
}