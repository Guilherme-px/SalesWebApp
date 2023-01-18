using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using salesWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace salesWebApp.Services
{
    public class DepartmentService
    {
        private readonly Context _context;

        public DepartmentService(Context context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAll()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task Insert(Seller obj)
        {
            obj.Department = _context.Department.First();
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}