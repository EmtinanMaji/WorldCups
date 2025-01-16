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

        public IActionResult CreateNewHotel(Hotel hotel,IFormFile photo)
        {
            if (photo != null || photo.Length==0)
            {
                return Content("File Not Selscted");
            }

            var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", photo.FileName);

            using(FileStream stream = new FileStream(path, FileMode.Create))
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
            if (photo != null || photo.Length == 0)
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
    }
}
