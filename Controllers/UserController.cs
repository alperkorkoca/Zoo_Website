using Microsoft.AspNetCore.Mvc;

using zoo_website.Models;

namespace Zoo_Info.AddControllersWithViews
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult AnimalList()
        {
            var animals = _context.Animals.ToList();
            return View(animals);
        }
    }
}
