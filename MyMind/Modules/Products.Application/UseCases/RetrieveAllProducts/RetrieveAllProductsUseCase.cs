using Microsoft.Extensions.Logging;
using Products.Application.Queries;
using Products.Domain.Entities;

namespace Products.Application.UseCases.RetrieveAllProducts;

internal class RetrieveAllProductsUseCase: IRetrieveAllProductsUseCase
{
    private readonly ILogger<RetrieveAllProductsUseCase> _logger;
    private readonly IRetrieveProductsQuery _retrieveProductsQuery;

    public RetrieveAllProductsUseCase(ILogger<RetrieveAllProductsUseCase> logger, IRetrieveProductsQuery retrieveProductsQuery)
    {
        _logger = logger;
        _retrieveProductsQuery = retrieveProductsQuery;
    }

    public async Task<IList<Product>> ExecuteAsync(RetrieveAllProductsUseCaseInput input, CancellationToken cancellationToken)
    {

        var products = await _retrieveProductsQuery.ExecuteAsync(cancellationToken);
        return products;
    }
}
