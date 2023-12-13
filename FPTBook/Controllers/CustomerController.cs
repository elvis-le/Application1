using FPTBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FPTBook.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        private readonly FptbookContext _context;

        public CustomerController(FptbookContext context)
        {
            _context = context;
        }

        // GET: CustomerController1
        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.Include(a => a.ImageBook).ToListAsync();
            return View(books);
        }

        // GET: CustomerController1/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        public async Task<IActionResult> Profile(int id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: CustomerController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
