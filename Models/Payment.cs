using System.ComponentModel.DataAnnotations;

namespace WorldCups.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        [Required]
        [CreditCard]
        public string CardNumber { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{3,4}$", ErrorMessage = "Invalid CVV")]
        public string CVV { get; set; }
        public bool IsSuccessful { get; set; } = false;

    }
}
