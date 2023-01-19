using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace salesWebApp.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        // [Required(ErrorMessage = "{0} obrigatorio!")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O nome deve ter no minimo {2} letras e no maximo {1} letras!")]
        public string? Name { get; set; }
        [Display(Name = "Email")]
        // [Required(ErrorMessage = "{0} obrigatorio!")]
        [EmailAddress(ErrorMessage = "Email inválido!")]
        public string? Email { get; set; }
        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "{0} obrigatorio!")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Salario")]
        [Required(ErrorMessage = "{0} obrigatorio!")]
        [Range(1000.00, 8000.00, ErrorMessage = "{0} deve ser no minimo {1} e no maximo {2}")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }
        public Department? Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSeller(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}