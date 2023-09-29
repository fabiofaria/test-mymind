using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Products.Application.UseCases.RetrieveAllProducts;

namespace ProductsFunctionApp.Functions;

public class GetProductsFunction
{
    private readonly IRetrieveAllProductsUseCase _useCase;

    public GetProductsFunction(IRetrieveAllProductsUseCase useCase)
    {
        _useCase = useCase;
    }

    [Function("GetProductsFunction")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "all")]
        HttpRequestData req,
        CancellationToken cancellationToken)
    {
        try
        {
            var useCaseInput = new RetrieveAllProductsUseCaseInput();
            var products = await _useCase.ExecuteAsync(useCaseInput, cancellationToken);

            return new OkObjectResult(products);
        }
        catch (BusinessException exc)
        {
            return new UnprocessableEntityObjectResult(exc.Message);
        }
    }
}