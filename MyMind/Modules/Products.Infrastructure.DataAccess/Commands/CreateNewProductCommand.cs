using Products.Application.Commands;
using Products.Domain.Entities;
using Products.Infrastructure.DataAccess.DbContexts;

namespace Products.Infrastructure.DataAccess.Commands;

internal class CreateNewProductCommand: ICreateNewProductCommand
{
    private readonly ProductsDbContext _dbContext;

    public CreateNewProductCommand(ProductsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> ExecuteAsync(Product product, CancellationToken cancellationToken)
    {
        await _dbContext.Products.AddAsync(product, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return product;
    }
}