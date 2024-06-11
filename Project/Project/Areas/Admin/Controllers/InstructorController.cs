using Microsoft.AspNetCore.Mvc;
using Project.Services;
using Project.Services.Interfaces;
using Project.ViewModels.Categories;
using Project.ViewModels.Instructors;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InstructorController : Controller
    {
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }
        public async Task<IActionResult> Index()
        {
            var instructors = await _instructorService.GetAllAsync();

            InstructorVM response = new InstructorVM()
            {
                Instructors = instructors
            };

            return View(response);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return BadRequest();

            var instructor = await _instructorService.GetWithCourseAsync((int)id);

            if (instructor is null) return NotFound();

            InstructorDetailVM response = new InstructorDetailVM()
            {
                Instructor = instructor
            };

            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var instructor = await _instructorService.GetByIdAsync((int)id);

            if (instructor is null) return NotFound();

            await _instructorService.DeleteAsync(instructor);

            return RedirectToAction(nameof(Index));
        }
    }
}
