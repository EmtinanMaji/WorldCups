using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldCups.Data;
using WorldCups.Models;

namespace WorldCups.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Create(int hotelId)
        {
            var hotel = _context.hotels.SingleOrDefault(h => h.Id == hotelId);
            if (hotel == null) return NotFound();

            ViewData["HotelId"] = hotelId;
            ViewData["HotelName"] = hotel.Name;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            var hotel = _context.hotels.SingleOrDefault(h => h.Id == booking.HotelId);

            if (hotel == null) return NotFound();

            var totalDays = (booking.CheckOutDate - booking.CheckInDate).Days;
            booking.TotalAmount = hotel.Price * totalDays;

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return RedirectToAction("Process", "Payment", new { bookingId = booking.Id });
        }

        public IActionResult Invoice(int bookingId)
        {
            var booking = _context.Bookings
                .Include(b => b.Hotel)
                .Include(b => b.Payment)
                .SingleOrDefault(b => b.Id == bookingId);

            if (booking == null)
            {
                Console.WriteLine($"Invoice request failed. Booking ID {bookingId} not found.");
                return NotFound();
            }

            Console.WriteLine($"Invoice method called for Booking ID: {bookingId}");
            return View(booking);
        }
    }
}
