using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Products.Application.UseCases.FindProductById;

namespace ProductsFunctionApp.Functions;

public class GetProductByIdFunction
{
    private readonly IFindProductByIdUseCase _useCase;

    public GetProductByIdFunction(IFindProductByIdUseCase useCase)
    {
        _useCase = useCase;
    }

    [Function("GetProductByIdFunction")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "product/{id}")]
        HttpRequestData req,
        int id,
        CancellationToken cancellationToken)
    {
        try
        {
            var useCaseInput = new FindProductByIdUseCaseInput(id);
            var product = await _useCase.ExecuteAsync(useCaseInput, cancellationToken);
            if (product is null) return new NotFoundResult();

            return new OkObjectResult(product);
        }
        catch (BusinessException exc)
        {
            return new UnprocessableEntityObjectResult(exc.Message);
        }
    }
}