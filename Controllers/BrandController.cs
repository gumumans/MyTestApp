using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;

namespace MyWebApp.Controllers;

public class BrandController : Controller
{
    private readonly MobileContext _context;

    public BrandController(MobileContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index()
    {
        var brands = _context.Brands.ToList();
        return View(brands);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Brand brand)
    {
        if (ModelState.IsValid)
        {
            _context.Add(brand);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}