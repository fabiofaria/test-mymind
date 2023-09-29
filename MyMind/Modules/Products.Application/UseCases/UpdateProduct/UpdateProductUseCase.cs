using BuildingBlocks.Exceptions;
using Microsoft.Extensions.Logging;
using Products.Application.Commands;
using Products.Application.Queries;

namespace Products.Application.UseCases.UpdateProduct;

internal class UpdateProductUseCase : IUpdateProductUseCase
{
    private readonly ILogger _logger;
    private readonly IFindProductByIdQuery _findProductByIdQuery;
    private readonly IUpdateProductCommand _updateProductCommand;

    public UpdateProductUseCase(ILogger<UpdateProductUseCase> logger, IFindProductByIdQuery findProductByIdQuery, IUpdateProductCommand updateProductCommand)
    {
        _logger = logger;
        _findProductByIdQuery = findProductByIdQuery;
        _updateProductCommand = updateProductCommand;
    }

    public async Task ExecuteAsync(UpdateProductUseCaseInput input, CancellationToken cancellationToken)
    {
        try
        {
            var existingProduct = await _findProductByIdQuery.ExecuteAsync(input.Id, cancellationToken);
            if (existingProduct is null) throw new BusinessException($"Product {input.Id} was not found.");


            existingProduct.UpdateProduct(input.Name, input.Price);
            await _updateProductCommand.ExecuteAsync(existingProduct, cancellationToken);
        }
        catch (ArgumentNullException exc)
        {
            throw new BusinessException(exc.Message);
        }
    }
}