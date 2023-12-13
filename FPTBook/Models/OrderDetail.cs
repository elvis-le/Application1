using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FPTBook.Models;

public partial class OrderDetail
{
    [Key]
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int? BookId { get; set; }

    public int Quantity { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Order? Order { get; set; }
}
