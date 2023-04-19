using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalManagementSystem.Models
{
    public class ItemModel
    {
        public long? ItemsId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string AccNo { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }
    }
}
