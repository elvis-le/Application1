using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FPTBook.Models;

public partial class Cart
{
    [Key]
    public int CartId { get; set; }

    public int BookId { get; set; }

    public int CustomerId { get; set; }

    public int Number { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
