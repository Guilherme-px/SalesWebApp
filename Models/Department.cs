using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace salesWebApp.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string? Name { get; set; }
        public ICollection<Seller> Sallers { get; set; } = new List<Seller>();

        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sallers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sallers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}