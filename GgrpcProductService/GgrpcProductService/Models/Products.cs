namespace GgrpcProductService.Models;

public class Products
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string Tags { get; set; } = "Default";
}