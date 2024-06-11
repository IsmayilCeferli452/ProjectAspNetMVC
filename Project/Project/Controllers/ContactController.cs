using FrontProjectAsp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Services.Interfaces;
using Project.ViewModels;
using static Project.ViewComponents.HeaderViewComponent;

namespace Project.Controllers
{
    public class ContactController : Controller
    {
        private readonly ISettingService _settingService;
        private readonly IContactService _contactService;
        private readonly UserManager<AppUser> _userManager;

        public ContactController(ISettingService settingService, 
                                 IContactService contactService,
                                 UserManager<AppUser> userManager)
        {
            _settingService = settingService;
            _contactService = contactService;
            _userManager = userManager;
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

        [HttpPost]
        public async Task<IActionResult> SendMessage(ContactVM request)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Contact");
            }

            await _contactService.SendMessage(request);            

            return RedirectToAction("Index");
        }
    }
}
