using Microsoft.EntityFrameworkCore;
using Products.Application.Queries;
using Products.Domain.Entities;
using Products.Infrastructure.DataAccess.DbContexts;

namespace Products.Infrastructure.DataAccess.Queries;

internal class FindProductByIdQuery: IFindProductByIdQuery
{
    private readonly ProductsDbContext _dbContext;

    public FindProductByIdQuery(ProductsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> ExecuteAsync(int id, CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        
        return product;
    }
}