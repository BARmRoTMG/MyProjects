using Microsoft.AspNetCore.Mvc;

namespace FirstAzureApp.Controllers
{
    public class GalleryController : Controller
    {
        private readonly string root;
        public GalleryController(IWebHostEnvironment env)
        {
            root = Path.Combine(env.WebRootPath, "imgs");
            if (!Directory.Exists(root))
                Directory.CreateDirectory(root);
        }
        public IActionResult Index()
        {
            var files = Directory.GetFiles(root)
                .Select(f => Path.GetFileName(f))
                .ToList();

            return View(files);
        }

        [HttpPost]
        public async Task<IActionResult>Save(IFormCollection formData)
        {
            foreach (var file in formData.Files)
            {
                var filePath = $@"{root}\{Guid.NewGuid().ToString("N")}.jpg";
                using var fs = new FileStream(filePath, FileMode.OpenOrCreate);
                await file.CopyToAsync(fs);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
