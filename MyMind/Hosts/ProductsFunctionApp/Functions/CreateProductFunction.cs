using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Products.Application.UseCases.CreateNewProduct;
using FromBodyAttribute = Microsoft.Azure.Functions.Worker.Http.FromBodyAttribute;

namespace ProductsFunctionApp.Functions;

public record CreateProductFunctionRequest(string Name, decimal Price);

public class CreateProductFunction
{
    private readonly ICreateNewProductUseCase _useCase;

    public CreateProductFunction(ICreateNewProductUseCase useCase)
    {
        _useCase = useCase;
    }

    [Function("CreateProductFunction")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "create")]
        HttpRequestData req,
        [FromBody]CreateProductFunctionRequest reqBody,
        CancellationToken cancellationToken)
    {
        try
        {
            var useCaseInput = new CreateNewProductUseCaseInput(reqBody.Name, reqBody.Price);
            var product = await _useCase.ExecuteAsync(useCaseInput, cancellationToken);

            return new CreatedResult($"/api/{product.Id}" ,product);
        }
        catch (BusinessException exc)
        {
            return new UnprocessableEntityObjectResult(exc.Message);
        }
    }
}
