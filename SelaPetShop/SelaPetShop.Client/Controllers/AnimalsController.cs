using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SelaPetShop.Client.Models;
using SelaPetShop.Models.Dtos;
using SelaPetShop.Models.Entities;
using SelaPetShop.Models.Helpers;
using SelaPetShop.Models.Interfaces;
using SelaPetShop.Services.Mappers;

namespace SelaPetShop.Client.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly IRepository<Animal> _context;
        private readonly IMapper<Animal, AnimalDto> _mapper;
        private readonly IMemoryCache _cache;

        public AnimalsController(IRepository<Animal> context, IMemoryCache cache, IMapper<Animal, AnimalDto> mapper)
        {
            _context = context;
            _cache = cache;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int id = 1)
        {
            ViewBag.Title = "Sela's Pet Shop";
            try
            {
                var model = new PageControlViewModel
                {
                    PageNumber = id > 0 ? id : 1,
                    PageSize = 10
                };

                var filter = new Filter
                {
                    PageNumber = model.PageNumber > 0 ? model.PageNumber : 1,
                    PageSize = model.PageSize > 0 ? model.PageSize : 10,
                    Name = model.Name,
                    Category = model.Category
                };

                var key = filter.ToString();
                FilterResponse<Animal> res;
                if (!_cache.TryGetValue(key, out res))
                {
                    res = await _context.Get(filter);
                    _cache.Set(key, res, TimeSpan.FromSeconds(180));
                };

                return View(res.Data.Select(p => _mapper.Map(p).Result));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
