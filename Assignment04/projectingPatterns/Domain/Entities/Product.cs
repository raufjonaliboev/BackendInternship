namespace projectingPatterns.Domain.Entities;

public class Product
{
    public long Id { get; set; }
    public string? Name { get; set; } 
    public string? Description { get; set; }
    public bool IsDeleted { get; set; } = false;
}