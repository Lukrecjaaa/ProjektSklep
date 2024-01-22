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
        TryAddProduct(new Product
        {
            Id = 1,
            Name = "Garnek",
            ImageUrl = "https://images-ext-2.discordapp.net/external/B5jdR-7M_S8DWO1NV0AdTv1NtEA1SyOmmHCuzpogL-8/https/gerlach.pl/img/cms/garnek-prime-white-24-cm.jpg?format=webp&width=671&height=671",
            Price = 55.99,
            Count = 1
        });
        
        TryAddProduct(new Product
        {
            Id = 2,
            Name = "Miska",
            ImageUrl = "https://florina.pl/hpeciai/0dbd903db9c01828868e01f4d8a6d31d/pol_pl_Miska-kuchenna-plastikowa-Praktyczna-mietowa-3-l-2800_2.webp",
            Price = 12.99,
            Count = 1
        });
        
        TryAddProduct(new Product
        {
            Id = 3,
            Name = "Patelnia",
            ImageUrl = "https://domex.leszno.pl/2-large_default/patelnia-classic-28-cm-non-stick-nieprzywierajaca-toscania.jpg",
            Price = 99.99,
            Count = 1
        });
        
        TryAddProduct(new Product
        {
            Id = 4,
            Name = "Zestaw sztućców (30 elementów)",
            ImageUrl = "https://www.villaitalia.pl/media/products/2f221d2d0d2240db51561fc19a2ff7b8/images/thumbnail/large_Antique-Zestaw.webp?lm=1686838401",
            Price = 149.99,
            Count = 1
        });
        
        TryAddProduct(new Product
        {
            Id = 5,
            Name = "Zestaw szklanek (5 elementów)",
            ImageUrl = "https://www.villaitalia.pl/media/products/401b9894265feac99746cb7b0d9a4099/images/thumbnail/large_komplet-szklanek-do-drinkow-AK409-K.webp?lm=1686905721",
            Price = 45.99,
            Count = 1
        });
        
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