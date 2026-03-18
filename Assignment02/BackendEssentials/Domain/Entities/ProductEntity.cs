using BackendEssentials.Domain.Common;

namespace BackendEssentials.Domain.Entities;

public class ProductEntity : BaseAuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } 
    public decimal Price { get; set; }
    public int Stock { get; set; }
}