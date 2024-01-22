namespace ProjektSklep.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
    public double Price { get; set; }
    public int Count { get; set; } = 1;
}