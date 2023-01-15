#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using salesWebApp.Models;

    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<salesWebApp.Models.Department> Department { get; set; }
    }
