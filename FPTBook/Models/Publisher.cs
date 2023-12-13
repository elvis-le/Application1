using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FPTBook.Models;

public partial class Publisher
{
    [Key]
    public int PublisherId { get; set; }

    public string? PublisherName { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
