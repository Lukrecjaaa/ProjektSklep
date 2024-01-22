using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektSklep.Data;
using ProjektSklep.Models;

namespace ProjektSklep.Controllers;

public class CartController : Controller
{
    private readonly ApplicationDbContext _context;

    public CartController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [Authorize]
    public IActionResult Index()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var cart = _context.Carts.Include(c => c.Products).FirstOrDefault(c => c.UserId == userId && c.IsOrdered == false);
        if (cart == null)
        {
            cart = new Cart
            {
                UserId = userId
            };
            _context.Carts.Add(cart);
        }

        // cart.Products = cart.Products.Distinct().ToList();
        
        return View(cart);
    }
    
    [Authorize]
    public IActionResult Add(int id)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var cart = _context.Carts.Include(c => c.Products).FirstOrDefault(c => c.UserId == userId && c.IsOrdered == false);
        if (cart == null)
        {
            cart = new Cart
            {
                UserId = userId
            };
            _context.Carts.Add(cart);
        }

        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product.Count == 0) product.Count = 1;

        var index = cart.Products.FindIndex(p => p.Equals(product));

        if (index != -1)
        {
            cart.Products[index].Count++;
        }
        else
        {
            cart.Products.Add(product);
        }
        
        // cart.Products = cart.Products.Distinct().ToList();

        cart.Sum += product.Price;
        
        cart.ProductIds.Add(product.Id);

        _context.SaveChanges();
        
        return View("Index", cart);
    }
    
    [Authorize]
    public IActionResult Remove(int id)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var cart = _context.Carts.Include(c => c.Products).FirstOrDefault(c => c.UserId == userId && c.IsOrdered == false);
        if (cart == null)
        {
            cart = new Cart
            {
                UserId = userId
            };
            _context.Carts.Add(cart);
        }

        var product = _context.Products.FirstOrDefault(p => p.Id == id);

        var index = cart.Products.FindIndex(p => p.Equals(product));

        if (index != -1)
        {
            cart.Products[index].Count--;
        }

        if (cart.Products[index].Count == 0)
        {
            cart.Products.RemoveAt(index);
        }
        
        // cart.Products = cart.Products.Distinct().ToList();
        
        cart.Sum -= product.Price;
        
        cart.ProductIds.Remove(product.Id);

        _context.SaveChanges();
        
        return View("Index", cart);
    }

    [Authorize]
    public IActionResult Order()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        var cart = _context.Carts.Include(c => c.Products).FirstOrDefault(c => c.UserId == userId && c.IsOrdered == false);
        if (cart == null)
        {
            cart = new Cart
            {
                UserId = userId
            };
            _context.Carts.Add(cart);
        }
        
        var products = new List<Product>();
            
        foreach (var id in cart.ProductIds)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            products.Add(product);
        }

        cart.Products = products;
        
        foreach (var product in cart.Products)
        {
            product.Count = 0;
        }

        cart.IsOrdered = true;
        // cart.Products = cart.Products.Distinct().ToList();

        _context.SaveChanges();

        return View("Success", cart);
    }
}