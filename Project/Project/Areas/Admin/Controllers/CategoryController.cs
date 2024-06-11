using Educal_MVC.Helpers.Extensions;
using Microsoft.AspNetCore.Mvc;
using Project.Services.Interfaces;
using Project.ViewModels.Categories;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();

            CategoryVM response = new CategoryVM()
            {
                Categories = categories
            };

            return View(response);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return BadRequest();

            var category = await _categoryService.GetWithCoursesAsync((int)id);

            if (category is null) return NotFound();

            CategoryDetailVM response = new CategoryDetailVM()
            {
                Category = category
            };

            return View(response);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (await _categoryService.ExistAsync(request.Name))
            {
                ModelState.AddModelError("Name", "Category with this name already exists");
                return View();
            }

            if (!request.Image.CheckFileType("image/"))
            {
                ModelState.AddModelError("Image", "Input can accept only image format");
                return View();
            }

            if (!request.Image.CheckFileSize(800))
            {
                ModelState.AddModelError("Image", "Image size must be max 800 KB");
                return View();
            }

            await _categoryService.CreateAsync(request);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var category = await _categoryService.GetByIdAsync((int)id);

            if (category is null) return NotFound();

            await _categoryService.DeleteAsync(category);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            var category = await _categoryService.GetByIdAsync((int)id);

            if (category is null) return NotFound();

            return View(new CategoryEditVM
            {
                Name = category.Name,
                Image = category.Image
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, CategoryEditVM request)
        {
            if (id is null) return BadRequest();

            var category = await _categoryService.GetByIdAsync((int)id);

            if (category is null) return NotFound();

            if (!ModelState.IsValid)
            {
                request.Image = category.Image;
                return View(request);
            }

            if (request.Name.Trim().ToLower() != category.Name.Trim().ToLower() && await _categoryService.ExistAsync(request.Name))
            {
                ModelState.AddModelError("Name", "Category with this name already exists");
                request.Image = category.Image;
                return View(request);
            }

            if (request.NewImage is not null)
            {
                if (!request.NewImage.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Image", "Input can accept only image format");
                    request.Image = category.Image;
                    return View(request);
                }

                if (!request.NewImage.CheckFileSize(800))
                {
                    ModelState.AddModelError("Image", "Image size must be max 800 KB");
                    request.Image = category.Image;
                    return View(request);
                }
            }

            await _categoryService.EditAsync(category, request);

            return RedirectToAction(nameof(Index));
        }
    }
}
