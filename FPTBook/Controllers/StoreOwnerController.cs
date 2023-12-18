using FPTBook.Interfaces;
using FPTBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FPTBook.Controllers
{
    public class StoreOwnerController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly FptbookContext _context;
        private readonly IBookRepository _bookRepository;

        public StoreOwnerController(FptbookContext context, IBookRepository bookRepository)
        {
            _context = context;
            _bookRepository = bookRepository;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookRepository.GetAll();

            return View(books);
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult ManageBook()
        {            
            return View();
        }

        public IActionResult Record()
        {
            return View();
        }

        public async Task<IActionResult> AddProduct()
        {
            ViewData["PublisherId"] = new SelectList(await _bookRepository.GetAllPublishers(), "PublisherId", "PublisherName");
            ViewData["CategoryId"] = new SelectList(await _bookRepository.GetAllCategories(), "CategoryId", "CategoryName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Book books)
        {
            if (ModelState.IsValid)
            {
                return View(books);
            }
            _bookRepository.Add(books);
            return RedirectToAction("ManageBook");
        }

        public IActionResult EditProduct()
        {
            return View();
        }

    }
}
