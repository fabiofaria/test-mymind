using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Application;
using Products.Infrastructure.DataAccess;

namespace Products.Module;

public static class ProductsModule
{
    public static IServiceCollection AddProductsModule(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddProductsApplication(configuration)
            .AddProductsInfrastructureDataAccess(configuration);
}