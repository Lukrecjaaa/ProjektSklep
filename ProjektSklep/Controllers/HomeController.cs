using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjektSklep.Data;
using ProjektSklep.Models;

namespace ProjektSklep.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public void TryAddProduct(Product product)
    {
        var dbProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);

        if (dbProduct != null) return;
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public IActionResult Index()
    {
        var p1 = new Product
        {
            Id = 1,
            Name = "AAA",
            Price = 1.23,
            Count = 1
        };
        var p2 = new Product
        {
            Id = 2,
            Name = "BBB",
            Price = 2.34,
            Count = 1
        };
        var p3 = new Product
        {
            Id = 3,
            Name = "CCC",
            Price = 3.45,
            Count = 1
        };
        
        var p4 = new Product
        {
            Id = 4,
            Name = "AAA",
            Price = 1.23,
            Count = 1
        };
        var p5 = new Product
        {
            Id = 5,
            Name = "BBB",
            Price = 2.34,
            Count = 1
        };
        var p6 = new Product
        {
            Id = 6,
            Name = "CCC",
            Price = 3.45,
            Count = 1
        };
        
        TryAddProduct(p1);
        TryAddProduct(p2);
        TryAddProduct(p3);
        TryAddProduct(p4);
        TryAddProduct(p5);
        TryAddProduct(p6);
        
        return View(_context.Products.ToList());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}