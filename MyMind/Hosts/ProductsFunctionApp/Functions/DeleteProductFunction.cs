using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Products.Application.UseCases.DeleteProduct;

namespace ProductsFunctionApp.Functions;

public class DeleteProductFunction
{
    private readonly IDeleteProductUseCase _useCase;

    public DeleteProductFunction(IDeleteProductUseCase useCase)
    {
        _useCase = useCase;
    }

    [Function("DeleteProductFunction")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "delete/{id}")]
        HttpRequestData req,
        int id,
        CancellationToken cancellationToken)
    {
        try
        {
            var useCaseInput = new DeleteProductUseCaseInput(id);
            await _useCase.ExecuteAsync(useCaseInput, cancellationToken);

            return new NoContentResult();
        }
        catch (BusinessException exc)
        {
            return new UnprocessableEntityObjectResult(exc.Message);
        }
    }
}