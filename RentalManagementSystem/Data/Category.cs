using System.ComponentModel.DataAnnotations;

namespace RentalManagementSystem.Data
{
    public class Category
    {
        [Key]
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
