using System.ComponentModel.DataAnnotations;
namespace zoo_website.Models;
using Microsoft.AspNetCore.Mvc;

public class Animal
{
    public int Id { get; set; }

    [Required]
    [StringLength(10 , ErrorMessage = "10 karakterden fazla olmasin.")]
[Remote(action: "IsNameAvailable", controller: "Animal")]


    public string Name { get; set; } = null!;  


    public string? Lifespan { get; set; } 

    
    public string? Diet { get; set; } 

   
    public string? Habitat { get; set; } 

    public string? Description { get; set; } 

    public string? ImagePath { get; set; } 
}
