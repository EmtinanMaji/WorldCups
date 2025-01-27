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
            //        Name = "�������",
            //        Icon = "<i class=\"fa fa-futbol-o text-success\" aria-hidden=\"true\" style=\"font-size: 100px;\"></i>",
            //        Url = "Stadiums"
            //    },

            //    new Categories
            //    {
            //        Id = 2,
            //        Name = "������ �������",
            //        Icon = "<i class=\"fa fa-clock-o text-success\" aria-hidden=\"true\" style=\"font-size: 100px;\"></i>",
            //        Url = "TableFootball"
            //    },

            //    new Categories
            //    {
            //        Id = 3,
            //        Name = "�������",
            //        Icon = "<i class=\"fa fa-bed text-success\" aria-hidden=\"true\" style=\"font-size: 100px;\"></i>",
            //        Url = "Hotel"
            //    },

            //    new Categories
            //    {
            //        Id = 4,
            //        Name = "�����",
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
            //        Name = "����� ����� ����� ������",
            //        Capacity = 92760,
            //        City = "������",
            //        Type = "��� ���",
            //        ConstractionDate =new DateTime(2029),
            //        Owner = "������ ������ �������",
            //        Space = 660000,
            //        Facilities = new List<string> { "����� ������ �������", "����� ��������", "���� ������ �����", "���� ������", "����� ������ �����", "����� ������ ��� ����� ��� ������� ���� ����� �������" },
            //        Images = "images/����� ����� ����� ������.jpg"
            //    },

            //    new Stadiums
            //    {
            //        Id = 2,
            //        Name = "����� ����� ����� ��� ��������",
            //        Capacity = 70200,
            //        City = "������",
            //        Type = "��� ���",
            //        ConstractionDate =new DateTime(2026),
            //        Owner = "������ ������ �������",
            //        Space = 500000,
            //        Facilities = new List<string> { "���� ��������", "������ ������ ���� ����� �������� �������", "����� ����� ������ ����� ����� �������", "������ ������� ������� �������� ���� ���� ���� ����� ���� ������� ������� ������ ���������� ������", " ������ �������� �������� �������� ������ ��������", "����� ����� ��� ���������� ������" },
            //        Images = "images/����� ����� ����� ������� ��������..jpg"
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
            //        Name = "���� ���� ������",
            //        Images = "images/���� ���� ������.webp",
            //        Location = "6623 �� �������, ���� ������� ������ 13241 � 2892 , 11622 ������, ������� ������� ��������",
            //        City = "������",
            //        Price = 850,
            //        Facilities = new List<string> { "���� ������ ���", "��� ��� �����", "���� ����� ����", "���� ��� ������", "��� ������", "������", "5 ����" },
            //    },
            //    new Hotel
            //    {
            //        Id = 2,
            //        Name = "������ ������ �����",
            //        Images = "images/������ ������ �����.webp",
            //        Location = "���� ������ ����� , 31952 �����, ������� ������� ����������� ����� ����ҡ ����� ���� �������� ������ ����� ������ɡ ��� �� ��� ��� ������ �������� �� ����� ����� ����� �� ��� ������ ����� ��.",
            //        City = "�����",
            //        Price = 350,
            //        Facilities = new List<string> { "���� ������ ����� �� ������", "��� ������", "���� ����� ����", "���� ��� ������", "��� ���� ��������", " ������ ��� �����" ,"����" },
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
                    Name = "������ ��������",
                    Color = "����",
                    Model = "�� �� ������",
                    ModelVersion = "2024",
                    Images = "images/������ �������� 2X4 �� �� ������ 2024.jpg",
                },
                new Transport
                {
                    Id = 2,
                    Name = "���� �������",
                    Color = "����",
                    Model = "������� 360",
                    ModelVersion = "2024",
                    Images = "images/������� 360.png",
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
                    Ateam1 = "��������",
                    Ateam2 = "�������",
                    MatchTime = new DateTime(4/4/2034)
                },
                new TableFootball
                {
                    Id = 2,
                    Ateam1 = "��������",
                    Ateam2 = "���������",
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
