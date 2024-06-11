using Educal_MVC.Helpers.Extensions;
using FrontProjectAsp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Services.Interfaces;
using Project.ViewModels.Carousels;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarouselController : Controller
    {
        private readonly ICarouselService _carouselService;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;


        public CarouselController(ICarouselService carouselService, AppDbContext context, IWebHostEnvironment environment)
        {
            _carouselService = carouselService;
            _context = context;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            var carousels = await _carouselService.GetAllAsync();

            CarouselVM response = new CarouselVM()
            {
                Carousels = carousels
            };

            return View(response);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarouselCreateVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            foreach (var item in request.Images)
            {
                if (!item.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Image", "Format is wrong");
                    return View();
                }
                
                if (!item.CheckFileSize(200))
                {
                    ModelState.AddModelError("Image", "Max image size is 200 KB");
                    return View();
                }
            }            

            await _carouselService.CreateAsync(request);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var carousel = await _context.Carousels.FindAsync((int)id);

            if (carousel == null)
            {
                return NotFound();
            }

            string path = Path.Combine(_environment.WebRootPath, "img", carousel.Image);

            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);

            _context.Carousels.Remove(carousel);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var carousel = await _context.Carousels.FindAsync((int)id);

            if (carousel == null)
            {
                return NotFound();
            }

            return View(new CarouselEditVM { Image = carousel.Image });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, CarouselEditVM request)
        {
            var carousel = await _context.Carousels.FindAsync((int)id);

            if (!request.NewImage.CheckFileType("image/"))
            {
                ModelState.AddModelError("Image", "Format is wrong");
                request.Image = carousel.Image;
                return View(request);
            }
            
            if (!request.NewImage.CheckFileSize(200))
            {
                ModelState.AddModelError("Image", "Max image size is 200 KB");
                request.Image = carousel.Image;
                return View(request);
            }

            if (id == null)
            {
                return BadRequest();
            }

            if (carousel == null)
            {
                return NotFound();
            }

            if (request.NewImage is null) return RedirectToAction(nameof(Index));

            string oldPath = Path.Combine(_environment.WebRootPath, "img", carousel.Image);

            if (System.IO.File.Exists(oldPath))
                System.IO.File.Delete(oldPath);

            string fileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;

            string newPath = Path.Combine(_environment.WebRootPath, "img", fileName);

            await request.NewImage.SaveFileToLocalAsync(newPath);

            carousel.Image = fileName;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
