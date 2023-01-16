using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using salesWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace salesWebApp.Services
{
    public class SellerServices
    {
        private readonly Context _context;

        public SellerServices(Context context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAll()
        {
            return await _context.Seller.ToListAsync();
        }
    }
}