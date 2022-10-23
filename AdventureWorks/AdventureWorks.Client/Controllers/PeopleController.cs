using AdventureWorks.Client.Models;
using AdventureWorks.Data.Models.Person;
using AdventureWorks.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorks.Client.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IRepository<Person> _personRepository;
        public PeopleController(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        // GET: PeopleController
        public ActionResult Index()
        {
            ViewBag.Title = "People List";
            var people = _personRepository.Get().Select(p => ModelMapper.MapToViewModel(p));
            return View(people);
        }

        // GET: PeopleController/Details/5
        public ActionResult Details(int id)
        {
            var person = _personRepository.Get(id);
            var model = ModelMapper.MapToViewModel(person);
            return View(model);
        }

        // GET: PeopleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeopleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PeopleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PeopleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PeopleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PeopleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
