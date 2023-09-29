using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Application.UseCases.CreateNewProduct;
using Products.Application.UseCases.DeleteProduct;
using Products.Application.UseCases.FindProductById;
using Products.Application.UseCases.RetrieveAllProducts;
using Products.Application.UseCases.UpdateProduct;

namespace Products.Application;

public static class Module
{
    public static IServiceCollection AddProductsApplication(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterUseCases(services);

        return services;
    }

    private static void RegisterUseCases(IServiceCollection services)
    {
        services.AddScoped<IFindProductByIdUseCase, FindProductByIdUseCase>();
        services.AddScoped<IRetrieveAllProductsUseCase, RetrieveAllProductsUseCase>();
        services.AddScoped<ICreateNewProductUseCase, CreateNewProductUseCase>();
        services.AddScoped<IUpdateProductUseCase, UpdateProductUseCase>();
        services.AddScoped<IDeleteProductUseCase, DeleteProductUseCase>();
    }

}