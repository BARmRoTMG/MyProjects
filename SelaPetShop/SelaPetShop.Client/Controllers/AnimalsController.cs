using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SelaPetShop.Client.Models;
using SelaPetShop.Models.Entities;
using SelaPetShop.Models.Helpers;
using SelaPetShop.Models.Interfaces;
using SelaPetShop.Services.Mappers;

namespace SelaPetShop.Client.Controllers
{
    public class AnimalsController : Controller
    {
        public readonly IRepository<Animal> _context;
        private readonly IMemoryCache _cache;

        public AnimalsController(IRepository<Animal> context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<IActionResult> Index(int id = 1)
        {
            var model = new PageControlViewModel
            {
                PageNumber = id > 0 ? id : 1,
                PageSize = 10
            };
            return await DisplayList(model);
        }

        private async Task<ActionResult> DisplayList(PageControlViewModel model)
        {
            ViewBag.Title = "Animals List";
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
            }

            ViewData.Add("PageControl", new PageControlViewModel
            {
                PageNumber = res.PageNumber,
                PageSize = res.PageSize,
                Count = res.Count
            });

            return View();//("Index", res.Data.Select(p => ModelMapper.(p)));
        }
    }
}
