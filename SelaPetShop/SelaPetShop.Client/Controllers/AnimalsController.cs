using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SelaPetShop.Client.Models;
using SelaPetShop.Models.Dtos;
using SelaPetShop.Models.Entities;
using SelaPetShop.Models.Helpers;
using SelaPetShop.Models.Interfaces;
using SelaPetShop.Services.Mappers;

using System;
using System.IO;
using System.Web;

namespace SelaPetShop.Client.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly IRepository<Animal> _contextAnimal;
        private readonly IRepository<Category> _contextCategory;
        private readonly IRepository<Image> _contextImage;
        private readonly IMapper<Animal, AnimalDto> _mapper;
        private readonly IMemoryCache _cache;
        private IWebHostEnvironment _environment;

        public AnimalsController(IRepository<Animal> context, IMemoryCache cache, IMapper<Animal, AnimalDto> mapper, IRepository<Category> contextCategory, IRepository<Image> contextImage)
        {
            _contextAnimal = context;
            _cache = cache;
            _mapper = mapper;
            _contextCategory = contextCategory;
            _contextImage = contextImage;
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
                    res = await _contextAnimal.Get(filter);
                    _cache.Set(key, res, TimeSpan.FromSeconds(180));
                };

                return View(res.Data.Select(p => _mapper.Map(p).Result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            var animal = await _contextAnimal.Get(id);

            if (animal == null)
                return NotFound();


            return View(await _mapper.Map(animal));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddComment(int id, IFormCollection collection)
        {
            var animal = await _contextAnimal.Get(id);
            var model = await _mapper.Map(animal);

            try
            {
                model.Comments.Add(new Comment
                {
                    CommentId = model.Comments.Count() + 1,
                    AnimalId = model.AnimalId,
                    Value = collection["tbComment"].ToString(),
            });
                //await _contextAnimal.Update(model);
                await _contextAnimal.Add(await _mapper.Map(model));

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> UploadFiles(List<IFormFile> postedFiles)
        {
            string wwwPath = this._environment.WebRootPath;
            string contentPath = this._environment.ContentRootPath;

            string path = Path.Combine(this._environment.WebRootPath, "Uploads");
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
            return View();
        }
    }
}
