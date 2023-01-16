using System;
using salesWebApp.Models;
using salesWebApp.Models.Enums;

namespace salesWebApp.Data
{
    public class SeedingService
    {
        private Context _context;

        public SeedingService(Context context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecords.Any())
            {
                return;
            }

            Department d1 = new Department(1, "Computadores");
            Department d2 = new Department(2, "Moda");
            Department d3 = new Department(3, "Livros");
            Department d4 = new Department(4, "Brinquedos");

            Seller s1 = new Seller(1, "Carlos Souza", "Carlos@gmail.com", new DateTime(1990, 2, 15), 1600.00, d1);
            Seller s2 = new Seller(2, "Ana Clara", "Ana_Clara@gmail.com", new DateTime(1984, 5, 1), 2000.00, d2);
            Seller s3 = new Seller(3, "Maria Silva", "maria@gmail.com", new DateTime(1996, 6, 13), 1650.60, d3);
            Seller s4 = new Seller(4, "Daniel Santos", "daniel@gmail.com", new DateTime(2001, 12, 26), 1860.00, d4);
            Seller s5 = new Seller(5, "Alan Pereira", "Alan@gmail.com", new DateTime(1991, 3, 13), 1900.00, d2);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2019, 03, 15), 2500.90, SalesStatus.Billed, s2);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2021, 05, 2), 100.99, SalesStatus.Billed, s1);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2015, 10, 3), 11000.00, SalesStatus.Billed, s3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2016, 03, 25), 3600.92, SalesStatus.Billed, s1);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2022, 06, 30), 350.40, SalesStatus.Billed, s4);
            SalesRecord r6 = new SalesRecord(6, new DateTime(2010, 09, 15), 1600.05, SalesStatus.Billed, s3);
            SalesRecord r7 = new SalesRecord(7, new DateTime(2015, 12, 1), 8000.20, SalesStatus.Billed, s2);
            SalesRecord r8 = new SalesRecord(8, new DateTime(2014, 11, 7), 760.99, SalesStatus.Billed, s1);
            SalesRecord r9 = new SalesRecord(9, new DateTime(2013, 08, 13), 220.00, SalesStatus.Billed, s1);
            SalesRecord r10 = new SalesRecord(10, new DateTime(2019, 03, 19), 110.35, SalesStatus.Billed, s4);
            SalesRecord r11 = new SalesRecord(11, new DateTime(2021, 09, 9), 4900.42, SalesStatus.Billed, s3);
            SalesRecord r12 = new SalesRecord(12, new DateTime(2020, 10, 22), 3000.65, SalesStatus.Billed, s2);
            SalesRecord r13 = new SalesRecord(13, new DateTime(2016, 11, 16), 950.90, SalesStatus.Billed, s4);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5);
            _context.SalesRecords.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r12, r13);

            _context.SaveChanges();
        }
    }
}