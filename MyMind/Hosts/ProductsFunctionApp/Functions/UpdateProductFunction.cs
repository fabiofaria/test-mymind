using BuildingBlocks.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Products.Application.UseCases.UpdateProduct;
using FromBodyAttribute = Microsoft.Azure.Functions.Worker.Http.FromBodyAttribute;

namespace ProductsFunctionApp.Functions;

public record UpdateProductFunctionRequest(string Name, decimal Price);

public class UpdateProductFunction
{
    private readonly IUpdateProductUseCase _useCase;

    public UpdateProductFunction(IUpdateProductUseCase useCase)
    {
        _useCase = useCase;
    }

    [Function("UpdateProductFunction")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "update/{id}")]
        HttpRequestData req,
        int id,
        [FromBody] UpdateProductFunctionRequest reqBody,
        CancellationToken cancellationToken)
    {
        try
        {
            var useCaseInput = new UpdateProductUseCaseInput(id, reqBody.Name, reqBody.Price);
            await _useCase.ExecuteAsync(useCaseInput, cancellationToken);

            return new NoContentResult();
        }
        catch (BusinessException exc)
        {
            return new UnprocessableEntityObjectResult(exc.Message);
        }
    }
}