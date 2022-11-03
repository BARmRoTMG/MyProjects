using AdventureWorks.Client.Models;
using AdventureWorks.Data.Models.Person;
using AdventureWorks.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace AdventureWorks.Client.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IRepository<Person> _repository;
        private readonly IMemoryCache _cache;

        public PeopleController(IRepository<Person> personRepository, IMemoryCache cache)
        {
            _repository = personRepository;
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

        [HttpPost]
        public async Task<ActionResult> Index(PageControlViewModel model)
        {
            return await DisplayList(model);
        }

        private async Task<ActionResult> DisplayList(PageControlViewModel model)
        {
            ViewBag.Title = "People List";
            ViewBag.PersonTypeOptions = Enum.GetValues<EnumPersonType>();
            var filter = new Filter
            {
                PageNumber = model.PageNumber > 0 ? model.PageNumber : 1,
                PageSize = model.PageSize > 0 ? model.PageSize : 10,
                PersonType = model.PersonType,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName
            };

            var key = filter.ToString();
            PageResponse<Person> res;
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

            return View("Index", res.Data.Select(p => ModelMapper.MapToBaseViewModel(p)));
        }
    }
}
