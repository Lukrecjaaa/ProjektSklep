using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjektSklep.Data;

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
        var orders = _context.Orders.FirstOrDefault(o => o.UserId == userId);

        return View(orders);
    }
}