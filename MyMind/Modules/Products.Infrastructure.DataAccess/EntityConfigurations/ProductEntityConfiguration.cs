using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Entities;

namespace Products.Infrastructure.DataAccess.EntityConfigurations;

internal class ProductEntityConfiguration: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Name).HasColumnName("Name");
        builder.Property(t => t.Price).HasColumnName("Price");
    }
}
