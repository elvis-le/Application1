using System;
using System.Collections.Generic;

namespace FPTBook.Models;

public partial class ImageBook
{
    public int BookId { get; set; }

    public string? BookImage1 { get; set; }

    public string? BookImage2 { get; set; }

    public string? BookImage3 { get; set; }

    public string? BookImage4 { get; set; }

    public string? BookImage5 { get; set; }

    public string? BookImage6 { get; set; }

    public string? BookImage7 { get; set; }

    public virtual Book Book { get; set; } = null!;
}
