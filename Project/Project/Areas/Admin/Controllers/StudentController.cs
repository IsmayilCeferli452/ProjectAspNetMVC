using Microsoft.AspNetCore.Mvc;
using Project.Services;
using Project.Services.Interfaces;
using Project.ViewModels.Categories;
using Project.ViewModels.Students;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllAsync();

            StudentVM response = new StudentVM()
            {
                Students = students
            };

            return View(response);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return BadRequest();

            var student = await _studentService.GetWithCoursesAsync((int)id);

            if (student is null) return NotFound();

            StudentDetailVM response = new StudentDetailVM()
            {
                Student = student
            };

            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var category = await _studentService.GetByIdAsync((int)id);

            if (category is null) return NotFound();

            await _studentService.DeleteAsync(category);

            return RedirectToAction(nameof(Index));
        }
    }
}
