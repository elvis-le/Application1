﻿using FPTBook.Interfaces;
using FPTBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace FPTBook.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly FptbookContext _context;
        private readonly IBookRepository _bookRepository;

        public AccountController(FptbookContext context, IBookRepository bookRepository)
        {
            _context = context;
            _bookRepository = bookRepository;
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
