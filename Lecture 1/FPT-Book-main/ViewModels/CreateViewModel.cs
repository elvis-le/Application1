using FPTBook.Models;
using System.ComponentModel.DataAnnotations;

namespace FPTBook.ViewModels
{
    public class CreateViewModel
    {
        public int BookId { get; set; }

        public string BookTitle { get; set; } = null!;

        public int BookPrice { get; set; }

        public int BookNumber { get; set; }

        public string? BookDetails { get; set; }

        public int PublisherId { get; set; }
        public int AuthorId { get; set; }

        public IFormFile Image { get; set; }

    }
}
