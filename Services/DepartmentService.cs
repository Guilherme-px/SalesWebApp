using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using salesWebApp.Models;
using Microsoft.EntityFrameworkCore;
using salesWebApp.Services.Exceptions;

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

        public async Task<Department?> FindById(int id)
        {
            return await _context.Department.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task Insert(Department obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Department?> GetDetails(int id)
        {
            return await _context.Department
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Department obj)
        {
            var DepartmentExists = await _context.Department.AnyAsync(x => x.Id == obj.Id);

            if (!DepartmentExists)
            {
                throw new NotFoundException("Id não encontrado");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task Remove(int id)
        {
            try
            {
                var obj = await _context.Department.FindAsync(id);
                _context.Department.Remove(obj!);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new IntegrityException("Não foi possivel deletar o departamento!");
            }
        }
    }
}