using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace library_1100.Controllers
{
    public class BooksViewsController : Controller
    {
        private readonly ILogger<BooksViewsController> _logger;

        public BooksViewsController(ILogger<BooksViewsController> logger)
        {
            _logger = logger;
        }

        public IActionResult BookList()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        
    }
}