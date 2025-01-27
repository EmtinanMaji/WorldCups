using System.Drawing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorldCups.Data;
using WorldCups.Models;

namespace WorldCups.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _webHostEnvironment;
        public DashboardController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

       

        public IActionResult CreateNewCategories(Categories categories)
        {
            if (ModelState.IsValid)
            {

                _context.Add(categories);
                _context.SaveChanges();
                TempData["Save"] = "  تمت عملية الحفظ بنجاح ";
                return RedirectToAction("Categories");



            }
            TempData["Save"] = "حدث خطأ, لم تتم عملية الحفظ";
            return View("Categories");
        }

        

        public IActionResult Categories(string name)
        {
            if (name != null)
            {
                var search = _context.categories.Where(p => p.Name.Contains(name)).ToList();
                return View(search);
            }
            var getdata = _context.categories.ToList();
            return View(getdata);
        }

        [HttpPost]
        public IActionResult Search(string Name)
        {
            if (Name != null && Name.Length > 0)
            {
                var search = _context.categories.Where(p => p.Name.Contains(Name)).ToList();
                return PartialView("_partial/_CategoriesPartialData", search);
            }
            var categories = _context.categories.ToList();
            return PartialView("_partial/_CategoriesPartialData", categories);
        }

        public IActionResult DeleteCategories(int id)
        {
            var categories = _context.categories.SingleOrDefault(c => c.Id == id); //searsh

            if (categories != null)
            {
                _context.categories.Remove(categories);
                _context.SaveChanges();
            }

            //Partial Data
            var catogries = _context.categories.ToList();  // read 

            return PartialView("_partial/_CategoriesPartialData", catogries);


            //return RedirectToAction("Categories");
        }

        public IActionResult EditCategories(int id)
        {
            var edit_catodries = _context.categories.SingleOrDefault(e => e.Id == id);
            return View(edit_catodries);
        }

        public IActionResult UpdateCategories(Categories categories)
        {
            _context.categories.Update(categories);
            _context.SaveChanges();

            return RedirectToAction("Categories");

        }


        public IActionResult CreateNewCategoriesTransportation(CategoriesTransportation categoriesTransportation)
        {
            _context.Add(categoriesTransportation);
            _context.SaveChanges();
            return RedirectToAction("CategoriesTransportation");
        }

        public IActionResult CategoriesTransportation()
        {
            var getdata = _context.transportations.ToList();
            return View(getdata);
        }

        public IActionResult CreateNewHotel(Hotel hotel, IFormFile photo)
        {

            if (photo == null || photo.Length == 0)
            {
                return Content("File Not Selected");
            }

            var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", photo.FileName); // path

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                photo.CopyTo(stream);
                stream.Close();
            }

            hotel.Images = photo.FileName;
            _context.Add(hotel);
            _context.SaveChanges();
            return RedirectToAction("Hotels");

        }

        public IActionResult Hotels()
        {
            var getdata = _context.hotels.ToList();
            return View(getdata);
        }

        [HttpPost]
        public IActionResult Search_Hotel(string Name)
        {
            if (Name != null && Name.Length > 0)
            {
                var search = _context.hotels.Where(p => p.Name.Contains(Name)).ToList();
                return PartialView("_partial/_HotelPartialData", search);
            }
            var categories = _context.hotels.ToList();
            return PartialView("_partial/_HotelPartialData", categories);
        }

        public IActionResult DeleteHotel(int id)
        {
            var hotels = _context.hotels.SingleOrDefault(c => c.Id == id); //searsh

            if (hotels != null)
            {
                _context.hotels.Remove(hotels);
                _context.SaveChanges();
            }

            //Partial Data
            var hotel = _context.hotels.ToList();  // read 

            return PartialView("_partial/_HotelPartialData", hotel);


        }

        public IActionResult EditHotels(int id)
        {
            var edit_hotels = _context.hotels.SingleOrDefault(e => e.Id == id);
            return View(edit_hotels);
        }
        public IActionResult UpdateHotels(Hotel hotel, IFormFile photo)
        {

            if (photo == null || photo.Length == 0)
            {
                return Content("File Not Selected");
            }

            var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", photo.FileName); // path

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                photo.CopyTo(stream);
                stream.Close();
            }

            hotel.Images = photo.FileName;
            _context.hotels.Update(hotel);
            _context.SaveChanges();
            return RedirectToAction("Hotels");

        }

        
        

        public IActionResult Transportation()
        {
            var getdata = _context.transportations.ToList();
            ViewBag.getdata = getdata;

            var transport = _context.transport.ToList();

            var getdatatransport = _context.transport.Join(
                _context.transportations,
                Transport => Transport.CategoriesTransportationId,
                Transportations => Transportations.Id,

                (Transport, Transportations) => new
                {
                    Id = Transport.Id,
                    NameCar = Transport.Name,
                    NameCategores = Transportations.Name,
                    Capacity = Transport.Capacity,
                    Color = Transport.Color,
                    Image = Transport.Images,
                    Model = Transport.Model,
                    ModelVersion = Transport.ModelVersion,
                    Km = Transport.Km,
                }).ToList();


            ViewBag.getdatatransport = getdatatransport;


            return View(transport);
        }

        public IActionResult CreateNewTransport(Transport transport,IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
            {
                return Content("File Not Selscted");
            }

            var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", photo.FileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                photo.CopyTo(stream);
                stream.Close();
            }
            transport.Images = photo.FileName;

            _context.Add(transport);
            _context.SaveChanges();
            return RedirectToAction("Transportation");

        }


        //Stadiums
        public IActionResult CreateNewStadiums(Stadiums stadiums, IFormFile photo)
        {

            if (photo == null || photo.Length == 0)
            {
                return Content("File Not Selected");
            }

            var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", photo.FileName); // path

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                photo.CopyTo(stream);
                stream.Close();
            }

            stadiums.Images = photo.FileName;
            _context.Add(stadiums);
            _context.SaveChanges();
            return RedirectToAction("Stadiums");

        }

        public IActionResult Stadiums()
        {
            var getdata = _context.stadiums.ToList();
            return View(getdata);
        }

        [HttpPost]
        public IActionResult Search_Stadiums(string Name)
        {
            if (Name != null && Name.Length > 0)
            {
                var search = _context.stadiums.Where(p => p.Name.Contains(Name)).ToList();
                return PartialView("_partial/_StadiumsPartialData", search);
            }
            var stadiums = _context.stadiums.ToList();
            return PartialView("_partial/_StadiumsPartialData", stadiums);
        }

        public IActionResult DeleteStadiums(int id)
        {
            var stadiums = _context.stadiums.SingleOrDefault(c => c.Id == id); //searsh

            if (stadiums != null)
            {
                _context.stadiums.Remove(stadiums);
                _context.SaveChanges();
            }

            //Partial Data
            var stadium = _context.stadiums.ToList();  // read 

            return PartialView("_partial/_StadiumsPartialData", stadium);


        }

        public IActionResult EditStadiums(int id)
        {
            var edit_stadiums = _context.stadiums.SingleOrDefault(e => e.Id == id);
            return View(edit_stadiums);
        }
        public IActionResult UpdateStadiums(Stadiums stadiums, IFormFile photo)
        {

            if (photo == null || photo.Length == 0)
            {
                return Content("File Not Selected");
            }

            var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", photo.FileName); // path

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                photo.CopyTo(stream);
                stream.Close();
            }

            stadiums.Images = photo.FileName;
            _context.stadiums.Update(stadiums);
            _context.SaveChanges();
            return RedirectToAction("Stadiums");

        }


        //TableFootball
        public IActionResult TableFootball()
        {
            var getdata = _context.stadiums.ToList();
            ViewBag.getdata = getdata;

            var tableFootballs = _context.tableFootballs.ToList();

            var getdatatableFootballs = _context.tableFootballs.Join(
                _context.stadiums,
                tableFootballs => tableFootballs.Stadiums_id,
                Stadiums => Stadiums.Id,

                (tableFootballs, stadiums) => new
                {
                    Id = tableFootballs.Id,
                    MatchTime = tableFootballs.MatchTime,
                    Stadiums_Name = stadiums.Name,
                    Ateam1 = tableFootballs.Ateam1,
                    Ateam2 = tableFootballs.Ateam2,
                }).ToList();


            ViewBag.getdatatableFootballs = getdatatableFootballs;


            return View(tableFootballs);
        }

        public IActionResult CreateNewTableFootball(TableFootball tableFootball)
        {
            _context.Add(tableFootball);
            _context.SaveChanges();
            return RedirectToAction("TableFootball");
        }

        [HttpPost]
        public IActionResult Search_TableFootball(string Ateam1)
        {
            if (Ateam1 != null && Ateam1.Length > 0)
            {
                var search = _context.tableFootballs.Where(p => p.Ateam1.Contains(Ateam1)).ToList();
                return PartialView("_partial/_TableFootballPartialData", search);
            }
            var tableFootballs = _context.tableFootballs.ToList();
            return PartialView("_partial/_TableFootballPartialData", tableFootballs);
        }

        public IActionResult DeleteTableFootball(int id)
        {
            var tableFootballs = _context.tableFootballs.SingleOrDefault(c => c.Id == id); //searsh

            if (tableFootballs != null)
            {
                _context.tableFootballs.Remove(tableFootballs);
                _context.SaveChanges();
            }

            //Partial Data
            var tableFootball = _context.tableFootballs.ToList();  // read 

            return PartialView("_partial/_TableFootballPartialData", tableFootball);


        }

        public IActionResult EditTableFootball(int id)
        {
            var edit_tableFootballs = _context.tableFootballs.SingleOrDefault(e => e.Id == id);
            return View(edit_tableFootballs);
        }

        public IActionResult UpdateTableFootball(TableFootball tableFootballs)
        {
            _context.tableFootballs.Update(tableFootballs);
            _context.SaveChanges();

            return RedirectToAction("TableFootball");

        }


    }
}
