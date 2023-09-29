namespace Products.Application.UseCases.DeleteProduct;

public interface IDeleteProductUseCase
{
    Task ExecuteAsync(DeleteProductUseCaseInput input, CancellationToken cancellationToken);
}