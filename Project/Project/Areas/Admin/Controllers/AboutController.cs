using Educal_MVC.Helpers.Extensions;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Services;
using Project.Services.Interfaces;
using Project.ViewModels.Abouts;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        public async Task<IActionResult> Index()
        {
            var about = await _aboutService.GetAllAsync();

            AboutVM response = new AboutVM()
            {
                About = about
            };

            return View(response);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            var about = await _aboutService.GetByIdAsync((int)id);

            if (about is null) return NotFound();

            return View(new AboutEditVM
            {
                Title = about.Title,
                Description = about.Description,
                Image = about.Image
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, AboutEditVM request)
        {
            if (id is null) return BadRequest();

            var about = await _aboutService.GetByIdAsync((int)id);

            if (about is null) return NotFound();

            if (!ModelState.IsValid)
            {
                request.Image = about.Image;
                return View(request);
            }

            if (request.Title.Trim().ToLower() != about.Title.Trim().ToLower() && await _aboutService.ExistAsync(request.Title))
            {
                ModelState.AddModelError("Name", "Category with this name already exists");
                request.Image = about.Image;
                return View(request);
            }

            if (request.NewImage is not null)
            {
                if (!request.NewImage.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Image", "Input can accept only image format");
                    request.Image = about.Image;
                    return View(request);
                }

                if (!request.NewImage.CheckFileSize(200))
                {
                    ModelState.AddModelError("Image", "Image size must be max 200 KB");
                    request.Image = about.Image;
                    return View(request);
                }
            }

            await _aboutService.EditAsync(about, request);

            return RedirectToAction(nameof(Index));
        }
    }
}
