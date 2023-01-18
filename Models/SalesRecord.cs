using System.ComponentModel.DataAnnotations;
using salesWebApp.Models.Enums;

namespace salesWebApp.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Display(Name = "Montante")]
        public double Amount { get; set; }
        public SalesStatus Status { get; set; }
        [Display(Name = "Vendedor")]
        public Seller? Seller { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SalesStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }

}