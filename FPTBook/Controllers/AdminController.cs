using FPTBook.Interfaces;
using FPTBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace FPTBook.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly FptbookContext _context;
        private readonly IBookRepository _bookRepository;

        public AdminController(FptbookContext context, IBookRepository bookRepository)
        {
            _context = context;
            _bookRepository = bookRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ManageCustomer()
        {
            return View();
        }

        public IActionResult ManageStoreOwner()
        {
            return View();
        }
    }
}
