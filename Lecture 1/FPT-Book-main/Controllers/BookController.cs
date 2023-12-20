using FPTBook.Data;
using FPTBook.Interfaces;
using FPTBook.Models;
using FPTBook.Respository;
using FPTBook.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FPTBook.Controllers
{
    public class BookController : Controller
    {

        private IWebHostEnvironment _env;
        private readonly FptbookContext _context;
        private readonly IBookRepository _bookRepository;

        public BookController(FptbookContext context, IWebHostEnvironment env, IBookRepository bookRepository)
        {
            _context = context;
            _env = env;
            _bookRepository = bookRepository;
        }
        public async Task<IActionResult> Detail(int id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }
            var book = _context.Books.FirstOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherName");
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel bookVM)
        {
            var images = "";

            if (ModelState.IsValid)
            {
                if (bookVM.Image!=null)
                {
                    String uploadfolder = Path.Combine(_env.WebRootPath, "images");

                    var filename = Guid.NewGuid().ToString() + Path.GetExtension(bookVM.Image.FileName);

                    var filepath = Path.Combine(uploadfolder, filename);

                    try
                    {
                        using (var fileStream = new FileStream(filepath, FileMode.Create))
                        {
                            await bookVM.Image.CopyToAsync(fileStream);
                        }

                        images = filename;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error copying file: {ex.Message}");
                        return View("Error");
                    }
                }
                var books = new Book
                {
                    BookTitle = bookVM.BookTitle,
                    BookPrice = bookVM.BookPrice,
                    BookNumber = bookVM.BookNumber,
                    BookDetails = bookVM.BookDetails,
                    PublisherId = bookVM.PublisherId,
                    AuthorId = bookVM.AuthorId,
                    ImageBooks = new List<ImageBook>() { new ImageBook { BookImage = images } }
                };
                _bookRepository.Add(books);
                return RedirectToAction("ManageBook", "Admin");
            }
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherName");
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorName");
            return View(bookVM);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _bookRepository.GetByIdAsync(id);

            _bookRepository.Delete(product);

            return RedirectToAction("ManageBook", "admin");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null) return View("Error");
            var bookVM = new EditViewModel
            {
                BookId = book.BookId,
                BookTitle = book.BookTitle,
                BookPrice = book.BookPrice,
                BookNumber = book.BookNumber,
                BookDetails = book.BookDetails,
                PublisherId = book.PublisherId,
                defaultImages = book.ImageBooks.Select(x => x.BookImage).ToList()
            };

            ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherName");
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorName");

            return View(bookVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel bookVM)
        {
            var images = "";

            if (ModelState.IsValid)
            {
                if (bookVM.Image!=null)
                {
                    _bookRepository.DeleteImages(bookVM.BookId);

                    String uploadfolder = Path.Combine(_env.WebRootPath, "images");

                    var filename = Guid.NewGuid().ToString() + Path.GetExtension(bookVM.Image.FileName);

                    var filepath = Path.Combine(uploadfolder, filename);

                    try
                    {
                        using (var fileStream = new FileStream(filepath, FileMode.Create))
                        {
                            await bookVM.Image.CopyToAsync(fileStream);
                        }

                        images = filename;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error copying file: {ex.Message}");
                        return View("Error");
                    }
                }

                var books = new Book
                {
                    BookId = bookVM.BookId,
                    BookTitle = bookVM.BookTitle,
                    BookPrice = bookVM.BookPrice,
                    BookNumber = bookVM.BookNumber,
                    BookDetails = bookVM.BookDetails,
                    PublisherId = bookVM.PublisherId,
                    AuthorId = bookVM.AuthorId,
                    ImageBooks = new List<ImageBook>() { new ImageBook() { BookImage = images } }
                };

                _bookRepository.Update(books);

                return RedirectToAction("ManageBook", "Admin");
            }

            ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherName");
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorName");
            return View(bookVM);
        }
    }
}

