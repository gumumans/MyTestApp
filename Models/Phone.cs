using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models;

public class Phone
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Company { get; set; }
    [Required]
    [Range(100, 1000)]
    public int Price { get; set; }
    
    public int? BrandId { get; set; }
    public Brand? Brand { get; set; }
         
}