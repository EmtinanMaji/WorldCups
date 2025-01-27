using Microsoft.AspNetCore.Mvc;
using WorldCups.Data;
using WorldCups.Models;

namespace WorldCups.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Process(int bookingId)
        {
            var booking = _context.Bookings.SingleOrDefault(b => b.Id == bookingId);

            if (booking == null) return NotFound();

            var payment = new Payment
            {
                BookingId = booking.Id

            };

            return View();
        }

        [HttpPost]
        public IActionResult Process(Payment payment)
        {

            
            payment.IsSuccessful = true;
            _context.Payments.Add(payment);
            _context.SaveChanges();

            return RedirectToAction("Invoice", "Booking", new { bookingId = payment.BookingId });
        }
        



    }
}
