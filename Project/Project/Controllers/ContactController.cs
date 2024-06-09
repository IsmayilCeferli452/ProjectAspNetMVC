using Microsoft.AspNetCore.Mvc;
using Project.Services.Interfaces;
using Project.ViewModels;
using static Project.ViewComponents.HeaderViewComponent;

namespace Project.Controllers
{
    public class ContactController : Controller
    {
        private readonly ISettingService _settingService;

        public ContactController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public async Task<IActionResult> Index()
        {
            var settings = await _settingService.GetAllAsync();

            var response = new ContactVM()
            {
                Settings = settings
            };

            return View(response);
        }
    }
}
