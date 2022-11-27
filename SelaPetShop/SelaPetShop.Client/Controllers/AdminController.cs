using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SelaPetShop.Client.Models;
using SelaPetShop.Models.Dtos;
using SelaPetShop.Models.Entities;
using SelaPetShop.Models.Helpers;
using SelaPetShop.Models.Interfaces;

namespace SelaPetShop.Client.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRepository<Animal> _context;
        private readonly IMapper<Animal, AnimalDto> _mapper;

        public AdminController(IRepository<Animal> context, IMapper<Animal, AnimalDto> mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int id = 1)
        {
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

                FilterResponse<Animal> res = await _context.Get(filter);

                return View(res.Data.Select(p => _mapper.Map(p).Result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection collection) 
        {
            try
            {
                Animal a = new Animal
                {
                    Name = collection["Name"],
                    //Category = collection["Category"],
                    //Birthdate = collection["Birthdate"],
                    Description = collection["Description"],
                    //Image = collection["Image.Url"],
                };

                var newAnimal = _mapper.Map(await _context.Add(a));

                return RedirectToAction(nameof(Index));
            } catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _context.Delete(id);
                return RedirectToAction(nameof(Index));
            } catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpGet] //invokes only get requests (DEFAULT)
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
                return NotFound();

            var animal = await _context.Get(id);

            if (animal == null)
                return NotFound();

            var animalDto = await _mapper.Map(animal);

            return View(animalDto);
        }

        [HttpPost] //invokes only post resurests
        [ValidateAntiForgeryToken] //Prevents forgery of a request
        public async Task<ActionResult> Edit(int id, AnimalDto model)
        {
            // validate request, save data, redirect to list
            if (model.AnimalId != model.AnimalId)
                return NotFound();

            var animalBeforeEdit = await _context.Get(id);
            model.AnimalId = id;
            model.Category= animalBeforeEdit.Category;
            model.Image = animalBeforeEdit.Image;
            model.Comments= animalBeforeEdit.Comments;
            ModelState.Remove("Category");
            ModelState.Remove("Image");
            ModelState.Remove("Comments");
            ModelState.Remove("Comment");
            if (ModelState.IsValid)
            {
                try
                {
                    var animal = await _mapper.Map(model);
                    animal = await _context.Update(animal);
                    return RedirectToAction("Index");
                    //_contextAnimal.Update(await _mapper.Map(model));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            return View(model);
        }
    }
}
