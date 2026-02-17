using Microsoft.AspNetCore.Mvc;
using ClientContactSolution.Models;
using ClientContactSolution.Data;
using System.Linq;

namespace ClientContactSolution.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Contact/Index
        public IActionResult Index()
        {
            var contacts = _context.Contacts
                .OrderBy(c => c.Surname)
                .ThenBy(c => c.Name)
                .ToList();
            return View(contacts);
        }

        // GET: Contact/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contact/CreateAjax
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAjax([FromForm] Contact model)
        {
            if (_context.Contacts.Any(c => c.Email == model.Email))
            {
                ModelState.AddModelError("Email", "This email already exists.");
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(kvp => kvp.Value.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.First().ErrorMessage
                    );

                return Json(new { success = false, errors });
            }

            _context.Contacts.Add(model);
            _context.SaveChanges();

            return Json(new
            {
                success = true,
                data = new
                {
                    model.Id,
                    model.Name,
                    model.Surname,
                    model.Email
                }
            });
        }

        // POST: Contact/DeleteAjax
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAjax(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return Json(new { success = false, message = "Contact not found." });
            }

            _context.Contacts.Remove(contact);
            _context.SaveChanges();

            return Json(new { success = true });
        }
    }
}