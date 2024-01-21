namespace ProjektSklep.Models;

public class Cart
{
    public int Id { get; set; }
    public List<Product>? Products { get; set; } = new List<Product>();
    public string? UserId { get; set; }
}