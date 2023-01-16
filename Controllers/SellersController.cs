using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace salesWebApp.Controllers
{
    [Route("[controller]")]
    public class SellersController : Controller
    {
        private readonly ILogger<SellersController> _logger;

        public SellersController(ILogger<SellersController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}