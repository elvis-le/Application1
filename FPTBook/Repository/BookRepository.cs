using FPTBook.Interfaces;
using FPTBook.Models;
using Microsoft.EntityFrameworkCore;

namespace FPTBook.Respository
{
    public class BookRepository : IBookRepository
    {
        private readonly FptbookContext _context;

        public BookRepository(FptbookContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<Publisher>> GetAllPublishers()
        {
            var publishers = _context.Publishers
                .OrderBy(c => c.PublisherId);

            return await publishers.ToListAsync();
        }

        public bool Add(Book book)
        {
            _context.Add(book);
            return Save();
        }

        public bool Delete(Book book)
        {
            _context.Remove(book);
            return Save();
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books
                .Include(a => a.ImageBook)
                .ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.ImageBook)
                .FirstOrDefaultAsync(b => b.BookId == id);
        }

        public async Task<IEnumerable<Book>> GetByTitle(string title)
        {
            return await _context.Books.Where(b => b.BookTitle.Contains(title)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0? true : false;
        }

        public bool Update(Book book)
        {
            _context.Update(book);
            return Save();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var categories = _context.Categories
                .OrderBy(c => c.CategoryId);

            return await categories.ToListAsync();
        }
    }
}
