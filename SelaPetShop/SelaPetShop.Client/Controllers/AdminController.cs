using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelaPetShop.Client.Models;
using SelaPetShop.Models.Dtos;
using SelaPetShop.Models.Entities;
using SelaPetShop.Models.Helpers;
using SelaPetShop.Models.Interfaces;
using static SelaPetShop.Models.Entities.Animal;

namespace SelaPetShop.Client.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRepository<Animal> _context;
        private readonly IMapper<Animal, AnimalDto> _mapper;
        private readonly IWebHostEnvironment _environment;

        public AdminController(IRepository<Animal> context, IMapper<Animal, AnimalDto> mapper, IWebHostEnvironment environment)
        {
            _context = context;
            _mapper = mapper;
            _environment = environment;
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

        public ActionResult Create()
        {
            ViewBag.CategoryOptions = Enum.GetValues<CategoryEnum>();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AnimalDto model)
        {
            var a = new Animal
            {
                Name = model.Name,
                Category = model.Category,
                Birthdate = model.Birthdate,
                Description = model.Description,
                Image = model.Image,
            };

            var newAnimal = _mapper.Map(await _context.Add(a));

            return RedirectToAction(nameof(Index));
        }
        //public async Task<ActionResult> Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        Animal a = new Animal
        //        {
        //            Name = collection["Name"],
        //            //CategoryEnumKey = CategoryEnum.["category"],
        //            //Category = new Category //need to replace with enum
        //            //{
        //            //    Name = collection["Category"],
        //            //},
        //            Birthdate = DateTime.Parse(collection["Birthdate"]),
        //            Description = collection["Description"],
        //            Image = new Image //doesnt get image id
        //            {
        //                //ImageId = int.Parse(Guid.NewGuid().ToString()),
        //                Name = collection["Name"] + " Image",
        //                Url = collection["Image.Url"],
        //                Description = collection["Name"] + " Image added on new animal."
        //            }
        //        };

        //        var newAnimal = _mapper.Map(await _context.Add(a));

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (Exception ex)
        //    {
        //        return View(ex.Message);
        //    }
        //}

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _context.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.CategoryOptions = Enum.GetValues<CategoryEnum>();

            var animal = await _context.Get(id);

            if (animal == null)
                return NotFound();

            var animalDto = await _mapper.Map(animal);

            return View(animal); //animalDto
        }


        [HttpPost] //invokes only post resurests
        [ValidateAntiForgeryToken] //Prevents forgery of a request
        public async Task<ActionResult> Edit(int id, AnimalDto model)
        {
            // validate request, save data, redirect to list

            //adding lost data
            var loastAnimal = await _mapper.Map(await _context.Get(id));

            model.AnimalId = loastAnimal.AnimalId;
            //model.Category.CategoryId = loastAnimal.Category.CategoryId;
            model.Image.ImageId = loastAnimal.Image.ImageId;
            model.Image.Name = loastAnimal.Image.Name;
            model.Image.Description = loastAnimal.Image.Description;
            //model.Category.Value = loastAnimal.Category.Value;

            ModelState.Remove("Category");
            ModelState.Remove("Comments");
            ModelState.Remove("Comment");

            if (ModelState.IsValid)
            {
                try
                {
                    var animal = new Animal
                    {
                        AnimalId = model.AnimalId,
                        Name = model.Name,
                        Category = model.Category,
                        Birthdate = model.Birthdate,
                        Description = model.Description,

                    };
                    animal = await _context.Update(animal);
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult UploadFiles(List<IFormFile> postedFiles)
        {
            if (postedFiles != null)
                try
                {
                    string wwwPath = this._environment.WebRootPath;
                    string contentPath = this._environment.ContentRootPath;

                    string path = Path.Combine(this._environment.WebRootPath, "~/Uploads");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    List<string> uploadedFiles = new List<string>();
                    foreach (IFormFile postedFile in postedFiles)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);
                        using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                            postedFile.CopyTo(stream);
                            uploadedFiles.Add(fileName);
                            ViewBag.Message += fileName + ",";
                        }
                    }
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View();
        }
    }
}
