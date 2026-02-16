using Microsoft.AspNetCore.Mvc;
using ClientContactSolution.Models;

namespace ClientContactSolution.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contacts = _context.Contacts
                .OrderBy(c => c.Surname)
                .ThenBy(c => c.Name)
                .ToList();

            return View(contacts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact model)
        {
            if (_context.Contacts.Any(c => c.Email == model.Email))
            {
                ModelState.AddModelError("Email", "Email already exists.");
            }

            if (!ModelState.IsValid)
                return View(model);

            _context.Contacts.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}