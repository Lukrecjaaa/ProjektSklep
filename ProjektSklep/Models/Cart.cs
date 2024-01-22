namespace ProjektSklep.Models;

public class Cart
{
    public int Id { get; set; }
    public List<Product>? Products { get; set; } = new List<Product>();
    public List<int> ProductIds { get; set; } = new List<int>();
    public string? UserId { get; set; }
    public bool IsOrdered { get; set; } = false;
    public double Sum { get; set; }
}