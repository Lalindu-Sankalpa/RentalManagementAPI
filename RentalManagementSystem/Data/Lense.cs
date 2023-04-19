using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalManagementSystem.Data
{
    public class Lense
    {
        [Key]
        public long LenseId { get; set; }
        public long CategoryId { get; set; }
        public string Quantity { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
    }
}
