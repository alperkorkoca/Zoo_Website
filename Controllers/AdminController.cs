using Microsoft.AspNetCore.Mvc;
using zoo_website.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using System;

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public AdminController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    [HttpGet]
    public IActionResult AddAnimal()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddAnimal(Animal animal, IFormFile imageFile)
    {
        if (imageFile != null && imageFile.Length > 0)
        {
            // 1. wwwroot/images klasörü oluşturulmamışsa oluştur
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // 2. Dosya adını benzersiz yap ve kaydet
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            // 3. Veritabanı için resmin yolunu ayarla (tarayıcı tarafından erişilebilir yol)
            animal.ImagePath = "/images/" + fileName;
        }

        _context.Animals.Add(animal);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Animal");
    }
}
