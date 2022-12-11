using Microsoft.AspNetCore.Mvc;
using NewPetShop.Client.Models;
using NewPetShop.Data.Entities;
using NewPetShop.Data.Filters;
using NewPetShop.Data.Interfaces;
using NewPetShop.Models;
using System.Diagnostics;

namespace NewPetShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Animal> _context;
        private readonly IMapper<Animal, AnimalDto> _mapper;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IRepository<Animal> context, IMapper<Animal, AnimalDto> mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            MostCommentedResponse<Animal> res = _context.GetMostCommented();

            return View("Index", res.Data.Select(a => _mapper.Map(a)));
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