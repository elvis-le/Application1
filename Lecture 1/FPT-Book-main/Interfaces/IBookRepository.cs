using FPTBook.Models;

namespace FPTBook.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Task<IEnumerable<Book>> GetByTitle(string title);
        Task<Book> GetByIdAsync(int id);
        Task<IEnumerable<Publisher>> GetAllPublishers();
        Task<IEnumerable<Category>> GetAllAuthors();
        bool Add(Book book);
        bool Delete(Book book);
        bool DeleteImages(int bookId);
        bool Update(Book book);
        bool Save();
    }
}
