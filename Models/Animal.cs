using System.ComponentModel.DataAnnotations;
namespace zoo_website.Models;
public class Animal
{
    public int Id { get; set; }

    
    public string Name { get; set; } = null!;  // Örnek: Lion


    public string? Lifespan { get; set; } // Örnek: 10–14 years in the wild

    
    public string? Diet { get; set; } // Örnek: Carnivore (antelopes, zebras, buffaloes)

   
    public string? Habitat { get; set; } // Örnek: African savannas and grasslands

    public string? Description { get; set; } // Açıklama paragrafı

    public string? ImagePath { get; set; } // Hayvan fotoğrafının yolu
}
