using Microsoft.AspNetCore.Mvc;
using ClientContactSolution.Models;

namespace ClientContactSolution.Controllers
{
    public class ClientController : Controller
    {
        private readonly AppDbContext _context;

        public ClientController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clients = _context.Clients
                .OrderBy(c => c.Name)
                .ToList();

            return View(clients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Client model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.ClientCode = GenerateClientCode(model.Name);

            _context.Clients.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        private string GenerateClientCode(string clientName)
        {
            string alpha = new string(clientName
                .Where(char.IsLetter)
                .Take(3)
                .ToArray())
                .ToUpper();

            while (alpha.Length < 3)
                alpha += (char)('A' + alpha.Length);

            int number = 1;
            string code;

            do
            {
                code = $"{alpha}{number:000}";
                number++;
            }
            while (_context.Clients.Any(c => c.ClientCode == code));

            return code;
        }
    }
}