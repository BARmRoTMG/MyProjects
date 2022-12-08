using Microsoft.AspNetCore.Mvc;
using NewPetShop.Client.Models;
using NewPetShop.Data.Entities;
using NewPetShop.Data.Filters;
using NewPetShop.Data.Interfaces;

namespace NewPetShop.Client.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRepository<Animal> _context;
        private readonly IMapper<Animal, AnimalDto> _mapper;
        private readonly ILogin<User> _login;

        public AdminController(IRepository<Animal> context, IMapper<Animal, AnimalDto> mapper, ILogin<User> login)
        {
            _context = context;
            _mapper = mapper;
            _login = login;
        }

        public IActionResult Index(int id = 1)
        {
            try
            {
                ViewBag.Title = "Animals List";
                ViewBag.CategoryOptions = Enum.GetValues<CategoryEnum>();

                var model = new PageControlViewModel
                {
                    PageNumber = id > 0 ? id : 1,
                    PageSize = 10
                };

                var filter = new Filter
                {
                    PageNumber = model.PageNumber > 0 ? model.PageNumber : 1,
                    PageSize = model.PageSize > 0 ? model.PageSize : 5,
                    Name = model.Name,
                    Category = model.Category
                };

                var key = filter.ToString();

                FilterResponse<Animal> res = _context.Get(filter);

                return View("Index", res.Data.Select(a => _mapper.Map(a)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.CategoryOptions = Enum.GetValues<CategoryEnum>();

            var animal = _context.Get(id);

            if (animal == null)
                return NotFound();

            ViewBag.Title = $"Editing: {animal.Name}";
            return View(_mapper.Map(animal));
        }

        [HttpPost]
        public ActionResult Edit(AnimalDto model)
        {
            try
            {
                //Adding lost data because of view.
                model.Image.Name = model.Name + "new image.";
                model.Image.Description = model.Name + "url of edited pet image.";
                ModelState.Remove("Comments");
                ModelState.Remove("comment");

                if (ModelState.IsValid)
                {
                    var modelToAnimal = _mapper.Map(model);
                    _context.Update(modelToAnimal);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Animal";
            ViewBag.CategoryOptions = Enum.GetValues<CategoryEnum>();
            return View();
        }

        [HttpPost]
        public ActionResult Create(AnimalDto model)
        {
            try
            {
                var newAnimal = _mapper.Map(model);
                model.Category.Name = model.Category.Value;
                _context.Add(newAnimal);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add a new animal: " + ex.Message);
            }
        }

        public ActionResult Delete(int id)
        {
            var animal = _context.Get(id);

            if (animal == null)
                return NotFound();

            ViewBag.Title = $"Are you sure you want to remove: {animal.Name} ?";
            return View(_mapper.Map(animal));
        }

        [HttpPost]
        public ActionResult Delete(AnimalDto model)
        {
            try
            {
                _context.Delete(model.AnimalId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception($"Animal removal failed, " + ex.Message);
            }
        }
    }
}
