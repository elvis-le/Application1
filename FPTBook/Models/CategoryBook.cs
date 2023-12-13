using System;
using System.Collections.Generic;

namespace FPTBook.Models;

public partial class CategoryBook
{
    public int CategoryId { get; set; }

    public int BookId { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;
}
