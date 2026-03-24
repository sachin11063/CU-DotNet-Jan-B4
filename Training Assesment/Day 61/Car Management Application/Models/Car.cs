using System.ComponentModel.DataAnnotations;
namespace Car_Management_Application.Models;
 
public class Car
{
    public int Id { get; set; }
 
    [Required(ErrorMessage = "Brand is required")]
    public string Brand { get; set; } = string.Empty;
 
    [Required(ErrorMessage = "Model is required")]
    public string Model { get; set; } = string.Empty;
 
    [Range(1886, 2100, ErrorMessage = "Enter a valid year")]
    public int Year { get; set; }
 
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }
}