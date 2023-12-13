using System;
using System.Collections.Generic;

namespace FPTBook.Models;

public partial class StoreOwnerBook
{
    public int StoreOwnerId { get; set; }

    public int BookId { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual StoreOwner StoreOwner { get; set; } = null!;
}
