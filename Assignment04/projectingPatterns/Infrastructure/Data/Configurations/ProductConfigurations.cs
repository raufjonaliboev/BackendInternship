using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projectingPatterns.Domain.Entities;

namespace projectingPatterns.Infrastructure.Data.Configurations;

public class ProductConfigurations
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasQueryFilter(o => !o.IsDeleted);
    }
}