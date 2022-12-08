using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using NewPetShop.Client.Mappers;
using NewPetShop.Client.Models;
using NewPetShop.Data.Entities;
using NewPetShop.Data.Filters;
using NewPetShop.Data.Interfaces;
using NuGet.Protocol.Core.Types;
using System;
using System.Runtime.InteropServices;
using static NewPetShop.Data.Entities.Animal;

namespace NewPetShop.Client.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IRepository<Animal> _context;
        private readonly IMapper<Animal, AnimalDto> _mapper;
        private readonly ILogin<User> _login;

        public AnimalController(IRepository<Animal> context, IMapper<Animal, AnimalDto> mapper, ILogin<User> login)
        {
            _context = context;
            _mapper = mapper;
            _login = login;
        }

        public IActionResult Index(int id = 1)
        {
            var model = new PageControlViewModel
            {
                PageNumber = id > 0 ? id : 1,
                PageSize = 5,
            };
            return DisplayList(model);
        }

        [HttpPost]
        public ActionResult Index(PageControlViewModel model)
        {
            return DisplayList(model);
        }

        private ActionResult DisplayList(PageControlViewModel model)
        {
            ViewBag.Title = "Animals List";
            ViewBag.CategoryOptions = Enum.GetValues<CategoryEnum>();

            var filter = new Filter
            {
                PageNumber = model.PageNumber > 0 ? model.PageNumber : 1,
                PageSize = model.PageSize > 0 ? model.PageSize : 5,
                Name = model.Name,
                Category = model.Category
            };

            FilterResponse<Animal> res = _context.Get(filter);

            ViewData.Add("PageControl", new PageControlViewModel
            {
                PageNumber = res.PageNumber,
                PageSize = res.PageSize,
                TotalCount = res.Count
            });

            return View("Index", res.Data.Select(a => _mapper.Map(a)));
        }

        public ActionResult Details(int id)
        {
            var animal = _context.Get(id);

            if (animal == null)
                return NotFound();

            return View(_mapper.Map(animal));
        }

        [HttpPost]
        public ActionResult AddComment(string comment, int id)
        {
            var animal = _context.Get(id);

            animal.Comments.Add(new Comment
            {
                Animal = animal,
                AnimalId = animal.AnimalId,
                Value = comment,
            });
            _context.Update(animal);

            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var user = _login.GetUser(model.Username);

            if (model.Username != user.Username)
                ViewBag.ErrorMessage = "Incorrect username.";

            if (model.Password != user.Password)
                ViewBag.ErrorMessage = "Incorrect password.";

            if (model.Username == user.Username && model.Password == user.Password)
                return RedirectToAction("Index", "Admin");

            ViewBag.ErrorMessage = "Incorrect password.";
            return View("Login");
        }
    }
}
