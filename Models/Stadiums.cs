using System.ComponentModel.DataAnnotations;

namespace WorldCups.Models
{
    public class Stadiums
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string City { get; set; }
        public string Type { get; set; }
        public DateTime ConstractionDate { get; set; }
        public string Owner { get; set; }
        public double Space { get; set; }
        public string Images { get; set; }
        public List<string> Facilities { get; set; } = new List<string>();
    }
}
