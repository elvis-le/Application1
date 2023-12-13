using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FPTBook.Models;

public partial class StoreOwner
{
    [Key]
    public int StoreOwnerId { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
