using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SelaPetShop.Client.Models;
using SelaPetShop.Data.Models;
using SelaPetShop.Data.Repositories;

namespace SelaPetShop.Client.Controllers
{
    public class PetShopController : Controller
    {
        private readonly IRepository<Animal> _repository;
        private readonly IRepository<User> _userRepository;
        private readonly IMemoryCache _cache;

        public PetShopController(IRepository<Animal> repository, IMemoryCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public async Task<ActionResult> Index(int id = 1)
        {
            var model = new PageControlViewModel
            {
                PageNumber = id > 0 ? id : 1,
                PageSize = 10
            };
            return await DisplayList(model);
        }

        public async Task<ActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(UserViewModel user)
        {
            if (user == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                //var newUser = ModelMapper.MapToUserViewModel(user);
                //newUser = await _userRepository.Register(newUser);

                ModelState.Clear();
                ViewBag.Message = $"{user.Username} successfully registered.";
                return View();
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        //public async Task<ActionResult> Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<ActionResult> Login(UserViewModel user)
        //{
        //    if (user != null)
        //    {
        //        _userRepository.Login(user);
        //    }
        //    else
        //    {
        //    }
        //}

        private async Task<ActionResult> DisplayList(PageControlViewModel model)
        {
            ViewBag.Title = "Animals List";
            var filter = new Filter
            {
                PageNumber = model.PageNumber > 0 ? model.PageNumber : 1,
                PageSize = model.PageSize > 0 ? model.PageSize : 10,
                Name = model.Name,
                Category = model.Category,
            };

            var key = filter.ToString();
            PageResponse<Animal> res;
            if (!_cache.TryGetValue(key, out res))
            {
                res = await _repository.Get(filter);
                _cache.Set(key, res, TimeSpan.FromSeconds(180));
            }

            ViewData.Add("PageControl", new PageControlViewModel
            {
                PageNumber = res.PageNumber,
                PageSize = res.PageSize,
                TotalCount = res.TotalCount
            });

            return View(res);
            //return View("Index", res.Data.Select(p => ModelMapper.MapToBaseViewModel(p)));
        }
    }
}
