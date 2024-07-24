using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Models;
using MyWebApp.ViewModels;

namespace MyWebApp.Controllers;

public class PhoneController : Controller
{

    private MobileContext _context;

    public PhoneController(MobileContext context)
    {
        _context = context;
    }
    // GET //localhost/Phone/Index
    public IActionResult Index(int? brandId)
    {
        List<Phone> phones = _context.Phones.Include(p => p.Brand).ToList();
        if (brandId.HasValue)
        {
            phones = phones.Where(p => p.BrandId == (int)brandId).ToList();
        }
        var brands = _context.Brands.ToList();
        var ipvm = new IndexPhoneViewModel()
        {
            Phones = phones,
            Brands = brands
        };
        return View(ipvm);
    }

    public IActionResult GetMessage()
    {
        Console.WriteLine("qwe");
        return PartialView("_GetMessage");
    }
    [HttpGet]
    public IActionResult Create()
    {
        var brands = _context.Brands.ToList();
        ViewBag.Brands = brands;
        return View();
    }

    [HttpPost]
    public IActionResult Create(Phone phone)
    {
        if (ModelState.IsValid)
        {
            _context.Add(phone);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        var brands = _context.Brands.ToList();
        ViewBag.Brands = brands;
        return View(phone);
    }

    public IActionResult Edit(int phoneId)
    {
        Phone phone = _context.Phones.FirstOrDefault(p => p.Id == phoneId);
        if (phone != null)
        {
            return View(phone);
        }
        else
        {
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult Edit(Phone phone)
    {
        if (phone != null)
        {
            _context.Update(phone);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int phoneId)
    {
        Phone phone = _context.Phones.FirstOrDefault(p => p.Id == phoneId);
        if (phone != null)
        {
            _context.Remove(phone);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}