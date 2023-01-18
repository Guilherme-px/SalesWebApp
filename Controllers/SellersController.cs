using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using salesWebApp.Models;
using salesWebApp.Services;

namespace salesWebApp.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerServices _sellerService;

        public SellersController(SellerServices sellerService)
        {
            _sellerService = sellerService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            await _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}