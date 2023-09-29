using Products.Application.Commands;
using Products.Domain.Entities;
using Products.Infrastructure.DataAccess.DbContexts;

namespace Products.Infrastructure.DataAccess.Commands;

internal class UpdateProductCommand : IUpdateProductCommand
{
    private readonly ProductsDbContext _dbContext;

    public UpdateProductCommand(ProductsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ExecuteAsync(Product product, CancellationToken cancellationToken)
    {
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}