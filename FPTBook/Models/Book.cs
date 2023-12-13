using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FPTBook.Models;

public partial class Book
{
    [Key]
    public int BookId { get; set; }

    public string BookTitle { get; set; } = null!;

    public int BookPrice { get; set; }

    public int BookNumber { get; set; }

    public string? BookDetails { get; set; }

    public int PublisherId { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ImageBook? ImageBook { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Publisher Publisher { get; set; } = null!;
}
