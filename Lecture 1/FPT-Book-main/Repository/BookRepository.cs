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

        public bool DeleteImages(int bookId)
        {
            var product = _context.Books.Include(p => p.ImageBooks).FirstOrDefault(p => p.BookId == bookId);

            if (product != null)
            {
                _context.ImageBooks.RemoveRange(product.ImageBooks);
                _context.Entry(product).State = EntityState.Detached;
            }

            return Save();
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books
                .Include(a => a.ImageBooks)
                .ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.ImageBooks)
                .FirstOrDefaultAsync(b => b.BookId == id);
        }

        public async Task<IEnumerable<Book>> GetByTitle(string title)
        {
            return await _context.Books.Where(b => b.BookTitle.Contains(title)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Book book)
        {
            _context.Update(book);
            return Save();
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            var authors = _context.Authors
                .OrderBy(c => c.AuthorId);

            return await authors.ToListAsync();
        }

        public Task<IEnumerable<Book>> GetBookByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Category>> IBookRepository.GetAllAuthors()
        {
            throw new NotImplementedException();
        }
    }
}
