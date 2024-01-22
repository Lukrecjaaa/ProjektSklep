using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektSklep.Data;
using ProjektSklep.Models;

namespace ProjektSklep.Controllers;

public class OrdersController : Controller
{
    private readonly ApplicationDbContext _context;

    public OrdersController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [Authorize]
    public IActionResult Index()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var carts = _context.Carts
            .Include(c => c.Products)
            .Where(c => c.UserId == userId && c.IsOrdered)
            .ToList();
        
        foreach (var cart in carts)
        {
            var products = new List<Product>();
            
            foreach (var id in cart.ProductIds)
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == id);
                products.Add(product);
            }

            cart.Products = products;
        }

        return View(carts);
    }
}