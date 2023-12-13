using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FPTBook.Models;

public partial class User
{
    [Key]
    public int UserId { get; set; }

    public string UserEmail { get; set; } = null!;

    public string UserFullName { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public int UserType { get; set; }

    public string? UserImage { get; set; }

    public string? UserAddress { get; set; }

    public string? UserPhone { get; set; }

    public DateTime? UserBirthday { get; set; }

    public string? UserSex { get; set; }

    public int UserSection { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual StoreOwner? StoreOwner { get; set; }
}
