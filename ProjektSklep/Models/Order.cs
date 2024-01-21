namespace ProjektSklep.Models;

public class Orders
{
    public int Id { get; set; }
    public List<Cart> Carts { get; set; } = new List<Cart>();
    public string? UserId { get; set; }
}