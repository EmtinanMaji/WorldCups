using System.ComponentModel.DataAnnotations;

namespace WorldCups.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public decimal TotalAmount { get; set; }
        //public int? PaymentId { get; set; }
        public Payment Payment { get; set; }

    }
}
