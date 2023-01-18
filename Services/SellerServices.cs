using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using salesWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace salesWebApp.Services
{
    public class SellerService
    {
        private readonly Context _context;

        public SellerService(Context context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAll()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task Insert(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller?> FindById(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task Remove(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj!);
            await _context.SaveChangesAsync();
        }
    }
}