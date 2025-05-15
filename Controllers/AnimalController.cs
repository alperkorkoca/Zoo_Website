using Microsoft.AspNetCore.Mvc;
using zoo_website.Models;
using System.Linq;

namespace Zoo_Info.AddControllersWithViews
{
    public class AnimalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnimalController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var animals = _context.Animals.ToList();
            return View(animals);
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult IsNameAvailable(string name)
        {
            bool nameExists = _context.Animals.Any(a => a.Name == name);
            if (nameExists)
            {
                return Json($"'{name}' isimli hayvan zaten var.");
            }

            return Json(true);
        }

        // GET: Animal/Add
        public IActionResult Add()
        {
            return View();
        }

        // POST: Animal/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Animals.Add(animal);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(animal);
        }

        // GET: Animal/Edit/5
        public IActionResult Edit(int id)
        {
            var animal = _context.Animals.Find(id);
            if (animal == null)
                return NotFound();

            return View(animal);
        }

        // POST: Animal/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Animal animal)
        {
            if (id != animal.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var existingAnimal = _context.Animals.Find(id);
                if (existingAnimal == null)
                    return NotFound();

                existingAnimal.Name = animal.Name;
                existingAnimal.Lifespan = animal.Lifespan;
                existingAnimal.Diet = animal.Diet;
                existingAnimal.Habitat = animal.Habitat;
                existingAnimal.Description = animal.Description;
                existingAnimal.ImagePath = animal.ImagePath;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(animal);
        }

        // GET: Animal/Delete/5
        public IActionResult Delete(int id)
        {
            var animal = _context.Animals.Find(id);
            if (animal == null)
                return NotFound();

            return View(animal);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var animal = _context.Animals.Find(id);
            if (animal == null)
                return NotFound();

            _context.Animals.Remove(animal);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        // GET: Animal/Details/5
public IActionResult Details(int id)
{
    var animal = _context.Animals.FirstOrDefault(a => a.Id == id);
    if (animal == null)
        return NotFound();

    return View(animal);
}

    }
}
