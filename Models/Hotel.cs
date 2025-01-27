using System.ComponentModel.DataAnnotations;

namespace WorldCups.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public decimal Price { get; set; }
        public List<string> Facilities { get; set; } = new List<string>();
        public List<Booking> Bookings { get; set; } = new List<Booking>();


    }
}
