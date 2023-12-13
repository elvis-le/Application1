using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FPTBook.Models;

public partial class Order
{
    [Key]
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
