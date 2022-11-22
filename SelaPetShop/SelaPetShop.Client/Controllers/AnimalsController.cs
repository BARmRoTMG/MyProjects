using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IRepository<Animal> _context;
        private readonly IMapper<Animal, AnimalDto> _mapper;
        private readonly IMemoryCache _cache;
        private IWebHostEnvironment _environment;

        public AnimalsController(IRepository<Animal> context, IMemoryCache cache, IMapper<Animal, AnimalDto> mapper)
        {
            _context = context;
            _cache = cache;
            _mapper = mapper;
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
                    res = await _context.Get(filter);
                    _cache.Set(key, res, TimeSpan.FromSeconds(180));
                };

                return View(res.Data.Select(p => _mapper.Map(p).Result));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            return View();
            //return View(_mapper.Map(await _context.Get(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AnimalDto model)
        {
            // validate request, save data, redirect to list
            if (model == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var animal = _context.Update(await _mapper.Map(model));
                return RedirectToAction("Index");
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            return View();
            //return View(_mapper.Map(await _context.Get(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AnimalDto model)
        {
            try
            {
                model.AnimalId = await _context.GetLastId() + 1;
                //model.Comments.Add(new Comment
                //{
                //    CommentId = model.Comments.Count + 1,
                //    AnimalId = model.AnimalId,
                //    Value = model.Comments.ToString(),
                //});

                _context.Add(await _mapper.Map(model));

                return RedirectToAction(nameof(Index));
            } catch
            {
                return View();
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
