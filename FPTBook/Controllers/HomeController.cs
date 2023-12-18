using FPTBook.Data;
using FPTBook.Interfaces;
using FPTBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FPTBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly FptbookContext _context;
        private readonly IBookRepository _bookRepository;

        public HomeController(FptbookContext context, IBookRepository bookRepository)
        {
            _context = context;
            _bookRepository = bookRepository;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookRepository.GetAll();

            return View(books);
        }

        public async Task<IActionResult> DetailBookAsync(int id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
