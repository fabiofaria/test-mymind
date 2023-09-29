using Microsoft.Extensions.Logging;
using Products.Application.Queries;
using Products.Domain.Entities;

namespace Products.Application.UseCases.FindProductById;

internal class FindProductByIdUseCase: IFindProductByIdUseCase
{
    private readonly ILogger _logger;
    private readonly IFindProductByIdQuery _findProductByIdQuery;

    public FindProductByIdUseCase(ILogger<FindProductByIdUseCase> logger, IFindProductByIdQuery findProductByIdQuery)
    {
        _logger = logger;
        _findProductByIdQuery = findProductByIdQuery;
    }

    public async Task<Product> ExecuteAsync(FindProductByIdUseCaseInput input, CancellationToken cancellationToken)
    {
        if (input is null) throw new ArgumentNullException(nameof(input));

        var product = await _findProductByIdQuery.ExecuteAsync(input.Id, cancellationToken);
        return product;
    }
}