using Microsoft.EntityFrameworkCore;
using Products.Application.Queries;
using Products.Domain.Entities;
using Products.Infrastructure.DataAccess.DbContexts;

namespace Products.Infrastructure.DataAccess.Queries;

internal class RetrieveProductsQuery : IRetrieveProductsQuery
{
    private readonly ProductsDbContext _dbContext;

    public RetrieveProductsQuery(ProductsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IList<Product>> ExecuteAsync(CancellationToken cancellationToken)
    {
        var products = await _dbContext.Products.ToListAsync(cancellationToken);

        return products;
    }
}