using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Models;

namespace MyWebApp.Controllers;

public class OrderController : Controller
{
    private readonly MobileContext _context;

    public OrderController(MobileContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index()
    {
        List<Order> orders = _context.Orders.Include(o => o.Phone).ToList();
        return View(orders);
    }
    public IActionResult Create(int phoneId)
    {
        Phone phone = _context.Phones.FirstOrDefault(p => p.Id == phoneId);
        return View(new Order(){Phone = phone});
    }
    [HttpPost]
    public IActionResult Create(Order order)
    {
        if (order != null)
        {
            _context.Add(order);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}