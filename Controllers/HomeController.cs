using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WorldCups.Data;
using WorldCups.Models;

namespace WorldCups.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        //public HomeController(ILogger<HomeController> logger)
        public HomeController(ApplicationDbContext context)
        {
            //_logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.categories.ToList();
            //var categories = new List<Categories>
            //{
            //    new Categories
            //    {
            //        Id = 1,
            //        Name = "«·„·«⁄»",
            //        Icon = "<i class=\"fa fa-futbol-o text-success\" aria-hidden=\"true\" style=\"font-size: 100px;\"></i>",
            //        Url = "Stadiums"
            //    },

            //    new Categories
            //    {
            //        Id = 2,
            //        Name = "„Ê«⁄Ìœ «·„»«—…",
            //        Icon = "<i class=\"fa fa-clock-o text-success\" aria-hidden=\"true\" style=\"font-size: 100px;\"></i>",
            //        Url = "TableFootball"
            //    },

            //    new Categories
            //    {
            //        Id = 3,
            //        Name = "«·›‰«œﬁ",
            //        Icon = "<i class=\"fa fa-bed text-success\" aria-hidden=\"true\" style=\"font-size: 100px;\"></i>",
            //        Url = "Hotel"
            //    },

            //    new Categories
            //    {
            //        Id = 4,
            //        Name = "«·‰ﬁ·",
            //        Icon = "<i class=\"fa fa-car text-success\" aria-hidden=\"true\" style=\"font-size: 100px;\"></i>",
            //        Url = "Transport"
            //    }
            //};
            return View(categories);
        }
        public IActionResult Stadiums()
        {
            //var stadiums = new List<Stadiums>
            //{
            //    new Stadiums
            //    {
            //        Id = 1,
            //        Name = "«” «œ «·„·ﬂ ”·„«‰ «·œÊ·Ì",
            //        Capacity = 92760,
            //        City = "«·—Ì«÷",
            //        Type = "ﬂ—… ﬁœ„",
            //        ConstractionDate =new DateTime(2029),
            //        Owner = "«·ÂÌ∆… «·⁄«„… ··—Ì«÷…",
            //        Space = 660000,
            //        Facilities = new List<string> { "·⁄»«‰ —œÌ›«‰ ·· œ—Ì»", "”«Õ«  ··„‘Ã⁄Ì‰", "’«·… —Ì«÷Ì… „€·ﬁ…", "„”»Õ √Ê·„»Ì", "„÷„«— ·√·⁄«» «·ﬁÊÏ", "„·«⁄» Œ«—ÃÌ… „À· „·«⁄» ﬂ—… «·ÿ«∆—… Êﬂ—… «·”·… Ê«·»«œ·" },
            //        Images = "images/«” «œ «·„·ﬂ ”·„«‰ «·œÊ·Ì.jpg"
            //    },

            //    new Stadiums
            //    {
            //        Id = 2,
            //        Name = "«” «œ „œÌ‰… «·„·ﬂ ›Âœ «·—Ì«÷Ì…",
            //        Capacity = 70200,
            //        City = "«·—Ì«÷",
            //        Type = "ﬂ—… ﬁœ„",
            //        ConstractionDate =new DateTime(2026),
            //        Owner = "«·ÂÌ∆… «·⁄«„… ··—Ì«÷…",
            //        Space = 500000,
            //        Facilities = new List<string> { "„»‰Ï «··«⁄»Ì‰", "«·„·⁄» «·⁄‘»Ì ·ﬂ—… «·ﬁœ„ Ê„·Õﬁ« Â «·Œœ„Ì…", "„÷„«— «·Ã—Ì Ê√·⁄«» «·ﬁÊÏ Êﬁ‰«… «·Õ„«Ì…", "«·’«·… «·„€ÿ«… ··√·⁄«» «·—Ì«÷Ì… ﬂﬂ—… «·Ìœ Êﬂ—… «·”·… Êﬂ—… «·ÿ«∆—… Ê—Ì«÷«  «·ÃÊœÊ Ê«·ﬂ«—« ÌÂ Ê€Ì—Â«", " «·„”Ãœ Ê«·”«Õ«  «·Œ«—ÃÌ… Ê«·Õœ«∆ﬁ Ê„Ê«ﬁ› «·”Ì«—« ", "„‰’«  „ﬁ«⁄œ –ÊÌ «·«Õ Ì«Ã«  «·Œ«’…" },
            //        Images = "images/«” «œ „œÌ‰… «·„·ﬂ ⁄»œ«··Â «·—Ì«÷Ì…..jpg"
            //    },
            //};
            return View();
        }
        public IActionResult Hotel()
        {
            var hotel = _context.hotels.ToList();
            //var hotel = new List<Hotel>
            //{
            //    new Hotel
            //    {
            //        Id = 1,
            //        Name = "›‰œﬁ Ê‘ﬁﬁ ÂÌ· Ê‰",
            //        Images = "images/›‰œﬁ Ê‘ﬁﬁ ÂÌ· Ê‰.webp",
            //        Location = "6623 ÕÌ «·‘Âœ«¡, ÿ—Ìﬁ «·œ«∆—Ì «·‘—ﬁÌ 13241 ñ 2892 , 11622 «·—Ì«÷, «·„„·ﬂ… «·⁄—»Ì… «·”⁄ÊœÌ…",
            //        City = "«·—Ì«÷",
            //        Price = 850,
            //        Facilities = new List<string> { "„Êﬁ› ”Ì«—«  Œ«’", "Ê«Ì ›«Ì „Ã«‰Ì", "„—ﬂ“ ⁄«›Ì… Ê”»«", "Œœ„… ‰ﬁ· «·„ÿ«—", "€—› ⁄«∆·Ì…", "„”»Õ«‰", "5 „ÿ⁄„" },
            //    },
            //    new Hotel
            //    {
            //        Id = 2,
            //        Name = "”Ê›Ì · ﬂÊ—‰Ì‘ «·Œ»—",
            //        Images = "images/”Ê›Ì · ﬂÊ—‰Ì‘ «·Œ»—.webp",
            //        Location = "Ã‰Ê» ﬂÊ—‰Ì‘ «·Œ»— , 31952 «·Œ»—, «·„„·ﬂ… «·⁄—»Ì… «·”⁄ÊœÌ…»⁄œ ≈Ã—«¡ «·ÕÃ“°   Ê›— Ã„Ì⁄ «·»Ì«‰«  «·Œ«’… »„ﬂ«‰ «·≈ﬁ«„…° »„« ›Ì –·ﬂ —ﬁ„ «·Â« › Ê«·⁄‰Ê«‰° ›Ì  √ﬂÌœ «·ÕÃ“ «·Œ«’ »ﬂ Ê›Ì «·Õ”«» «·Œ«’ »ﬂ.",
            //        City = "«·Œ»—",
            //        Price = 350,
            //        Facilities = new List<string> { "„Êﬁ› ”Ì«—«  „Ã«‰Ì ›Ì «·„Êﬁ⁄", "€—› ⁄«∆·Ì…", "„—ﬂ“ ⁄«›Ì… Ê”»«", "Œœ„… ‰ﬁ· «·„ÿ«—", "€—› ·€Ì— «·„œŒ‰Ì‰", " «ÿ·«·… ⁄·Ï «·»Õ—" ,"„ÿ⁄„" },
            //    },


            //};
            return View(hotel);
        }
        public IActionResult Transport()
        {
            var transport = new List<Transport>
            {
                new Transport
                {
                    Id = 1,
                    Name = " ÊÌÊ « Â«Ì·«‰œ—",
                    Color = "«”Êœ",
                    Model = "«· «Ì Â«Ì»—œ",
                    ModelVersion = "2024",
                    Images = "images/ ÊÌÊ « Â«Ì·«‰œ— 2X4 «· «Ì Â«Ì»—œ 2024.jpg",
                },
                new Transport
                {
                    Id = 2,
                    Name = "ÃÌ·Ì „Ê‰Ã«—Ê",
                    Color = "«”Êœ",
                    Model = "„Ê‰Ã«—Ê 360",
                    ModelVersion = "2024",
                    Images = "images/„Ê‰Ã«—Ê 360.png",
                },


            };
            return View(transport);
        }
        public IActionResult TableFootball()
        {
            var tableFootball = new List<TableFootball>
            {
                new TableFootball
                {
                    Id = 1,
                    Ateam1 = "«·”⁄ÊœÌ…",
                    Ateam2 = "«·Ì«»«‰",
                    MatchTime = new DateTime(4/4/2034)
                },
                new TableFootball
                {
                    Id = 2,
                    Ateam1 = "«·”⁄ÊœÌ…",
                    Ateam2 = "«·«—Ã‰ Ì‰",
                    MatchTime = new DateTime(6/4/2034)
                },


            };
            return View(tableFootball);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
