using System.ComponentModel.DataAnnotations;

namespace WorldCups.Models
{
    public class CategoriesTransportation
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
