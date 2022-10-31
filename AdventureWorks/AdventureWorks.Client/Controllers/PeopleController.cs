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
            ViewBag.Title = "Person Details";
            var model = ModelMapper.MapToDetailsViewModel(_personRepository.Get(id));
            return View(model);
        }

        // GET: PeopleController/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create";
            return View();
        }

        // POST: PeopleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Person p1 = new Person
                {
                    FirstName = collection["First Name"],
                    MiddleName = collection["Middle Name"],
                    LastName = collection["Last Name"],
                    AdditionalContactInfo = collection["Address"]
                };
                var newPerson = _personRepository.Add(p1);
                var model = ModelMapper.MapToViewModel(newPerson);
               return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: PeopleController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";
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
            ViewBag.Title = "Delete Person";
            var model = ModelMapper.MapToDetailsViewModel(_personRepository.Get(id));
            return View(model);
        }

        // POST: PeopleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _personRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
