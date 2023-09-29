using Products.Application.Commands;
using Products.Domain.Entities;
using Products.Infrastructure.DataAccess.DbContexts;

namespace Products.Infrastructure.DataAccess.Commands;

internal class DeleteProductCommand : IDeleteProductCommand
{
    private readonly ProductsDbContext _dbContext;

    public DeleteProductCommand(ProductsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ExecuteAsync(Product product, CancellationToken cancellationToken)
    {
        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}