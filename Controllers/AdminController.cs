using Microsoft.AspNetCore.Mvc;
using zoo_website.Models;

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
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            animal.ImagePath = "/images/" + fileName;
        }

        _context.Animals.Add(animal);
        await _context.SaveChangesAsync();

        return RedirectToAction("AnimalList", "User");
    }
}
