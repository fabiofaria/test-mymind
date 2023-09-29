using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Application.Commands;
using Products.Application.Queries;
using Products.Infrastructure.DataAccess.Commands;
using Products.Infrastructure.DataAccess.DbContexts;
using Products.Infrastructure.DataAccess.Queries;

namespace Products.Infrastructure.DataAccess;

public static class Module
{
    public static IServiceCollection AddProductsInfrastructureDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterDataBases(services, configuration);
        RegisterQueries(services);
        RegisterCommands(services);

        return services;
    }

    private static void RegisterDataBases(IServiceCollection services, IConfiguration configuration)
    {
        var myMindConnectionString = configuration.GetConnectionString("MyMind");

        services.AddDbContextPool<ProductsDbContext>(options =>
        {
            options.UseSqlServer(myMindConnectionString);
        });
    }

    private static void RegisterQueries(IServiceCollection services)
    {
        services.AddScoped<IFindProductByIdQuery, FindProductByIdQuery>();
        services.AddScoped<IRetrieveProductsQuery, RetrieveProductsQuery>();
    }    
    
    private static void RegisterCommands(IServiceCollection services)
    {
        services.AddScoped<ICreateNewProductCommand, CreateNewProductCommand>();
        services.AddScoped<IUpdateProductCommand, UpdateProductCommand>();
        services.AddScoped<IDeleteProductCommand, DeleteProductCommand>();
    }


}