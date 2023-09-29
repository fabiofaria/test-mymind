using BuildingBlocks.Exceptions;
using Microsoft.Extensions.Logging;
using Products.Application.Commands;
using Products.Application.UseCases.UpdateProduct;
using Products.Domain.Entities;

namespace Products.Application.UseCases.CreateNewProduct;

internal class CreateNewProductUseCase : ICreateNewProductUseCase
{
    private readonly ILogger _logger;
    private readonly ICreateNewProductCommand _createNewProductCommand;

    public CreateNewProductUseCase(ILogger<CreateNewProductUseCase> logger, ICreateNewProductCommand createNewProductCommand)
    {
        _logger = logger;
        _createNewProductCommand = createNewProductCommand;
    }

    public async Task<Product> ExecuteAsync(CreateNewProductUseCaseInput input, CancellationToken cancellationToken)
    {
        try
        {
            var newProduct = new Product(input.Name, input.Price);

            var product = await _createNewProductCommand.ExecuteAsync(newProduct, cancellationToken);
            return product;
        }
        catch (ArgumentNullException exc)
        {
            throw new BusinessException(exc.Message);
        }
    }
}