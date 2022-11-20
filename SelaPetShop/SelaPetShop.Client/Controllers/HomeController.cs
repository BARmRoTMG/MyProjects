using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SelaPetShop.Client.Models;
using SelaPetShop.Models.Dtos;
using SelaPetShop.Models.Entities;
using SelaPetShop.Models.Interfaces;
using System.Diagnostics;

namespace SelaPetShop.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Animal> _context;
        private readonly IMapper<Animal, AnimalDto> _mapper;
        private readonly IMemoryCache _cache;

        public HomeController(ILogger<HomeController> logger, IRepository<Animal> context, IMemoryCache cache, IMapper<Animal, AnimalDto> mapper)
        {
            _logger = logger;
            _context = context;
            _cache = cache;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(_context.Get().Result.Data.Select(p => _mapper.Map(p).Result));
        }

        public IActionResult CataloguePage()
        {
            return View();
        }

        public IActionResult Login()
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