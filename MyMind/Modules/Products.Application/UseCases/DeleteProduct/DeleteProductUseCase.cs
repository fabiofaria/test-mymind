using BuildingBlocks.Exceptions;
using Microsoft.Extensions.Logging;
using Products.Application.Commands;
using Products.Application.Queries;

namespace Products.Application.UseCases.DeleteProduct;

internal class DeleteProductUseCase: IDeleteProductUseCase
{
    private readonly ILogger<DeleteProductUseCase> _logger;
    private readonly IDeleteProductCommand _deleteProductCommand;
    private readonly IFindProductByIdQuery _findProductByIdQuery;

    public DeleteProductUseCase(ILogger<DeleteProductUseCase> logger, IDeleteProductCommand deleteProductCommand, IFindProductByIdQuery findProductByIdQuery)
    {
        _logger = logger;
        _deleteProductCommand = deleteProductCommand;
        _findProductByIdQuery = findProductByIdQuery;
    }

    public async Task ExecuteAsync(DeleteProductUseCaseInput input, CancellationToken cancellationToken)
    {
        try
        {
            var existingProduct = await _findProductByIdQuery.ExecuteAsync(input.Id, cancellationToken);
            if (existingProduct is null) return;


            await _deleteProductCommand.ExecuteAsync(existingProduct, cancellationToken);
        }
        catch (ArgumentNullException exc)
        {
            throw new BusinessException(exc.Message);
        }
    }
}


